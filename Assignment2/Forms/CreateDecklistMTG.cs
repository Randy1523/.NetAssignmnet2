using Assignment2.DataModels;
using Assignment2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            Pages = new List<List<MagicCard>>();

            int currentIndex = 0;


            while (currentIndex < FileManager.MagicCards.Count)
            {
                if (!(currentIndex + 20 > FileManager.MagicCards.Count))
                {
                    List<MagicCard> page = FileManager.MagicCards.GetRange(currentIndex, 20);
                    Pages.Add(page);
                }
                else
                {
                    List<MagicCard> page = FileManager.MagicCards.GetRange(currentIndex, FileManager.MagicCards.Count - currentIndex);
                    Pages.Add(page);
                }

                currentIndex += 20;

            }

            deck = new MagicDeck();
            LoadCards(Pages[pageNum - 1]);
            PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();

        }

    
        //Function to load cards.
        private void LoadCards(List<MagicCard> cards)
        {
            CardContainer.Controls.Clear();
            CardContainer.SuspendLayout();

            //For each card add a new cardview in each page. Each page holds 20 cards.
            foreach (MagicCard card in cards)
            {
                CardView cardView = new CardView();
                CardContainer.Controls.Add(cardView);
                cardView.setDetails(card);

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

        private void FilterCards()
        {
            if(SearchBox.Text.Equals("") && CardTypes.Text.Equals(""))
            {
                Filtering = false;
                pageNum = 1;
                LoadCards(Pages[pageNum - 1]);
            }
            else
            {
                Filtering = true;
                pageNum = 1;
                List<MagicCard> filtered =  Utils.FilterMagicCards(FileManager.MagicCards, SearchBox.Text);
                List<MagicCard> filtered2 = Utils.FilterMagicType(filtered, CardTypes.Text);

                FilteredList = Utils.ConvertToPages<MagicCard>(filtered2,20);
                
                LoadCards(FilteredList[pageNum - 1]);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            deck.SaveDeckList();
            this.Close();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (!Filtering)
            {
                pageNum++;
                LoadCards(Pages[pageNum - 1]);
                PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
            }
            else
            {
                pageNum++;
                LoadCards(FilteredList[pageNum - 1]);
                PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
            }

        }

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
                    PageCount.Text = pageNum.ToString() + "/" + Pages.Count.ToString();
                }
                
            }
        }

        private void AddCardClick(string productID, string rarity)
        {
            deck.AddCard(FileManager.MagicCardLookup[new Pair(productID, rarity)]);
            DeckCount.Text = deck.DeckCount.ToString() + "/" + "60";
        }

        private void RemoveCardClick(string productID, string rarity)
        {
            deck.RemoveCard(FileManager.MagicCardLookup[new Pair(productID, rarity)]);
            DeckCount.Text = deck.DeckCount.ToString() + "/" + "60";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterCards();
        }
    }
}
