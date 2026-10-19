using Assignment2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class TCGSelectCreate : Form
    {
        public TCGSelectCreate()
        {
            InitializeComponent();
            PokemonBackImage.Load("../../../Data/Images/PokemonCardBack.jpg");
            MagicBackImage.Load("../../../Data/Images/MagicCardBack.jpg");
        }

        private void selectMTG_Click(object sender, EventArgs e)
        {
            CreateDecklistMTG form = new CreateDecklistMTG();

            form.Show();
            this.Close();
        }

        private void selectPokemon_Click(object sender, EventArgs e)
        {
            CreateDeckListPokemon form = new CreateDeckListPokemon();

            form.Show();
            this.Close();
        }


    }
}
