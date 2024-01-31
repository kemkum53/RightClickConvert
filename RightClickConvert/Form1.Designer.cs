namespace RightClickConvert
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBox1 = new RichTextBox();
            chb_confirm = new CheckBox();
            btn_start = new Button();
            prg_progress = new ProgressBar();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(260, 177);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // chb_confirm
            // 
            chb_confirm.AutoSize = true;
            chb_confirm.Location = new Point(12, 195);
            chb_confirm.Name = "chb_confirm";
            chb_confirm.Size = new Size(138, 19);
            chb_confirm.TabIndex = 1;
            chb_confirm.Text = "I have read and agree";
            chb_confirm.UseVisualStyleBackColor = true;
            chb_confirm.CheckedChanged += chb_confirm_CheckedChanged;
            // 
            // btn_start
            // 
            btn_start.Enabled = false;
            btn_start.Location = new Point(161, 220);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(111, 23);
            btn_start.TabIndex = 2;
            btn_start.Text = "Start Installation";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // prg_progress
            // 
            prg_progress.Location = new Point(12, 249);
            prg_progress.Name = "prg_progress";
            prg_progress.Size = new Size(260, 23);
            prg_progress.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 284);
            Controls.Add(prg_progress);
            Controls.Add(btn_start);
            Controls.Add(chb_confirm);
            Controls.Add(richTextBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "RightClickConvert";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private CheckBox chb_confirm;
        private Button btn_start;
        private ProgressBar prg_progress;
    }
}
