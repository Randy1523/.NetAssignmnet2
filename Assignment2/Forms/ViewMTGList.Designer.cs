namespace Assignment2.Forms
{
    partial class ViewMTGList
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
            components = new System.ComponentModel.Container();
            Edit = new Button();
            CardViewPanel = new FlowLayoutPanel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            DeckCount = new Label();
            MarketPrice = new Label();
            LowPrice = new Label();
            HighPrice = new Label();
            StatsButton = new Button();
            SuspendLayout();
            // 
            // Edit
            // 
            Edit.Font = new Font("Segoe UI", 20F);
            Edit.Location = new Point(1235, 674);
            Edit.Name = "Edit";
            Edit.Size = new Size(116, 52);
            Edit.TabIndex = 0;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // CardViewPanel
            // 
            CardViewPanel.AutoScroll = true;
            CardViewPanel.Location = new Point(12, 12);
            CardViewPanel.Name = "CardViewPanel";
            CardViewPanel.Size = new Size(1339, 656);
            CardViewPanel.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // DeckCount
            // 
            DeckCount.AutoSize = true;
            DeckCount.Font = new Font("Segoe UI", 18F);
            DeckCount.Location = new Point(12, 686);
            DeckCount.Name = "DeckCount";
            DeckCount.Size = new Size(195, 32);
            DeckCount.TabIndex = 3;
            DeckCount.Text = "Card Count: 0/60";
            // 
            // MarketPrice
            // 
            MarketPrice.AutoSize = true;
            MarketPrice.Font = new Font("Segoe UI", 18F);
            MarketPrice.Location = new Point(213, 686);
            MarketPrice.Name = "MarketPrice";
            MarketPrice.Size = new Size(127, 32);
            MarketPrice.TabIndex = 4;
            MarketPrice.Text = "Market: $0";
            // 
            // LowPrice
            // 
            LowPrice.AutoSize = true;
            LowPrice.Font = new Font("Segoe UI", 18F);
            LowPrice.Location = new Point(404, 686);
            LowPrice.Name = "LowPrice";
            LowPrice.Size = new Size(94, 32);
            LowPrice.TabIndex = 5;
            LowPrice.Text = "Low: $0";
            // 
            // HighPrice
            // 
            HighPrice.AutoSize = true;
            HighPrice.Font = new Font("Segoe UI", 18F);
            HighPrice.Location = new Point(582, 686);
            HighPrice.Name = "HighPrice";
            HighPrice.Size = new Size(103, 32);
            HighPrice.TabIndex = 6;
            HighPrice.Text = "High: $0";
            // 
            // StatsButton
            // 
            StatsButton.Font = new Font("Segoe UI", 20F);
            StatsButton.Location = new Point(1081, 674);
            StatsButton.Name = "StatsButton";
            StatsButton.Size = new Size(148, 52);
            StatsButton.TabIndex = 7;
            StatsButton.Text = "View Stats";
            StatsButton.UseVisualStyleBackColor = true;
            StatsButton.Click += StatsButton_Click;
            // 
            // ViewMTGList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1363, 738);
            Controls.Add(StatsButton);
            Controls.Add(HighPrice);
            Controls.Add(LowPrice);
            Controls.Add(MarketPrice);
            Controls.Add(DeckCount);
            Controls.Add(CardViewPanel);
            Controls.Add(Edit);
            Name = "ViewMTGList";
            Text = "ViewMTGList";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Edit;
        private FlowLayoutPanel CardViewPanel;
        private ContextMenuStrip contextMenuStrip1;
        private Label DeckCount;
        private Label MarketPrice;
        private Label LowPrice;
        private Label HighPrice;
        private Button StatsButton;
    }
}