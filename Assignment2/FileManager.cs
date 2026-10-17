using Assignment2.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Assignment2
{
    public class FileManager
    {

        //Static variables for all the cards so they don't have to be loaded everytime
        public static List<MagicCard> MagicCards;

        //Direct lookup table using productID and rarity as there are duplicate productIDs and setCoded cards only differing in Rarity
        public static Dictionary<Pair, MagicCard> MagicCardLookup;

        //Test Function to test loading of cards.
        public static List<MagicCard> LoadMagicCards()
        {
            List<MagicCard> cards = new List<MagicCard>();

            string path = "../../../Data/Magic/10thEditionProductsAndPrices.csv";

            using var parser = new TextFieldParser(path);

            parser.TextFieldType = FieldType.Delimited;

            parser.SetDelimiters(",");

            parser.HasFieldsEnclosedInQuotes = true;

            string[] headers = parser.ReadFields();

            while (!parser.EndOfData)
            {
                string[]? fields = parser.ReadFields();
                if (!fields[10].Equals("") && fields != null)
                {
                    if (fields[16].Equals(""))
                    {
                        fields[16] = "0";
                    }
                    cards.Add(new MagicCard(fields[1], fields[0], fields[3], Int32.Parse(fields[5]), Int32.Parse(fields[4]),
                                            fields[11], float.Parse(fields[16]), float.Parse(fields[13]), float.Parse(fields[15]), fields[18], fields[10]));

                }
            }

            return cards;
        }

        //Appends a line to a file and creates it if it doesn't exit.
        public static void AppendToFile(string path, string line) 
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            File.AppendAllText(path, line + "\n");
        }

        //Overwrites an existing file a blank start
        public static void Overwrite(string path) 
        {
            if (File.Exists(path)) 
            {
                File.WriteAllText(path, "");
            }
        }

    }
}
