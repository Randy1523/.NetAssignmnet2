using Assignment2.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Assignment2
{
    public class FileManager
    {
        //public static List<MagicCard> LoadMagicCards()
        //{
        //    List<MagicCard> cards = new List<MagicCard>();

        //    string path = "../../../Data/Magic/10thEditionProductsAndPrices.csv";

        //    using var parser = new TextFieldParser(path);

        //    parser.TextFieldType = FieldType.Delimited;

        //    parser.SetDelimiters(",");

        //    parser.HasFieldsEnclosedInQuotes = true;

        //    string[] headers = parser.ReadFields();

        //    while (!parser.EndOfData)
        //    {
        //        string[]? fields = parser.ReadFields();
        //        if (!fields[10].Equals("") && fields != null) {
        //            if (fields[16].Equals("")){
        //                fields[16] = "0";
        //            }
        //            cards.Add(new MagicCard(fields[1], fields[0], fields[3], Int32.Parse(fields[5]), Int32.Parse(fields[4]),
        //                                    fields[11], float.Parse(fields[16]), float.Parse(fields[13]), float.Parse(fields[15]), fields[18], fields[10]));

        //            //Console.WriteLine(string.Join(" | ", fields));
        //        }
        //    }

        //    return cards;
        //}

    }
}
