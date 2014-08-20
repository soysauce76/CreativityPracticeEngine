using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativityPractice
{

    // program-wide constants defined here
    static class Constants
    {
        public static string mainDirectory = "C:/Users/Owner/Documents/CreativityPracticeEngine";
        public static string promptsDirectory = "C:/Users/Owner/Documents/CreativityPracticeEngine/Prompts";
        public static string promptPicturesDirectory = "C:/Users/Owner/Documents/CreativityPracticeEngine/PromptPictures";
        public static string submissionsDirectoryName = "Submissions";
        public static string initialPictureUploadDirectory = "C:/Users/Owner/Pictures";
        public static string generalErrorString = "ERROR";
        public static string[] categories = { "Art", "Writing", "Poetry", "Music", "Engineering", "Miscellaneous" };
        public static string promptDelimiter = "======================";

        public static int maxPictureHeight = 250;
        public static int maxPictureWidth = 250;
        public static int widthOfPromptForm = 622;
    }

    // program-wide functions defined here
    public class Functions
    {

//================================================================================================
        // the following involves reading/parsing prompt files

        public static List<string> getPromptsFromFile(string fileName)
        {
            List<string> result = new List<string>();

            // pull all lines from file
            if (!System.IO.File.Exists(fileName))
            {
                result.Add(Constants.generalErrorString);
                return result;
            }
            string[] fileLines = System.IO.File.ReadAllLines(fileName);

            // go through each line of file to separate out prompt chunks
            bool recording = true;
            string resultString = "";
            for (int i = 0; i < fileLines.Length; i++)
            {
                // if encounter "tag:" then start recording new prompt
                if (fileLines[i].Split()[0].Equals("tag:")) 
                {
                    resultString = "";
                    recording = true;
                }
                // if encounter "=====" then prompt is over
                else if (fileLines[i].Contains(Constants.promptDelimiter))
                //else if (fileLines[i].Trim().Length == 0 && i < fileLines.Length - 1)
                {
                    //if (fileLines[i + 1].Contains("tag:"))
                        recording = false;
                        result.Add(resultString);
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

//=====================================================================================================
        
        // the following functions save result files

        // Saves a plain text file result
        public static int saveTextPromptResults(String promptName, string prompt, String textContent)
        {
            // build file path for results
            string filePath = getResultFileName(promptName, ".rtf");
            if (filePath.Equals(Constants.generalErrorString)) { return -1; }
            //System.Windows.Forms.MessageBox.Show(filePath);

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
                return -1;
            }
            return 0;
        }

        // copy a picture file from its current location to the submissions directory, with new name
        public static int savePictureResult(string promptName, string sourcePath)
        {
            // get the output filename
            string destinationPath = getResultFileName(promptName, System.IO.Path.GetExtension(sourcePath));
            if (destinationPath.Equals(Constants.generalErrorString)) { return -1; }
            //System.Windows.Forms.MessageBox.Show(destinationPath);

            // now copy the file over
            try
            {
                System.IO.File.Copy(sourcePath, destinationPath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error copying file " + System.IO.Path.GetFileName(sourcePath) + " to " + destinationPath);
                System.Windows.Forms.MessageBox.Show("Error copying file " + System.IO.Path.GetFileName(sourcePath) + " to " + 
                    destinationPath + "\nError: " + ex);
                return -1;
            }
            return 0;
        }


//=====================================================================================================
        // The following functions deal with finding folders/paths

        // Checks if a directory exists. Creates directory if not. Returns Constants.generalErrorString if creation fails
        public static string checkDirectory(string dir)
        {
            if (dir.Contains(Constants.generalErrorString)) { return Constants.generalErrorString; }
            if (!System.IO.Directory.Exists(dir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("Functions.checkDirectory() : Error creating directory " + dir + " Error message: " + ex);
                    return Constants.generalErrorString;
                }
            }
            return dir;
        }

        public static bool checkFile(string file)
        {
            if (!System.IO.File.Exists(file))
            {
                return false;
            }
            return true;
        }

        public static string getCategoryFileName(string category)
        {
            string categoryFile = category + "Prompts.txt";
            string fileName = System.IO.Path.Combine(getPromptsDirectoryName(), categoryFile);
            return fileName;
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

        // builds submission file name
        public static string getResultFileName(string promptName, string extension)
        {
            // build the file name and path
            //string directoryName = getCurrentDateDirectoryName();
            string directoryName = getSubmissionsDirectoryName();
            if (directoryName.Equals(Constants.generalErrorString)) { return Constants.generalErrorString; }

            DateTime myDate = DateTime.Now;
            string dateString = myDate.ToString("_MMM_dd_yyy"); 
            string fileName = promptName + dateString + extension;
            string filePath = System.IO.Path.Combine(directoryName, fileName);

            // in case there is a similarly named file, rename this one with V2, V3 etc.
            int i = 2;
            while (System.IO.File.Exists(filePath))
            {
                filePath = System.IO.Path.Combine(directoryName, System.IO.Path.GetFileNameWithoutExtension(filePath));
                // if already V2 or higher, remove version tag before adding new one
                if (i > 2)
                {
                    filePath = filePath.Substring(0, filePath.Length - 3);
                }
                filePath = filePath + "_V" + i + extension;
                i++;
            }
            return filePath;
        }
    }

}


