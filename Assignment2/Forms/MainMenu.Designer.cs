namespace Assignment2
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateDecklist = new Button();
            ViewDecklists = new Button();
            TournamentData = new Button();
            Title = new Label();
            btnDownload = new Button();
            pictureBox1 = new PictureBox();
            ClipImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClipImage).BeginInit();
            SuspendLayout();
            // 
            // CreateDecklist
            // 
            CreateDecklist.BackgroundImageLayout = ImageLayout.None;
            CreateDecklist.Location = new Point(50, 181);
            CreateDecklist.Name = "CreateDecklist";
            CreateDecklist.Size = new Size(267, 70);
            CreateDecklist.TabIndex = 0;
            CreateDecklist.Text = "Create New Decklist";
            CreateDecklist.UseVisualStyleBackColor = true;
            CreateDecklist.Click += button1_Click;
            // 
            // ViewDecklists
            // 
            ViewDecklists.Location = new Point(50, 303);
            ViewDecklists.Name = "ViewDecklists";
            ViewDecklists.Size = new Size(267, 70);
            ViewDecklists.TabIndex = 1;
            ViewDecklists.Text = "View Decklists";
            ViewDecklists.UseVisualStyleBackColor = true;
            ViewDecklists.Click += ViewDecklists_Click;
            // 
            // TournamentData
            // 
            TournamentData.Location = new Point(50, 417);
            TournamentData.Name = "TournamentData";
            TournamentData.Size = new Size(267, 70);
            TournamentData.TabIndex = 2;
            TournamentData.Text = "View Usage Data";
            TournamentData.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 25F);
            Title.Location = new Point(351, 29);
            Title.Name = "Title";
            Title.Size = new Size(278, 46);
            Title.TabIndex = 4;
            Title.Text = "TCG Market Plays";
            // 
            // btnDownload
            // 
            btnDownload.BackgroundImageLayout = ImageLayout.None;
            btnDownload.Location = new Point(107, 135);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(157, 40);
            btnDownload.TabIndex = 5;
            btnDownload.Text = "Update Pricing";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += button1_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // ClipImage
            // 
            ClipImage.Location = new Point(537, 135);
            ClipImage.Name = "ClipImage";
            ClipImage.Size = new Size(353, 439);
            ClipImage.SizeMode = PictureBoxSizeMode.Zoom;
            ClipImage.TabIndex = 7;
            ClipImage.TabStop = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 648);
            Controls.Add(ClipImage);
            Controls.Add(pictureBox1);
            Controls.Add(btnDownload);
            Controls.Add(Title);
            Controls.Add(TournamentData);
            Controls.Add(ViewDecklists);
            Controls.Add(CreateDecklist);
            Name = "MainMenu";
            Text = "TCG Market Plays";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClipImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateDecklist;
        private Button ViewDecklists;
        private Button TournamentData;
        private Label Title;
        private Button btnDownload;
        private PictureBox pictureBox1;
        private PictureBox ClipImage;
    }
}
