using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bright.Subsystem
{
    //Prefetch system service provider
    public class Prefetch
    {
        #region Singleton
        private static Prefetch instance = new Prefetch();
        public static Prefetch Instance { get { return instance; } }
        #endregion

        public event Action<bool> PrefetchingUpdate;
        public bool Prefetching
        {
            get { return Interlocked.Read(ref this.referenceCtor) != 0; }
        }
        private long referenceCtor = 0;
        private void PrefetchEnter()
        {
            if (Interlocked.Increment(ref referenceCtor) >= 1)
                PrefetchingUpdate(true);
        }
        private void PrefetchExit()
        {
            if (Interlocked.Decrement(ref referenceCtor) == 0)
                PrefetchingUpdate(false);
        }

        /// <summary>
        /// Complete prefetch one item (CAUTION:Thread is another)
        /// </summary>
        public event Action<Data.GroupingElement> PrefetchCompleted;

        /// <summary>
        /// Complete thumbnail prefetch one item (CAUTION:Thread is another)
        /// </summary>
        public event Action<Data.GroupingElement> PrefetchThumbnailCompleted;

        private Prefetch()
        {
            Core.CurrentOperationUpdated += new Action(Core_CurrentOperationUpdated);
            System.Windows.Forms.Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            Loader.ElementsDispose.DisposeAll();
        }

        void Core_CurrentOperationUpdated()
        {
            if (Core.CurrentOperation != null)
            {
                Core.CurrentOperation.IndexUpdated += new Action(DoPrefetch);
                DoPrefetch();
            }
        }

        Action<int> prefbg = null;
        /// <summary>
        /// 画像の先読みroot
        /// </summary>
        void DoPrefetch()
        {
            if (Core.Config.BehaviorConfig.PrefetchConfig.EnablePrefetch)
            {
                prefbg = new Action<int>(DoPrefetchBackground);
                prefbg.BeginInvoke(Core.CurrentOperation.Index, (iar) => ((Action<int>)iar.AsyncState).EndInvoke(iar), prefbg);
            }
            else if (Core.Config.BehaviorConfig.PrefetchConfig.EnableThumbnailPrefetch)
            {
                prefbg = new Action<int>(DoThumbPrefetchBackground);
                prefbg.BeginInvoke(Core.CurrentOperation.Index, (iar) => ((Action<int>)iar.AsyncState).EndInvoke(iar), prefbg);
            }
        }

        /// <summary>
        /// 画像の読み込みmanager
        /// </summary>
        void DoPrefetchBackground(int startIndex)
        {
            System.Diagnostics.Debug.WriteLine("Prefetch executing...");
            //Prefetch core
            int max = Core.Config.BehaviorConfig.PrefetchConfig.PrefetchLength;
            for (int i = startIndex; i < max + startIndex; i++)
            {
                System.Diagnostics.Debug.WriteLine("Invoking::" + i.ToString());
                if (i >= Core.CurrentOperation.Data.ElementsLength)
                    break;
                var elem = Core.CurrentOperation.Data.GetElement(i);
                //Checking data
                if (elem.IsBuffered || elem.LoadFailed)
                    continue;

                //Invoke image loader with async
                Action<int> fork = new Action<int>(LoadImageFork);
                fork.BeginInvoke(i, (iar) => ((Action<int>)iar.AsyncState).EndInvoke(iar), fork);
            }
            System.Diagnostics.Debug.WriteLine("pref breaked.");
            //Thumbnail prefetch
            max = Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailPrefetchLength;
            bool all = Core.Config.BehaviorConfig.PrefetchConfig.PrefetchAllThumbnail;
            for (int i = startIndex; i < max + startIndex || all; i++)
            {
                if (i >= Core.CurrentOperation.Data.ElementsLength)
                    break;
                //Checking data
                var elem = Core.CurrentOperation.Data.GetElement(i);
                if (elem.IsBuffered || elem.LoadFailed)
                    continue;
                if (!elem.IsThumbnailBuffered)
                {
                    //Invoke image loader with async
                    Action<int> fork = new Action<int>(LoadThumbnailFork);
                    fork.BeginInvoke(i, (iar) => ((Action<int>)iar.AsyncState).EndInvoke(iar), fork);
                }
            }
        }

        /// <summary>
        /// サムネイル読み込みmanager
        /// </summary>
        /// <remarks>
        /// サムネイルのみ読み込む設定時のみ使用、それ以外はDoPrefetchBackgroundですべて行う
        /// </remarks>
        void DoThumbPrefetchBackground(int startIndex)
        {
            //Thumbnail prefetch core
            int max = Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailKeepMaximum;
            bool all = Core.Config.BehaviorConfig.PrefetchConfig.PrefetchAllThumbnail;
            for (int i = startIndex; i < max + startIndex || all; i++)
            {
                if (i >= Core.CurrentOperation.Data.ElementsLength)
                    break;
                //Checking data
                var elem = Core.CurrentOperation.Data.GetElement(i);
                if (elem.IsBuffered || elem.LoadFailed)
                    continue;

                //Invoke image loader with async
                Action<int> fork = new Action<int>(LoadThumbnailFork);
                fork.BeginInvoke(i, (iar) => ((Action<int>)iar.AsyncState).EndInvoke(iar), fork);
            }
        }

        /// <summary>
        /// 画像の読み込み
        /// </summary>
        void LoadImageFork(int index)
        {
            //Get current element
            PrefetchEnter();
            var elem = Core.CurrentOperation.Data.GetElement(index);
            System.Diagnostics.Debug.WriteLine("prefetch:" + index.ToString() + "=>" + elem.ImageSourcePath);
            Loader.LoadImageByElem(elem);
            if (PrefetchThumbnailCompleted != null)
                PrefetchThumbnailCompleted.Invoke(elem);
            if (PrefetchCompleted != null)
                PrefetchCompleted.Invoke(elem);
            PrefetchExit();
        }

        /// <summary>
        /// サムネイルの読み込み
        /// </summary>
        /// <param name="index"></param>
        void LoadThumbnailFork(int index)
        {
            PrefetchEnter();
            //Get current elem
            var elem = Core.CurrentOperation.Data.GetElement(index);
            Loader.LoadThumbnailByElem(elem);
            if (PrefetchThumbnailCompleted != null)
                PrefetchThumbnailCompleted.Invoke(elem);
            PrefetchExit();
        }

        /// <summary>
        /// 画像のローダー
        /// </summary>
        public ImageLoader Loader = new ImageLoader();
        
        /// <summary>
        /// ローダークラス
        /// </summary>
        public class ImageLoader
        {
            public ElementDisposer ElementsDispose = new ElementDisposer();
            public class ElementDisposer
            {
                private class ExQueue<T>
                {
                    List<T> Collection = new List<T>();

                    public void Enqueue(T obj)
                    {
                        Collection.Add(obj);
                    }

                    public void Insert(T obj)
                    {
                        Collection.Insert(0, obj);
                    }

                    public int Count
                    {
                        get { return Collection.Count; }
                    }

                    public T Dequeue()
                    {
                        if (Collection.Count > 0)
                        {
                            var item = Collection[0];
                            Collection.RemoveAt(0);
                            return item;
                        }
                        else
                            throw new InvalidOperationException();
                    }

                    public T Peek()
                    {
                        if (Collection.Count > 0)
                            return Collection[0];
                        else
                            throw new InvalidOperationException();
                    }

                    public T PeekEnd()
                    {
                        if (Collection.Count > 0)
                            return Collection[Collection.Count - 1];
                        else
                            throw new InvalidOperationException();
                    }

                    public T Pop()
                    {
                        if (Collection.Count > 0)
                        {
                            var item = Collection[Collection.Count - 1];
                            Collection.RemoveAt(Collection.Count - 1);
                            return item;
                        }
                        else
                            throw new InvalidOperationException();
                    }
                }

                ExQueue<Data.GroupingElement> imageQueue = new ExQueue<Bright.Data.GroupingElement>();
                ExQueue<Data.GroupingElement> thumbnailQueue = new ExQueue<Bright.Data.GroupingElement>();

                public void InsertImage(Data.GroupingElement elem)
                {
                    imageQueue.Insert(elem);
                    while (imageQueue.Count > Core.Config.BehaviorConfig.PrefetchConfig.PrefetchKeepMaximum)
                    {
                        var deq = imageQueue.Pop();
                        if (!deq.IsBuffered) continue;
                        try
                        {
                            deq.BufferedImage.Dispose();
                        }
                        finally
                        {
                            deq.BufferedImage = null;
                        }
                    }
                }

                public void InsertThumbnail(Data.GroupingElement elem)
                {
                    thumbnailQueue.Insert(elem);
                    if (Core.Config.BehaviorConfig.PrefetchConfig.KeepAllThumbnail)
                        return;
                    while (imageQueue.Count > Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailKeepMaximum)
                    {
                        var deq = thumbnailQueue.Pop();
                        if (!deq.IsBuffered) continue;
                        try
                        {
                            deq.BufferedImage.Dispose();
                        }
                        finally
                        {
                            deq.BufferedImage = null;
                        }
                    }
                }

                public void EnqueueImage(Data.GroupingElement elem)
                {
                    imageQueue.Enqueue(elem);
                    while (imageQueue.Count > Core.Config.BehaviorConfig.PrefetchConfig.PrefetchKeepMaximum)
                    {
                        var deq = imageQueue.Dequeue();
                        if (!deq.IsBuffered) continue;
                        try
                        {
                            deq.BufferedImage.Dispose();
                        }
                        finally
                        {
                            deq.BufferedImage = null;
                        }
                    }
                }

                public void EnqueueThumbnail(Data.GroupingElement elem)
                {
                    thumbnailQueue.Enqueue(elem);
                    if (Core.Config.BehaviorConfig.PrefetchConfig.KeepAllThumbnail)
                        return;
                    while (imageQueue.Count > Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailKeepMaximum)
                    {
                        var deq = thumbnailQueue.Dequeue();
                        if (!deq.IsThumbnailBuffered) continue;
                        try
                        {
                            deq.BufferedThumbnail.Dispose();
                        }
                        finally
                        {
                            deq.BufferedThumbnail = null;
                        }
                    }
                }

                public void DisposeAll()
                {
                    while (imageQueue.Count > 0)
                        imageQueue.Dequeue().Dispose();
                    while (thumbnailQueue.Count > 0)
                        thumbnailQueue.Dequeue().Dispose();

                }
            }

            private static object CheckLockingLocker = new object();

            public void LoadImageByElem(Data.GroupingElement elem)
            {
                //locking this image
                lock (CheckLockingLocker)
                {
                    if (elem.BILocking || elem.IsBuffered) return;
                    elem.BILocking = true;
                }
                try
                {
                    //load image
                    elem.BufferedImage = Subsystem.ImageReader.Instance.LoadImage(elem.ImageSourcePath);
                    elem.LoadFailed = false;
                    this.ElementsDispose.EnqueueImage(elem);
                    if (!elem.IsThumbnailBuffered)
                        LoadThumbnailByElem(elem);
                }
                catch (Exception excp)
                {
                    //error following
                    if (elem.BufferedImage == null)
                    {
                        elem.LoadFailed = true;
                        elem.ExceptionText = excp.ToString();
                    }
                }
                finally
                {
                    //release image's locking
                    elem.BILocking = false;
                }
            }

            public static object ThumbCheckLockingLocker = new object();
            /// <summary>
            /// サムネイルの読み込み
            /// </summary>
            public void LoadThumbnailByElem(Data.GroupingElement elem)
            {
                //lock image
                lock (ThumbCheckLockingLocker)
                {
                    if (elem.BTLocking || elem.IsThumbnailBuffered) return;
                    elem.BTLocking = true;
                }
                try
                {
                    //If prefetch have finished, we create thumbnail with buffered image.
                    if (elem.IsBuffered)
                        elem.BufferedThumbnail = Subsystem.ImageReader.Instance.CreateThumbnail(elem.BufferedImage);
                    else
                        elem.BufferedThumbnail = Subsystem.ImageReader.Instance.CreateThumbnail(elem.ImageSourcePath);
                    this.ElementsDispose.EnqueueThumbnail(elem);
                }
                catch (Exception excp)
                {
                    //following error
                    if (!elem.IsBuffered && elem.IsThumbnailBuffered)
                    {
                        elem.LoadFailed = true;
                        elem.ExceptionText = excp.ToString();
                    }
                }
                finally
                {
                    //release locking
                    elem.BTLocking = false;
                }
            }

        }
    }
}
