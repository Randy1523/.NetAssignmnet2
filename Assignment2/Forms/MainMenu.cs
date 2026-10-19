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
            ClipImage.Load("../../../Data/Images/TCGclip.png");
        }

        //
        private void button1_Click(object sender, EventArgs e)
        {
            TCGSelectCreate form = new TCGSelectCreate();
            form.Show();
        }

        private void ViewDecklists_Click(object sender, EventArgs e)
        {
            ViewDecklistsSelect form = new ViewDecklistsSelect();

            form.Show();
        }


        private async void button1_Click_1(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;   
            try
            {
                await TcgCsvDownloader.RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Download failed");
            }
            finally
            {
                btnDownload.Enabled = true;
            }
        }
    }
}
