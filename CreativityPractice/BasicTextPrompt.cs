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
        public System.Windows.Forms.PictureBox picture1;
        public System.Windows.Forms.PictureBox picture2;
        public System.Windows.Forms.PictureBox picture3;
        public System.Windows.Forms.PictureBox picture4;
        public System.Windows.Forms.PictureBox picture5;

        public string category;
        public string creativityType;
        public string type;
        public int num;

        public int suggestedTime;

        public string boldPrompt;
        public string greyPrompt;

        public BasicTextPrompt()
        {
            ERROR = false;
            category = "unspecified";
            creativityType = "unspecified";
            type = "unspecified";
            suggestedTime = 0;
            boldPrompt = "uninitialized";
            greyPrompt = "uninitialized";
            useUploadPicture = true;
        }

        public BasicTextPrompt(int pictures, bool text, string newCategory, string newCreativityType, string newType, int newTime, string newBoldPrompt, string newGreyPrompt)
        {
            useUploadPicture = true;  // TEMPORARY
            ERROR = false; 
            // initialize picture boxes if necessary
            if (pictures > 0) { picture1 = new System.Windows.Forms.PictureBox(); }
            if (pictures > 1) { picture2 = new System.Windows.Forms.PictureBox(); }
            if (pictures > 2) { picture3 = new System.Windows.Forms.PictureBox(); }
            if (pictures > 3) { picture4 = new System.Windows.Forms.PictureBox(); }
            if (pictures > 4) { picture5 = new System.Windows.Forms.PictureBox(); }
            // initialize text box if necesary
            if (text == true) {
                this.useTextBox = true;
            }

            // initialize prompt values
            this.category = newCategory;
            this.creativityType = newCreativityType;
            this.type = newType;
            this.suggestedTime = newTime;
            this.boldPrompt = newBoldPrompt;
            this.greyPrompt = newGreyPrompt;
            this.num = 1;
        }
    }
}
