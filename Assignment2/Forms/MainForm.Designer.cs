namespace Assignment2.Forms
{
    partial class MainForm
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
            Panel = new Panel();
            TopBar = new Panel();
            GameSelect = new ComboBox();
            Options = new Button();
            Header = new Label();
            Back = new Button();
            TopBar.SuspendLayout();
            SuspendLayout();
            // 
            // Panel
            // 
            Panel.Dock = DockStyle.Fill;
            Panel.Location = new Point(0, 50);
            Panel.Name = "Panel";
            Panel.Size = new Size(984, 661);
            Panel.TabIndex = 1;
            // 
            // TopBar
            // 
            TopBar.BackColor = SystemColors.ButtonHighlight;
            TopBar.Controls.Add(GameSelect);
            TopBar.Controls.Add(Back);
            TopBar.Controls.Add(Options);
            TopBar.Controls.Add(Header);
            TopBar.Dock = DockStyle.Top;
            TopBar.Location = new Point(0, 0);
            TopBar.Name = "TopBar";
            TopBar.Size = new Size(984, 50);
            TopBar.TabIndex = 2;
            // 
            // GameSelect
            // 
            GameSelect.Anchor = AnchorStyles.Left;
            GameSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            GameSelect.FormattingEnabled = true;
            GameSelect.Items.AddRange(new object[] { "Magic: The Gathering", "Pokémon" });
            GameSelect.Location = new Point(757, 13);
            GameSelect.Name = "GameSelect";
            GameSelect.Size = new Size(150, 23);
            GameSelect.TabIndex = 1;
            // 
            // Options
            // 
            Options.Anchor = AnchorStyles.Right;
            Options.AutoSize = true;
            Options.Location = new Point(913, 12);
            Options.Name = "Options";
            Options.Size = new Size(59, 25);
            Options.TabIndex = 3;
            Options.Text = "Options";
            Options.UseVisualStyleBackColor = true;
            Options.Click += Options_Click;
            // 
            // Header
            // 
            Header.Dock = DockStyle.Fill;
            Header.Font = new Font("Segoe UI", 16F);
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Padding = new Padding(60, 0, 240, 0);
            Header.Size = new Size(984, 50);
            Header.TabIndex = 0;
            Header.Text = "TCG Market Plays";
            Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Back
            // 
            Back.Anchor = AnchorStyles.Left;
            Back.AutoSize = true;
            Back.Location = new Point(12, 12);
            Back.Name = "Back";
            Back.Size = new Size(42, 25);
            Back.TabIndex = 3;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(984, 711);
            Controls.Add(Panel);
            Controls.Add(TopBar);
            MinimumSize = new Size(200, 200);
            Name = "MainForm";
            Text = "TCG Market Plays";
            TopBar.ResumeLayout(false);
            TopBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel;
        private Panel TopBar;
        private Label Header;
        private ComboBox GameSelect;
        private Button Options;
        private Button Back;
    }
}