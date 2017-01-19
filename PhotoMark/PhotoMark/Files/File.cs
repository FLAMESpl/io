using PhotoMark.Annotations;
using System.Collections.Generic;

namespace PhotoMark.Files
{
    public class File
    {
        public string Name { get; set; }
        public ICollection<Annotation> Annotations { get; }

        public File(string name)
        {
            Name = name;
            Annotations = new List<Annotation>();
        }
    }
}
