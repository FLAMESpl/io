using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dialog.ShowDialog();
            workspace.LoadFilePacket(dialog.SelectedPath);
        }
    }
}
