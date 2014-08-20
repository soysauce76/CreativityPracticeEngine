using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativityPractice
{
    public class BasicTextPrompt
    {
        public bool ERROR;

        public int numPictures;
        public bool useTextBox;
        public bool useUploadPicture;
        public string picture1;
        public string picture2;
        public string music;

        public string tag;
        public string category;
        public string creativityType;

        public int suggestedTime;

        public string boldPrompt;
        public string greyPrompt;

        public BasicTextPrompt()
        {
            ERROR = false;
            tag = "";
            category = "unspecified";
            creativityType = "unspecified";
            suggestedTime = 0;
            boldPrompt = "uninitialized";
            greyPrompt = "uninitialized";
            useUploadPicture = true;
        }

        public BasicTextPrompt(List<string> pictures, string musicFile, string nametag, string newCategory, string newCreativityType, int newTime, string newBoldPrompt, string newGreyPrompt)
        {
            useUploadPicture = true;  // TEMPORARY
            ERROR = false;
            //// initialize picture boxes if necessary
            //if (pictures > 0) { picture1 = new System.Windows.Forms.PictureBox(); }
            //if (pictures > 1) { picture2 = new System.Windows.Forms.PictureBox(); }

            // initialize prompt values
            this.tag = nametag;
            this.category = newCategory;
            this.creativityType = newCreativityType;
            this.suggestedTime = newTime;
            this.boldPrompt = newBoldPrompt;
            this.greyPrompt = newGreyPrompt;
            if (pictures.Count > 0)
            {
                picture1 = pictures[0];
            }
            if (pictures.Count > 1)
            {
                picture2 = pictures[1];
            }
            this.music = musicFile;
        }

        public static BasicTextPrompt parsePrompt(string promptString, string category)
        {
            BasicTextPrompt newPrompt = new BasicTextPrompt();

            string nametag = "";
            string thinking = "";
            int tim = 0;
            string bold = "";
            string gray = "";
            string pic1 = "";
            string pic2 = "";
            string mus = "";

            string[] promptLines = System.Text.RegularExpressions.Regex.Split(promptString, @"\r?\n|\r");
            List<string> pics = new List<string>();
            bool readingBold = false;

            // parse the text file and populate the new BasicTextPrompt instance
            Console.WriteLine("Trying to parse text file!");
            for (int i = 0; i < promptLines.Length; i++)
            {
                string line = promptLines[i];
                string[] tokens = line.Split(':');
                if (tokens.Length < 2 && line.Contains(":")) { continue; }
                if (tokens.Length < 2 || !line.Contains(":"))
                {
                    if (readingBold)
                    {
                        bold += Environment.NewLine + line;
                    }
                    continue;
                }
                if (tokens[0].Equals("tag")) { nametag = line.Substring(line.IndexOf(':') + 2); }
                if (tokens[0].Equals("creativityType")) { thinking = line.Substring(line.IndexOf(':') + 2); }
                if (tokens[0].Equals("time")) { tim = Convert.ToInt32(tokens[1].Trim()); }
                if (tokens[0].Equals("picture1") && line.Contains(":")) 
                { 
                    pic1 = line.Substring(line.IndexOf(':') + 2); 
                    if (Functions.checkFile(pic1)) {pics.Add(pic1); }
                    else { pics.Add(""); }
                }
                if (tokens[0].Equals("picture2") && line.Contains(":")) 
                { 
                    pic2 = line.Substring(line.IndexOf(':') + 2);
                    if (Functions.checkFile(pic2)) { pics.Add(pic2); }
                    else { pics.Add(""); }
                }
                if (tokens[0].Equals("music") && line.Contains(":")) 
                { 
                    mus = line.Substring(line.IndexOf(':') + 2); 
                    if (!Functions.checkFile(mus)) { mus = ""; }
                }
                if (tokens[0].Equals("pictureResponse")) { }
                if (tokens[0].Equals("boldPrompt")) 
                {
                    readingBold = true;
                    bold = line.Substring(line.IndexOf(':') + 2);
                    continue;
                }
                if (tokens[0].Equals("grayPrompt")) 
                {
                    readingBold = false;
                    gray = line.Substring(line.IndexOf(':') + 2); 
                }
                if (readingBold)
                {
                    bold += Environment.NewLine + line;
                }
            }

            // generate the new prompt
            newPrompt = new BasicTextPrompt(pics, mus, nametag, category, thinking, tim, bold, gray);
            return newPrompt;

        }


        // write out a new prompt
        public int writeOut()
        {
            int success = 0;

            // find prompt file
            string outputDirectory = Constants.promptsDirectory;
            string fileName = Functions.getCategoryFileName(this.category);
            string outputFile = System.IO.Path.Combine(outputDirectory, fileName);
            Console.WriteLine("output file for new prompt is: " + outputFile);
            //System.Windows.Forms.MessageBox.Show("output file for new prompt is: " + outputFile);

            // create output prompt file if it doesn't exist yet
            if (!System.IO.File.Exists(outputFile))
            {
                System.IO.FileStream fs = new System.IO.FileStream(outputFile, System.IO.FileMode.OpenOrCreate);
                System.IO.StreamWriter str = new System.IO.StreamWriter(fs);
                str.Flush();
                str.Close();
                fs.Close();
            }
            if (!System.IO.File.Exists(outputFile))
            {
                System.Windows.Forms.MessageBox.Show("Error: Could not find nor create prompt file for category " + category);
                Console.WriteLine("BasicTextPrompt.writeOut(): Error creating output prompt file");
                return -1;
            }

            // create output string
            string output = "tag: " + tag + System.Environment.NewLine +
                            "creativityType: " + creativityType + System.Environment.NewLine +
                            "time: " + suggestedTime + System.Environment.NewLine +
                            "picture1: " + picture1 + System.Environment.NewLine +
                            "picture2: " + picture2 + System.Environment.NewLine +
                            "music: " + music + System.Environment.NewLine +
                            "pictureResponse: " + useUploadPicture + System.Environment.NewLine +
                            "boldPrompt: " + boldPrompt + System.Environment.NewLine +
                            "grayPrompt: " + greyPrompt + System.Environment.NewLine + System.Environment.NewLine +
                            "=============================================================" + System.Environment.NewLine;

            // append new prompt to file
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(outputFile))
            {
                try
                {
                    sw.WriteLine(output);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error appending prompt to file: exception: " + e);
                    System.Windows.Forms.MessageBox.Show("Error appending prompt to file: exception: " + e);
                    return -1;
                }
            }

            return success;
        }
    }
}
