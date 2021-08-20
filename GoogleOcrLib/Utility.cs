using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOcrLib
{
    public class Utility
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public static bool IsImageFile(string path)
        {            
            var ext = Path.GetExtension(path).ToUpperInvariant();
            return ImageExtensions.Contains(ext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ext"></param> e.g. ".pdf", ".tiff"
        /// <returns></returns>
        public static bool IsFileType(string path, string ext)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(ext))
                return false;

            var ext2 = Path.GetExtension(path);
            if (string.IsNullOrEmpty(ext2))
                return false;
            return ext2.ToUpperInvariant().Equals(ext.ToUpperInvariant());
        }

    }
}
