using Assignment2.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2.Forms
{
    public partial class CreateDeckListPokemon : Form
    {

        List<List<PokemonCard>> Pages;

        List<List<PokemonCard>> FilteredList;

        bool Filtering = false;
        PokemonCard deck;
        int pageNum = 1;
        public CreateDeckListPokemon()
        {
            InitializeComponent();
        }
    }
}
