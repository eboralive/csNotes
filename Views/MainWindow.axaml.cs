using Avalonia.Controls;

using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.ComponentModel;

namespace csNotes.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            this.Closing += (s, e) =>
            {
                if (this.DataContext != null) {
                    csNotes.ViewModels.MainWindowViewModel tmp = (csNotes.ViewModels.MainWindowViewModel) this.DataContext;
                    System.Console.WriteLine("closing time");
                    tmp.Save();
                }
               

            };

        }



      
    }
}