using PhotoMark.Files;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhotoMark.Controls
{
    public partial class Carousel : UserControl
    {
        private List<File> files;

        public Carousel()
        {
            InitializeComponent();
        }

        public void LoadFiles(IEnumerable<File> files)
        {
            files = new List<File>(files).Sort()
        }
    }
}
