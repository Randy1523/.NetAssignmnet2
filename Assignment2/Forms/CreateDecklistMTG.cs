using Assignment2.DataModels;
using Assignment2.Forms;

namespace Assignment2
{
    public partial class CreateDecklistMTG : Form
    {
        List<List<MagicCard>> Pages;

        List<List<MagicCard>> FilteredList;

        bool Filtering = false;
        MagicDeck deck;
        int pageNum = 1;

        public CreateDecklistMTG()
        {
            InitializeComponent();

            Pages = Utils.ConvertToPages(MagicCard.Cards.List, 20);

            deck = new MagicDeck();
            LoadCards(Pages[pageNum - 1]);
            PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
            DeckPrice.Text = "Market: $0.0";
        }

        public CreateDecklistMTG(MagicDeck deck)
        {
            InitializeComponent();

            Pages = Utils.ConvertToPages(MagicCard.Cards.List, 20);

            this.deck = deck;
            LoadCards(Pages[pageNum - 1]);
            PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
            DeckPrice.Text = $"Market: ${Math.Round(deck.CalculateDeckPrice(), 2)}";
            DeckCount.Text = $"{deck.DeckCount}/60";
        }

        //Function to load cards.
        private void LoadCards(List<MagicCard> cards)
        {
            CardContainer.Controls.Clear();
            CardContainer.SuspendLayout();

            //For each card add a new cardview in each page. Each page holds 20 cards.
            foreach (MagicCard card in cards)
            {
                CardView cardView = new();
                CardContainer.Controls.Add(cardView);
                cardView.SetDetails(card);

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
                        AddCardClick(int.Parse(cardView.productID), cardView.RarityString);
                        cardView.QuantityNum++;

                        cardView.SetQuantity(cardView.QuantityNum);
                    }
                };

                cardView.RemoveClicked += (s, e) =>
                {
                    if (cardView.QuantityNum > 0)
                    {
                        RemoveCardClick(int.Parse(cardView.productID), cardView.RarityString);
                        cardView.QuantityNum--;

                        cardView.SetQuantity(cardView.QuantityNum);
                    }
                };
            }
            CardContainer.ResumeLayout(true);
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

                FilteredList = Utils.ConvertToPages([.. (from card in MagicCard.Cards.List where (string.IsNullOrWhiteSpace(SearchBox.Text) || card.Name.Contains(SearchBox.Text, StringComparison.CurrentCultureIgnoreCase)) && card.CardType.Contains(CardTypes.Text) select card)], 20);
                if (FilteredList.Count > 0)
                {
                    LoadCards(FilteredList[pageNum - 1]);
                    PageCount.Text = pageNum.ToString() + "/" + FilteredList.Count;
                }
                else
                {
                    FilteredList.Add([]);
                    LoadCards(FilteredList[pageNum - 1]);
                    PageCount.Text = "0/0";
                }
            }
        }

        //Save the deck on click.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            deck.SaveDeckList();
            this.Close();
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

        //Functions to add new and remove cards from the deck and update details accordingly
        private void AddCardClick(int productID, string rarity)
        {
            deck.AddCard(MagicCard.Cards.Get((productID, rarity))!);
            DeckCount.Text = deck.DeckCount.ToString() + "/" + "60";
            DeckPrice.Text = "Market: $" + Math.Round(deck.CalculateDeckPrice(), 2).ToString();
        }

        private void RemoveCardClick(int productID, string rarity)
        {
            deck.RemoveCard(MagicCard.Cards.Get((productID, rarity))!);
            DeckCount.Text = deck.DeckCount.ToString() + "/" + "60";
            DeckPrice.Text = "Market: $" + Math.Round(deck.CalculateDeckPrice(), 2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterCards();
        }

        public void SetDeck(MagicDeck deck)
        {
            this.deck = deck;
            LoadCards(Pages[pageNum - 1]);
        }
    }
}
