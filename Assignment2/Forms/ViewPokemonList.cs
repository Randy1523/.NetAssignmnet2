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
    public partial class ViewPokemonList : Form
    {
        PokemonDeck Deck;
        public ViewPokemonList(PokemonDeck deck)
        {
            InitializeComponent();
            Deck = deck;
            LoadCards(Deck);

            DeckCount.Text = "Card Count:" + Deck.DeckCount.ToString() + "/60";
            MarketPrice.Text = $"Market: ${Math.Round(Deck.CalculateDeckPrice(), 2)}";
            HighPrice.Text = $"High: ${Math.Round(Deck.CalculateDeckPriceHigh(), 2)}";
            LowPrice.Text = $"Low: ${Math.Round(Deck.CalculateDeckPriceLow(), 2)}";
        }

        private void LoadCards(PokemonDeck deck)
        {
            CardViewPanel.Controls.Clear();
            CardViewPanel.SuspendLayout();

            foreach (KeyValuePair<PokemonCard, int> card in Deck.Cards)
            {
                CardViewer cardView = new CardViewer();
                cardView.setDetails(card.Key.ImageURL, card.Value, card.Key.Name, card.Key.Rarity, card.Key.MarketPrice);

                CardViewPanel.Controls.Add(cardView);
            }
            CardViewPanel.ResumeLayout(true);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            CreateDeckListPokemon form = new CreateDeckListPokemon(Deck);
            form.Show();
            this.Close();
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> stats = Deck.ReturnDeckStats();

            string statsString = "";

            foreach (KeyValuePair<string, int> stat in stats)
            {
                statsString += $"{stat.Key}: x{stat.Value} \n";
            }

            MessageBox.Show(statsString);
        }

 
    }
}
