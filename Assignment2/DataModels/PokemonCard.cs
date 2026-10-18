using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.DataModels
{
    public class PokemonCard : Card
    {
        public string? Stage {get;set;}

        public string Foiling { get;set;}
        public string CardID {get;set;}
        public PokemonCard(string name, string productID, string imageURL, int groupID, int categoryID,
                         string type, float market, float low, float high, string foiling, string cardID, string rarity)
        {

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
            Foiling = foiling;
            CardID = cardID;

        }

        public PokemonCard(string name, string productID, string imageURL, int groupID, int categoryID,
                         string type, float market, float low, float high, string foiling, string cardID, string rarity, string stage)
        {

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
            Foiling = foiling;
            CardID = cardID;
            Stage = stage;
        }
    }
}
