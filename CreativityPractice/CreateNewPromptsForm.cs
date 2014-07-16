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
        public CreateNewPromptsForm()
        {
            InitializeComponent();
            //string[] myGenres = { "Art", "Writing", "Poetry", "Music" };
            string[] myGenres = Constants.categories;
            categoryListBox.Items.AddRange(myGenres);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int success = checkInput();
            if (success != 0)
            {
                Console.WriteLine("CreateNewPromptsForm.createButton_Click: input not formatted correctly. Returning.");
                return;
            }
            if (convergentCheckBox.Checked && !divergentCheckBox.Checked)
            {
                // handle convergent
            }
            else if (!convergentCheckBox.Checked && divergentCheckBox.Checked)
            {
                // handle divergent
            }
            // find out which category was selected (should only be one)
            if (categoryListBox.CheckedItems.Count == 0) { return; }
            string category = categoryListBox.CheckedItems[0].ToString();

            //List<string> checkedItemsList = new List<string>();
            //for (int i = 0; i < categoryListBox.Items.Count; i++)
            //{
            //    if (categoryListBox.GetItemChecked(i))
            //    {
            //        checkedItemsList.Add(categoryListBox.Items[i].ToString());
            //    }
            //}
            MessageBox.Show("You clicked Create!");
        }

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

            // Make sure user entered a prompt
            if (boldPromptBox.Text.Equals("<enter text>") || boldPromptBox.Text.Trim().Equals(""))
            {
                errorString = errorString + "-Please enter a prompt" + "\n\n";
                success = -1;
            }


            if (success != 0)
            {
                MessageBox.Show(errorString);
            }

            return success;
        }

        private void ideasLabel_MouseEnter(object sender, EventArgs e)
        {
            ideasLabel.ForeColor = System.Drawing.Color.Cyan;
        }
        private void ideasLabel_MouseLeave(object sender, EventArgs e)
        {
            ideasLabel.ForeColor = System.Drawing.Color.Black;
        }

        private void ideasLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Come up with your own damn ideas, lazy ass");
        }
    }
}
