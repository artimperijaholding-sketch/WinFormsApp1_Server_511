namespace WinFormsApp1Server
{
    partial class FormServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStart = new Button();
            buttonSend = new Button();
            textBoxInput = new TextBox();
            textBoxOutput = new TextBox();
            buttonPing = new Button();
            listBoxClients = new ListBox();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 21);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(525, 271);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(12, 50);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ReadOnly = true;
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(464, 189);
            textBoxInput.TabIndex = 2;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(12, 272);
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(498, 23);
            textBoxOutput.TabIndex = 3;
            // 
            // buttonPing
            // 
            buttonPing.Location = new Point(241, 21);
            buttonPing.Name = "buttonPing";
            buttonPing.Size = new Size(75, 23);
            buttonPing.TabIndex = 4;
            buttonPing.Text = "Send Ping";
            buttonPing.UseVisualStyleBackColor = true;
            buttonPing.Click += buttonPing_Click;
            // 
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.Location = new Point(482, 50);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.SelectionMode = SelectionMode.MultiExtended;
            listBoxClients.Size = new Size(118, 184);
            listBoxClients.TabIndex = 5;
            listBoxClients.MouseDown += listBoxClients_MouseDown;
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 307);
            Controls.Add(listBoxClients);
            Controls.Add(buttonPing);
            Controls.Add(textBoxOutput);
            Controls.Add(textBoxInput);
            Controls.Add(buttonSend);
            Controls.Add(buttonStart);
            Name = "FormServer";
            Text = "FormServer";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button buttonStart;
        private Button buttonSend;
        private TextBox textBoxInput;
        private TextBox textBoxOutput;
        private Button buttonPing;
        private ListBox listBoxClients;
    }
}
