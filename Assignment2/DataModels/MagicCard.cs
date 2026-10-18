using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.DataModels
{
    public class MagicCard : Card
    {
        public required string CardID { get; set; }

        //public int Power { get; set; }

        //public int Toughness { get; set; }

        public MagicCard(string name, string productID, string imageURL, int groupID, int categoryID,
                         string type, float market, float low, float high, string rarity,string cardID) {

            Name = name;
            ProductID = productID;
            ImageURL = imageURL;
            GroupID = groupID;
            CategoryID = categoryID;
            CardType = type;
            MarketPrice = market;
            LowPrice = low;
            HighPrice = high;
            Rarity = rarity;
            this.cardID = cardID;

        }
    }
}
