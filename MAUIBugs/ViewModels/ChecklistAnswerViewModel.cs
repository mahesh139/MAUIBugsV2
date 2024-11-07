using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Graphics.Platform;
using MvvmHelpers;
using PropertyChanged;
using System.Windows.Input;

namespace MAUIBugs.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ChecklistAnswerViewModel
    {
        /// <summary>
        /// Gets or sets the question text.
        /// </summary>
        /// <value>
        /// The question text.
        /// </value>
        [DoNotNotify]
        public string QuestionText { get; set; }

        /// <summary>
        /// checks whether question is enabled or not.
        /// </summary>
        public bool IsSignatureEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible { get; set; }

        /// <summary>
        /// signature
        /// </summary>
        public byte[]? Signature { get; set; }

        /// <summary>
        /// signature lines
        /// </summary>
        public ObservableRangeCollection<IDrawingLine> SignatureLines { get; set; }

        /// <summary>
        /// edit signature command
        /// </summary>
        public ICommand EditSignatureCommand { get; set; }

        /// <summary>
        /// clear signature command
        /// </summary>
        public ICommand ClearSignatureCommand { get; set; }

        /// <summary>
        /// Save signature command
        /// </summary>
        public ICommand SaveSignatureCommand { get; set; }

        public ChecklistAnswerViewModel()
        {
            this.Initilise();
        }

        private void Initilise()
        {
            this.IsSignatureEnabled = false;
            this.Signature = null;
            this.SignatureLines = new ObservableRangeCollection<IDrawingLine>();
            this.RegisterCommands();
        }

        /// <summary>
        /// register commands
        /// </summary>
        private void RegisterCommands()
        {
            this.EditSignatureCommand = new Command(() =>
            {
                this.IsSignatureEnabled = !this.IsSignatureEnabled;
            });

            this.ClearSignatureCommand = new Command(() =>
            {
                this.SignatureLines.Clear();
            });

            this.SaveSignatureCommand = new Command(async () =>
            {
                if (this.IsSignatureEnabled)
                {


                    if (this.SignatureLines != null && this.SignatureLines.Any())
                    {
                        using (Stream stream = await DrawingView.GetImageStream(this.SignatureLines, new Size(300, 300), Brush.Transparent))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                stream.CopyTo(ms);
                                this.Signature = ms.ToArray();
                            }
                        }
                    }
                    else
                    {
                        this.Signature = null;
                    }

                    this.IsSignatureEnabled = false;
                }
            });
        }
    }
}
