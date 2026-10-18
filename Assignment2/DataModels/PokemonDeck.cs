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

        }

        public string PrintDeckList()
        {
            return "";
        }

        public float CalculateDeckPrice()
        {
            return 0;
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

        }

    }
}
