using Assignment2.DataModels;
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
    public partial class CreateDecklistMTG : Form
    {
        public CreateDecklistMTG()
        {
            InitializeComponent();
            //List<MagicCard> cards = FileManager.LoadMagicCards();
            //LoadCards(cards);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }


        //Function to load cards.
        private void LoadCards(List<MagicCard> cards)
        {
            CardContainer.Controls.Clear();
            
            foreach(Card card in cards)
            {
                CardView cardView = new CardView();
                CardContainer.Controls.Add(cardView);
                cardView.setDetails(card);
            }
        }

        private void FilterCards()
        {

        }
    }
}
