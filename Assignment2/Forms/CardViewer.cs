using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2.Forms
{
    public partial class CardViewer : UserControl
    {
        public CardViewer()
        {
            InitializeComponent();
            CardImage.WaitOnLoad = false;
        }

        //WIP
        public void setDetails(string url, int quant, string name, string rarity, float market)
        {
            Quant.Text = quant.ToString();
            CardImage.LoadAsync(url);
            CardName.Text = name;
            CardRarity.Text = "Type:" +rarity;
            MarketPrice.Text = "Market: " + market.ToString();

        }
    }
}
