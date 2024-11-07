using MvvmHelpers;
using PropertyChanged;
using System.Windows.Input;

namespace MAUIBugs.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TestViewModel
    {
        public ObservableRangeCollection<ChecklistAnswerViewModel> Section1Answers { get; set; }

        public ObservableRangeCollection<ChecklistAnswerViewModel> Section2Answers { get; set; }

        public ObservableRangeCollection<ChecklistAnswerViewModel> CurrentAnswers { get; set; }

        /// <summary>
        /// section label
        /// </summary>
        public string SectionLabel { get; set; }

        public ICommand LoadSection1Command { get; set; }

        public ICommand LoadSection2Command { get; set; }

        public TestViewModel()
        {
            this.Section1Answers = new ObservableRangeCollection<ChecklistAnswerViewModel>();
            this.Section2Answers = new ObservableRangeCollection<ChecklistAnswerViewModel>();
            this.CurrentAnswers = new ObservableRangeCollection<ChecklistAnswerViewModel>();

            this.Section1Answers.Add(new ChecklistAnswerViewModel()
            {
                QuestionText = "Please Sign Section 1",
            });
            this.RegisterCommands();
            this.SetSection1Answers();
        }

        public void SetSection1Answers()
        {
            this.SectionLabel = "Section 1";
            this.CurrentAnswers.ReplaceRange(this.Section1Answers);
        }

        public void SetSection2Answers()
        {
            this.SectionLabel = "Section 2";
            this.CurrentAnswers.Clear();
        }

        private void RegisterCommands()
        {
            this.LoadSection1Command = new Command(() =>
            {
                this.SetSection1Answers();
            });

            this.LoadSection2Command = new Command(() =>
            {
                this.SetSection2Answers();
            });
        }
    }
}
