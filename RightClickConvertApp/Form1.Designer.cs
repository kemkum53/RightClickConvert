namespace RightClickConvertApp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            cmb_type = new ComboBox();
            btn_convert = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lbl_converting = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Select Type";
            // 
            // cmb_type
            // 
            cmb_type.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_type.FormattingEnabled = true;
            cmb_type.Items.AddRange(new object[] { "mp4", "mp4(h264)", "mp4(h265)", "mp4(mpeg4)", "avi", "mp3", "wav" });
            cmb_type.Location = new Point(83, 10);
            cmb_type.Name = "cmb_type";
            cmb_type.Size = new Size(118, 23);
            cmb_type.TabIndex = 1;
            // 
            // btn_convert
            // 
            btn_convert.Location = new Point(207, 10);
            btn_convert.Name = "btn_convert";
            btn_convert.Size = new Size(93, 23);
            btn_convert.TabIndex = 2;
            btn_convert.Text = "Convert";
            btn_convert.UseVisualStyleBackColor = true;
            btn_convert.Click += btn_convert_Click;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // lbl_converting
            // 
            lbl_converting.AutoSize = true;
            lbl_converting.Enabled = false;
            lbl_converting.Location = new Point(12, 37);
            lbl_converting.Name = "lbl_converting";
            lbl_converting.Size = new Size(57, 15);
            lbl_converting.TabIndex = 3;
            lbl_converting.Text = "Waiting...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 60);
            Controls.Add(lbl_converting);
            Controls.Add(btn_convert);
            Controls.Add(cmb_type);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Convert Video";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_convert;
        private System.Windows.Forms.Timer timer1;
        private Label lbl_converting;
        public ComboBox cmb_type;
    }
}
