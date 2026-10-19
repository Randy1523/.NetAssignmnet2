using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2.Forms
{
    public partial class DeckView : UserControl
    {
        public string DeckCode = "N/A";

        public event EventHandler DoubleClicked;
        public DeckView()
        {
            InitializeComponent();

            DeckImage.Click += (s, e) => DoubleClicked?.Invoke(this, e);

            DeckImage.WaitOnLoad = false;
        }

        public void SetDeckCode(string code)
        {
            DeckCode = code;
            DeckName.Text = code;
        }

        public void setImage(string url)
        {
            DeckImage.LoadAsync(url);
        }
    }
}
