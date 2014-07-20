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
    public partial class BasicTextPromptForm : Form
    {

        public int flashSpeed = 500;
        public int secondSpeed = 1000;
        public int mouseTimerInterval = 100;
        public List<string> categories;
        private int currentExtension;
        public string boldPrompt;
        public int promptNumber;
        public string promptCategory;
        public string promptTag;
        public string fileToUpload;
        public string picture1;
        public string picture2;
   
        public BasicTextPromptForm()
        {
            InitializeComponent();
            categories = new List<string>();
            richTextBox1.Visible = false;
            currentExtension = 0;
        }

        public void InitializePrompt(BasicTextPrompt input) 
        {
            timer1.Stop();

            // reset basic format
            boldPromptBox.Font = new Font(boldPromptBox.Font.FontFamily, 12, FontStyle.Bold);
            uploadPictureLabel.Visible = false;
            uploadedFileLabel.Text = "";
            fileToUpload = "";
            richTextBox1.Text = "<enter text>";
            this.picture1 = ""; this.picture2 = "";
            pictureBoxCenter.Visible = false;
            pictureBoxCenter.Size = new Size(10, 10);
            pictureBox1.Visible = false;
            pictureBox1.Size = new Size(10, 10);
            pictureBox2.Visible = false;
            pictureBox2.Size = new Size(10, 10);
            // reduce extension if currently extended
            this.Height = this.Height - currentExtension;
            currentExtension = 0;

            // pull prompt contents
            this.promptTag = input.tag;
            this.promptCategory = input.category;
            this.boldPrompt = input.boldPrompt;
            this.picture1 = input.picture1;
            this.picture2 = input.picture2;
            promptTypeLabel.Text = input.creativityType + " Thinking";
            boldPromptBox.Text = input.boldPrompt;

            if (input.useUploadPicture == true)
            {
                uploadPictureLabel.Visible = true;
            }

            // if one picture, add and center it
            if (!picture1.Trim().Equals("") && picture2.Trim().Equals(""))
            {
                pictureBoxCenter.Visible = true;
                Bitmap image = new Bitmap(this.picture1);
                List<int> scaling = findPictureScale(this.picture1);
                image = new Bitmap(image, new Size(scaling[0], scaling[1]));
                pictureBoxCenter.Image = image;
                pictureBoxCenter.Size = pictureBoxCenter.Image.Size;
                this.Height = this.Height + scaling[1];
                currentExtension = currentExtension + scaling[1];
            }
            // if two pictures, place them side by side
            else if (!picture1.Trim().Equals("") && !picture2.Trim().Equals(""))
            {
                pictureBox1.Visible = true; pictureBox2.Visible = true; 

                Bitmap image1 = new Bitmap(picture1);
                List<int> scaling1 = findPictureScale(picture1);
                image1 = new Bitmap(image1, new Size(scaling1[0], scaling1[1]));
                pictureBox1.Image = image1;
                pictureBox1.Size = pictureBox1.Image.Size;

                Bitmap image2 = new Bitmap(picture2);
                List<int> scaling2 = findPictureScale(picture2);
                image2 = new Bitmap(image2, new Size(scaling2[0], scaling2[1]));
                pictureBox2.Image = image2;
                pictureBox2.Size = pictureBox2.Image.Size;

                // see which one is taller and resize form to fit
                this.Height = this.Height + scaling1[1];
                currentExtension = currentExtension + scaling1[1];
            }
            // if prompt is big, reduce font size
            if (boldPromptBox.Text.Length > 200) { boldPromptBox.Font = new Font(boldPromptBox.Font.FontFamily, 11); }
            if (boldPromptBox.Text.Length > 300) { boldPromptBox.Font = new Font(boldPromptBox.Font.FontFamily, 9); }

            greyPromptBox.Text = input.greyPrompt;
            timeLabel.Text = input.suggestedTime + ":00";
            richTextBox1.Visible = true;
            timer1.Start();
        }

        List<int> findPictureScale(string fileName)
        {
            List<int> result = new List<int>();
            Bitmap image = new Bitmap(fileName);
            float width = Constants.maxPictureWidth;
            float height = Constants.maxPictureHeight;
            float scale = Math.Min(width / image.Width, height / image.Height);
            int scaleWidth = (int)(image.Width * scale);
            int scaleHeight = (int)(image.Height * scale);
            result.Add(scaleWidth);
            result.Add(scaleHeight);
            return result;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // save text results
            string text = this.richTextBox1.Rtf;
            if (!richTextBox1.Text.Equals("<enter text>") && !richTextBox1.Text.Trim().Equals(""))
            {
                Functions.saveTextPromptResults(this.promptTag, this.boldPrompt, text);
            }
            this.richTextBox1.Clear();

            // save picture result
            if (fileToUpload.Length > 0)
            {
                Functions.savePictureResult(this.promptCategory, this.fileToUpload);
            }

            generateNewPrompt();
        }

        virtual public void skipButton_Click(object sender, EventArgs e)
        {
            generateNewPrompt();
        }

        // generate a new prompt without destroying or reloading form
        private void generateNewPrompt()
        {
            PromptGenerator generator = new PromptGenerator(categories);
            BasicTextPrompt newPrompt = generator.findAPrompt(categories);
            if (newPrompt.ERROR == true)
            {
                Console.WriteLine("BasicTextPromptForm.generateNewPrompt() : Error - failed to make new prompt");
                MessageBox.Show("Error generating prompt. Please try again.");
                return;
            }
            InitializePrompt(newPrompt);
        }


        // THE FOLLOWING FUNCTIONS CONTROL THE TIMER
//---------------------------------------------------------------------------------------------------
        private void incrementTime(int numSeconds)
        {
            // amount is in seconds
            int addedSeconds = numSeconds % 60;
            int addedMinutes = numSeconds / 60;

            string[] tokens = timeLabel.Text.Split(':');
            if (tokens.Length != 2) { return; }
            int currentMin = Convert.ToInt32(tokens[0]);
            int currentSec = Convert.ToInt32(tokens[1]);

            // when jumping by 30 (for holding button down), round to nearest 30 first
            if (numSeconds == 30)
            {
                if (currentSec > 30) { currentSec = 0; currentMin++; }
                if (currentSec > 0 && currentSec < 30) { currentSec = 30; }
            }

            // add new time to old
            if (currentSec + addedSeconds < 60)
            {
                currentSec += addedSeconds;
            }
            else if (currentSec + addedSeconds > 59)
            {
                currentSec = currentSec + addedSeconds - 60;
                currentMin++;
            }
            currentMin = currentMin + addedMinutes;
            printTime(currentMin,currentSec);
        }

        private void decrementTime(int numSeconds) 
        {

            int reducedSeconds = numSeconds % 60;
            int reducedMinutes = numSeconds / 60;

            string[] tokens = timeLabel.Text.Split(':');
            int currentMin = Convert.ToInt32(tokens[0]);
            int currentSec = Convert.ToInt32(tokens[1]);

            // when jumping by 30 (for holding button down), round to nearest 30 first
            if (numSeconds == 30)
            {
                if (currentSec > 30) { currentSec = 30; }
                if (currentSec > 0 && currentSec < 30) { currentSec = 0; }
            }

            // subtract time
            if (currentSec - reducedSeconds >=0)
            {
                currentSec -= reducedSeconds;
            }
            else if (currentSec - reducedSeconds < 0 && currentMin > 0)
            {
                currentSec = currentSec - reducedSeconds + 60;
                currentMin--;
            }

            // if it's at zero, set it to flashing
            if (currentMin <= 0 && currentSec <= 0)
            {
                timeLabel.Text = "0:00";
                timer1.Interval = flashSpeed;
                return;
            }

            printTime(currentMin,currentSec);
        }

        // update time label text
        private void printTime(int min, int sec)
        {
            string output;
            if (sec < 10)
            {
                output = min + ":0" + sec;
            }
            else
            {
                output = min + ":" + sec;
            }
            timeLabel.Text = output;
        }

        // single click of +/- increments/decrements by 30 seconds
        private void plusButton_Click(object sender, EventArgs e)
        {
            incrementTime(30);
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            decrementTime(30);
        }

        // timer1 counts down the seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if the interval is flashSpeed, then time is out, so just make it flash
            if (timer1.Interval == flashSpeed) {
                if (timeLabel.Text == "0:00") { timeLabel.Text = "";}
                else if (timeLabel.Text == "") { timeLabel.Text = "0:00";}
                return;
            }
            // if the interval is secondSpeed, then there is still time available, so decrement by 1
            if (timer1.Interval == secondSpeed) {
                decrementTime(1);
            }
        }

        // if user hits clear on the time, just set it to 0:00. Don't bother flashing
        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timeLabel.Text = "0:00";
        }

        // when holding mouse on timer up/down, set timer to increment/decrement at constant pace
        private void timerButton_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            mouseTimer.Interval = mouseTimerInterval;
            mouseTimer.Start();

        }
        // when user releases mouse, end increment/decrementing
        private void timerButton_MouseUp(object sender, MouseEventArgs e)
        {
            mouseTimer.Stop();
            if (!timer1.Enabled)
            {
                timer1.Interval = secondSpeed;
                timer1.Start();
            }
            timer1.Start();
        }
        // timer that controls how fast time is incremented/decremented when held
        private void mouseTimer_Tick(object sender, EventArgs e)
        {
            if (plusButton.Focused)
            {
                incrementTime(30);
            }
            else if (minusButton.Focused)
            {
                decrementTime(30);
            }
        }


// Basic formatting/appearance stuff
//-----------------------------------------------------------------------------------------
        // Make the submit button blue when you hover over it
        private void submitButton_MouseEnter(object sender, EventArgs e)
        {
            submitButton.ForeColor = System.Drawing.Color.Cyan;
        }
        private void submitButton_MouseLeave(object sender, EventArgs e)
        {   
            submitButton.ForeColor = System.Drawing.Color.Black;
        }

        // Make the Upload Picture button blue when you hover over it
        private void uploadPictureLabel_MouseEnter(object sender, EventArgs e)
        {
            uploadPictureLabel.ForeColor = System.Drawing.Color.Cyan;
        }
        private void uploadPictureLabel_MouseLeave(object sender, EventArgs e)
        {
            uploadPictureLabel.ForeColor = System.Drawing.Color.Black;
        }

        // first time user clicks on box, remove <enter text> prompt
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Equals("<enter text>")) { richTextBox1.Text = ""; }
        }

        // Hack to get Tab working (as opposed to scrolling through buttons)
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab) return false;
            return base.ProcessDialogKey(keyData);
        }

        // Implement rich text keyboard shortcuts (Bold, Italic, Underline, Bullets, Tab, Red font)
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle Toggle Bold
            if (e.Control && e.KeyCode.ToString() == "B")
            {
                if (richTextBox1.SelectionFont != null)
                {
                    System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    if (richTextBox1.SelectionFont.Bold == true)
                    {
                        newFontStyle = FontStyle.Regular;
                    }
                    else
                    {
                        newFontStyle = FontStyle.Bold;
                    }
                    richTextBox1.SelectionFont = new Font(
                        currentFont.FontFamily,
                        currentFont.Size,
                        newFontStyle
                     );
                }

            }
            // Handle Toggle Italic
            if (e.Control && e.KeyCode.ToString() == "I")
            {
                if (richTextBox1.SelectionFont != null)
                {
                    System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    if (richTextBox1.SelectionFont.Italic == true)
                    {
                        newFontStyle = FontStyle.Regular;
                    }
                    else
                    {
                        newFontStyle = FontStyle.Italic;
                    }

                    richTextBox1.SelectionFont = new Font(
                       currentFont.FontFamily,
                       currentFont.Size,
                       newFontStyle
                    );
                    // This is used to suppress the build in indent response of RichTextBox
                    e.SuppressKeyPress = true;
                }
            }
            // Handle Toggle Underline
            if (e.Control && e.KeyCode.ToString() == "U")
            {
                if (richTextBox1.SelectionFont != null)
                {
                    System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    if (richTextBox1.SelectionFont.Underline == true)
                    {
                        newFontStyle = FontStyle.Regular;
                    }
                    else
                    {
                        newFontStyle = FontStyle.Underline;
                    }

                    richTextBox1.SelectionFont = new Font(
                       currentFont.FontFamily,
                       currentFont.Size,
                       newFontStyle
                    );
                }
            }
            // Handle Toggle Red font
            if (e.Control && e.Shift && e.KeyCode.ToString() == "R")
            {
                if (richTextBox1.SelectionFont != null)
                {
                    Color currentFont = richTextBox1.SelectionColor;

                    if (richTextBox1.SelectionColor == Color.Red)
                    {
                        richTextBox1.SelectionColor = Color.Black;
                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Red;
                    }
                }
            }
            // Handle Bulleted List
            if (e.Control && e.KeyCode.ToString() == "Q")
            {
                //if (richTextBox1.SelectionFont != null)
                //{
                if (richTextBox1.SelectionBullet == true)
                {
                    richTextBox1.SelectionBullet = false;
                    richTextBox1.SelectionIndent = 0;
                }
                else
                {
                    richTextBox1.SelectionBullet = true;
                }
                //}
            }
            // Handle tab indention 
            if (e.KeyCode.ToString() == "\t")
            {
                if (richTextBox1.SelectionFont != null)
                {
                    if (richTextBox1.SelectionBullet == false)
                    {

                        richTextBox1.AppendText("     ");
                    }
                    if (richTextBox1.SelectionBullet == true)
                    {
                        MessageBox.Show("Got here");
                        richTextBox1.BulletIndent = 8;
                    }
                }
            }
        }

        // User clicks Upload Picture; allow them to select a file
        private void uploadPictureLabel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Constants.initialPictureUploadDirectory;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                if (!System.IO.File.Exists(fileName))
                {
                    MessageBox.Show("File " + fileName + " does not exist");
                    return;
                }
                uploadedFileLabel.Text = System.IO.Path.GetFileName(fileName);
                fileToUpload = fileName;
            }

        }

        private void BasicTextPromptForm_Resize(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_Resize(object sender, EventArgs e)
        {
            //int added = richTextBox1.Height - richTextBox1.PreferredHeight;
            //this.Height = this.Height + added;
            //this.currentExtension = currentExtension + added;
        }
    }
}
