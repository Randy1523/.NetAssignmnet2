using System.Runtime.CompilerServices;

namespace Assignment2.DataModels
{
    public abstract class CardList<TKey, TCard> where TKey : ITuple where TCard : Card
    {
        private Dictionary<TKey, TCard> Dict { get; } = [];

        public List<TCard> List => [.. Dict.Values];

        public TCard? Get(TKey key)
        {
            return Dict.GetValueOrDefault(key);
        }

        public void InitializeCards()
        {
            Dict.Clear();
            IEnumerable<TCard> cards = FileManager.LoadCardData(PathFromDataDirectory, HeadersToCheck).Select(ProcessCardData).OfType<TCard>();
            foreach (TCard card in cards)
            {
                Dict.Add(Key(card), card);
            }
        }

        protected abstract string PathFromDataDirectory { get; }
        protected abstract string[] HeadersToCheck { get; }

        protected abstract TCard? ProcessCardData(Dictionary<string, string> data);

        protected abstract TKey Key(TCard card);
    }
}
