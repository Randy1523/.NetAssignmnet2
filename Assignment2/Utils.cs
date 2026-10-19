namespace Assignment2
{
    public class Utils
    {
        private static readonly Random rnd = new();

        //RNG for deck codes
        public static int GenerateDeckID() => rnd.Next(1, 99999);

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

        //simple downoad for updating the prices of cards.
        public static void updatePricing()
        {

        }

        //update tourney data (?)
    }
}
