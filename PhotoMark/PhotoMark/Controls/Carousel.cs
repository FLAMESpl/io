using PhotoMark.Controls.Events;
using PhotoMark.Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhotoMark.Controls
{
    public partial class Carousel : UserControl
    {
        public event EventHandler<FileSelectionEventArgs> FileSelection;

        private PictureBox selectedPictureBox = null;
        private readonly Color activeColor = SystemColors.ActiveCaption;
        private readonly Color inactiveColor = SystemColors.InactiveCaption;

        public Carousel()
        {
            InitializeComponent();
        }

        public Size ThumbnailSize() => new Size((int)(flowLayoutPanel.Height * 1.25), flowLayoutPanel.Height);

        public void OnFileSelected(FileSelectionEventArgs e) => FileSelection?.Invoke(this, e);

        public void ShowFiles(IEnumerable<File> files)
        {
            ClearContent();
            foreach (var file in files)
            {
                var pictureBox = new PictureBox
                {
                    BackColor = inactiveColor,
                    Size = ThumbnailSize(),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(file.Name)
                };
                pictureBox.Click += (s, e) => ThumbnailClick(s as PictureBox, file.Name);
                flowLayoutPanel.Controls.Add(pictureBox);
            }

        }

        public void ClearContent()
        {
            var pictureBoxes = flowLayoutPanel.Controls.Cast<PictureBox>().ToList();
            selectedPictureBox = null;
            flowLayoutPanel.Controls.Clear();
            pictureBoxes.ForEach(p => p.Dispose());
        }

        private void ThumbnailClick(PictureBox thumbnail, string fileName)
        {
            if (selectedPictureBox != null)
                selectedPictureBox.BackColor = inactiveColor;
            
            selectedPictureBox = thumbnail;
            thumbnail.BackColor = activeColor;

            OnFileSelected(new FileSelectionEventArgs { NewFilePath = fileName });
        }
    }
}
