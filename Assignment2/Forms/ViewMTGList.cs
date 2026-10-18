using Assignment2.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2.Forms
{
    public partial class ViewMTGList : Form
    {
        MagicDeck Deck;
        public ViewMTGList(MagicDeck deck)
        {
            InitializeComponent();
            Deck = deck;

            LoadCards(Deck);
        }

        //WIP
        private void LoadCards(MagicDeck deck)
        {
            CardViewPanel.Controls.Clear();
            CardViewPanel.SuspendLayout();

            foreach (KeyValuePair<MagicCard, int> card in Deck.Cards)
            {
                CardViewer cardView = new CardViewer();
                cardView.setDetails(card.Key.ImageURL, card.Value, card.Key.Name, card.Key.Rarity, card.Key.MarketPrice);

                CardViewPanel.Controls.Add(cardView);
            }
            CardViewPanel.ResumeLayout(true);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            CreateDecklistMTG form = new CreateDecklistMTG(Deck);
            form.Show();
            this.Close();
        }
    }
}
