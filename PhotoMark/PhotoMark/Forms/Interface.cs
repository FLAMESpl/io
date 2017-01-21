using System;
using System.Windows.Forms;

namespace PhotoMark.Forms
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }

        private void buttonLoadFiles_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                workspace.LoadFilePacket(dialog.SelectedPath);
        }

        private void buttonSave_Click(object sender, EventArgs e) => workspace.SaveFilePacket();
    }
}
