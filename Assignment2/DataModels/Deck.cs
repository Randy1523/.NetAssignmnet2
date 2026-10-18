using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public interface Deck
    {

        public float CalculateDeckPrice();

        public bool CheckDeck();

        //Will change the return type later once I better figure out which it is
        public void ReturnDeckStats();

        public void SaveDeckList();


    }
}
