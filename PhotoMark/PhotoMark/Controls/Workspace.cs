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
using System;

namespace PhotoMark.Controls
{
    public partial class Workspace : UserControl
    {
        private List<File> files;
        private File activeFile;

        public Workspace()
        {
            InitializeComponent();
            carousel.FileSelection += carousel_FileSelected;
        }

        public void SaveFilePacket()
        {
            foreach (var file in files)
            {
                if (file.HasChanged)
                {
                    file.HasChanged = false;
                    file.SaveAnnotations();
                }

            }
        }

        public void LoadFilePacket(string directory)
        {
            files = new List<File>(IO.Directory.GetFiles(directory)
                    .Where(f => FilesExtensions.Check(f))
                    .Select(f => new File(f).LoadAnnotations()))
                    .SortByName();

            pictureBox.Image = null;
            carousel.ShowFiles(files);
        }

        private void LoadFile(File file)
        {
            activeFile = file;
            pictureBox.Image?.Dispose();
            pictureBox.Image = Image.FromFile(file.Name);
            foreach (var annotation in file.Annotations)
            {
                DrawMarker(annotation as Marker);
            }
        }

        private void DrawMarker(Marker marker)
        {
            using (var graphics = Graphics.FromImage(pictureBox.Image))
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

        private void pictureBox_Click(object sender, EventArgs e)
        {
            var eventArgs = (MouseEventArgs)e;
            var pictureBox = sender as PictureBox;
            var image = pictureBox.Image;
            if (image == null)
                return;

            var marker = new Marker();
            var scale = image.Size.Width / (double)pictureBox.Size.Width;

            marker.Position = eventArgs.Location.MapToImage(pictureBox.Size, image.Size);
            activeFile.Annotations.Add(marker);
            activeFile.HasChanged = true;
            DrawMarker(marker);
            pictureBox.Invalidate();
            
        }
    }
}
