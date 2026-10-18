namespace Assignment2.Forms
{
    partial class DeckView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DeckImage = new PictureBox();
            DeckName = new Label();
            ((System.ComponentModel.ISupportInitialize)DeckImage).BeginInit();
            SuspendLayout();
            // 
            // DeckImage
            // 
            DeckImage.Location = new Point(3, 3);
            DeckImage.Name = "DeckImage";
            DeckImage.Size = new Size(226, 261);
            DeckImage.SizeMode = PictureBoxSizeMode.Zoom;
            DeckImage.TabIndex = 0;
            DeckImage.TabStop = false;
            // 
            // DeckName
            // 
            DeckName.AutoSize = true;
            DeckName.Font = new Font("Segoe UI", 12F);
            DeckName.Location = new Point(3, 267);
            DeckName.Name = "DeckName";
            DeckName.Size = new Size(49, 21);
            DeckName.TabIndex = 1;
            DeckName.Text = "name";
            // 
            // DeckView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DeckName);
            Controls.Add(DeckImage);
            Name = "DeckView";
            Size = new Size(232, 303);
            ((System.ComponentModel.ISupportInitialize)DeckImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox DeckImage;
        private Label DeckName;
    }
}
