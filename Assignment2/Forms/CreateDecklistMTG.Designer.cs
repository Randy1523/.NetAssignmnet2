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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(19, 137);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(121, 45);
            label1.TabIndex = 0;
            label1.Text = "Search:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 28);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(445, 57);
            label2.TabIndex = 1;
            label2.Text = "Build your MTG Deck";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 141);
            textBox1.Margin = new Padding(6, 6, 6, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(439, 39);
            textBox1.TabIndex = 2;
            textBox1.UseWaitCursor = true;
            textBox1.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(19, 205);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 45);
            label3.TabIndex = 3;
            label3.Text = "Filters";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(24, 271);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 37);
            label4.TabIndex = 4;
            label4.Text = "Type";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Land", "Creature", "Aritfact", "Enchantment", "Planeswalker", "Battle", "Instant", "Sorcery" });
            comboBox1.Location = new Point(113, 271);
            comboBox1.Margin = new Padding(6, 6, 6, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 40);
            comboBox1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(349, 271);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 37);
            label5.TabIndex = 6;
            label5.Text = "Attack";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(449, 271);
            numericUpDown1.Margin = new Padding(6, 6, 6, 6);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(61, 39);
            numericUpDown1.TabIndex = 8;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(693, 271);
            numericUpDown2.Margin = new Padding(6, 6, 6, 6);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(61, 39);
            numericUpDown2.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(544, 271);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(141, 37);
            label6.TabIndex = 9;
            label6.Text = "Toughness";
            // 
            // CardContainer
            // 
            CardContainer.Location = new Point(19, 367);
            CardContainer.Margin = new Padding(6, 6, 6, 6);
            CardContainer.Name = "CardContainer";
            CardContainer.Size = new Size(2251, 1058);
            CardContainer.TabIndex = 11;
            // 
            // CreateDecklistMTG
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2292, 1649);
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
            Margin = new Padding(6, 6, 6, 6);
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
    }
}