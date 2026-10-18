namespace Assignment2.Forms
{
    partial class CreateDeckListPokemon
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
            SearchButton = new Button();
            NextButton = new Button();
            BackButton = new Button();
            PageCount = new Label();
            DeckCount = new Label();
            SaveButton = new Button();
            CardContainer = new FlowLayoutPanel();
            CardTypes = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            SearchBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            DeckPrice = new Label();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.Font = new Font("Segoe UI", 10F);
            SearchButton.Location = new Point(319, 60);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(43, 25);
            SearchButton.TabIndex = 30;
            SearchButton.Text = "Go";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // NextButton
            // 
            NextButton.BackColor = SystemColors.Control;
            NextButton.Font = new Font("Segoe UI", 13F);
            NextButton.Location = new Point(791, 834);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(40, 51);
            NextButton.TabIndex = 29;
            NextButton.Text = ">";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // BackButton
            // 
            BackButton.BackColor = SystemColors.Control;
            BackButton.Font = new Font("Segoe UI", 13F);
            BackButton.Location = new Point(455, 834);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(40, 51);
            BackButton.TabIndex = 28;
            BackButton.Text = "<";
            BackButton.UseVisualStyleBackColor = false;
            BackButton.Click += BackButton_Click;
            // 
            // PageCount
            // 
            PageCount.AutoSize = true;
            PageCount.FlatStyle = FlatStyle.Flat;
            PageCount.Font = new Font("Segoe UI", 20F);
            PageCount.Location = new Point(612, 836);
            PageCount.Name = "PageCount";
            PageCount.Size = new Size(73, 37);
            PageCount.TabIndex = 27;
            PageCount.Text = "0/60";
            // 
            // DeckCount
            // 
            DeckCount.AutoSize = true;
            DeckCount.FlatStyle = FlatStyle.Flat;
            DeckCount.Font = new Font("Segoe UI", 28F);
            DeckCount.Location = new Point(225, 867);
            DeckCount.Name = "DeckCount";
            DeckCount.Size = new Size(97, 51);
            DeckCount.TabIndex = 26;
            DeckCount.Text = "0/60";
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 13F);
            SaveButton.Location = new Point(12, 852);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(207, 77);
            SaveButton.TabIndex = 25;
            SaveButton.Text = "Save Deck";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CardContainer
            // 
            CardContainer.AutoScroll = true;
            CardContainer.Location = new Point(9, 168);
            CardContainer.Name = "CardContainer";
            CardContainer.Size = new Size(1295, 665);
            CardContainer.TabIndex = 24;
            // 
            // CardTypes
            // 
            CardTypes.FormattingEnabled = true;
            CardTypes.Items.AddRange(new object[] { "", "Grass", "Fire", "Water", "Lightning", "Psychic", "Fighting", "Darkness", "Metal", "Dragon", "Colorless", "Fairy", "Item", "Supporter", "Stadium", "ACE SPEC", "Energy" });
            CardTypes.Location = new Point(60, 123);
            CardTypes.Name = "CardTypes";
            CardTypes.Size = new Size(121, 23);
            CardTypes.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(12, 123);
            label4.Name = "label4";
            label4.Size = new Size(37, 19);
            label4.TabIndex = 22;
            label4.Text = "Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(9, 92);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 21;
            label3.Text = "Filters";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(75, 62);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(238, 23);
            SearchBox.TabIndex = 20;
            SearchBox.UseWaitCursor = true;
            SearchBox.WordWrap = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(268, 30);
            label2.TabIndex = 19;
            label2.Text = "Build your Pokemon Deck";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(9, 60);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 18;
            label1.Text = "Search:";
            // 
            // DeckPrice
            // 
            DeckPrice.AutoSize = true;
            DeckPrice.FlatStyle = FlatStyle.Flat;
            DeckPrice.Font = new Font("Segoe UI", 28F);
            DeckPrice.Location = new Point(987, 867);
            DeckPrice.Name = "DeckPrice";
            DeckPrice.RightToLeft = RightToLeft.Yes;
            DeckPrice.Size = new Size(226, 51);
            DeckPrice.TabIndex = 31;
            DeckPrice.Text = "Market: $0.0";
            // 
            // CreateDeckListPokemon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 940);
            Controls.Add(DeckPrice);
            Controls.Add(SearchButton);
            Controls.Add(NextButton);
            Controls.Add(BackButton);
            Controls.Add(PageCount);
            Controls.Add(DeckCount);
            Controls.Add(SaveButton);
            Controls.Add(CardContainer);
            Controls.Add(CardTypes);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SearchBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateDeckListPokemon";
            Text = "CreateDeckListPokemon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private Button NextButton;
        private Button BackButton;
        private Label PageCount;
        private Label DeckCount;
        private Button SaveButton;
        private FlowLayoutPanel CardContainer;
        private ComboBox CardTypes;
        private Label label4;
        private Label label3;
        private TextBox SearchBox;
        private Label label2;
        private Label label1;
        private Label DeckPrice;
    }
}