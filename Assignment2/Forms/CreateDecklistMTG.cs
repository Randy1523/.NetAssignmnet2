using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class CreateDecklistMTG : Form
    {
        public CreateDecklistMTG()
        {
            InitializeComponent();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LoadCards(List<Card> cards)
        {
            CardContainer.Controls.Clear();
        }

        private void FilterCards()
        {

        }
    }
}
