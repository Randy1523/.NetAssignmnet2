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

        public static List<PokemonCard> PokemonCards;

        public static Dictionary<Pair, PokemonCard> PokemonCardLookup;

        //Test Function to test loading of cards.
        public static List<MagicCard> LoadMagicCards()
        {
            List<MagicCard> cards = new List<MagicCard>();

            string[] paths = Directory.GetFiles("../../../Data/Magic/", "*.csv");
            foreach(string path in paths) { 
                using var parser = new TextFieldParser(path);

                parser.TextFieldType = FieldType.Delimited;

                parser.SetDelimiters(",");

                parser.HasFieldsEnclosedInQuotes = true;

                string[] headers = parser.ReadFields();

                int fieldNum1 = headers.IndexOf("name");
                int fieldNum2 = headers.IndexOf("productId");
                int fieldNum3 = headers.IndexOf("imageUrl");
                int fieldNum4 = headers.IndexOf("groupId");
                int fieldNum5 = headers.IndexOf("categoryId");
                int fieldNum6 = headers.IndexOf("extSubType");
                int fieldNum7 = headers.IndexOf("marketPrice");
                int fieldNum8 = headers.IndexOf("lowPrice");
                int fieldNum9 = headers.IndexOf("highPrice");
                int fieldNum10 = headers.IndexOf("subTypeName");
                int fieldNum11 = headers.IndexOf("extNumber");

                if (fieldNum11 != -1 && fieldNum10 != -1 && fieldNum3 != -1 && fieldNum6 != -1)
                {
                    while (!parser.EndOfData)
                    {
                        string[]? fields = parser.ReadFields();
                        if (!fields[fieldNum11].Equals("") && fields != null)
                        {
                            if (fields[fieldNum7].Equals(""))
                            {
                                fields[fieldNum7] = "0";
                            }
                            cards.Add(new MagicCard(fields[fieldNum1], fields[fieldNum2], fields[fieldNum3], Int32.Parse(fields[fieldNum4]), Int32.Parse(fields[fieldNum5]),
                                                    fields[fieldNum6], float.Parse(fields[fieldNum7]), float.Parse(fields[fieldNum8]), float.Parse(fields[fieldNum9]),
                                                    fields[fieldNum10], fields[fieldNum11]));

                        }
                    }
                }
            }

                return cards;
        }

        //Reads all csvs in the Pokemon folder and generates a list from it.
        public static List<PokemonCard> LoadPokemonCards()
        {
            List<PokemonCard> cards = new List<PokemonCard>();

            string[] paths = Directory.GetFiles("../../../Data/Pokemon/", "*.csv");
            foreach (string path in paths)
            {
                using var parser = new TextFieldParser(path);

                parser.TextFieldType = FieldType.Delimited;

                parser.SetDelimiters(",");

                parser.HasFieldsEnclosedInQuotes = true;

                string[] headers = parser.ReadFields();

                int fieldNum1 = headers.IndexOf("name");
                int fieldNum2 = headers.IndexOf("productId");
                int fieldNum3 = headers.IndexOf("imageUrl");
                int fieldNum4 = headers.IndexOf("groupId");
                int fieldNum5 = headers.IndexOf("categoryId");
                int fieldNum6 = headers.IndexOf("extSubType");
                int fieldNum7 = headers.IndexOf("marketPrice");
                int fieldNum8 = headers.IndexOf("lowPrice");
                int fieldNum9 = headers.IndexOf("highPrice");
                int fieldNum10 = headers.IndexOf("subTypeName");
                int fieldNum11 = headers.IndexOf("extNumber");
                int fieldNum12 = headers.IndexOf("extRarity");
                int fieldNum13 = headers.IndexOf("extStage");

                if (fieldNum11 != -1 && fieldNum10 != -1 && fieldNum3 != -1 && fieldNum6 != -1 && fieldNum12 != -1 && fieldNum13 != -1) 
                {
                    while (!parser.EndOfData)
                    {
                        string[]? fields = parser.ReadFields();
                        if (!fields[fieldNum11].Equals("") && fields != null)
                        {
                            if (fields[fieldNum7].Equals(""))
                            {
                                fields[fieldNum7] = "0";
                            }
                            if (!fields[fieldNum13].Equals("")) { 
                                cards.Add(new PokemonCard(fields[fieldNum1], fields[fieldNum2], fields[fieldNum3], Int32.Parse(fields[fieldNum4]), Int32.Parse(fields[fieldNum5]),
                                                        fields[fieldNum6], float.Parse(fields[fieldNum7]), float.Parse(fields[fieldNum8]), float.Parse(fields[fieldNum9]),
                                                        fields[fieldNum10], fields[fieldNum11], fields[fieldNum12]));
                            }
                            else
                            {
                                cards.Add(new PokemonCard(fields[fieldNum1], fields[fieldNum2], fields[fieldNum3], Int32.Parse(fields[fieldNum4]), Int32.Parse(fields[fieldNum5]),
                                                        fields[fieldNum6], float.Parse(fields[fieldNum7]), float.Parse(fields[fieldNum8]), float.Parse(fields[fieldNum9]),
                                                        fields[fieldNum10], fields[fieldNum11], fields[fieldNum12], fields[fieldNum13]));
                            }

                        }
                    } 
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
