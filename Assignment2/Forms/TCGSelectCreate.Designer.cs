namespace Assignment2
{
    partial class TCGSelectCreate
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
            selectPokemon = new Button();
            selectMTG = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            selectPokemon.Location = new Point(484, 325);
            selectPokemon.Name = "button1";
            selectPokemon.Size = new Size(130, 49);
            selectPokemon.TabIndex = 0;
            selectPokemon.Text = "Pokemon";
            selectPokemon.UseVisualStyleBackColor = true;
            selectPokemon.Click += selectPokemon_Click;
            // 
            // button2
            // 
            selectMTG.Location = new Point(144, 325);
            selectMTG.Name = "button2";
            selectMTG.Size = new Size(130, 49);
            selectMTG.TabIndex = 1;
            selectMTG.Text = "Magic: The Gathering";
            selectMTG.UseVisualStyleBackColor = true;
            selectMTG.Click += selectMTG_Click;
            // 
            // TCGSelectCreate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(selectMTG);
            Controls.Add(selectPokemon);
            Name = "TCGSelectCreate";
            Text = "Select your TCG";
            ResumeLayout(false);
        }

        #endregion

        private Button selectPokemon;
        private Button selectMTG;
    }
}