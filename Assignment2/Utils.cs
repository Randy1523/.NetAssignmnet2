using Assignment2.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment2
{
    public class Utils
    {

        private static readonly Random rnd = new Random();

        //These functions are used to create dictionaries to easier search cards by their product ID and rarity. They're pairs because
        //many cards share the same product id with differing rarity/foiling
        public static Dictionary<Pair, MagicCard> CreateMagicLookup(List<MagicCard> cards){

            Dictionary<Pair, MagicCard> LookupTable = new Dictionary<Pair, MagicCard>();
            
            foreach(MagicCard card in cards)
            {
                LookupTable.Add(new Pair(card.ProductID, card.Rarity), card);
            }

            return LookupTable;
        
        }

        public static Dictionary<Pair, PokemonCard> CreatePokemonLookup(List<PokemonCard> cards)
        {

            Dictionary<Pair, PokemonCard> LookupTable = new Dictionary<Pair, PokemonCard>();

            foreach (PokemonCard card in cards)
            {
                LookupTable.Add(new Pair(card.ProductID, card.Foiling), card);
            }

            return LookupTable;

        }

        //RNG for deck codes
        public static int GenerateDeckID()
        {

            return rnd.Next(1,99999);
        }

        //Name filtering function
        public static List<MagicCard> FilterMagicCards(List<MagicCard> cards, string name) 
        {
            List<MagicCard> filtered = new List<MagicCard>();

            if (name.Equals(""))
            {
                return cards;
            }

            foreach (MagicCard card in cards)
            {
                if (card.Name.ToLower().Contains(name.ToLower()))
                {
                    filtered.Add(card);
                }
            }

            return filtered;
        }

        //Function to filter for types in magic
        public static List<MagicCard> FilterMagicType(List<MagicCard> cards, string type)
        {
            List<MagicCard> filtered = new List<MagicCard>();
            
            if (type.Equals(""))
            {
                return cards;
            }

            foreach(MagicCard card in cards)
            {
                if (card.CardType.Contains(type))
                {
                    filtered.Add(card);
                }
            }

            return filtered;
        }

        public static List<PokemonCard> FilterPokemonCards(List<PokemonCard> cards, string name)
        {
            List<PokemonCard> filtered = new List<PokemonCard>();

            if (name.Equals(""))
            {
                return cards;
            }

            foreach (PokemonCard card in cards)
            {
                if (card.Name.ToLower().Contains(name.ToLower()))
                {
                    filtered.Add(card);
                }
            }

            return filtered;
        }

        public static List<PokemonCard> FilterPokemonType(List<PokemonCard> cards, string type)
        {
            List<PokemonCard> filtered = new List<PokemonCard>();

            if (type.Equals(""))
            {
                return cards;
            }

            foreach (PokemonCard card in cards)
            {
                if (card.CardType.Contains(type))
                {
                    filtered.Add(card);
                }
            }

            return filtered;
        }


        //Generic Function to convert lists into a list of a segmented lists.
        public static List<List<T>> ConvertToPages<T>(List<T> list, int pageSize)
        {
            List<List<T>> pages = new List<List<T>>();

            int index = 0;

            while(index < list.Count)
            {
                if(index + pageSize < list.Count)
                {
                    List<T> page = list.GetRange(index, pageSize);
                    pages.Add(page);
                }
                else
                {
                    List<T> page = list.GetRange(index, list.Count - index);
                    pages.Add(page);
                }

                index += pageSize;
            }

            return pages;
        }

    }

    //Pair to have a pair of items.
    public struct Pair
    {
        public string ProductID { get;}
        public string Rarity { get;}

        public Pair(string x, string y)
        {
            ProductID = x;

            Rarity = y;
        }
    }
}
