using Assignment2.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignment2
{
    public class Utils
    {

        private static readonly Random rnd = new Random();

        public static Dictionary<Pair, MagicCard> CreateMagicLookup(List<MagicCard> cards){

            Dictionary<Pair, MagicCard> LookupTable = new Dictionary<Pair, MagicCard>();
            
            foreach(MagicCard card in cards)
            {
                LookupTable.Add(new Pair(card.ProductID, card.Rarity), card);
            }

            return LookupTable;
        
        }

        public static int GenerateDeckID()
        {

            return rnd.Next(1,99999);
        }
        



    }

    //Pair to have a pair of items.
    public struct Pair
    {
        public string X { get;}
        public string Y { get;}

        public Pair(string x, string y)
        {
            X = x;

            Y = y;
        }
    }
}
