using Assignment2.DataModels;

namespace Assignment2
{
    public partial class MainMenu : Form
    {

        
        public MainMenu()
        {
            InitializeComponent();
            //Load data into the static Lists.
            FileManager.MagicCards = FileManager.LoadMagicCards();

            FileManager.MagicCardLookup = Utils.CreateMagicLookup(FileManager.MagicCards);

            FileManager.PokemonCards = FileManager.LoadPokemonCards();

            FileManager.PokemonCardLookup = Utils.CreatePokemonLookup(FileManager.PokemonCards);
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
