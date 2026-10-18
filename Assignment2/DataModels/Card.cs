using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public abstract class Card
    {
        public required string Name { get; set; }
        public required string ProductID { get; set; }
        public required string ImageURL {  get; set; }
        
        public int GroupID { get; set; }

        public int CategoryID { get; set; }

        public required string CardType { get; set; }

        public float MarketPrice { get; set; }

        public float LowPrice { get; set; }

        public float HighPrice { get; set; }

        public required string Rarity { get; set; }
    }
}
