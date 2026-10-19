namespace Assignment2.Forms
{
    partial class CardViewer
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
            CardImage = new PictureBox();
            Quant = new Label();
            CardRarity = new Label();
            MarketPrice = new Label();
            CardName = new Label();
            ((System.ComponentModel.ISupportInitialize)CardImage).BeginInit();
            SuspendLayout();
            // 
            // CardImage
            // 
            CardImage.Location = new Point(3, 3);
            CardImage.Name = "CardImage";
            CardImage.Size = new Size(209, 233);
            CardImage.SizeMode = PictureBoxSizeMode.Zoom;
            CardImage.TabIndex = 0;
            CardImage.TabStop = false;
            // 
            // Quant
            // 
            Quant.AutoSize = true;
            Quant.Font = new Font("Segoe UI", 12F);
            Quant.Location = new Point(96, 303);
            Quant.Name = "Quant";
            Quant.Size = new Size(19, 21);
            Quant.TabIndex = 1;
            Quant.Text = "0";
            // 
            // CardRarity
            // 
            CardRarity.Anchor = AnchorStyles.Top;
            CardRarity.AutoSize = true;
            CardRarity.Font = new Font("Segoe UI", 12F);
            CardRarity.Location = new Point(9, 279);
            CardRarity.Name = "CardRarity";
            CardRarity.Size = new Size(51, 21);
            CardRarity.TabIndex = 2;
            CardRarity.Text = "Rarity";
            CardRarity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MarketPrice
            // 
            MarketPrice.Anchor = AnchorStyles.Top;
            MarketPrice.AutoSize = true;
            MarketPrice.Font = new Font("Segoe UI", 12F);
            MarketPrice.Location = new Point(9, 258);
            MarketPrice.Name = "MarketPrice";
            MarketPrice.Size = new Size(59, 21);
            MarketPrice.TabIndex = 3;
            MarketPrice.Text = "Market";
            MarketPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CardName
            // 
            CardName.Anchor = AnchorStyles.Top;
            CardName.AutoSize = true;
            CardName.Font = new Font("Segoe UI", 10F);
            CardName.Location = new Point(9, 239);
            CardName.Name = "CardName";
            CardName.Size = new Size(45, 19);
            CardName.TabIndex = 4;
            CardName.Text = "Name";
            CardName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CardViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CardName);
            Controls.Add(MarketPrice);
            Controls.Add(CardRarity);
            Controls.Add(Quant);
            Controls.Add(CardImage);
            Name = "CardViewer";
            Size = new Size(215, 324);
            ((System.ComponentModel.ISupportInitialize)CardImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox CardImage;
        private Label Quant;
        private Label CardRarity;
        private Label MarketPrice;
        private Label CardName;
    }
}
