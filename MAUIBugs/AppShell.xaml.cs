namespace MAUIBugs
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(BindableLayoutPickerBug), typeof(BindableLayoutPickerBug));
        }
    }
}
