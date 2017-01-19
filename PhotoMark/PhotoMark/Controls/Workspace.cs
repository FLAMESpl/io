using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PhotoMark.Files;
using IO = System.IO;

namespace PhotoMark.Controls
{
    public partial class Workspace : UserControl
    {
        private List<File> files;

        public Workspace()
        {
            InitializeComponent();
        }

        public void LoadFilePacket(string directory)
        {
            files.AddRange(IO.Directory.GetFiles(directory)
                .Where(f => FilesExtensions.Check(f))
                .Select(f => new File(f)));
        }
    }
}
