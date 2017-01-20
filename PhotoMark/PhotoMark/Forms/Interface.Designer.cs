namespace PhotoMark.Forms
{
    partial class Interface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadFiles = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.workspace = new PhotoMark.Controls.Workspace();
            this.SuspendLayout();
            // 
            // buttonLoadFiles
            // 
            this.buttonLoadFiles.Location = new System.Drawing.Point(10, 11);
            this.buttonLoadFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLoadFiles.Name = "buttonLoadFiles";
            this.buttonLoadFiles.Size = new System.Drawing.Size(102, 34);
            this.buttonLoadFiles.TabIndex = 0;
            this.buttonLoadFiles.Text = "Wczytaj pakiet";
            this.buttonLoadFiles.UseVisualStyleBackColor = true;
            this.buttonLoadFiles.Click += new System.EventHandler(this.buttonLoadFiles_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(476, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zapisz odpowiedź";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // workspace
            // 
            this.workspace.Location = new System.Drawing.Point(10, 50);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(571, 522);
            this.workspace.TabIndex = 2;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 587);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLoadFiles);
            this.Name = "Interface";
            this.Text = "PhotoMark";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFiles;
        private System.Windows.Forms.Button button2;
        private Controls.Workspace workspace;
    }
}

