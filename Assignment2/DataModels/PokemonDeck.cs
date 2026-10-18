using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.DataModels
{
    public class PokemonDeck : Deck
    {
        public Dictionary<PokemonCard, int> Cards;
        public int deckID;
        public int DeckCount;
         
        public PokemonDeck(int deckID)
        {

        }

        public PokemonDeck()
        {
            Cards = new Dictionary<PokemonCard, int>();
            DeckCount = 0;
            deckID = Utils.GenerateDeckID();
        }

        //All WIP
        public float CalculateDeckPrice()
        {
            float price = 0;

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {
                price += card.Key.MarketPrice * card.Value;

            }

            return price;
        }

        public bool CheckDeck()
        {
            return false;
        }

        public void ReturnDeckStats()
        {

        }

        public void SaveDeckList()
        {
            string path = $"../../../Data/LocalDecks/Pokemon/{deckID}.txt";

            FileManager.Overwrite(path);

            FileManager.AppendToFile(path, deckID.ToString());

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {
                string text = $"{card.Key.ProductID}|{card.Key.Rarity}|{card.Key.Name}|{card.Value}|Group: {card.Key.GroupID}";
                FileManager.AppendToFile(path, text);

            }
        }

        public void AddCard(PokemonCard card)
        {
            if (card.GetType() == typeof(PokemonCard))
            {
                if (!Cards.ContainsKey(card))
                {

                    Cards.Add(card, 1);
                    DeckCount++;

                }
                else
                {
                    Cards[card]++;
                    DeckCount++;
                }


            }
        }


        public void RemoveCard(PokemonCard card)
        {
            if (card.GetType() == typeof(PokemonCard))
            {
                if (Cards.ContainsKey(card))
                {
                    if (Cards[card] <= 1)
                    {
                        Cards.Remove(card);
                    }
                    else
                    {
                        Cards[card]--;
                    }

                    DeckCount--;
                }
            }
        }

        //Checks if a card is within already
        public bool Contains(PokemonCard card)
        {
            return Cards.ContainsKey(card);
        }

        public int CheckCard(PokemonCard card)
        {
            return Cards[card];
        }

    }
}
