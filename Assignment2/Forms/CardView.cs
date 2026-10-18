using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2.Forms
{
    public partial class CardView : UserControl
    {
        public string ImageURL = "n/a";

        public string CardNameString = "Name";

        public event EventHandler AddClicked;

        public event EventHandler RemoveClicked;

        public string productID = "0";

        public string RarityString = "";
        public string Type = "";
        public int QuantityNum = 0;
        public CardView()
        {
            InitializeComponent();

            pictureBox1.WaitOnLoad = false;

            //Create new event handlers to let the class raise it's own event and attach them to the Click delegate
            addCard.Click += (s, e) => AddClicked?.Invoke(this, e);
            removeCard.Click += (s, e) => RemoveClicked?.Invoke(this, e);

        }

        //set's the details of the card based on a card.
        public void setDetails(Card card)
        {
            //Load image asynchronously
            ImageURL = card.ImageURL;
            pictureBox1.LoadAsync(ImageURL);

            CardNameString = card.Name;

            CardName.Text = CardNameString;

            productID = card.ProductID;

            RarityString = card.Rarity;

            marketPrice.Text = "Market: " + card.MarketPrice.ToString();

            LowPrice.Text = "Low: " + card.LowPrice.ToString();

            HighPrice.Text = "High: " + card.HighPrice.ToString();

            Rarity.Text = "Type: " + card.Rarity;

            Type = card.CardType;

        }

        
        //Manual setting of properties in the case that it needs to be changed (E.g Pokemon's Foiling)
        public void SetQuantity(int quantity)
        { 
            QuantityNum = quantity;
            Quantity.Text = QuantityNum.ToString();
        }

        public void SetRarity(string rarity)
        {
            Rarity.Text = rarity;
            RarityString = rarity;
        }
    }
}
