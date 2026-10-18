namespace Assignment2
{
    partial class CreateDecklistMTG
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
            label1 = new Label();
            label2 = new Label();
            SearchBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            CardTypes = new ComboBox();
            CardContainer = new FlowLayoutPanel();
            SaveButton = new Button();
            DeckCount = new Label();
            PageCount = new Label();
            BackButton = new Button();
            NextButton = new Button();
            button1 = new Button();
            DeckPrice = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(10, 64);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 0;
            label1.Text = "Search:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 13);
            label2.Name = "label2";
            label2.Size = new Size(221, 30);
            label2.TabIndex = 1;
            label2.Text = "Build your MTG Deck";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(76, 66);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(238, 23);
            SearchBox.TabIndex = 2;
            SearchBox.UseWaitCursor = true;
            SearchBox.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(10, 96);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 3;
            label3.Text = "Filters";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(13, 127);
            label4.Name = "label4";
            label4.Size = new Size(37, 19);
            label4.TabIndex = 4;
            label4.Text = "Type";
            // 
            // CardTypes
            // 
            CardTypes.FormattingEnabled = true;
            CardTypes.Items.AddRange(new object[] { "Land", "Creature", "Aritfact", "Enchantment", "Planeswalker", "Battle", "Instant", "Sorcery" });
            CardTypes.Location = new Point(61, 127);
            CardTypes.Name = "CardTypes";
            CardTypes.RightToLeft = RightToLeft.No;
            CardTypes.Size = new Size(121, 23);
            CardTypes.TabIndex = 5;
            // 
            // CardContainer
            // 
            CardContainer.AutoScroll = true;
            CardContainer.Location = new Point(10, 172);
            CardContainer.Name = "CardContainer";
            CardContainer.Size = new Size(1295, 665);
            CardContainer.TabIndex = 11;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 13F);
            SaveButton.Location = new Point(13, 856);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(207, 77);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save Deck";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeckCount
            // 
            DeckCount.AutoSize = true;
            DeckCount.FlatStyle = FlatStyle.Flat;
            DeckCount.Font = new Font("Segoe UI", 28F);
            DeckCount.Location = new Point(226, 870);
            DeckCount.Name = "DeckCount";
            DeckCount.Size = new Size(97, 51);
            DeckCount.TabIndex = 13;
            DeckCount.Text = "0/60";
            // 
            // PageCount
            // 
            PageCount.AutoSize = true;
            PageCount.FlatStyle = FlatStyle.Flat;
            PageCount.Font = new Font("Segoe UI", 20F);
            PageCount.Location = new Point(613, 840);
            PageCount.Name = "PageCount";
            PageCount.Size = new Size(73, 37);
            PageCount.TabIndex = 14;
            PageCount.Text = "0/60";
            // 
            // BackButton
            // 
            BackButton.BackColor = SystemColors.Control;
            BackButton.Font = new Font("Segoe UI", 13F);
            BackButton.Location = new Point(456, 838);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(40, 51);
            BackButton.TabIndex = 15;
            BackButton.Text = "<";
            BackButton.UseVisualStyleBackColor = false;
            BackButton.Click += BackButton_Click;
            // 
            // NextButton
            // 
            NextButton.BackColor = SystemColors.Control;
            NextButton.Font = new Font("Segoe UI", 13F);
            NextButton.Location = new Point(792, 838);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(40, 51);
            NextButton.TabIndex = 16;
            NextButton.Text = ">";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(320, 64);
            button1.Name = "button1";
            button1.Size = new Size(43, 25);
            button1.TabIndex = 17;
            button1.Text = "Go";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DeckPrice
            // 
            DeckPrice.AutoSize = true;
            DeckPrice.FlatStyle = FlatStyle.Flat;
            DeckPrice.Font = new Font("Segoe UI", 28F);
            DeckPrice.Location = new Point(1010, 870);
            DeckPrice.Name = "DeckPrice";
            DeckPrice.RightToLeft = RightToLeft.Yes;
            DeckPrice.Size = new Size(226, 51);
            DeckPrice.TabIndex = 18;
            DeckPrice.Text = "Market: $0.0";
            // 
            // CreateDecklistMTG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 945);
            Controls.Add(DeckPrice);
            Controls.Add(button1);
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
            Name = "CreateDecklistMTG";
            Text = "Create Decklist";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox SearchBox;
        private Label label3;
        private Label label4;
        private ComboBox CardTypes;
        private FlowLayoutPanel CardContainer;
        private Button SaveButton;
        private Label DeckCount;
        private Label PageCount;
        private Button BackButton;
        private Button NextButton;
        private Button button1;
        private Label DeckPrice;
    }
}