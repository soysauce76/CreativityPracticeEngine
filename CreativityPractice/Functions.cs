﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativityPractice
{

    static class Constants
    {
        public static string mainDirectory = "C:/Users/Owner/Documents/CreativityPracticeEngine";
        public static string promptsDirectory = "C:/Users/Owner/Documents/CreativityPracticeEngine/Prompts";
        public static string promptPicturesDirectory = "C:/Users/Owner/Documents/CreativityPracticeEngine/PromptPictures";
        public static string submissionsDirectoryName = "Submissions";
        public static string initialPictureUploadDirectory = "C:/Users/Owner/Pictures";
    }

    public class Functions
    {
        // The following functions deal with finding folders/paths

        // Checks if directory exists. Creates directory if not. Returns "ERROR" if creation fails
        public static string checkDirectory(string dir)
        {
            if (dir.Contains("ERROR")) { return "ERROR"; }
            if (!System.IO.Directory.Exists(dir))
            {
                try {
                    System.IO.Directory.CreateDirectory(dir);
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("Functions.checkDirectory() : Error creating directory " + dir + " Error message: " + ex);
                    return "ERROR";
                }
            }
            return dir;
        }
 

        public static string getCategoryFileName(string category)
        {
            string categoryFile = category + "Prompts.txt";
            string fileName = System.IO.Path.Combine(getPromptsDirectoryName(), categoryFile);
            if (!System.IO.File.Exists(fileName))
            {
                return "ERROR";
            }
            return fileName;
        }

        public static List<string> getPromptsFromFile(string fileName)
        {
            List<string> result = new List<string>();

            // pull all lines from file
            if (!System.IO.File.Exists(fileName))
            {
                result.Add("ERROR");
                return result;
            }
            string[] fileLines = System.IO.File.ReadAllLines(fileName);

            // go through each line of file to separate out prompt chunks
            bool recording = true;
            string resultString = "";
            for (int i = 0; i < fileLines.Length; i++)
            {
                // if encounter "Name:" then start recording new prompt
                if (fileLines[i].Split()[0].Equals("name:")) 
                {
                    resultString = "";
                    recording = true;
                }
                // if encounter a blank line followed by "Name:", then last prompt is over.
                else if (fileLines[i].Trim().Length == 0 && i < fileLines.Length - 1)
                {
                    if (fileLines[i + 1].Contains("name:"))
                    {
                        recording = false;
                        result.Add(resultString);
                    }
                }
                // if recording new prompt, add line to result string
                if (recording == true)
                {
                    resultString = resultString + System.Environment.NewLine + fileLines[i];
                }
            }
            // add last result string to prompt collection.
            result.Add(resultString);

            return result;
        }

        public static BasicTextPrompt parsePrompt(string promptString)
        {
            BasicTextPrompt newPrompt = new BasicTextPrompt();

            string cat = "";
            string thinking = "";
            int tim = 0;
            string bold = "";
            string grey = "";
            bool text = false;

            string[] promptLines = System.Text.RegularExpressions.Regex.Split(promptString, @"\r?\n|\r");

            // parse the text file and populate the new BasicTextPrompt instance
            Console.WriteLine("Trying to parse text file!");
            for (int i = 0; i < promptLines.Length; i++)
            {
                string line = promptLines[i];
                string[] tokens = line.Split(':');
                if (tokens.Length != 2) { continue; }
                Console.WriteLine("token[0] = '" + tokens[0] + "' and token[1] = '" + tokens[1] + "'");
                if (tokens[0].Equals("name")) { cat = tokens[1].Trim(); }
                if (tokens[0].Equals("creativity type")) { thinking = tokens[1].Trim(); }
                if (tokens[0].Equals("time")) { tim = Convert.ToInt32(tokens[1].Trim()); }
                if (tokens[0].Equals("pictures")) { }
                if (tokens[0].Equals("picture response")) { }
                if (tokens[0].Equals("text response")) { if (tokens[1].Trim().Equals("yes")) { text = true; } }
                if (tokens[0].Equals("bold prompt")) { bold = tokens[1].Trim(); }
                if (tokens[0].Equals("grey prompt")) { grey = tokens[1].Trim(); }
            }

            // generate the new prompt
            newPrompt = new BasicTextPrompt(0, text, cat, thinking, "", tim, bold, grey);
            return newPrompt;

        }

        public static string getPromptsDirectoryName()
        {
            string directoryName = System.IO.Path.Combine(Constants.mainDirectory, Constants.promptsDirectory);
            directoryName = checkDirectory(directoryName);
            return directoryName;
        }

        public static string getPromptPicturesDirectoryName()
        {
            string directoryName = System.IO.Path.Combine(Constants.mainDirectory, Constants.promptPicturesDirectory);
            directoryName = checkDirectory(directoryName);
            return directoryName;
        }   

        public static string getSubmissionsDirectoryName()
        {
            string directoryName = System.IO.Path.Combine(Constants.mainDirectory, Constants.submissionsDirectoryName);
            directoryName = checkDirectory(directoryName);
            return directoryName;
        }

        public static string getCurrentDateDirectoryName()
        {
            DateTime myDate = DateTime.Now;
            string dateString = myDate.ToString("MMM_dd_yyy");
            string directoryName = System.IO.Path.Combine(getSubmissionsDirectoryName(), dateString);
            directoryName = checkDirectory(directoryName);
            return directoryName;
        }

        public static string getResultFileName(string promptName)
        {
            // build the file name and path
            string directoryName = getCurrentDateDirectoryName();
            if (directoryName.Equals("ERROR")) { return "ERROR"; }
            string fileName = promptName + ".rtf";
            string filePath = System.IO.Path.Combine(directoryName, fileName);

            // in case there is a similarly named file, rename this one with V2, V3 etc.
            int i = 2;
            while (System.IO.File.Exists(filePath))
            {
                // if already V2 or higher, remove version tag before adding new one
                if (i > 2)
                {
                    filePath = filePath.Substring(0, filePath.Length - 3);
                }
                filePath = filePath.Substring(0, filePath.Length - 4) + "_V" + i + ".rtf";
                i++;
            }
            return filePath;
        }

//=====================================================================================================
        
        // the following involves saving result files

        // Saves a plain text file result
        public static void saveTextPromptResults(String promptName, string prompt, String textContent)
        {
            // build file path for results
            string filePath = getResultFileName(promptName);
            if (filePath.Equals("ERROR")) { return; }
            System.Windows.Forms.MessageBox.Show(filePath);

            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@filePath))
                {
                    writer.Write(textContent);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}