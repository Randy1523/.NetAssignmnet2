namespace Assignment2.DataModels
{
    public class PokemonCard : Card
    {
        public static PokemonCardList Cards { get; } = new();

        public string Foiling { get; init; }
        public string CardNumber { get; init; }
        public string? Stage { get; init; }

        public PokemonCard(Dictionary<string, string> data) : base(data)
        {
            CardType = data["extCardType"];
            Rarity = data["extRarity"];
            Foiling = data["subTypeName"];
            CardNumber = data["extNumber"];
            if (!string.IsNullOrEmpty(data["extStage"])) Stage = data["extStage"];
        }
    }

    public class PokemonCardList : CardList<(int ProductID, string Foiling), PokemonCard>
    {
        protected override string PathFromDataDirectory => "Pokemon";
        protected override string[] HeadersToCheck => ["extNumber", "subTypeName", "imageUrl", "extCardType", "extRarity", "extStage"];

        protected override PokemonCard? ProcessCardData(Dictionary<string, string> data)
        {
            if (string.IsNullOrEmpty(data["extNumber"])) return null;
            return new PokemonCard(data);
        }

        protected override (int, string) Key(PokemonCard card) => (card.ProductID, card.Foiling);
    }
}
