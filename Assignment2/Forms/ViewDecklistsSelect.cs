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
    public partial class ViewDecklistsSelect : Form
    {
        public ViewDecklistsSelect()
        {
            InitializeComponent();
        }

        private void selectMTG_Click(object sender, EventArgs e)
        {
            MTGDecklists form = new MTGDecklists();
            form.Show();
            this.Close();   
        }

        private void selectPokemon_Click(object sender, EventArgs e)
        {

        }
    }
}
