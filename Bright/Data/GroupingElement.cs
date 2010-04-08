using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Bright.Data
{
    public class GroupingElement :IDisposable
    {
        public GroupingElement(string path)
        {
            ImageSourcePath = path;
        }

        /// <summary>
        /// Image source path
        /// </summary>
        public string ImageSourcePath { get; private set; }

        /// <summary>
        /// Can't load this image.
        /// </summary>
        public bool LoadFailed { get; set; }

        /// <summary>
        /// Load fail excp text.
        /// </summary>
        public string ExceptionText { get; set; }
        
        /// <summary>
        /// Buffered image
        /// </summary>
        public Image BufferedImage { get; set; }

        /// <summary>
        /// Locking state in BufferedImage
        /// </summary>
        public volatile bool BILocking = false;

        /// <summary>
        /// Buffered thumbnail image
        /// </summary>
        public Image BufferedThumbnail { get; set; }

        /// <summary>
        /// Locking state in BufferedThumbnail
        /// </summary>
        public volatile bool BTLocking = false;
        
        /// <summary>
        /// Buffered this image
        /// </summary>
        public bool IsBuffered
        {
            get { return this.BufferedImage != null; }
        }

        /// <summary>
        /// Buffered this thumbnail
        /// </summary>
        public bool IsThumbnailBuffered
        {
            get { return this.BufferedThumbnail != null; }
        }

        public void SetSingleDirectDest(string dest)
        {
            Destinations.Clear();
            Destinations.Add(new DestData() { Destination = dest });
        }

        /// <summary>
        /// Image destination(You MUST set this prop with Destination.SetDestination(GroupingElement) method.)
        /// </summary>
        public List<DestData> Destinations = new List<DestData>();

        /// <summary>
        /// Rename name
        /// </summary>
        public string NewName = null;

        public class DestData
        {
            public DestData() { }
            public DestData(string destDirect)
            {
                this.SetDestination(destDirect);
            }
            public DestData(Data.Destination dest)
            {
                this.SetDestination(dest);
            }

            public void SetDestination(string destDirect)
            {
                this.Destination = destDirect;
            }

            public void SetDestination(Data.Destination dest)
            {
                dest.SetElementDestination(this);
            }

            public string Destination { get; set; }
        }

        /// <summary>
        /// Distribution mode enumerate
        /// </summary>
        public enum DistributionModes { Copy, Move, Link, App = -1 }

        /// <summary>
        /// Distribution mode
        /// </summary>
        public DistributionModes DistributionMode { get; set; }

        /// <summary>
        /// Grouped this image
        /// </summary>
        public bool IsGrouped
        {
            get { return this.Destinations.Count != 0; }
        }

        public void Dispose()
        {
            if (this.IsBuffered)
                this.BufferedImage.Dispose();
            this.BufferedImage = null;
            if (this.IsThumbnailBuffered)
                this.BufferedThumbnail.Dispose();
            this.BufferedThumbnail = null;
        }
    }
}
