namespace Assignment2.DataModels
{
    public class MagicDeck : IDeck
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

        public MagicDeck(int code)
        {
            Cards = new Dictionary<MagicCard, int>();
            DeckCount = 0;
            deckID = code;
        }

        //Caculates deck price
        public float CalculateDeckPrice()
        {

            float price = 0;

            foreach (KeyValuePair<MagicCard, int> card in Cards)
            {
                if(card.Key.MarketPrice > 0)
                {
                    price += card.Key.MarketPrice * card.Value;
                }
                else
                {
                    price += card.Key.LowPrice * card.Value;
                }
                

            }

            return price;
        }

        public float CalculateDeckPriceLow()
        {

            float price = 0;

            foreach (KeyValuePair<MagicCard, int> card in Cards)
            {
                
                 price += card.Key.LowPrice * card.Value;
               
            }

            return price;
        }

        public float CalculateDeckPriceHigh()
        {

            float price = 0;

            foreach (KeyValuePair<MagicCard, int> card in Cards)
            {

                price += card.Key.HighPrice * card.Value;

            }

            return price;
        }

        //Will later be used to check legality of deck, can be cut if we don't see it being useful
        public bool CheckDeck()
        {

            return false;
        }

        //To return stats of deck such as colour or type distributions and so on
        public Dictionary<string, int> ReturnDeckStats() { 
            Dictionary<string, int> stats = new Dictionary<string, int>();
            
            foreach(KeyValuePair<MagicCard,int> card in Cards)
            {
                if (!stats.Keys.Contains(card.Key.CardType))
                {
                    stats.Add(card.Key.CardType, card.Value);
                }
                else
                {
                    stats[card.Key.CardType] += card.Value;
                }
            }

            return stats;

        }

        //Fucntions to add and remove cards.
        public void AddCard(MagicCard card)
        {
            if (card.GetType() == typeof(MagicCard))
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

        public void AddCard(MagicCard card, int i)
        {
            if (card.GetType() == typeof(MagicCard))
            {
                if (!Cards.ContainsKey(card))
                {

                    Cards.Add(card, i);
                    DeckCount += i;

                }
                else
                {
                    Cards[card] += i;
                    DeckCount += i;
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
                string text = $"{card.Key.ProductID}|{card.Key.Rarity}|{card.Key.Name}|{card.Value}|Group: {card.Key.GroupID}";
                FileManager.AppendToFile(path, text);

            }
        }
    }
}
