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
            MagicBackImage = new PictureBox();
            PokemonBackImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)MagicBackImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PokemonBackImage).BeginInit();
            SuspendLayout();
            // 
            // selectPokemon
            // 
            selectPokemon.Location = new Point(484, 325);
            selectPokemon.Name = "selectPokemon";
            selectPokemon.Size = new Size(130, 49);
            selectPokemon.TabIndex = 0;
            selectPokemon.Text = "Pokemon";
            selectPokemon.UseVisualStyleBackColor = true;
            selectPokemon.Click += selectPokemon_Click;
            // 
            // selectMTG
            // 
            selectMTG.Location = new Point(144, 325);
            selectMTG.Name = "selectMTG";
            selectMTG.Size = new Size(130, 49);
            selectMTG.TabIndex = 1;
            selectMTG.Text = "Magic: The Gathering";
            selectMTG.UseVisualStyleBackColor = true;
            selectMTG.Click += selectMTG_Click;
            // 
            // MagicBackImage
            // 
            MagicBackImage.Location = new Point(114, 70);
            MagicBackImage.Name = "MagicBackImage";
            MagicBackImage.Size = new Size(207, 249);
            MagicBackImage.SizeMode = PictureBoxSizeMode.Zoom;
            MagicBackImage.TabIndex = 2;
            MagicBackImage.TabStop = false;
            // 
            // PokemonBackImage
            // 
            PokemonBackImage.ImageLocation = "..\\..\\Data\\Images\\PokemonCardBack.jpg";
            PokemonBackImage.Location = new Point(456, 70);
            PokemonBackImage.Name = "PokemonBackImage";
            PokemonBackImage.Size = new Size(207, 249);
            PokemonBackImage.SizeMode = PictureBoxSizeMode.Zoom;
            PokemonBackImage.TabIndex = 3;
            PokemonBackImage.TabStop = false;
            // 
            // TCGSelectCreate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PokemonBackImage);
            Controls.Add(MagicBackImage);
            Controls.Add(selectMTG);
            Controls.Add(selectPokemon);
            Name = "TCGSelectCreate";
            Text = "Select your TCG";
            ((System.ComponentModel.ISupportInitialize)MagicBackImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)PokemonBackImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button selectPokemon;
        private Button selectMTG;
        private PictureBox MagicBackImage;
        private PictureBox PokemonBackImage;
    }
}