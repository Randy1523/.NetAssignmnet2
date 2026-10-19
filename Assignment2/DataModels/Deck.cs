using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public interface Deck
    {

        public float CalculateDeckPrice();

        public float CalculateDeckPriceLow();
        public float CalculateDeckPriceHigh();

        public Dictionary<string, int> ReturnDeckStats();
        public bool CheckDeck();
        public void SaveDeckList();


    }
}
