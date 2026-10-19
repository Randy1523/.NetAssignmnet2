namespace Assignment2.Forms
{
    partial class OptionsForm
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
            UpdatePricing = new Button();
            SuspendLayout();
            // 
            // UpdatePricing
            // 
            UpdatePricing.AutoSize = true;
            UpdatePricing.Location = new Point(12, 12);
            UpdatePricing.Name = "UpdatePricing";
            UpdatePricing.Size = new Size(260, 25);
            UpdatePricing.TabIndex = 0;
            UpdatePricing.Text = "Update Pricing Data";
            UpdatePricing.UseVisualStyleBackColor = true;
            UpdatePricing.Click += UpdatePricing_Click;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(UpdatePricing);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "OptionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button UpdatePricing;
    }
}