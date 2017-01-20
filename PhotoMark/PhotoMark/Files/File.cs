using PhotoMark.Annotations;
using System.Collections;
using System.Collections.Generic;

namespace PhotoMark.Files
{
    public class File
    {
        public string Name { get; set; }
        public ICollection<Annotation> Annotations { get; set; }

        public File(string name)
        {
            Name = name;
            Annotations = new List<Annotation>();
        }
    }

    public class FileComparer : IComparer<File>
    {
        public int Compare(File x, File y) => new CaseInsensitiveComparer().Compare(x.Name, y.Name);
    }

    public static class FileExtensions
    {
        public static List<File> SortByName(this List<File> list)
        {
            list.Sort(new FileComparer());
            return list;
        }
    }
}
