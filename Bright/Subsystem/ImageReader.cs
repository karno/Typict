using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SpiMngx;
using System.Drawing.Imaging;

namespace Bright.Subsystem
{
    public class ImageReader : IDisposable
    {
        #region Singleton
        static ImageReader instance = null;
        public static ImageReader Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImageReader();
                return instance;
            }
        }
        #endregion

        public SpiManager SusieManager;
        public ImageReader()
        {
            SusieManager = new SpiManager(LoadFlag.Default & ~LoadFlag.Load00AM);
            SusieManager.LoadAll();
        }

        public void Dispose()
        {
            if (SusieManager != null)
                SusieManager.Dispose();
            SusieManager = null;
        }

        public IEnumerable<string> AcceptExtents()
        {
            foreach (var ext in GetSystemAcceptExt())
                yield return ext;
            foreach (var ext in GetSusieAcceptExt())
                yield return ext;
        }

        /// <summary>
        /// システムがサポートする画像フォーマットの拡張子の配列を取得します。
        /// </summary>
        /// <returns>読み込める拡張子のString配列</returns>
        public IEnumerable<string> GetSystemAcceptExt()
        {
            ImageCodecInfo[] decoders = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo ici in decoders)
            {
                //セミコロン区切りで渡されるので
                string[] exts = ici.FilenameExtension.Split(new char[] { ';' });
                foreach (string ext in exts)
                    yield return ext;
            }
        }

        /// <summary>
        /// Susie Plug-inで読み込める画像フォーマットの拡張子を取得します。
        /// </summary>
        /// <returns>読み込める拡張子のString配列</returns>
        public IEnumerable<string> GetSusieAcceptExt()
        {
            // all images/arcives|*....|JPEG...|*.jpg...
            //               　　↑ここから取得(対応形式全てがセミコロン区切りで取得できる)
            string SusieExt = this.SusieManager.GetFileFilter();
            //対応形式全てのセミコロン区切りを取得する
            if (String.IsNullOrEmpty(SusieExt))
                yield break;

            SusieExt = SusieExt.Split(new char[] { '|' })[1];

            foreach (string addext in SusieExt.Split(new char[] { ';' }))
                yield return addext;
        }

        public Image LoadImage(string path)
        {
            Image loaded = null;
            if (!System.IO.File.Exists(path))
                //ファイルが見つからない
                throw new System.IO.FileNotFoundException("Image not found:" + path);

            loaded = SusieImageReader(path);
            if (loaded == null)
            {
                loaded = K.Snippets.Images.ImageSafeReader(path, false);
            }

            if (loaded == null)
                throw new Exception("Image cannot read");
            return loaded;
        }

        /// <summary>
        /// 画像をSusieプラグインから読み込みます。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Image SusieImageReader(string path)
        {
            if (SusieManager.Plugins.Count == 0)
                return null;
            using (ImagePlugin ip = SusieManager.QueryImagePlugin(path))
            {
                if (ip == null)
                    return null;
                return ip.GetPicture(path);
            }
        }

        public Image CreateThumbnail(string path)
        {
            Image loaded = null;
            if (!System.IO.File.Exists(path))
                //ファイルが見つからない
                throw new System.IO.FileNotFoundException("Image not found:" + path);

            loaded = SusieThumbnailReader(path);
            if (loaded == null)
                loaded = K.Snippets.Images.ImageSafeReader(path, false);

            if (loaded == null)
                loaded = SusieImageReader(path);

            if (loaded == null)
                throw new Exception("Image cannot read");
            var thumbnail = CreateThumbnail(loaded);
            loaded.Dispose();
            return thumbnail;
        }

        public Image CreateThumbnail(Image img)
        {
            return img.GetThumbnailImage(
                Core.Config.DisplayConfig.ThumbnailSize.Width,
                Core.Config.DisplayConfig.ThumbnailSize.Height,
                () => false, IntPtr.Zero);
        }

        private Image SusieThumbnailReader(string path)
        {
            if (SusieManager.Plugins.Count == 0)
                return null;
            using (ImagePlugin ip = SusieManager.QueryImagePlugin(path))
            {
                if (ip == null)
                    return null;
                return ip.GetPreview(path);
            }
        }

        ~ImageReader()
        {
            if (SusieManager != null)
                SusieManager.Dispose();
            SusieManager = null;
        }
    }
}
