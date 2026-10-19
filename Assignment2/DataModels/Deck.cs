namespace Assignment2.DataModels
{
    public interface IDeck
    {
        //Deck interface, made an interface as implementation might change depending on the deck
        public float CalculateDeckPrice();

        public float CalculateDeckPriceLow();
        public float CalculateDeckPriceHigh();

        public Dictionary<string, int> ReturnDeckStats();
        public void SaveDeckList();
    }
}
