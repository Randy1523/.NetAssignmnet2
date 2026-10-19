namespace Assignment2.Forms
{
    partial class ViewPokemonList
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
            StatsButton = new Button();
            HighPrice = new Label();
            LowPrice = new Label();
            MarketPrice = new Label();
            DeckCount = new Label();
            CardViewPanel = new FlowLayoutPanel();
            Edit = new Button();
            SuspendLayout();
            // 
            // StatsButton
            // 
            StatsButton.Font = new Font("Segoe UI", 20F);
            StatsButton.Location = new Point(1081, 674);
            StatsButton.Name = "StatsButton";
            StatsButton.Size = new Size(148, 52);
            StatsButton.TabIndex = 14;
            StatsButton.Text = "View Stats";
            StatsButton.UseVisualStyleBackColor = true;
            StatsButton.Click += StatsButton_Click;
            // 
            // HighPrice
            // 
            HighPrice.AutoSize = true;
            HighPrice.Font = new Font("Segoe UI", 18F);
            HighPrice.Location = new Point(582, 686);
            HighPrice.Name = "HighPrice";
            HighPrice.Size = new Size(103, 32);
            HighPrice.TabIndex = 13;
            HighPrice.Text = "High: $0";
            // 
            // LowPrice
            // 
            LowPrice.AutoSize = true;
            LowPrice.Font = new Font("Segoe UI", 18F);
            LowPrice.Location = new Point(404, 686);
            LowPrice.Name = "LowPrice";
            LowPrice.Size = new Size(94, 32);
            LowPrice.TabIndex = 12;
            LowPrice.Text = "Low: $0";
            // 
            // MarketPrice
            // 
            MarketPrice.AutoSize = true;
            MarketPrice.Font = new Font("Segoe UI", 18F);
            MarketPrice.Location = new Point(213, 686);
            MarketPrice.Name = "MarketPrice";
            MarketPrice.Size = new Size(127, 32);
            MarketPrice.TabIndex = 11;
            MarketPrice.Text = "Market: $0";
            // 
            // DeckCount
            // 
            DeckCount.AutoSize = true;
            DeckCount.Font = new Font("Segoe UI", 18F);
            DeckCount.Location = new Point(12, 686);
            DeckCount.Name = "DeckCount";
            DeckCount.Size = new Size(195, 32);
            DeckCount.TabIndex = 10;
            DeckCount.Text = "Card Count: 0/60";
            // 
            // CardViewPanel
            // 
            CardViewPanel.AutoScroll = true;
            CardViewPanel.Location = new Point(12, 12);
            CardViewPanel.Name = "CardViewPanel";
            CardViewPanel.Size = new Size(1339, 656);
            CardViewPanel.TabIndex = 9;
            // 
            // Edit
            // 
            Edit.Font = new Font("Segoe UI", 20F);
            Edit.Location = new Point(1235, 674);
            Edit.Name = "Edit";
            Edit.Size = new Size(116, 52);
            Edit.TabIndex = 8;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // ViewPokemonList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 740);
            Controls.Add(StatsButton);
            Controls.Add(HighPrice);
            Controls.Add(LowPrice);
            Controls.Add(MarketPrice);
            Controls.Add(DeckCount);
            Controls.Add(CardViewPanel);
            Controls.Add(Edit);
            Name = "ViewPokemonList";
            Text = "ViewPokemonList";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StatsButton;
        private Label HighPrice;
        private Label LowPrice;
        private Label MarketPrice;
        private Label DeckCount;
        private FlowLayoutPanel CardViewPanel;
        private Button Edit;
    }
}