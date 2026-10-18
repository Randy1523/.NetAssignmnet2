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
    public partial class MTGDecklists : Form
    {
        List<MagicDeck> decks;
        public MTGDecklists()
        {
            InitializeComponent();
            decks = FileManager.LoadMagicDecks();

            LoadDecks(decks);
        }

        public void LoadDecks(List<MagicDeck> decks)
        {
            DecklistPanel.Controls.Clear();

            DecklistPanel.SuspendLayout();

            foreach (MagicDeck deck in decks)
            {
                DeckView deckView = new DeckView();
                deckView.SetDeckCode(deck.deckID);
                deckView.setImage(deck.Cards.Keys.First().ImageURL);

                DecklistPanel.Controls.Add(deckView);

                deckView.DoubleClicked += (s, e) =>
                {
                    ViewMTGList create = new ViewMTGList(deck);
                    create.Show();
                    this.Close(); 
                };
            }

            DecklistPanel.ResumeLayout(true);
        }
    }
}
