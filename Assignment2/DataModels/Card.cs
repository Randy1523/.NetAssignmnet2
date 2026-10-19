namespace Assignment2.DataModels
{
    public abstract class Card
    {
        public int ProductID { get; init; }
        public int GroupID { get; init; }
        public int CategoryID { get; init; }
        public string Name { get; init; }
        public string ImageURL { get; init; }
        public string CardType { get; init; }
        public string Rarity { get; init; }
        public float MarketPrice { get; init; }
        public float LowPrice { get; init; }
        public float HighPrice { get; init; }

        public Card(Dictionary<string, string> data)
        {
            ProductID = int.Parse(data["productId"]);
            GroupID = int.Parse(data["groupId"]);
            CategoryID = int.Parse(data["categoryId"]);
            Name = data["name"];
            ImageURL = data["imageUrl"];
            CardType = string.Empty;
            Rarity = string.Empty;
            MarketPrice = string.IsNullOrEmpty(data["marketPrice"]) ? 0 : float.Parse(data["marketPrice"]);
            LowPrice = string.IsNullOrEmpty(data["lowPrice"]) ? 0 : float.Parse(data["lowPrice"]);
            HighPrice = string.IsNullOrEmpty(data["highPrice"]) ? 0 : float.Parse(data["highPrice"]);
        }
    }
}
