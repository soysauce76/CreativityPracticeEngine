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
    public partial class EntryMenu : Form
    {

        public string promptFiles = "C:/Users/Owner/Desktop/creativityPrompts";

        public EntryMenu()
        {
            InitializeComponent();
            // Sets up the initial objects in the CheckedListBox. 
            //string[] myGenres = { "Art", "Writing", "Poetry", "Music" };
            string[] myGenres = Constants.categories;
            genreCheckedListBox.Items.AddRange(myGenres);
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            // turn start button blue cuz it looks good
            startButton.ForeColor = System.Drawing.Color.Cyan;

            // find out which categories were selected
            List<string> checkedItemsList = new List<string>();
            for (int i = 0; i <= (genreCheckedListBox.Items.Count - 1); i++)
            {
                if (genreCheckedListBox.GetItemChecked(i))
                {
                    checkedItemsList.Add(genreCheckedListBox.Items[i].ToString());
                }
            }
            // if user did not select a category, warn them and exit.
            if (checkedItemsList.Count < 1)
            {
                MessageBox.Show("Please select a category!");

                return;
            }

            // otherwise, generate a prompt to match
            PromptGenerator promptGenerator = new PromptGenerator(checkedItemsList);
            promptGenerator.generatePrompt();
        }

        private void mouseOverStart(object sender, EventArgs e)
        {
            startButton.ForeColor = System.Drawing.Color.Cyan;
        }
        private void mouseLeavesStart(object sender, EventArgs e)
        {
            startButton.ForeColor = System.Drawing.Color.Black;
        }
        private void createNewPromptsLabel_MouseEnter(object sender, EventArgs e)
        {
            createNewPromptsLabel.ForeColor = System.Drawing.Color.Cyan;
        }
        private void createNewPromptsLabel_MouseLeave(object sender, EventArgs e)
        {
            createNewPromptsLabel.ForeColor = System.Drawing.Color.Black;
        }

        private void createNewPromptsLabel_Click(object sender, EventArgs e)
        {
            // pop open new form 
            CreateNewPromptsForm creation = new CreateNewPromptsForm();
            if (creation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
        }


    }
}
