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
            LB_K9 = new Label();
            LB_UW = new Label();
            K9_Clear_Btn = new Button();
            UW_Clear_Btn = new Button();
            Btn_CopyK9 = new Button();
            Btn_CopyUW = new Button();
            Btn_Check = new Button();
            LB_Panama = new Label();
            LB_Time = new Label();
            Btn_Pending = new Button();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // K9RichTextBox
            // 
            K9RichTextBox.AcceptsTab = true;
            K9RichTextBox.BackColor = SystemColors.Info;
            K9RichTextBox.BorderStyle = BorderStyle.None;
            K9RichTextBox.Dock = DockStyle.Fill;
            K9RichTextBox.EnableAutoDragDrop = true;
            K9RichTextBox.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            K9RichTextBox.Location = new Point(0, 0);
            K9RichTextBox.Name = "K9RichTextBox";
            K9RichTextBox.Size = new Size(417, 795);
            K9RichTextBox.TabIndex = 0;
            K9RichTextBox.Text = "Copy K9 here....!!!";
            K9RichTextBox.WordWrap = false;
            K9RichTextBox.ContextMenuStripChanged += RichTextContextMenu;
            K9RichTextBox.TextChanged += K9RichTextBox_TextChanged;
            K9RichTextBox.MouseDown += K9RichTextBox_MouseDown;
            // 
            // UWRichTextBox
            // 
            UWRichTextBox.AcceptsTab = true;
            UWRichTextBox.BackColor = SystemColors.Info;
            UWRichTextBox.BorderStyle = BorderStyle.None;
            UWRichTextBox.Dock = DockStyle.Fill;
            UWRichTextBox.EnableAutoDragDrop = true;
            UWRichTextBox.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            UWRichTextBox.Location = new Point(0, 0);
            UWRichTextBox.Name = "UWRichTextBox";
            UWRichTextBox.Size = new Size(439, 795);
            UWRichTextBox.TabIndex = 1;
            UWRichTextBox.Text = "Copy UnderWater here...!!!";
            UWRichTextBox.WordWrap = false;
            UWRichTextBox.ContextMenuStripChanged += RichTextContextMenu;
            UWRichTextBox.TextChanged += UWRichTextBox_TextChanged;
            UWRichTextBox.MouseDown += UWRichTextBox_MouseDown;
            // 
            // LB_K9
            // 
            LB_K9.AutoSize = true;
            LB_K9.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            LB_K9.ForeColor = Color.White;
            LB_K9.Location = new Point(300, 7);
            LB_K9.Name = "LB_K9";
            LB_K9.Size = new Size(50, 38);
            LB_K9.TabIndex = 3;
            LB_K9.Text = "K9";
            // 
            // LB_UW
            // 
            LB_UW.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LB_UW.AutoSize = true;
            LB_UW.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            LB_UW.ForeColor = Color.White;
            LB_UW.Location = new Point(560, 7);
            LB_UW.Name = "LB_UW";
            LB_UW.Size = new Size(169, 38);
            LB_UW.TabIndex = 4;
            LB_UW.Text = "Underwater";
            // 
            // K9_Clear_Btn
            // 
            K9_Clear_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            K9_Clear_Btn.BackColor = Color.FromArgb(255, 128, 128);
            K9_Clear_Btn.FlatStyle = FlatStyle.Flat;
            K9_Clear_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            K9_Clear_Btn.Location = new Point(0, 759);
            K9_Clear_Btn.Name = "K9_Clear_Btn";
            K9_Clear_Btn.Size = new Size(75, 36);
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
            UW_Clear_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            UW_Clear_Btn.Location = new Point(0, 759);
            UW_Clear_Btn.Name = "UW_Clear_Btn";
            UW_Clear_Btn.Size = new Size(75, 36);
            UW_Clear_Btn.TabIndex = 8;
            UW_Clear_Btn.Text = "Delete";
            UW_Clear_Btn.UseVisualStyleBackColor = false;
            UW_Clear_Btn.Click += UW_Clear_Btn_Click;
            // 
            // Btn_CopyK9
            // 
            Btn_CopyK9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Btn_CopyK9.BackColor = Color.FromArgb(192, 255, 255);
            Btn_CopyK9.FlatStyle = FlatStyle.Flat;
            Btn_CopyK9.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_CopyK9.Location = new Point(302, 759);
            Btn_CopyK9.Name = "Btn_CopyK9";
            Btn_CopyK9.Size = new Size(115, 36);
            Btn_CopyK9.TabIndex = 9;
            Btn_CopyK9.Text = "Copy K9";
            Btn_CopyK9.UseVisualStyleBackColor = false;
            Btn_CopyK9.Click += Btn_CopyK9_Click;
            // 
            // Btn_CopyUW
            // 
            Btn_CopyUW.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Btn_CopyUW.BackColor = Color.FromArgb(192, 255, 255);
            Btn_CopyUW.FlatStyle = FlatStyle.Flat;
            Btn_CopyUW.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_CopyUW.Location = new Point(324, 759);
            Btn_CopyUW.Name = "Btn_CopyUW";
            Btn_CopyUW.Size = new Size(115, 36);
            Btn_CopyUW.TabIndex = 10;
            Btn_CopyUW.Text = "Copy U/W";
            Btn_CopyUW.UseVisualStyleBackColor = false;
            Btn_CopyUW.Click += Btn_CopyUW_Click;
            // 
            // Btn_Check
            // 
            Btn_Check.Anchor = AnchorStyles.Top;
            Btn_Check.BackColor = Color.FromArgb(192, 255, 255);
            Btn_Check.FlatStyle = FlatStyle.Flat;
            Btn_Check.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Check.Location = new Point(362, 8);
            Btn_Check.Name = "Btn_Check";
            Btn_Check.Size = new Size(137, 36);
            Btn_Check.TabIndex = 11;
            Btn_Check.Text = "Check";
            Btn_Check.UseVisualStyleBackColor = false;
            Btn_Check.Click += Btn_Check_Click;
            // 
            // LB_Panama
            // 
            LB_Panama.AutoSize = true;
            LB_Panama.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LB_Panama.ForeColor = Color.White;
            LB_Panama.Location = new Point(12, 13);
            LB_Panama.Name = "LB_Panama";
            LB_Panama.Size = new Size(138, 26);
            LB_Panama.TabIndex = 12;
            LB_Panama.Text = "Panama Now :";
            // 
            // LB_Time
            // 
            LB_Time.AutoSize = true;
            LB_Time.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LB_Time.ForeColor = Color.Yellow;
            LB_Time.Location = new Point(156, 13);
            LB_Time.Name = "LB_Time";
            LB_Time.Size = new Size(138, 26);
            LB_Time.TabIndex = 13;
            LB_Time.Text = "Date and Time";
            // 
            // Btn_Pending
            // 
            Btn_Pending.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Pending.BackColor = Color.FromArgb(192, 255, 255);
            Btn_Pending.FlatStyle = FlatStyle.Flat;
            Btn_Pending.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Pending.Location = new Point(735, 8);
            Btn_Pending.Name = "Btn_Pending";
            Btn_Pending.Size = new Size(137, 36);
            Btn_Pending.TabIndex = 14;
            Btn_Pending.Text = "Pending";
            Btn_Pending.UseVisualStyleBackColor = false;
            Btn_Pending.Click += Btn_Pending_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 54);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(K9RichTextBox);
            splitContainer1.Panel1.Controls.Add(K9_Clear_Btn);
            splitContainer1.Panel1.Controls.Add(Btn_CopyK9);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(UWRichTextBox);
            splitContainer1.Panel2.Controls.Add(Btn_CopyUW);
            splitContainer1.Panel2.Controls.Add(UW_Clear_Btn);
            splitContainer1.Size = new Size(860, 795);
            splitContainer1.SplitterDistance = 417;
            splitContainer1.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(884, 861);
            Controls.Add(splitContainer1);
            Controls.Add(Btn_Pending);
            Controls.Add(LB_Time);
            Controls.Add(LB_Panama);
            Controls.Add(Btn_Check);
            Controls.Add(LB_UW);
            Controls.Add(LB_K9);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inspections Checker";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ContextMenuStripChanged += RichTextContextMenu;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LB_K9;
        private Label LB_UW;
        private Label LB_Panama;
        private Label LB_Time;
        private RichTextBox K9RichTextBox;
        private RichTextBox UWRichTextBox;
        private Button K9_Clear_Btn;
        private Button UW_Clear_Btn;
        private Button Btn_CopyK9;
        private Button Btn_CopyUW;
        private Button Btn_Check;
        private Button Btn_Pending;
        private SplitContainer splitContainer1;
    }
}
