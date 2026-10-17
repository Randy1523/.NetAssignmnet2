using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.DataModels
{
    internal class MagicDeck : Deck
    {

        public Dictionary<MagicCard, int> Cards;
        public int deckID;
        public int DeckCount;
        public MagicDeck()
        {
            Cards = new Dictionary<MagicCard, int>();
            DeckCount = 0;
            deckID = Utils.GenerateDeckID();
        }

        public string PrintDeckList() {
            
            
            
            return "";
        }

        //Caculates deck price
        public float CalculateDeckPrice() {

            float price = 0;

            foreach(KeyValuePair<MagicCard, int> card in Cards)
            {
                price += card.Key.MarketPrice * card.Value;

            }

            return price;
        }

        //Will later be used to check legality of deck, can be cut if we don't see it being useful
        public bool CheckDeck() {

            return false;
        }

        //To return stats of deck such as colour or type distributions and so on
        public void ReturnDeckStats() { 
        }

        //Fucntions to add and remove cards.
        public void AddCard(MagicCard card)
        {
           if(card.GetType() == typeof(MagicCard))
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
        
        
        public void RemoveCard(MagicCard card)
        {
            if (card.GetType() == typeof(MagicCard))
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
        public bool Contains(MagicCard card)
        {
            return Cards.ContainsKey(card);
        }

        public int CheckCard(MagicCard card)
        {
            return Cards[card];
        }

        //Writes the deck to a txt file in the local decks folder.
        public void SaveDeckList()
        {
            string path = $"../../../Data/LocalDecks/Magic/{deckID}.txt";

            FileManager.Overwrite(path);

            FileManager.AppendToFile(path, deckID.ToString());

            foreach (KeyValuePair<MagicCard, int> card in Cards)
            {
                string text = $"{card.Key.ProductID}|{card.Key.Rarity}|{card.Key.Name}|{card.Value}";
                FileManager.AppendToFile(path, text);

            }
        }
    }
}
