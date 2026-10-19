namespace Assignment2.DataModels
{
    public class PokemonDeck : IDeck
    {
        public Dictionary<PokemonCard, int> Cards;
        public int deckID;
        public int DeckCount;

        public PokemonDeck(int deckID)
        {
            Cards = new Dictionary<PokemonCard, int>();
            DeckCount = 0;
            this.deckID = deckID;
        }

        public PokemonDeck()
        {
            Cards = new Dictionary<PokemonCard, int>();
            DeckCount = 0;
            deckID = Utils.GenerateDeckID();
        }

       
        public float CalculateDeckPrice()
        {
            float price = 0;

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {
                if (card.Key.MarketPrice > 0)
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

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {

                price += card.Key.LowPrice * card.Value;

            }

            return price;
        }

        public float CalculateDeckPriceHigh()
        {

            float price = 0;

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {

                price += card.Key.HighPrice * card.Value;

            }

            return price;
        }

        //Not sure if we're gonna have time to implement this
        public bool CheckDeck()
        {
            return false;
        }


        
        public Dictionary<string,int> ReturnDeckStats()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {
                if (!stats.Keys.Contains(card.Key.CardType))
                {
                    stats.Add(card.Key.CardType, card.Value);
                }
                else
                {
                    stats[card.Key.CardType] += card.Value;
                }

                if(card.Key.Stage != null && !card.Key.Stage.Equals(""))
                {
                    if (!stats.Keys.Contains(card.Key.Stage))
                    {
                        stats.Add(card.Key.Stage, card.Value);
                    }
                    else
                    {
                        stats[card.Key.Stage] += card.Value;
                    }
                }
            }

            return stats;
        }

        public void SaveDeckList()
        {
            string path = $"../../../Data/LocalDecks/Pokemon/{deckID}.txt";

            FileManager.Overwrite(path);

            FileManager.AppendToFile(path, deckID.ToString());

            foreach (KeyValuePair<PokemonCard, int> card in Cards)
            {
                string text = $"{card.Key.ProductID}|{card.Key.Foiling}|{card.Key.Name}|{card.Value}|Group: {card.Key.GroupID}";
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

        public void AddCard(PokemonCard card, int i)
        {
            if (card.GetType() == typeof(PokemonCard))
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
