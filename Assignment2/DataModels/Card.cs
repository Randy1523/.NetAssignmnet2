using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public abstract class Card
    {
        public string Name { get; set; }
        public string ProductID { get; set; }
        public string ImageURl {  get; set; }
        
        public int GroupID { get; set; }

        public int CategoryID { get; set; }

        public string CardType { get; set; }

        public float MarketPrice { get; set; }

        public float LowPrice { get; set; }

        public float HighPrice { get; set; }

    }
}
