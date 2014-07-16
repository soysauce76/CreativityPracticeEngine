namespace CreativityPractice
{
    partial class BasicTextPromptForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clearTimeButton = new System.Windows.Forms.Label();
            this.promptTypeLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.TextBox();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.mouseTimer = new System.Windows.Forms.Timer(this.components);
            this.submitButton = new System.Windows.Forms.Button();
            this.skipButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.boldPromptBox = new System.Windows.Forms.TextBox();
            this.greyPromptBox = new System.Windows.Forms.TextBox();
            this.uploadPictureLabel = new System.Windows.Forms.Label();
            this.uploadedFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clearTimeButton
            // 
            this.clearTimeButton.AutoSize = true;
            this.clearTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTimeButton.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.clearTimeButton.Location = new System.Drawing.Point(515, 62);
            this.clearTimeButton.Name = "clearTimeButton";
            this.clearTimeButton.Size = new System.Drawing.Size(52, 16);
            this.clearTimeButton.TabIndex = 1;
            this.clearTimeButton.Text = "<clear>";
            this.clearTimeButton.Click += new System.EventHandler(this.label1_Click);
            // 
            // promptTypeLabel
            // 
            this.promptTypeLabel.AutoSize = true;
            this.promptTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.promptTypeLabel.Location = new System.Drawing.Point(27, 17);
            this.promptTypeLabel.Name = "promptTypeLabel";
            this.promptTypeLabel.Size = new System.Drawing.Size(121, 18);
            this.promptTypeLabel.TabIndex = 2;
            this.promptTypeLabel.Text = "Prompt type here";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeLabel.Enabled = false;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(467, 17);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.ReadOnly = true;
            this.timeLabel.Size = new System.Drawing.Size(100, 42);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "0:00";
            this.timeLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // plusButton
            // 
            this.plusButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusButton.Location = new System.Drawing.Point(573, 12);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(23, 23);
            this.plusButton.TabIndex = 4;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            this.plusButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.timerButton_MouseDown);
            this.plusButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timerButton_MouseUp);
            // 
            // minusButton
            // 
            this.minusButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minusButton.Location = new System.Drawing.Point(573, 36);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(23, 23);
            this.minusButton.TabIndex = 5;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            this.minusButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.timerButton_MouseDown);
            this.minusButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timerButton_MouseUp);
            // 
            // mouseTimer
            // 
            this.mouseTimer.Interval = 50;
            this.mouseTimer.Tick += new System.EventHandler(this.mouseTimer_Tick);
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.submitButton.AutoSize = true;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(232, 380);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(119, 41);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            this.submitButton.MouseEnter += new System.EventHandler(this.submitButton_MouseEnter);
            this.submitButton.MouseLeave += new System.EventHandler(this.submitButton_MouseLeave);
            // 
            // skipButton
            // 
            this.skipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skipButton.FlatAppearance.BorderSize = 0;
            this.skipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skipButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.skipButton.Location = new System.Drawing.Point(493, 388);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(101, 30);
            this.skipButton.TabIndex = 7;
            this.skipButton.Text = "Skip >>";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(30, 216);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(552, 158);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "<enter text>";
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // boldPromptBox
            // 
            this.boldPromptBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boldPromptBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boldPromptBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldPromptBox.Location = new System.Drawing.Point(30, 82);
            this.boldPromptBox.Multiline = true;
            this.boldPromptBox.Name = "boldPromptBox";
            this.boldPromptBox.ReadOnly = true;
            this.boldPromptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boldPromptBox.Size = new System.Drawing.Size(537, 84);
            this.boldPromptBox.TabIndex = 11;
            this.boldPromptBox.Text = "Bold Prompt";
            // 
            // greyPromptBox
            // 
            this.greyPromptBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.greyPromptBox.BackColor = System.Drawing.SystemColors.Window;
            this.greyPromptBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.greyPromptBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greyPromptBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.greyPromptBox.Location = new System.Drawing.Point(30, 172);
            this.greyPromptBox.Multiline = true;
            this.greyPromptBox.Name = "greyPromptBox";
            this.greyPromptBox.ReadOnly = true;
            this.greyPromptBox.Size = new System.Drawing.Size(537, 32);
            this.greyPromptBox.TabIndex = 12;
            this.greyPromptBox.Text = "Grey Prompt";
            // 
            // uploadPictureLabel
            // 
            this.uploadPictureLabel.AutoSize = true;
            this.uploadPictureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadPictureLabel.Location = new System.Drawing.Point(27, 380);
            this.uploadPictureLabel.Name = "uploadPictureLabel";
            this.uploadPictureLabel.Size = new System.Drawing.Size(97, 16);
            this.uploadPictureLabel.TabIndex = 13;
            this.uploadPictureLabel.Text = "Upload Picture";
            this.uploadPictureLabel.Visible = false;
            this.uploadPictureLabel.Click += new System.EventHandler(this.uploadPictureLabel_Click);
            this.uploadPictureLabel.MouseEnter += new System.EventHandler(this.uploadPictureLabel_MouseEnter);
            this.uploadPictureLabel.MouseLeave += new System.EventHandler(this.uploadPictureLabel_MouseLeave);
            // 
            // uploadedFileLabel
            // 
            this.uploadedFileLabel.AutoSize = true;
            this.uploadedFileLabel.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.uploadedFileLabel.Location = new System.Drawing.Point(37, 405);
            this.uploadedFileLabel.Name = "uploadedFileLabel";
            this.uploadedFileLabel.Size = new System.Drawing.Size(0, 13);
            this.uploadedFileLabel.TabIndex = 14;
            // 
            // BasicTextPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(606, 433);
            this.Controls.Add(this.uploadedFileLabel);
            this.Controls.Add(this.uploadPictureLabel);
            this.Controls.Add(this.greyPromptBox);
            this.Controls.Add(this.boldPromptBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.promptTypeLabel);
            this.Controls.Add(this.clearTimeButton);
            this.Name = "BasicTextPromptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creativity Practice Engine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label clearTimeButton;
        private System.Windows.Forms.Label promptTypeLabel;
        private System.Windows.Forms.TextBox timeLabel;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Timer mouseTimer;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox greyPromptBox;
        private System.Windows.Forms.TextBox boldPromptBox;
        private System.Windows.Forms.Label uploadPictureLabel;
        private System.Windows.Forms.Label uploadedFileLabel;
    }
}