using System.Data;
using Assignment2.DataModels;

namespace Assignment2.Forms
{
    public partial class CreateDeckListPokemon : Form
    {
        List<List<PokemonCard>> Pages;

        List<List<PokemonCard>> FilteredList;

        bool Filtering = false;
        PokemonDeck deck;
        int pageNum = 1;
        public CreateDeckListPokemon()
        {
            InitializeComponent();

            Pages = Utils.ConvertToPages(PokemonCard.Cards.List, 20);

            deck = new PokemonDeck();
            LoadCards(Pages[pageNum - 1]);
            PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
            DeckPrice.Text = "Market: $0.0";
        }

        public CreateDeckListPokemon(PokemonDeck deck)
        {
            InitializeComponent();

            Pages = Utils.ConvertToPages<PokemonCard>(PokemonCard.Cards.List, 20);

            this.deck = deck;
            LoadCards(Pages[pageNum - 1]);
            PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
            DeckPrice.Text = $"Market: ${Math.Round(deck.CalculateDeckPrice(),2)}";
            DeckCount.Text = $"{deck.DeckCount}/60";
        }
        private void LoadCards(List<PokemonCard> cards)
        {
            CardContainer.Controls.Clear();
            CardContainer.SuspendLayout();

            //For each card add a new cardview in each page. Each page holds 20 cards.
            foreach (PokemonCard card in cards)
            {
                CardView cardView = new CardView();
                CardContainer.Controls.Add(cardView);
                cardView.setDetails(card);
                cardView.SetRarity(card.Foiling);

                //Checks to see if the card is already in the deck and sets the quantity to match.
                if (deck.Contains(card))
                {
                    cardView.SetQuantity(deck.CheckCard(card));
                }

                //Anonymous methods attached to each controller for each deck. One for adding and removing a card respecitively
                cardView.AddClicked += (s, e) =>
                {
                    if (cardView.QuantityNum < 4 || cardView.Type.Contains("Basic"))
                    {
                        AddCardClick(cardView.productID, cardView.RarityString);
                        cardView.QuantityNum++;

                        cardView.SetQuantity(cardView.QuantityNum);
                    }
                };


                cardView.RemoveClicked += (s, e) =>
                {
                    if (cardView.QuantityNum > 0)
                    {
                        RemoveCardClick(cardView.productID, cardView.RarityString);
                        cardView.QuantityNum--;

                        cardView.SetQuantity(cardView.QuantityNum);
                    }
                };
            }
            CardContainer.ResumeLayout(true);
        }

        private void AddCardClick(string productID, string rarity)
        {
            deck.AddCard(PokemonCard.Cards.Get((int.Parse(productID), rarity))!);
            DeckCount.Text = deck.DeckCount.ToString() + "/" + "60";
            DeckPrice.Text = "Market: $" + Math.Round(deck.CalculateDeckPrice(), 2).ToString();
        }

        private void RemoveCardClick(string productID, string rarity)
        {
            deck.RemoveCard(PokemonCard.Cards.Get((int.Parse(productID), rarity))!);
            DeckCount.Text = deck.DeckCount.ToString() + "/" + "60";
            DeckPrice.Text = "Market: $" + Math.Round(deck.CalculateDeckPrice(), 2).ToString();
        }

        private void FilterCards()
        {
            if (SearchBox.Text.Equals("") && CardTypes.Text.Equals(""))
            {
                Filtering = false;
                pageNum = 1;
                LoadCards(Pages[pageNum - 1]);
                PageCount.Text = pageNum.ToString() + "/" + Pages.Count;
            }
            else
            {
                Filtering = true;
                pageNum = 1;

                FilteredList = Utils.ConvertToPages([.. (from card in PokemonCard.Cards.List where (string.IsNullOrWhiteSpace(SearchBox.Text) || card.Name.Contains(SearchBox.Text, StringComparison.CurrentCultureIgnoreCase)) && card.CardType.Contains(CardTypes.Text) select card)], 20);
                if (FilteredList.Count > 0)
                {
                    LoadCards(FilteredList[pageNum - 1]);
                    PageCount.Text = pageNum.ToString() + "/" + FilteredList.Count;
                }
                else
                {
                    FilteredList.Add(new List<PokemonCard>());
                    LoadCards(FilteredList[pageNum - 1]);
                    PageCount.Text = "0/0";
                }
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            FilterCards();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (!Filtering)
            {
                if (pageNum < Pages.Count)
                {
                    pageNum++;
                    LoadCards(Pages[pageNum - 1]);
                    PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
                }
            }
            else
            {
                if (pageNum < FilteredList.Count)
                {
                    pageNum++;
                    LoadCards(FilteredList[pageNum - 1]);
                    PageCount.Text = pageNum.ToString() + "/" + FilteredList.Count.ToString();
                }
            }
        }

        //Navigate to the prev page
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (pageNum > 1)
            {
                if (!Filtering)
                {
                    pageNum--;
                    LoadCards(Pages[pageNum - 1]);
                    PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
                }
                else
                {
                    pageNum--;
                    LoadCards(FilteredList[pageNum - 1]);
                    PageCount.Text = pageNum.ToString() + "/" + FilteredList.Count.ToString();
                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            deck.SaveDeckList();
            this.Close();
        }
    }
}
