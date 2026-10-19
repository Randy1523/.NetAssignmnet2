namespace Assignment2.DataModels
{
    public class MagicCard : Card
    {
        public static MagicCardList Cards { get; } = new();

        public string CardNumber { get; init; }

        public MagicCard(Dictionary<string, string> data) : base(data)
        {
            CardType = data["extSubType"];
            Rarity = data["subTypeName"];
            CardNumber = data["extNumber"];
        }
    }

    public class MagicCardList : CardList<(int ProductID, string Rarity), MagicCard>
    {
        protected override string PathFromDataDirectory => "Magic";
        protected override string[] HeadersToCheck => ["extNumber", "subTypeName", "imageUrl", "extSubType"];

        protected override MagicCard? ProcessCardData(Dictionary<string, string> data)
        {
            if (string.IsNullOrEmpty(data["extNumber"])) return null;
            return new MagicCard(data);
        }

        protected override (int, string) Key(MagicCard card) => (card.ProductID, card.Rarity);
    }
}
