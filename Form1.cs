using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Compare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string K9FilePath = Path.Combine(Application.StartupPath, "K9.txt");
            string UWFilePath = Path.Combine(Application.StartupPath, "UW.txt");

            if (File.Exists(K9FilePath))
            {
                string text = File.ReadAllText(K9FilePath);
                K9RichTextBox.Text = text;
            }
            if (File.Exists(UWFilePath))
            {
                string text = File.ReadAllText(UWFilePath);
                UWRichTextBox.Text = text;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the text to separate files for each text box
            string K9FilePath = Path.Combine(Application.StartupPath, "K9.txt");
            string UWFilePath = Path.Combine(Application.StartupPath, "UW.txt");

            File.WriteAllText(K9FilePath, K9RichTextBox.Text);
            File.WriteAllText(UWFilePath, UWRichTextBox.Text);
        }
        private void RichTextContextMenu(object sender, EventArgs e) { }
        private void K9RichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new();

                ToolStripMenuItem cutItem = new("Cut");
                cutItem.Click += (s, args) => K9RichTextBox.Cut();
                menu.Items.Add(cutItem);

                ToolStripMenuItem copyItem = new("Copy");
                copyItem.Click += (s, args) => K9RichTextBox.Copy();
                menu.Items.Add(copyItem);

                ToolStripMenuItem pasteItem = new("Paste");
                pasteItem.Click += (s, args) => K9RichTextBox.Paste();
                menu.Items.Add(pasteItem);

                menu.Show(K9RichTextBox, e.Location);
            }
        }
        private void UWRichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new();

                ToolStripMenuItem cutItem = new("Cut");
                cutItem.Click += (s, args) => UWRichTextBox.Cut();
                menu.Items.Add(cutItem);

                ToolStripMenuItem copyItem = new("Copy");
                copyItem.Click += (s, args) => UWRichTextBox.Copy();
                menu.Items.Add(copyItem);

                ToolStripMenuItem pasteItem = new("Paste");
                pasteItem.Click += (s, args) => UWRichTextBox.Paste();
                menu.Items.Add(pasteItem);

                menu.Show(UWRichTextBox, e.Location);
            }
        }
        private void Check_Btn_Click(object sender, EventArgs e)
        {
            // Clear previous highlights
            ClearHighlights(K9RichTextBox);
            ClearHighlights(UWRichTextBox);

            // Get the lines from each RichTextBox
            string[] lines1 = K9RichTextBox.Lines;
            string[] lines2 = UWRichTextBox.Lines;

            // Create sets to keep track of matched and unmatched lines
            HashSet<string> matchedLines = new HashSet<string>();
            HashSet<int> matchedLines1 = new HashSet<int>();
            HashSet<int> matchedLines2 = new HashSet<int>();

            // Find matching lines
            for (int i = 0; i < lines1.Length; i++)
            {
                for (int j = 0; j < lines2.Length; j++)
                {
                    if (!matchedLines2.Contains(j) && lines1[i] == lines2[j])
                    {
                        matchedLines.Add(lines1[i]);
                        matchedLines1.Add(i);
                        matchedLines2.Add(j);
                        HighlightLine(K9RichTextBox, i, Color.LightGreen);
                        HighlightLine(UWRichTextBox, j, Color.LightGreen);
                        break;
                    }
                }
            }
            // Count differences in lines1 that are not in lines2
            for (int i = 0; i < lines1.Length; i++)
            {
                if (!matchedLines1.Contains(i))
                {
                    HighlightLine(K9RichTextBox, i, Color.LightCoral);
                }
            }
            // Count additions and differences in lines2 that are not in lines1
            for (int j = 0; j < lines2.Length; j++)
            {
                if (!matchedLines2.Contains(j))
                {
                    HighlightLine(UWRichTextBox, j, Color.LightCoral);
                }
            }
        }
        private void ClearHighlights(RichTextBox richTextBox)
        {
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.DeselectAll();
        }
        private void HighlightLine(RichTextBox richTextBox, int lineIndex, Color backColor)
        {
            int start = richTextBox.GetFirstCharIndexFromLine(lineIndex);
            if (start < 0) return; // Line doesn't exist

            int length = richTextBox.Lines[lineIndex].Length;

            richTextBox.Select(start, length);
            richTextBox.SelectionBackColor = backColor;
            richTextBox.DeselectAll();
        }
        // Delete Function
        private void K9_Clear_Btn_Click(object sender, EventArgs e)
        {
            K9RichTextBox.Clear();
        }
        private void UW_Clear_Btn_Click(object sender, EventArgs e)
        {
            UWRichTextBox.Clear();
        }
    }
}
