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
            Edit = new Button();
            CardViewPanel = new FlowLayoutPanel();
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
            // ViewMTGList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1363, 738);
            Controls.Add(CardViewPanel);
            Controls.Add(Edit);
            Name = "ViewMTGList";
            Text = "ViewMTGList";
            ResumeLayout(false);
        }

        #endregion

        private Button Edit;
        private FlowLayoutPanel CardViewPanel;
    }
}