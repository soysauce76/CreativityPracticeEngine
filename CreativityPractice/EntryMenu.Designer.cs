namespace CreativityPractice
{
    partial class EntryMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.genreCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.createNewPromptsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startButton.Location = new System.Drawing.Point(245, 318);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(146, 48);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.mouseOverStart);
            this.startButton.MouseLeave += new System.EventHandler(this.mouseLeavesStart);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "What would you like to practice?";
            // 
            // genreCheckedListBox
            // 
            this.genreCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genreCheckedListBox.CheckOnClick = true;
            this.genreCheckedListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.genreCheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreCheckedListBox.FormattingEnabled = true;
            this.genreCheckedListBox.HorizontalScrollbar = true;
            this.genreCheckedListBox.Location = new System.Drawing.Point(264, 179);
            this.genreCheckedListBox.Name = "genreCheckedListBox";
            this.genreCheckedListBox.Size = new System.Drawing.Size(137, 133);
            this.genreCheckedListBox.TabIndex = 2;
            this.genreCheckedListBox.UseCompatibleTextRendering = true;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(91, 56);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(465, 29);
            this.welcomeLabel.TabIndex = 3;
            this.welcomeLabel.Text = "Welcome to the Creativity Practice Engine!";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createNewPromptsLabel
            // 
            this.createNewPromptsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createNewPromptsLabel.AutoSize = true;
            this.createNewPromptsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewPromptsLabel.Location = new System.Drawing.Point(17, 341);
            this.createNewPromptsLabel.Name = "createNewPromptsLabel";
            this.createNewPromptsLabel.Size = new System.Drawing.Size(120, 15);
            this.createNewPromptsLabel.TabIndex = 4;
            this.createNewPromptsLabel.Text = "Create New Prompts";
            this.createNewPromptsLabel.Click += new System.EventHandler(this.createNewPromptsLabel_Click);
            this.createNewPromptsLabel.MouseEnter += new System.EventHandler(this.createNewPromptsLabel_MouseEnter);
            this.createNewPromptsLabel.MouseLeave += new System.EventHandler(this.createNewPromptsLabel_MouseLeave);
            // 
            // EntryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(632, 368);
            this.Controls.Add(this.createNewPromptsLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.genreCheckedListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Name = "EntryMenu";
            this.Text = "Creativity Practice Engine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox genreCheckedListBox;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label createNewPromptsLabel;
    }
}

