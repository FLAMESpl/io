using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IO = System.IO;
using PhotoMark.Files;
using PhotoMark.Controls.Events;
using System.Drawing;
using PhotoMark.Serializing;
using PhotoMark.Annotations;

namespace PhotoMark.Controls
{
    public partial class Workspace : UserControl
    {
        private List<File> files;

        public Workspace()
        {
            InitializeComponent();
            carousel.FileSelection += carousel_FileSelected;
        }

        public void LoadFilePacket(string directory)
        {
            files = new List<File>(IO.Directory.GetFiles(directory)
                    .Where(f => FilesExtensions.Check(f))
                    .Select(f => new File(f).LoadAnnotations()))
                    .SortByName();

            carousel.ShowFiles(files);
        }

        private void LoadFile(File file)
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = Image.FromFile(file.Name);
            foreach (var annotation in file.Annotations)
            {
                DrawMarker(annotation as Marker);
            }
        }

        private void DrawMarker(Marker marker)
        {
            using (var graphics = Graphics.FromImage(pictureBox1.Image))
            {
                using (var brush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillEllipse(brush, marker.Position.X, marker.Position.Y, 16, 16);
                }
            }
        }

        private void carousel_FileSelected(object sender, FileSelectionEventArgs e)
        {
            var file = files.FirstOrDefault(x => x.Name == e.NewFilePath);
            if (file != null)
            {
                LoadFile(file);
            }
            else
            {
                MessageBox.Show("No file found", $"Could not load `{ e.NewFilePath }` file from disc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
