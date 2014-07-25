using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativityPractice
{
    class PromptGenerator
    {
        public List<string> categories;


        // constructors
        public PromptGenerator()
        {
            categories = new List<string>();
        }
        public PromptGenerator(List<string> cat)
        {
            categories = cat;
        }

        public void generatePrompt()
        {
            // find a prompt to match
            BasicTextPrompt myPrompt = findAPrompt(categories);

            // if there was a problem finding a prompt, exit
            if (myPrompt.ERROR)
            {
                Console.WriteLine("startButton_Click(): myPrompt.ERROR = true");
                return;
            }
            // otherwise, set up a new prompt windows form and run it
            BasicTextPromptForm promptTest = new BasicTextPromptForm();
            //FancyTextPromptForm promptTest = new FancyTextPromptForm();
            promptTest.InitializePrompt(myPrompt);
            promptTest.categories = this.categories;
            promptTest.ShowDialog();
        }

        public BasicTextPrompt findAPrompt(List<string> categories)
        {
            BasicTextPrompt newPrompt = new BasicTextPrompt();

            // pick a random category
            Random rnd = new Random();
            int categoryIndex = rnd.Next(categories.Count);
            string category = categories[categoryIndex]; 

            string fullPath = Functions.getCategoryFileName(category);
            Console.WriteLine("path for prompt files: " + fullPath);

            // if path to desired category returned an error, return
            if (fullPath.Contains("ERROR"))
            {
                System.Windows.Forms.MessageBox.Show("Error - failed to generate prompt for category " + category);
                newPrompt.ERROR = true;
                return newPrompt;
            }

            // find available prompts in prompt file
            List<string> availablePrompts = Functions.getPromptsFromFile(fullPath);
            //foreach (string prompt in availablePrompts)
            //{
            //    //Console.WriteLine(prompt);
            //}

            // if no prompts, return error
            if (availablePrompts.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No available prompts for category " + category + ". Please create some!");
                newPrompt.ERROR = true;
                return newPrompt;
            }

            // pick one using a random number
            int numAvailablePrompts = availablePrompts.Count;
            if (numAvailablePrompts < 1)
            {
                System.Windows.Forms.MessageBox.Show("No prompts available for category " + category);
                newPrompt.ERROR = true;
                return newPrompt;
            }

            Random rnd2 = new Random();
            int choiceIndex = rnd2.Next(0, numAvailablePrompts);
            string choicePrompt = availablePrompts[choiceIndex];
            Console.WriteLine("chosen file = " + choicePrompt);

            // process the prompt
            newPrompt = BasicTextPrompt.parsePrompt(choicePrompt, category);

            // return the final prompt
            return newPrompt;
        }

    }
}
