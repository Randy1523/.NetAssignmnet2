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
            pictureBox1.Location = new Point(27, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 216);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            
            // 
            // Quantity
            // 
            Quantity.AutoSize = true;
            Quantity.Location = new Point(106, 312);
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(13, 15);
            Quantity.TabIndex = 1;
            Quantity.Text = "0";
            // 
            // CardName
            // 
            CardName.AutoSize = true;
            CardName.FlatStyle = FlatStyle.Flat;
            CardName.Font = new Font("Segoe UI", 10F);
            CardName.Location = new Point(91, 222);
            CardName.Name = "CardName";
            CardName.RightToLeft = RightToLeft.No;
            CardName.Size = new Size(45, 19);
            CardName.TabIndex = 2;
            CardName.Text = "Name";
            CardName.TextAlign = ContentAlignment.TopCenter;
            // 
            // addCard
            // 
            addCard.Location = new Point(158, 308);
            addCard.Name = "addCard";
            addCard.Size = new Size(22, 23);
            addCard.TabIndex = 3;
            addCard.Text = "+";
            addCard.UseVisualStyleBackColor = true;
            // 
            // removeCard
            // 
            removeCard.Location = new Point(52, 308);
            removeCard.Name = "removeCard";
            removeCard.Size = new Size(22, 23);
            removeCard.TabIndex = 4;
            removeCard.Text = "-";
            removeCard.UseVisualStyleBackColor = true;
            // 
            // Rarity
            // 
            Rarity.AutoSize = true;
            Rarity.Location = new Point(91, 241);
            Rarity.Name = "Rarity";
            Rarity.Size = new Size(37, 15);
            Rarity.TabIndex = 5;
            Rarity.Text = "Rarity";
            Rarity.TextAlign = ContentAlignment.TopCenter;
            // 
            // marketPrice
            // 
            marketPrice.AutoSize = true;
            marketPrice.Location = new Point(91, 256);
            marketPrice.Name = "marketPrice";
            marketPrice.Size = new Size(70, 15);
            marketPrice.TabIndex = 6;
            marketPrice.Text = "MarketPrice";
            marketPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // LowPrice
            // 
            LowPrice.AutoSize = true;
            LowPrice.Location = new Point(91, 271);
            LowPrice.Name = "LowPrice";
            LowPrice.Size = new Size(55, 15);
            LowPrice.TabIndex = 7;
            LowPrice.Text = "LowPrice";
            LowPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // HighPrice
            // 
            HighPrice.AutoSize = true;
            HighPrice.Location = new Point(91, 286);
            HighPrice.Name = "HighPrice";
            HighPrice.Size = new Size(59, 15);
            HighPrice.TabIndex = 8;
            HighPrice.Text = "HighPrice";
            HighPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // CardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
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
            Name = "CardView";
            Size = new Size(242, 340);
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
