using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using csNotes.ViewModels;
using csNotes.Views;
using System.ComponentModel;

namespace csNotes
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
        
            csNotes.Models.fileOps fOps = new csNotes.Models.fileOps();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(fOps),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }






       
    }
}