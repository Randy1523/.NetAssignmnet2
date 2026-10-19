using Assignment2.DataModels;

namespace Assignment2
{
    public class Utils
    {
        private static readonly Random rnd = new();

        //RNG for deck codes
        public static int GenerateDeckID() => rnd.Next(1, 99999);

        //Name filtering function
        public static List<MagicCard> FilterMagicCards(List<MagicCard> cards, string name)
        {
            List<MagicCard> filtered = [];

            if (name.Equals(""))
            {
                return cards;
            }

            foreach (MagicCard card in cards)
            {
                if (card.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    filtered.Add(card);
                }
            }

            return filtered;
        }

        //Function to filter for types in magic
        public static List<MagicCard> FilterMagicType(List<MagicCard> cards, string type)
        {
            List<MagicCard> filtered = [];

            if (type.Equals(""))
            {
                return cards;
            }

            foreach (MagicCard card in cards)
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
            List<PokemonCard> filtered = [];

            if (name.Equals(""))
            {
                return cards;
            }

            foreach (PokemonCard card in cards)
            {
                if (card.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    filtered.Add(card);
                }
            }

            return filtered;
        }

        public static List<PokemonCard> FilterPokemonType(List<PokemonCard> cards, string type)
        {
            List<PokemonCard> filtered = [];

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
            List<List<T>> pages = [];

            int index = 0;

            while (index < list.Count)
            {
                if (index + pageSize < list.Count)
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
}
