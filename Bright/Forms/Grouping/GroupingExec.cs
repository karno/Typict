using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using Smdn.Windows.UserInterfaces.Shells;

namespace Bright.Forms.Grouping
{
    public partial class GroupingExec : Form
    {
        bool Finished = false;
        List<Data.GroupingElement> elems = new List<Bright.Data.GroupingElement>();
        class OperatedData
        {
            public Data.GroupingElement.DistributionModes DistributedMode = Bright.Data.GroupingElement.DistributionModes.Copy;
            public bool Succeed = true;
            public string Dest = null;
            public string Orig = null;
        }

        public GroupingExec(IEnumerable<Data.GroupingElement> elements)
        {
            InitializeComponent();
            elems.AddRange(elements);
        }

        private void GroupingExec_Load(object sender, EventArgs e)
        {
            finishOperationCandidates.SelectedIndex = 0;
            mainProgressBar.Maximum = elems.Count;
        }

        private void GroupingExec_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Finished && e.CloseReason != CloseReason.TaskManagerClosing && e.CloseReason == CloseReason.WindowsShutDown &&
                MessageBox.Show("オペレーションを実行している途中です。" + Environment.NewLine +
                "終了してもよろしいですか？", "オペレーションの中断", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
            if (!Finished)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }

        private void GroupingExec_Shown(object sender, EventArgs e)
        {
            OnCalcuateTime += new Action<int>(GroupingExec_OnCalcuateTime);
            OnUpdateOperatedList += new Action<OperatedData>(GroupingExec_OnUpdateOperatedList);
            OnHandledException += new Action<Exception>(GroupingExec_OnHandledException);
            Action a = new Action(DoOperation);
            a.BeginInvoke((iar) =>
            {
                ((Action)iar.AsyncState).EndInvoke(iar);
                this.Invoke(new Action(() =>
                {
                    //何もしない
                    //このウィンドウを閉じる
                    //Typictを終了する
                    //Windowsをシャットダウンする
                    switch (finishOperationCandidates.SelectedIndex)
                    {
                        case 1:
                            this.Close();
                            return;
                        case 2:
                            this.Close();
                            Application.Exit();
                            return;
                        case 3:
                            K.Snippets.Windows.WinExit.Exit(K.Snippets.Windows.WinExit.ExitOption.Shutdown);
                            this.Close();
                            Application.Exit();
                            return;
                    }
                    mainProgressBar.Value = mainProgressBar.Maximum;
                    cancelButton.Text = "閉じる";
                    if (Finished)
                        stateLabel.Text = "オペレーションは何らかの理由で中断されました。";
                    else
                        stateLabel.Text = "オペレーションを完了しました。";
                    remainTimeLabel.Text = "";
                    moveFileLabel.Text = "完了";
                    errorTrace.AppendText("完了" + Environment.NewLine);
                    Finished = true;
                }));

            }, a);
        }

        void GroupingExec_OnUpdateOperatedList(OperatedData dat)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<OperatedData>(GroupingExec_OnUpdateOperatedList), dat);
                return;
            }
            elementsList.Items.Add(dat);
            elementsList.TopIndex = elementsList.Items.Count - 1;
            elementsList.Refresh();
        }

        Stopwatch sw = new Stopwatch();
        void GroupingExec_OnCalcuateTime(int count)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(GroupingExec_OnCalcuateTime), count);
                return;
            }
            mainProgressBar.Value = count;
            if (count == 0)
            {
                sw.Reset();
                sw.Start();
            }
            else
            {
                long perms = sw.ElapsedMilliseconds / count;
                int remain = elems.Count - count;
                long last = (perms * remain) / 1000;
                StringBuilder sb = new StringBuilder();
                if (last > 31536000)
                {
                    sb.Append((last / 31536000).ToString() + "年");
                    last %= 31536000;

                }
                if (last > 86400)
                {
                    sb.Append((last / 86400).ToString() + "日");
                    last %= 86400;
                }
                if (last > 3600)
                {
                    sb.Append((last / 3600).ToString() + "時間");
                    last %= 3600;
                }
                if (last > 60)
                {
                    sb.Append((last / 60).ToString() + "分");
                    last %= 60;
                }
                sb.Append(last.ToString() + "秒");
                remainTimeLabel.Text = "残り時間:" + sb.ToString();
            }
            elementsList.Refresh();
        }

        void GroupingExec_OnHandledException(Exception obj)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Exception>(GroupingExec_OnHandledException), obj);
                return;
            }
            errorTrace.AppendText(obj.ToString() + Environment.NewLine);
        }

        event Action<int> OnCalcuateTime;
        event Action<OperatedData> OnUpdateOperatedList;
        event Action<Exception> OnHandledException;

        void DoOperation()
        {
            int ctor = 0;
            foreach (var e in elems)
            {
                if (e.Destinations.Count == 0)
                {
                    ctor++;
                }
                else
                {
                    if (OnCalcuateTime != null)
                        OnCalcuateTime(ctor);
                    ctor++;
                    if (e.Destinations.Count == 1)
                    {
                        //Single copy
                        var dest = e.Destinations[0].Destination;
                        if (dest == Define.RemoveIDString)
                            continue;
                        if (File.Exists(dest))
                        {
                            //Application passing
                            var process = System.Diagnostics.Process.Start(dest, e.ImageSourcePath);
                            if (Core.Config.BehaviorConfig.WaitExternalApp)
                                process.WaitForExit();
                            else if (Core.Config.BehaviorConfig.WaitExternalAppIdling)
                                process.WaitForInputIdle();

                            if (e.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Move)
                            {
                                OnHandledException.Invoke(new ArgumentException("アプリケーションへ渡すように設定されていますが、振り分け方法が「移動」になっています。Typictは、この振り分け方法を無視します。ファイルは削除されません。"));
                            }
                            if (OnUpdateOperatedList != null)
                                OnUpdateOperatedList.Invoke(new OperatedData()
                                {
                                    Dest = dest,
                                    Orig = e.ImageSourcePath,
                                    DistributedMode = Bright.Data.GroupingElement.DistributionModes.App,
                                    Succeed = true
                                });
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(e.NewName))
                                dest = Path.Combine(dest, e.NewName);
                            else
                                dest = Path.Combine(dest, Path.GetFileName(e.ImageSourcePath));
                            bool ret = DoMoveCopy(e.ImageSourcePath, ref dest, e.DistributionMode);
                            if (OnUpdateOperatedList != null)
                                OnUpdateOperatedList.Invoke(new OperatedData()
                                {
                                    Dest = dest,
                                    Orig = e.ImageSourcePath,
                                    DistributedMode = e.DistributionMode,
                                    Succeed = ret
                                });
                        }
                    }
                    else
                    {
                        //Multi copy
                        bool deletable = true;
                        int count = 0;
                        string firstDistributeTo = null;
                        foreach (var deste in e.Destinations)
                        {
                            count++;
                            var dest = deste.Destination;
                            if (dest == Define.RemoveIDString)
                                continue;
                            if (File.Exists(dest))
                            {
                                //Application passing
                                var process = System.Diagnostics.Process.Start(dest, e.ImageSourcePath);
                                if (Core.Config.BehaviorConfig.WaitExternalApp)
                                    process.WaitForExit();
                                else if (Core.Config.BehaviorConfig.WaitExternalAppIdling)
                                    process.WaitForInputIdle();
                                deletable = false;
                                if (e.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Move)
                                {
                                    OnHandledException.Invoke(new ArgumentException("アプリケーションへ渡すように設定されていますが、振り分け方法が「移動」になっています。Typictは、この振り分け方法を無視します。ファイルは削除されません。"));
                                }
                                if (OnUpdateOperatedList != null)
                                    OnUpdateOperatedList.Invoke(new OperatedData()
                                    {
                                        Dest = dest,
                                        Orig = e.ImageSourcePath,
                                        DistributedMode = Bright.Data.GroupingElement.DistributionModes.App,
                                        Succeed = true
                                    });
                            }
                            else
                            {
                                bool ret = false;
                                if (!String.IsNullOrEmpty(e.NewName))
                                    dest = Path.Combine(dest, e.NewName);
                                else
                                    dest = Path.Combine(dest, Path.GetFileName(e.ImageSourcePath));
                                if (!Core.Config.BehaviorConfig.MultiCopyTreatsReference || String.IsNullOrEmpty(firstDistributeTo) || !File.Exists(firstDistributeTo))
                                {
                                    if (e.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Link)
                                        ret = DoMoveCopy(e.ImageSourcePath, ref dest, Bright.Data.GroupingElement.DistributionModes.Link);
                                    else
                                        ret = DoMoveCopy(e.ImageSourcePath, ref dest, Bright.Data.GroupingElement.DistributionModes.Copy);
                                    if (ret) firstDistributeTo = dest;
                                    System.Diagnostics.Debug.WriteLine("First distribute to:" + firstDistributeTo);
                                    if (OnUpdateOperatedList != null)
                                        OnUpdateOperatedList.Invoke(new OperatedData()
                                        {
                                            Dest = dest,
                                            Orig = e.ImageSourcePath,
                                            DistributedMode = e.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Link ? Bright.Data.GroupingElement.DistributionModes.Link : Bright.Data.GroupingElement.DistributionModes.Copy,
                                            Succeed = ret
                                        });
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("Alternate link from:" + firstDistributeTo + " to " + dest);
                                    ret = DoMoveCopy(firstDistributeTo, ref dest, Bright.Data.GroupingElement.DistributionModes.Link);
                                    if (OnUpdateOperatedList != null)
                                        OnUpdateOperatedList.Invoke(new OperatedData()
                                        {
                                            Dest = dest,
                                            Orig = firstDistributeTo,
                                            DistributedMode = Bright.Data.GroupingElement.DistributionModes.Link,
                                            Succeed = ret
                                        });
                                }
                                if (!ret)
                                    deletable = false;
                            }
                        }
                        if (e.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Move)
                        {
                            if (deletable)
                                File.Delete(e.ImageSourcePath);
                            else
                                OnHandledException.Invoke(new InvalidOperationException("マルチコピーで1件以上の移動エラーが発生しているため、ファイルの削除は行われません。"));
                        }
                    }
                }
                if (Finished)
                    break;
            }
        }

        DialogResult AllTrap = DialogResult.None;
        private bool DoMoveCopy(string source, ref string dest, Bright.Data.GroupingElement.DistributionModes distMode)
        {
            if (source == dest)
                return false;
            if (File.Exists(dest))
            {
                DialogResult dr = AllTrap;
                if (dr == DialogResult.None)
                {
                    using (var dp = new Duplication(source, dest))
                    {
                        dr = dp.ShowDialog();
                        if (dp.AllTrap)
                            AllTrap = dr;
                    }
                }
                switch (dr)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Abort:
                        Finished = true;
                        return false;
                    case DialogResult.OK:
                        FileSystem.DeleteFile(dest, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        break;
                    case DialogResult.Retry:
                        string destn = Path.Combine(Path.GetDirectoryName(dest), Path.GetFileNameWithoutExtension(dest));
                        string ext = Path.GetExtension(dest);
                        int ctor = 1;
                        while (File.Exists(destn + "(" + ctor + ")" + ext))
                            ctor++;
                        dest = destn + "(" + ctor + ")" + ext;
                        break;
                    default:
                        throw new Exception("Duplicate processing error.");
                }
            }
            try
            {
                if (distMode == Bright.Data.GroupingElement.DistributionModes.Copy)
                {
                    File.Copy(source, dest);
                }
                else if (distMode == Bright.Data.GroupingElement.DistributionModes.Move)
                {
                    File.Move(source, dest);
                }
                else if (distMode == Bright.Data.GroupingElement.DistributionModes.Link)
                {
                    using (var shortcut = new ShellLink())
                    {
                        shortcut.Description = "Image file link, created by typict";
                        shortcut.TargetPath = source;
                        shortcut.ShowCommand = SW.NORMAL;

                        shortcut.Save(dest + ".lnk");
                    }
                }
                else
                {
                    throw new ArgumentException("distribution mode is invalid: value " + ((int)distMode).ToString());
                }
            }
            catch (Exception e)
            {
                if (OnHandledException != null)
                    OnHandledException.Invoke(e);
                return false;
            }
            return true;
        }

        private void showErrorTrace_CheckedChanged(object sender, EventArgs e)
        {
            errorTrace.Visible = showErrorTrace.Checked;
        }

        private void elementsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < -1) return;
            var item = elementsList.Items[e.Index] as OperatedData;
            e.DrawBackground();
            e.Graphics.FillRectangle(Brushes.Gainsboro, new Rectangle(0, e.Bounds.Top, 16, e.Bounds.Height));
            e.Graphics.FillRectangle(Brushes.Gainsboro, new Rectangle(0, e.Bounds.Bottom - 1, e.Bounds.Width, 1));
            if (item.Succeed)
            {
                switch (item.DistributedMode)
                {
                    case Bright.Data.GroupingElement.DistributionModes.Copy:
                        e.Graphics.DrawImage(Properties.Resources.copy, e.Bounds.Location);
                        break;
                    case Bright.Data.GroupingElement.DistributionModes.Move:
                        e.Graphics.DrawImage(Properties.Resources.cut, e.Bounds.Location);
                        break;
                    case Bright.Data.GroupingElement.DistributionModes.Link:
                        e.Graphics.DrawImage(Properties.Resources.link, e.Bounds.Location);
                        break;
                    case Bright.Data.GroupingElement.DistributionModes.App:
                        e.Graphics.DrawImage(Properties.Resources.externalapp, e.Bounds.Location);
                        break;
                    default:
                        throw new ArgumentException("Distributed enumerate is invalid: value " + ((int)item.DistributedMode).ToString());
                }
            }
            else
                e.Graphics.DrawImage(Properties.Resources.cancel, e.Bounds.Location);
            var srcRect = e.Bounds;
            srcRect.X += 16;
            srcRect.Width -= srcRect.X;
            srcRect.Width /= 2;
            srcRect.Height -= 1;
            TextRenderer.DrawText(e.Graphics, item.Orig, this.Font, srcRect, Color.Black,
                 TextFormatFlags.SingleLine | TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            e.Graphics.FillRectangle(Brushes.Gainsboro, new Rectangle(srcRect.Right + 1, e.Bounds.Top, 1, e.Bounds.Height));
            var destRect = e.Bounds;
            destRect.X = srcRect.Right + 1;
            destRect.Width -= destRect.X;
            TextRenderer.DrawText(e.Graphics, item.Dest, this.Font, destRect, Color.Black,
                 TextFormatFlags.SingleLine | TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            e.DrawFocusRectangle();
        }
    }
}
