using Assignment2.DataModels;

namespace Assignment2.Forms
{
    public partial class MainMenu : UserControl, IScreen
    {
        public UserControl UserControl => this;
        public string Header => "TCG Market Plays";
        public IScreen? BackScreen => null;

        public MainMenu()
        {
            InitializeComponent();
            ClipImage.Load("../../../Data/Images/TCGclip.png");
        }

        private void TournamentData_Click(object? sender, EventArgs e)
        { 
            UsageData.Navigator.Open();
        }
        private void CreateDecklist_Click(object sender, EventArgs e)
        {
            TCGSelectCreate form = new();
            form.Show();
        }

        private void ViewDecklists_Click(object sender, EventArgs e)
        {
            ViewDecklistsSelect form = new();

            form.Show();
        }
    }
}
