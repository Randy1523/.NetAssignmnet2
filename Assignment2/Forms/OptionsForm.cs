namespace Assignment2.Forms
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private async void UpdatePricing_Click(object sender, EventArgs e)
        {
            UpdatePricing.Enabled = false;
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
                UpdatePricing.Enabled = true;
            }
        }
    }
}
