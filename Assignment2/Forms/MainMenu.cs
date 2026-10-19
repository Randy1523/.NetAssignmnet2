using Assignment2.DataModels;

namespace Assignment2
{
    public partial class MainMenu : Form
    {

        
        public MainMenu()
        {
            InitializeComponent();

            MagicCard.Cards.InitializeCards();
            PokemonCard.Cards.InitializeCards();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCGSelectCreate form = new TCGSelectCreate();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewDecklists_Click(object sender, EventArgs e)
        {
            ViewDecklistsSelect form = new ViewDecklistsSelect();

            form.Show();
        }
    }
}
