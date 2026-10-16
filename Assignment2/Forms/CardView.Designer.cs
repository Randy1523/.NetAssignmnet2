namespace Assignment2.Forms
{
    partial class CardView
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
            pictureBox1 = new PictureBox();
            Quantity = new Label();
            CardName = new Label();
            addCard = new Button();
            removeCard = new Button();
            Rarity = new Label();
            marketPrice = new Label();
            LowPrice = new Label();
            HighPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(50, 6);
            pictureBox1.Margin = new Padding(6, 6, 6, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(344, 461);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Quantity
            // 
            Quantity.AutoSize = true;
            Quantity.Location = new Point(197, 666);
            Quantity.Margin = new Padding(6, 0, 6, 0);
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(27, 32);
            Quantity.TabIndex = 1;
            Quantity.Text = "0";
            // 
            // CardName
            // 
            CardName.AutoSize = true;
            CardName.FlatStyle = FlatStyle.Flat;
            CardName.Font = new Font("Segoe UI", 10F);
            CardName.Location = new Point(169, 474);
            CardName.Margin = new Padding(6, 0, 6, 0);
            CardName.Name = "CardName";
            CardName.RightToLeft = RightToLeft.No;
            CardName.Size = new Size(88, 37);
            CardName.TabIndex = 2;
            CardName.Text = "Name";
            CardName.TextAlign = ContentAlignment.TopCenter;
            // 
            // addCard
            // 
            addCard.Location = new Point(293, 657);
            addCard.Margin = new Padding(6, 6, 6, 6);
            addCard.Name = "addCard";
            addCard.Size = new Size(41, 49);
            addCard.TabIndex = 3;
            addCard.Text = "+";
            addCard.UseVisualStyleBackColor = true;
            addCard.Click += addCard_Click;
            // 
            // removeCard
            // 
            removeCard.Location = new Point(97, 657);
            removeCard.Margin = new Padding(6, 6, 6, 6);
            removeCard.Name = "removeCard";
            removeCard.Size = new Size(41, 49);
            removeCard.TabIndex = 4;
            removeCard.Text = "-";
            removeCard.UseVisualStyleBackColor = true;
            removeCard.Click += removeCard_Click;
            // 
            // Rarity
            // 
            Rarity.AutoSize = true;
            Rarity.Location = new Point(169, 514);
            Rarity.Margin = new Padding(6, 0, 6, 0);
            Rarity.Name = "Rarity";
            Rarity.Size = new Size(74, 32);
            Rarity.TabIndex = 5;
            Rarity.Text = "Rarity";
            Rarity.TextAlign = ContentAlignment.TopCenter;
            // 
            // marketPrice
            // 
            marketPrice.AutoSize = true;
            marketPrice.Location = new Point(169, 546);
            marketPrice.Margin = new Padding(6, 0, 6, 0);
            marketPrice.Name = "marketPrice";
            marketPrice.Size = new Size(140, 32);
            marketPrice.TabIndex = 6;
            marketPrice.Text = "MarketPrice";
            marketPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // LowPrice
            // 
            LowPrice.AutoSize = true;
            LowPrice.Location = new Point(169, 578);
            LowPrice.Margin = new Padding(6, 0, 6, 0);
            LowPrice.Name = "LowPrice";
            LowPrice.Size = new Size(107, 32);
            LowPrice.TabIndex = 7;
            LowPrice.Text = "LowPrice";
            LowPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // HighPrice
            // 
            HighPrice.AutoSize = true;
            HighPrice.Location = new Point(169, 610);
            HighPrice.Margin = new Padding(6, 0, 6, 0);
            HighPrice.Name = "HighPrice";
            HighPrice.Size = new Size(116, 32);
            HighPrice.TabIndex = 8;
            HighPrice.Text = "HighPrice";
            HighPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // CardView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(HighPrice);
            Controls.Add(LowPrice);
            Controls.Add(marketPrice);
            Controls.Add(Rarity);
            Controls.Add(removeCard);
            Controls.Add(addCard);
            Controls.Add(CardName);
            Controls.Add(Quantity);
            Controls.Add(pictureBox1);
            Margin = new Padding(6, 6, 6, 6);
            Name = "CardView";
            Size = new Size(449, 725);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Quantity;
        private Label CardName;
        private Button addCard;
        private Button removeCard;
        private Label Rarity;
        private Label marketPrice;
        private Label LowPrice;
        private Label HighPrice;
    }
}
