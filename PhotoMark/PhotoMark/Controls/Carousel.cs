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

        private int index;
        private IReadOnlyList<File> files;
        private PictureBox selectedPictureBox = null;
        private readonly Color activeColor = SystemColors.ActiveCaption;
        private readonly Color inactiveColor = SystemColors.InactiveCaption;

        public Carousel()
        {
            InitializeComponent();
        }

        public void OnFileSelected(FileSelectionEventArgs e) => FileSelection?.Invoke(this, e);

        public Size ThumbnailSize()
        {
            var basicHeight = flowLayoutPanel.Height - 26;
            return new Size((int)(basicHeight * 1.25), basicHeight);
        }

        public void ShowFiles(IReadOnlyList<File> files)
        {
            ClearContent();
            this.files = files;
            for (int i = 0; i < files.Count; i++)
            {
                var pictureBox = new PictureBox
                {
                    BackColor = inactiveColor,
                    Size = ThumbnailSize(),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(files[i].Name)
                };
                var indexForEvent = i;
                pictureBox.Click += (s, e) => ThumbnailSelect(s as PictureBox, files[indexForEvent].Name, indexForEvent);
                flowLayoutPanel.Controls.Add(pictureBox);
            }

        }

        public void ClearContent()
        {
            index = -1;
            var pictureBoxes = flowLayoutPanel.Controls.Cast<PictureBox>().ToList();
            selectedPictureBox = null;
            flowLayoutPanel.Controls.Clear();
            pictureBoxes.ForEach(p => p.Dispose());
        }

        private void ThumbnailSelect(PictureBox thumbnail, string fileName, int newIndex)
        {
            if (selectedPictureBox != null)
                selectedPictureBox.BackColor = inactiveColor;
            
            selectedPictureBox = thumbnail;
            index = newIndex;
            thumbnail.BackColor = activeColor;

            OnFileSelected(new FileSelectionEventArgs { NewFilePath = fileName });
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (files != null)
            {
                var newIndex = index - 1;
                if (newIndex >= 0)
                    ThumbnailSelect(flowLayoutPanel.Controls[newIndex] as PictureBox, files[newIndex].Name, newIndex);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (files != null)
            {
                var newIndex = index + 1;
                if (newIndex < files.Count)
                    ThumbnailSelect(flowLayoutPanel.Controls[newIndex] as PictureBox, files[newIndex].Name, newIndex);
            }
        }
    }
}
