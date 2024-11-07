using MAUIBugs.ViewModels;

namespace MAUIBugs
{
    public partial class BindableLayoutPickerBug : ContentPage
    {
        public BindableLayoutPickerBug()
        {
            InitializeComponent();
            this.BindingContext = new BugViewModel();
        }
    }
}
