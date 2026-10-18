namespace Assignment2
{
    partial class ViewDecklistsSelect
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
            selectMTG = new Button();
            selectPokemon = new Button();
            SuspendLayout();
            // 
            // selectMTG
            // 
            selectMTG.Location = new Point(155, 341);
            selectMTG.Name = "selectMTG";
            selectMTG.Size = new Size(130, 49);
            selectMTG.TabIndex = 3;
            selectMTG.Text = "Magic: The Gathering";
            selectMTG.UseVisualStyleBackColor = true;
            selectMTG.Click += selectMTG_Click;
            // 
            // selectPokemon
            // 
            selectPokemon.Location = new Point(495, 341);
            selectPokemon.Name = "selectPokemon";
            selectPokemon.Size = new Size(130, 49);
            selectPokemon.TabIndex = 2;
            selectPokemon.Text = "Pokemon";
            selectPokemon.UseVisualStyleBackColor = true;
            selectPokemon.Click += selectPokemon_Click;
            // 
            // ViewDecklistsSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(selectMTG);
            Controls.Add(selectPokemon);
            Name = "ViewDecklistsSelect";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button selectMTG;
        private Button selectPokemon;
    }
}