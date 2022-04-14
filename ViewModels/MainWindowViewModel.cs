
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace csNotes.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        
        private csNotes.Models.fileOps fOps; // = new csNotes.Models.fileOps();

      

        private string textBoxFileName = "";
        public string SetFileNameTextBoxText
        {
            get 
            {
                return textBoxFileName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref textBoxFileName, value);
            }
        }

        private string textBoxFileText = "";
        public string SetTextBoxFileText
        {
            get 
            {
                return textBoxFileText;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref textBoxFileText, value);
            }
        }

        private string textBlockText = "File:";
        public string SetTextBlockText 
        {
            get 
            {
                return  textBlockText;
            }
            set 
            {
                this.RaiseAndSetIfChanged(ref textBlockText, value);
            }
        } 

        public string ButtonText => "New Note";


  

        private void GetInitialFileList() 
        {
            MyItems = new ObservableCollection<string>();
            List<string> lis = fOps.GetFileList();
            foreach (string s in lis)
            {
                MyItems.Add(s);
            }
        }
        

        public ObservableCollection<string> MyItems 
        {
            get ;
            set;
        } 
      
        private string selectedItem = "";

        public string SelectedListItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                Save();
                SetTextBoxFileText = fOps.GetFileText(value);
                SetFileNameTextBoxText = value;
                this.RaiseAndSetIfChanged(ref selectedItem, value);
            }
        }

        private int selectedIndex = 0;

        public int SelectedListIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedIndex, value);
            }
        }

        public void ButtonClicked()
        { 
            SetTextBlockText = "button clicked";
            if (SetFileNameTextBoxText.Length > 0 && ! MyItems.Contains(SetFileNameTextBoxText))
            {
                fOps.CreateNewTextFile(SetFileNameTextBoxText);
                SetTextBoxFileText = "";
                MyItems.Add(SetFileNameTextBoxText);
                SelectedListIndex = MyItems.Count - 1;
            }
            else
            {
                System.Console.WriteLine("no thank you");
            }
            
        }

        public void Save()
        { 
            fOps.WriteFile(SetTextBoxFileText);
        }

        public MainWindowViewModel(csNotes.Models.fileOps fileOp)
        {
            fOps = fileOp;
            
            
            GetInitialFileList();
            if (MyItems == null)
            {
                MyItems = new ObservableCollection<string>();
            }

        }

     


// myButton = this.FindControl<global::Avalonia.Controls.Button>("myButton");


    }
}
