namespace WinFormsApp1Klient
{
    partial class FormKlient
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
            buttonConnect = new Button();
            buttonSend = new Button();
            textBoxOutput = new TextBox();
            textBoxInput = new TextBox();
            SuspendLayout();
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(12, 252);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(75, 23);
            buttonConnect.TabIndex = 0;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(537, 252);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(111, 252);
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(407, 23);
            textBoxOutput.TabIndex = 2;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(12, 12);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(600, 234);
            textBoxInput.TabIndex = 3;
            // 
            // FormKlient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 287);
            Controls.Add(textBoxInput);
            Controls.Add(textBoxOutput);
            Controls.Add(buttonSend);
            Controls.Add(buttonConnect);
            Name = "FormKlient";
            Text = "FormKlient";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button buttonConnect;
        private Button buttonSend;
        private TextBox textBoxOutput;
        private TextBox textBoxInput;
    }
}
