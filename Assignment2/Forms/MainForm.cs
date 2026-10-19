using Assignment2.DataModels;

namespace Assignment2.Forms
{
    public partial class MainForm : Form
    {
        public Type SelectedGame => GameSelect.SelectedIndex switch
        {
            0 => typeof(MagicCard),
            1 => typeof(PokemonCard),
            _ => throw new ArgumentOutOfRangeException("MainForm GameSelect has too many options")
        };

        private IScreen? BackScreen { get; set; }

        public MainForm()
        {
            InitializeComponent();
            GameSelect.SelectedIndex = 0;
            MagicCard.Cards.InitializeCards();
            PokemonCard.Cards.InitializeCards();

            ChangeScreen(new MainMenu());
        }

        public void ChangeScreen(IScreen screen)
        {
            Panel.Controls.Clear();
            Panel.Controls.Add(screen.UserControl);
            Text = screen.Header;
            Header.Text = screen.Header;
            BackScreen = screen.BackScreen;
            Back.Enabled = BackScreen != null;
        }

        private async void Options_Click(object sender, EventArgs e)
        {
            Options.Enabled = false;
            await new OptionsForm().ShowAsync();
            Options.Enabled = true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            ChangeScreen(BackScreen ?? throw new NullReferenceException("Back button not disabled with no BackScreen"));
        }
    }
}
