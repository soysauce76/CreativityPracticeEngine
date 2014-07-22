using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreativityPractice
{
    public partial class CreateNewPromptsForm : Form
    {

        string uploadFile1;
        string uploadFile2;
        string uploadFileMusic;
        private static string noPictureText = "No Picture";

        public CreateNewPromptsForm()
        {
            InitializeComponent();
            uploadFile1 = "";
            uploadFile2 = "";
            uploadFileMusic = "";

            // load available categories
            categoryListBox.Items.AddRange(Constants.categories);
        }

        // user submits form. If input is correct, save new prompt to file
        private void createButton_Click(object sender, EventArgs e)
        {
            string promptName = "";
            string creativityType = "";
            string category;
            int tim = 0;
            string boldPrompt = "";
            string grayPrompt = "";

            // check if form was filled out correctly
            int success = checkInput();
            if (success != 0)
            {
                // * if failed, user should be warned by messagebox in checkInput();
                Console.WriteLine("CreateNewPromptsForm.createButton_Click: input not formatted correctly. Returning.");
                return;
            }

            // pull creativity type
            if (convergentCheckBox.Checked && !divergentCheckBox.Checked)
            {
                creativityType = "Convergent";
            }
            else if (!convergentCheckBox.Checked && divergentCheckBox.Checked)
            {
                creativityType = "Divergent";
            }

            // find out which category was selected
            if (categoryListBox.CheckedItems.Count != 1) { return; }
            category = categoryListBox.CheckedItems[0].ToString();

            // pull time and prompts
            promptName = nameTextBox.Text.Trim().Replace(' ','_');
            boldPrompt = boldPromptBox.Text;
            grayPrompt = grayPromptBox.Text;
            Int32.TryParse(timeBox.Text, out tim);

            // pull included pictures
            List<string> pics = new List<string>();
            if (!pictureLabel1.Text.Trim().Equals(noPictureText))
            {
                pics.Add(uploadFile1);
            }
            if (!pictureLabel2.Text.Trim().Equals(""))
            {
                pics.Add(uploadFile2);
            }

            BasicTextPrompt newPrompt = new BasicTextPrompt(pics, uploadFileMusic, promptName, category, creativityType, tim, boldPrompt, grayPrompt);
            newPrompt.writeOut();

            // For convenience of rapidly creating similar prompts, clear pictures but leave all text
            uploadFile1 = ""; uploadFile2 = "";
            pictureLabel1.Text = noPictureText;
            pictureLabel2.Text = "";
            uploadMusicLabel.Text = "";
        }

        // check that information has been entered correctly in the form
        private int checkInput()
        {
            string errorString = "";
            int success = 0;

            // check convergent/divergent
            if (!convergentCheckBox.Checked && !divergentCheckBox.Checked)
            {
                errorString = errorString + "-Please select Divergent or Convergent thinking." + "\n" +
                    "Remember: Divergent refers to the generation of many ideas. Convergent refers to the refining of one idea." + "\n\n";
                success = -1;
            }
            else if (convergentCheckBox.Checked && divergentCheckBox.Checked)
            {
                errorString = errorString + "-Please select either Divergent OR Convergent thinking" + "\n\n";
                success = -1;
            }

            // if user did not select a single category, warn them and exit.
            if (categoryListBox.CheckedItems.Count < 1)
            {
                errorString = errorString + "-Please select a category"+ "\n\n";
                success = -1;
            }
            if (categoryListBox.CheckedItems.Count > 1)
            {
                errorString = errorString + "-Please select only one category" + "\n\n";
                success = -1;
            }

            // Make sure user entered a prompt name
            if (nameTextBox.Text.Trim().Equals(""))
            {
                errorString = errorString + "-Please enter a prompt label (for file naming purposes)" + "\n\n";
                success = -1;
            }

            // Make sure time was entered and is a positive integer
            if (timeBox.Text.Trim().Equals(""))
            {
                errorString = errorString + "-Please enter a suggested time" + "\n\n";
                success = -1;
            }
            int tim = 0;
            bool result = Int32.TryParse(timeBox.Text, out tim);
            if (!result)
            {
                errorString = errorString + "-Suggested time must be a whole number, eg. 1, 2, 3..." + "\n\n";
                success = -1;
            }
            else if (result && tim < 0)
            {
                errorString = errorString + "-Suggested time cannot be negative" + "\n\n";
                success = -1;
            }

            // Make sure user entered a bold prompt. Gray prompt is optional
            if (boldPromptBox.Text.Equals("<enter text>") || boldPromptBox.Text.Trim().Equals(""))
            {
                errorString = errorString + "-Please enter a prompt" + "\n\n";
                success = -1;
            }

            // make sure upload files exist
            if (uploadFile1.Length > 0 && !System.IO.File.Exists(uploadFile1))
            {
                errorString = errorString + "- File " + uploadFile1 + " does not exist";
                success = -1;
            }
            if (uploadFile2.Length > 0 && !System.IO.File.Exists(uploadFile2))
            {
                errorString = errorString + "- File " + uploadFile2 + " does not exist";
                success = -1;
            }
            if (uploadFileMusic.Length > 0 && !System.IO.File.Exists(uploadFileMusic))
            {
                errorString = errorString + "- File " + uploadFileMusic + " does not exist";
                success = -1;
            }

            // show all errors at once
            if (success != 0)
            {
                Console.WriteLine("CreateNewPromptForm.checkInput(): User input formatted incorrectly");
                MessageBox.Show(errorString);
            }

            return success;
        }

        // display some prompt ideas or commonly used prompts to copy/paste and modify
        private void ideasLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Develop 4 environment thumbnails (b&w or color) for :" + Environment.NewLine
                + "Develop 5 rough b&w creature concepts for : _______ OR this weeks COW challenge" + Environment.NewLine
                + "Develop 3 rough mechanical designs for: " + Environment.NewLine
                + "Please upload final picture below");
        }

        private string getUserSelectedFile(string filter)
        {
            string fileName = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Constants.initialPictureUploadDirectory;
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // have user select a file to upload
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK )
            {
                fileName = openFileDialog1.FileName;
                if (!System.IO.File.Exists(fileName))
                {
                    MessageBox.Show("File " + fileName + " does not exist");
                    return Constants.generalErrorString;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return "Canceled";
            }
            return fileName;
        }

        // allow user to select a picture to use for the prompt
        private void includePicturesButton_Click(object sender, EventArgs e)
        {

            string fileName = getUserSelectedFile("Image Files (*.bmp, *.jpg, *.png, *.jpeg, *.gif)|*.bmp;*.jpg;*.png,*.jpeg,*.gif");
            if (fileName.Equals(Constants.generalErrorString))
            {
                return;
            }
            else if (fileName.Equals("Canceled"))
            {
                return;
            }
            // save filename and display which file was selected on the form in gray text
            if (pictureLabel1.Text.Trim().Equals(noPictureText))
            {
                uploadFile1 = fileName;
                pictureLabel1.Text = System.IO.Path.GetFileName(fileName);
            }
            else if (pictureLabel2.Text.Trim().Equals(""))
            {
                uploadFile2 = fileName;
                pictureLabel2.Text = System.IO.Path.GetFileName(fileName);
            }
            else {
                MessageBox.Show("Can only upload 2 files! click on a file name to delete");
            }

        }

        // allow user to select an mp3 to use for the prompt
        private void includeMusicButton_Click(object sender, EventArgs e)
        {
            string file = getUserSelectedFile("Music Files (*.mp3)|*.bmp;*.mp3");
            if (file.Equals(Constants.generalErrorString))
            {
                return;
            }
            else if (file.Equals("Canceled"))
            {
                return;
            }
            if (!uploadFileMusic.Trim().Equals(""))
            {
                MessageBox.Show("Can only upload one song per prompt!\n You may remove the current song by clicking on it");
                return;
            }
            uploadFileMusic = file;
            uploadMusicLabel.Text = System.IO.Path.GetFileName(file);
        }

        // allow user to chose to delete uploaded picture by clicking on it
        private void pictureLabel1_Click(object sender, EventArgs e)
        {
            if (pictureLabel1.Text.Trim().Equals(noPictureText)) { return; }
            if (MessageBox.Show("Remove picture?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                uploadFile1 = "";       
                if (pictureLabel2.Text.Equals(""))
                {
                    pictureLabel1.Text = noPictureText;
                    uploadFile1 = "";
                }
                else
                {
                    pictureLabel1.Text = pictureLabel2.Text;
                    pictureLabel2.Text = "";
                    uploadFile1 = uploadFile2;
                    uploadFile2 = "";
                }
            }
            else
            {
                return;
            }           
        }
        private void pictureLabel2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove picture?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    pictureLabel2.Text = "";
                    uploadFile2 = "";
            }
            else
            {
                return;
            }
        }
        private void uploadMusicLabel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                uploadMusicLabel.Text = "";
                uploadFileMusic = "";
            }
            else
            {
                return;
            }
        }

        // remove "<enter text>" in prompt box when user clicks in first time
        private void boldPromptBox_Click(object sender, EventArgs e)
        {
            if (boldPromptBox.Text.Equals("<enter text>"))
            {
                boldPromptBox.Text = "";
            }
        }

        // making clickable labels turn blue when you mouse over them. 
        private void turnTextBlue(object sender, EventArgs e)
        {
            if (sender.Equals(pictureLabel1))
            {
                pictureLabel1.ForeColor = System.Drawing.Color.Cyan;       
            }
            else if (sender.Equals(pictureLabel2))
            {
                pictureLabel2.ForeColor = System.Drawing.Color.Cyan;
            }
            else if (sender.Equals(ideasLabel))
            {
                ideasLabel.ForeColor = System.Drawing.Color.Cyan;
            }
            else if (sender.Equals(uploadMusicLabel)) 
            {
                uploadMusicLabel.ForeColor = System.Drawing.Color.Cyan;
            }
        }
        private void turnTextGray(object sender, EventArgs e)
        {
            if (sender.Equals(pictureLabel1))
            {
                pictureLabel1.ForeColor = System.Drawing.Color.Gray;
            }
            else if (sender.Equals(pictureLabel2))
            {
                pictureLabel2.ForeColor = System.Drawing.Color.Gray;
            }
            else if (sender.Equals(uploadMusicLabel))
            {
                uploadMusicLabel.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void turnTextBlack(object sender, EventArgs e)
        {
            ideasLabel.ForeColor = System.Drawing.Color.Black;
        }



    }
}
