namespace Compare
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // Set the timer interval to 1 second (1000 milliseconds)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DisplayPanamaTime();
        }
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            DisplayPanamaTime();
            InitializeTimer();
            InitializeForm2();

            // Subscribe to the KeyDown event for both RichTextBox controls
            K9RichTextBox.KeyDown += new KeyEventHandler(RichTextBox_KeyDown);
            UWRichTextBox.KeyDown += new KeyEventHandler(RichTextBox_KeyDown);
        }
        private void InitializeForm2()
        {
            form2 = new Form2();
            form2.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
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
        private void DisplayPanamaTime()
        {
            try
            {
                // Define the Panama time zone (Eastern Standard Time, UTC-5 without DST)
                TimeZoneInfo panamaTimeZone = TimeZoneInfo.CreateCustomTimeZone("Panama Standard Time", TimeSpan.FromHours(-5), "Panama Standard Time", "Panama Standard Time");

                // Get current UTC time
                DateTime utcNow = DateTime.UtcNow;

                // Convert UTC time to Panama local time
                DateTime panamaLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, panamaTimeZone);

                // Format the Panama local time as "DD/MM HH:MM"
                string formattedPanamaTime = panamaLocalTime.ToString("dd/MM HH:mm:ss");

                // Display the Panama local time on the label
                LB_Time.Text = $"{formattedPanamaTime}";
            }
            catch (Exception ex)
            {
                LB_Time.Text = $"An error occurred: {ex.Message}";
            }
        }
        // Override ProcessCmdKey to handle the Tab key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                // Handle the Tab key
                Control focusedControl = ActiveControl as RichTextBox;
                if (focusedControl != null && focusedControl is RichTextBox box)
                {
                    RichTextBox richTextBox = box;

                    // Insert a tab character
                    int position = richTextBox.SelectionStart;
                    richTextBox.Text = richTextBox.Text.Insert(position, "\t");
                    richTextBox.SelectionStart = position + 1;

                    // Suppress the default behavior of Tab key
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.Z))
            {
                // Handle Ctrl+Z for undo
                Control focusedControl = ActiveControl as RichTextBox;
                if (focusedControl != null && focusedControl is RichTextBox box)
                {
                    RichTextBox richTextBox = box;

                    // Perform undo operation
                    if (richTextBox.CanUndo)
                    {
                        richTextBox.Undo();
                        // Suppress the default behavior of Ctrl+Z
                        return true;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Optional: Additional key handling can be added here if needed
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
        private void CompareRichTextBoxes()
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
                        HighlightLine(K9RichTextBox, i, Color.LightBlue);
                        HighlightLine(UWRichTextBox, j, Color.LightBlue);
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
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            CompareRichTextBoxes();
        }
        private static void ClearHighlights(RichTextBox richTextBox)
        {
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.DeselectAll();
        }
        private static void HighlightLine(RichTextBox richTextBox, int lineIndex, Color backColor)
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
        private void K9RichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void UWRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void Btn_CopyK9_Click(object sender, EventArgs e)
        {
            // Check if K9RichTextBox is not empty
            if (!string.IsNullOrWhiteSpace(K9RichTextBox.Text))
            {
                // Copy the text content of K9RichTextBox to the clipboard
                Clipboard.SetText(K9RichTextBox.Text);
            }
        }
        private void Btn_CopyUW_Click(object sender, EventArgs e)
        {
            // Check if UWRichTextBox is not empty
            if (!string.IsNullOrWhiteSpace(UWRichTextBox.Text))
            {
                // Copy the text content of UWRichTextBox to the clipboard
                Clipboard.SetText(UWRichTextBox.Text);
            }
        }
        private void Btn_Check_Click(object sender, EventArgs e)
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
                        HighlightLine(K9RichTextBox, i, Color.LightBlue);
                        HighlightLine(UWRichTextBox, j, Color.LightBlue);
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
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2.Dispose();
            form2 = null;
        }
        private void Btn_Pending_Click(object sender, EventArgs e)
        {
            if (form2 == null)
            {
                InitializeForm2();
            }

            // Check if Form2 is already open
            if (form2.Visible)
            {
                // Close Form2
                form2.Hide();
            }
            else
            {
                // Open Form2
                form2.Show();
            }
        }
    }
}