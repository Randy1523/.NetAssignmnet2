using Assignment2.DataModels;
using Microsoft.VisualBasic.FileIO;

namespace Assignment2
{
    public static class FileManager
    {
        public static IEnumerable<Dictionary<string, string>> LoadCardData(string pathFromDataDirectory, string[] headersToCheck)
        {
            List<Dictionary<string, string>> result = [];
            foreach (string filename in Directory.GetFiles($"../../../Data/{pathFromDataDirectory}/", "*.csv"))
            {
                using var parser = new TextFieldParser(filename);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                string[]? headers = parser.ReadFields();
                if (headers == null) continue;

                bool skipCurrentFile = false;
                foreach (string s in headersToCheck)
                {
                    if (!headers.Contains(s)) skipCurrentFile = true;
                }
                if (skipCurrentFile) continue;

                while (!parser.EndOfData)
                {
                    string[]? fields = parser.ReadFields();
                    if (fields == null) continue;
                    result.Add(headers.Zip(fields).ToDictionary());
                }
            }
            return result;
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


        public static List<MagicDeck> LoadMagicDecks()
        {
            List<MagicDeck> decks = [];

            string[] paths = Directory.GetFiles("../../../Data/LocalDecks/Magic/", "*.txt");

            foreach (string path in paths)
            {


                string[] lines = File.ReadAllLines(path);
                MagicDeck deck = new(Int32.Parse(lines[0]));

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] split = lines[i].Split('|');

                    MagicCard card = MagicCard.Cards.Get((int.Parse(split[0]), split[1])) ?? throw new InvalidOperationException("Card from loaded deck not found in database");

                    deck.AddCard(card, Int32.Parse(split[3]));
                }

                decks.Add(deck);

            }

            return decks;
        }

        public static List<PokemonDeck> LoadPokemonDecks()
        {
            List<PokemonDeck> decks = [];

            string[] paths = Directory.GetFiles("../../../Data/LocalDecks/Pokemon/", "*.txt");

            foreach (string path in paths)
            {


                string[] lines = File.ReadAllLines(path);
                PokemonDeck deck = new(Int32.Parse(lines[0]));

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] split = lines[i].Split('|');

                    PokemonCard card = PokemonCard.Cards.Get((int.Parse(split[0]), split[1])) ?? throw new InvalidOperationException("Card from loaded deck not found in database");

                    deck.AddCard(card, Int32.Parse(split[3]));
                }

                decks.Add(deck);

            }

            return decks;
        }
    }
}

