
using System;
using System.Collections.Generic;
using System.Text;

namespace csNotes.Models
{
    public class fileOps
    {

        public string GetHomeDir() 
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }

        public string GetNotesDir() 
        {
            string notesDir = GetHomeDir() + "/.csNotes";
            if (! System.IO.Directory.Exists(notesDir)) 
            {
                System.IO.Directory.CreateDirectory(notesDir);
            }
            return notesDir;
        }

        public List<string> GetFileList() 
        {
            string[] files = System.IO.Directory.GetFiles(GetNotesDir());
            List<string> fileList = new List<string>();
            foreach (string aFile in files)
            {
                string[] filez = aFile.Split('/');
                fileList.Add(filez[filez.Length -1]);
            }
            return fileList;
        }

        public string GetFileText(string fileName) 
        {
            currentFileName = fileName;
            try
            {
                using (var sr = new System.IO.StreamReader(GetNotesDir() + "/" + fileName))
                {   
                    lastOpenedText = sr.ReadToEnd();
                    return lastOpenedText;
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return "";
        }

        private string lastOpenedText = "";
        private string currentFileName = "";

        public void WriteFile(string text) 
        {
            if (currentFileName.Length > 0 && text != lastOpenedText)
            {
                WriteTheFile(text);
                System.Console.WriteLine("saved");
            } 
            else 
            { 
                 System.Console.WriteLine("no save");
            }
            
        }

        private void WriteTheFile(string text) 
        {
            using System.IO.StreamWriter outputFile = new System.IO.StreamWriter(GetNotesDir() + "/" + currentFileName);
            outputFile.Write(text);
        }

        public void CreateNewTextFile(string newFileName) 
        {
            if (! System.IO.File.Exists(GetNotesDir() + "/" + newFileName))
            {
                currentFileName = newFileName;
                WriteTheFile("");
                System.Console.WriteLine("new file created called " + newFileName);
            }
            else
            {
                System.Console.WriteLine("file already exists called " + newFileName);
            }
          
        }


    }
}


