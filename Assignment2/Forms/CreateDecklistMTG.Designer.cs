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
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label6 = new Label();
            CardContainer = new FlowLayoutPanel();
            SaveButton = new Button();
            DeckCount = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
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
            // textBox1
            // 
            textBox1.Location = new Point(76, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 2;
            textBox1.UseWaitCursor = true;
            textBox1.WordWrap = false;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Land", "Creature", "Aritfact", "Enchantment", "Planeswalker", "Battle", "Instant", "Sorcery" });
            comboBox1.Location = new Point(61, 127);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(188, 127);
            label5.Name = "label5";
            label5.Size = new Size(48, 19);
            label5.TabIndex = 6;
            label5.Text = "Attack";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(242, 127);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(33, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(373, 127);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(33, 23);
            numericUpDown2.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(293, 127);
            label6.Name = "label6";
            label6.Size = new Size(74, 19);
            label6.TabIndex = 9;
            label6.Text = "Toughness";
            // 
            // CardContainer
            // 
            CardContainer.AutoScroll = true;
            CardContainer.AutoSize = true;
            CardContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CardContainer.Location = new Point(10, 172);
            CardContainer.Name = "CardContainer";
            CardContainer.Size = new Size(0, 0);
            CardContainer.TabIndex = 11;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Segoe UI", 13F);
            SaveButton.Location = new Point(13, 687);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(207, 77);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save Deck";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // DeckCount
            // 
            DeckCount.AutoSize = true;
            DeckCount.FlatStyle = FlatStyle.Flat;
            DeckCount.Font = new Font("Segoe UI", 28F);
            DeckCount.Location = new Point(1113, 701);
            DeckCount.Name = "DeckCount";
            DeckCount.Size = new Size(97, 51);
            DeckCount.TabIndex = 13;
            DeckCount.Text = "0/60";
            // 
            // CreateDecklistMTG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 788);
            Controls.Add(DeckCount);
            Controls.Add(SaveButton);
            Controls.Add(CardContainer);
            Controls.Add(numericUpDown2);
            Controls.Add(label6);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateDecklistMTG";
            Text = "Create Decklist";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label6;
        private FlowLayoutPanel CardContainer;
        private Button SaveButton;
        private Label DeckCount;
    }
}