namespace Assignment2.DataModels
{
    public interface IDeck
    {
        public float CalculateDeckPrice();

        public float CalculateDeckPriceLow();
        public float CalculateDeckPriceHigh();

        public Dictionary<string, int> ReturnDeckStats();
        public bool CheckDeck();
        public void SaveDeckList();
    }
}
