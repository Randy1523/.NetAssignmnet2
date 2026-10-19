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
    public partial class PokemonDecklists : Form
    {

        List<PokemonDeck> decks;
        public PokemonDecklists()
        {
            InitializeComponent();

            decks = FileManager.LoadPokemonDecks();

            LoadDecks(decks);
        }

        public void LoadDecks(List<PokemonDeck> decks)
        {
            DecklistPanel.Controls.Clear();

            DecklistPanel.SuspendLayout();

            foreach (PokemonDeck deck in decks)
            {
                DeckView deckView = new DeckView();
                deckView.SetDeckCode(deck.deckID);
                deckView.setImage(deck.Cards.Keys.First().ImageURL);

                DecklistPanel.Controls.Add(deckView);

                deckView.DoubleClicked += (s, e) =>
                {
                    ViewPokemonList create = new ViewPokemonList(deck);
                    create.Show();
                    this.Close();
                };
            }

            DecklistPanel.ResumeLayout(true);
        }
    }
}
