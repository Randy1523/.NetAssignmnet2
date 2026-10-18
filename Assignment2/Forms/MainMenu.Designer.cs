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
            OtherDecklists = new Button();
            Title = new Label();
            SuspendLayout();
            // 
            // CreateDecklist
            // 
            CreateDecklist.BackgroundImageLayout = ImageLayout.None;
            CreateDecklist.Location = new Point(49, 109);
            CreateDecklist.Name = "CreateDecklist";
            CreateDecklist.Size = new Size(267, 70);
            CreateDecklist.TabIndex = 0;
            CreateDecklist.Text = "Create New Decklist";
            CreateDecklist.UseVisualStyleBackColor = true;
            CreateDecklist.Click += button1_Click;
            // 
            // ViewDecklists
            // 
            ViewDecklists.Location = new Point(49, 231);
            ViewDecklists.Name = "ViewDecklists";
            ViewDecklists.Size = new Size(267, 70);
            ViewDecklists.TabIndex = 1;
            ViewDecklists.Text = "View Decklists";
            ViewDecklists.UseVisualStyleBackColor = true;
            ViewDecklists.Click += ViewDecklists_Click;
            // 
            // TournamentData
            // 
            TournamentData.Location = new Point(49, 345);
            TournamentData.Name = "TournamentData";
            TournamentData.Size = new Size(267, 70);
            TournamentData.TabIndex = 2;
            TournamentData.Text = "View Usage Data";
            TournamentData.UseVisualStyleBackColor = true;
            // 
            // OtherDecklists
            // 
            OtherDecklists.Location = new Point(49, 472);
            OtherDecklists.Name = "OtherDecklists";
            OtherDecklists.Size = new Size(267, 70);
            OtherDecklists.TabIndex = 3;
            OtherDecklists.Text = "View Other Decklists";
            OtherDecklists.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 15F);
            Title.Location = new Point(394, 40);
            Title.Name = "Title";
            Title.Size = new Size(162, 28);
            Title.TabIndex = 4;
            Title.Text = "TCG Market Plays";
            Title.Click += label1_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 648);
            Controls.Add(Title);
            Controls.Add(OtherDecklists);
            Controls.Add(TournamentData);
            Controls.Add(ViewDecklists);
            Controls.Add(CreateDecklist);
            Name = "MainMenu";
            Text = "TCG Market Plays";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateDecklist;
        private Button ViewDecklists;
        private Button TournamentData;
        private Button OtherDecklists;
        private Label Title;
    }
}
