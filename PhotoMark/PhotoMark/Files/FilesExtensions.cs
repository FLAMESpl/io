using System.Collections.Generic;
using System.Linq;

namespace PhotoMark.Files
{
    public static class FilesExtensions
    {
        private static readonly List<string> extensionNames = new List<string>
        {
            "BMP",
            "JPG",
            "PNG"
        };

        public static bool Check(string fileName)
        {
            return extensionNames.Contains(fileName.Split('.').Last().ToUpper());
        }
    }
}
