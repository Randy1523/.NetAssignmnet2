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
            button1 = new Button();
            NextButton = new Button();
            BackButton = new Button();
            PageCount = new Label();
            DeckCount = new Label();
            SaveButton = new Button();
            CardContainer = new FlowLayoutPanel();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(319, 60);
            button1.Name = "button1";
            button1.Size = new Size(43, 25);
            button1.TabIndex = 30;
            button1.Text = "Go";
            button1.UseVisualStyleBackColor = true;
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
            DeckCount.Location = new Point(1207, 852);
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
            // 
            // CardContainer
            // 
            CardContainer.AutoScroll = true;
            CardContainer.Location = new Point(9, 168);
            CardContainer.Name = "CardContainer";
            CardContainer.Size = new Size(1295, 665);
            CardContainer.TabIndex = 24;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Land", "Creature", "Aritfact", "Enchantment", "Planeswalker", "Battle", "Instant", "Sorcery" });
            comboBox1.Location = new Point(60, 123);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 23;
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
            // textBox1
            // 
            textBox1.Location = new Point(75, 62);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 20;
            textBox1.UseWaitCursor = true;
            textBox1.WordWrap = false;
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
            // CreateDeckListPokemon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 940);
            Controls.Add(button1);
            Controls.Add(NextButton);
            Controls.Add(BackButton);
            Controls.Add(PageCount);
            Controls.Add(DeckCount);
            Controls.Add(SaveButton);
            Controls.Add(CardContainer);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateDeckListPokemon";
            Text = "CreateDeckListPokemon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button NextButton;
        private Button BackButton;
        private Label PageCount;
        private Label DeckCount;
        private Button SaveButton;
        private FlowLayoutPanel CardContainer;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
    }
}