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

        public string Name = "Name";

        public event EventHandler AddClicked;

        public event EventHandler RemoveClicked;

        public event EventHandler QuantityChanged;

        public string productID = "0";

        public int QuantityNum = 0;
        public CardView()
        {
            InitializeComponent();

            pictureBox1.WaitOnLoad = false;

            //Create new event handlers to let the class raise it's own event and attach them to the Click delegate
            addCard.Click += (s, e) => AddClicked?.Invoke(this, e);
            removeCard.Click += (s, e) => RemoveClicked?.Invoke(this, e);
            Quantity.TextChanged += (s, e) => QuantityChanged?.Invoke(this, e);

        }


        public void setDetails(Card card)
        {
            //Load image asynchronously
            ImageURL = card.ImageURL;
            pictureBox1.LoadAsync(ImageURL);

            Name = card.Name;

            CardName.Text = Name;

            productID = card.ProductID;

            marketPrice.Text = card.MarketPrice.ToString();

            LowPrice.Text = card.LowPrice.ToString();

            HighPrice.Text = card.HighPrice.ToString();

            Rarity.Text = card.Rarity;

        }

        private void addCard_Click(object sender, EventArgs e)
        {
            if(QuantityNum < 4)
            {
                QuantityNum++;
                Quantity.Text = QuantityNum.ToString();
            }
        }

        private void removeCard_Click(object sender, EventArgs e)
        {
            if (QuantityNum > 0)
            {
                QuantityNum--;
                Quantity.Text = QuantityNum.ToString();
            }
        }
    }
}
