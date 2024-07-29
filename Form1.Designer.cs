using System.Windows.Forms;

namespace Compare
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
            K9RichTextBox = new RichTextBox();
            UWRichTextBox = new RichTextBox();
            Check_Btn = new Button();
            LB_K9 = new Label();
            LB_UW = new Label();
            K9_Clear_Btn = new Button();
            UW_Clear_Btn = new Button();
            SuspendLayout();
            // 
            // K9RichTextBox
            // 
            K9RichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            K9RichTextBox.BackColor = SystemColors.Info;
            K9RichTextBox.BorderStyle = BorderStyle.None;
            K9RichTextBox.Location = new Point(12, 71);
            K9RichTextBox.Name = "K9RichTextBox";
            K9RichTextBox.Size = new Size(374, 378);
            K9RichTextBox.TabIndex = 0;
            K9RichTextBox.Text = "";
            K9RichTextBox.ContextMenuStripChanged += RichTextContextMenu;
            K9RichTextBox.MouseDown += K9RichTextBox_MouseDown;
            // 
            // UWRichTextBox
            // 
            UWRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            UWRichTextBox.BackColor = SystemColors.Info;
            UWRichTextBox.BorderStyle = BorderStyle.None;
            UWRichTextBox.Location = new Point(418, 71);
            UWRichTextBox.Name = "UWRichTextBox";
            UWRichTextBox.Size = new Size(374, 378);
            UWRichTextBox.TabIndex = 1;
            UWRichTextBox.Text = "";
            UWRichTextBox.MouseDown += UWRichTextBox_MouseDown;
            // 
            // Check_Btn
            // 
            Check_Btn.BackColor = SystemColors.ActiveCaption;
            Check_Btn.FlatStyle = FlatStyle.Flat;
            Check_Btn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Check_Btn.Location = new Point(341, 9);
            Check_Btn.Name = "Check_Btn";
            Check_Btn.Size = new Size(119, 48);
            Check_Btn.TabIndex = 2;
            Check_Btn.Text = "Check";
            Check_Btn.UseVisualStyleBackColor = false;
            Check_Btn.Click += Check_Btn_Click;
            // 
            // LB_K9
            // 
            LB_K9.AutoSize = true;
            LB_K9.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LB_K9.Location = new Point(180, 38);
            LB_K9.Name = "LB_K9";
            LB_K9.Size = new Size(39, 30);
            LB_K9.TabIndex = 3;
            LB_K9.Text = "K9";
            // 
            // LB_UW
            // 
            LB_UW.AutoSize = true;
            LB_UW.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LB_UW.Location = new Point(540, 38);
            LB_UW.Name = "LB_UW";
            LB_UW.Size = new Size(131, 30);
            LB_UW.TabIndex = 4;
            LB_UW.Text = "Underwater";
            // 
            // K9_Clear_Btn
            // 
            K9_Clear_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            K9_Clear_Btn.BackColor = Color.FromArgb(255, 128, 128);
            K9_Clear_Btn.FlatStyle = FlatStyle.Flat;
            K9_Clear_Btn.Location = new Point(311, 426);
            K9_Clear_Btn.Name = "K9_Clear_Btn";
            K9_Clear_Btn.Size = new Size(75, 23);
            K9_Clear_Btn.TabIndex = 7;
            K9_Clear_Btn.Text = "Delete";
            K9_Clear_Btn.UseVisualStyleBackColor = false;
            K9_Clear_Btn.Click += K9_Clear_Btn_Click;
            // 
            // UW_Clear_Btn
            // 
            UW_Clear_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UW_Clear_Btn.BackColor = Color.FromArgb(255, 128, 128);
            UW_Clear_Btn.FlatStyle = FlatStyle.Flat;
            UW_Clear_Btn.Location = new Point(418, 426);
            UW_Clear_Btn.Name = "UW_Clear_Btn";
            UW_Clear_Btn.Size = new Size(75, 23);
            UW_Clear_Btn.TabIndex = 8;
            UW_Clear_Btn.Text = "Delete";
            UW_Clear_Btn.UseVisualStyleBackColor = false;
            UW_Clear_Btn.Click += UW_Clear_Btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(804, 461);
            Controls.Add(UW_Clear_Btn);
            Controls.Add(K9_Clear_Btn);
            Controls.Add(LB_UW);
            Controls.Add(LB_K9);
            Controls.Add(Check_Btn);
            Controls.Add(UWRichTextBox);
            Controls.Add(K9RichTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(820, 1000);
            MinimumSize = new Size(820, 500);
            Name = "Form1";
            Text = "Inspections Checker";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ContextMenuStripChanged += RichTextContextMenu;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox K9RichTextBox;
        private RichTextBox UWRichTextBox;
        private Button Check_Btn;
        private Label LB_K9;
        private Label LB_UW;
        private Button K9_Clear_Btn;
        private Button UW_Clear_Btn;
    }
}
