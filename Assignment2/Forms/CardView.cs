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

        public float marketPriceFloat = 0;

        public float lowPriceFloat = 0;

        public float highPriceFloat = 0;

        public event EventHandler AddClicked;

        public event EventHandler RemoveClicked;

        public string productID = "0";

        public CardView()
        {
            InitializeComponent();

            pictureBox1.WaitOnLoad = false;

            addCard.Click += (s, e) => AddClicked?.Invoke(this,e);
            removeCard.Click += (s, e) => RemoveClicked?.Invoke(this, e);
        }


        public void setDetails(Card card)
        {

        }
        
    }
}
