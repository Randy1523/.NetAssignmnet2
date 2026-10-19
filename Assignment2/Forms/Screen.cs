namespace Assignment2.Forms
{
    public interface IScreen
    {
        public UserControl UserControl { get; }

        public string Header { get; }

        public IScreen? BackScreen { get; }
    }
}
