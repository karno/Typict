using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bright.Cores
{
    public class Config
    {
        [XmlIgnore()]
        public readonly bool IsFirstBoot;

        public Config()
        {
            IsFirstBoot = !File.Exists(Define.ConfigFile);
        }

        public static Config LoadConfig()
        {
            if (File.Exists(Define.ConfigFile))
                return K.Snippets.Files.LoadXML<Config>(Define.ConfigFile, true);
            else
                return new Config();
        }

        public void SaveConfig()
        {
            K.Snippets.Files.SaveXML<Config>(Define.ConfigFile, this);
        }

        public Behavior BehaviorConfig = new Behavior();
        public class Behavior
        {
            public bool UseHandMoveOnNotZooming = true;
            public bool KeyDoubleTypeToRegistNew = true;
            public bool RememberPreviousOperationConfig = true;
            public bool ClearDestOnBack = true;
            public int BackupInterval = 3;
            public bool WaitExternalApp = false;
            public bool WaitExternalAppIdling = false;
            public bool MultiCopyTreatsReference = false;

            public enum KeyListEvents { None, SetDestination, EditDestination }
            public KeyListEvents KeyListEvent = KeyListEvents.SetDestination;

            public Prefetch PrefetchConfig = new Prefetch();
            public class Prefetch
            {
                public bool EnablePrefetch = true;
                public int PrefetchLength = 5;
                public int PrefetchKeepMaximum = 10;
                public bool EnableThumbnailPrefetch = true;
                public int ThumbnailPrefetchLength = 50;
                public int ThumbnailKeepMaximum = 100;
                public bool KeepAllThumbnail = false;
                public bool PrefetchAllThumbnail = false;
            }
        }

        public Display DisplayConfig = new Display();
        public class Display
        {
            public bool CenteringImage = true;

            public InterpolationMode InterpolationMode = InterpolationMode.HighQualityBicubic;
            public bool UseDynamicInterpolate = true;
            public ulong SizeBorder = 1500 * 1500;
            public InterpolationMode BigImageIntpMode = InterpolationMode.NearestNeighbor;

            public Size ThumbnailSize = new Size(60, 40);
            public double KeyListPoint = 9.0;

            public class OverlapObject
            {
                public bool Show = true;
                public enum DrawLocations { LeftTop, LeftBottom, RightTop, RightBottom, Center }
                public DrawLocations DrawLocation = DrawLocations.LeftTop;
                public Point Offset = new Point(0, 0);
            }
            public OverlapThumbnail OverlapThumbnailConfig = new OverlapThumbnail();
            public class OverlapThumbnail : OverlapObject
            {
                public OverlapThumbnail()
                {
                    this.DrawLocation = DrawLocations.RightBottom;
                }
                public Size ThumbnailSize = new Size(240, 160);
            }
            public OverlapText FileNameTextConfig = new OverlapText();
            public class OverlapText : OverlapObject
            {
                public bool FileNameTextFullpath = false;
                public bool UseAntiAlias = true;
                public K.Data.XFont UsingFont = new K.Data.XFont(new Font(System.Windows.Forms.Control.DefaultFont.FontFamily, 30));
            }
        }

        public State StateConfig = new State();
        public class State
        {
            public Rectangle WindowPosition = new Rectangle(100, 100, 600, 400);
            public FormWindowState WindowState = FormWindowState.Normal;
            public bool ZoomPicture = true;
            public bool ZoomSmallPicture = false;
            public bool KeepProportion = true;
            public Data.GroupingElement.DistributionModes DistributionMode = Bright.Data.GroupingElement.DistributionModes.Copy;
            public string PrevSetupData = null;
            public byte[] DockData = null;
            public bool HorizontalOpView = false;
        }
    }
}
