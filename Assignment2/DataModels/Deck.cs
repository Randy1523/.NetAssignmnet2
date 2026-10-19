namespace Assignment2.DataModels
{
    public interface IDeck
    {
        public float CalculateDeckPrice();

        public bool CheckDeck();

        //Will change the return type later once I better figure out which it is
        public void ReturnDeckStats();

        public void SaveDeckList();
    }
}
