using System.Globalization;

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
        private TimeZoneInfo panamaTimeZone;
        private System.Windows.Forms.Timer updateTimer;
        private DateTime lastUpdateTime;


        public Form1()
        {
            InitializeComponent();
            DisplayPanamaTime();
            InitializeTimer();
            InitializeForm2();
            InitializeUpdateTimer();


            panamaTimeZone = TimeZoneInfo.CreateCustomTimeZone("Panama Standard Time", TimeSpan.FromHours(-5), "Panama Standard Time", "Panama Standard Time");

            // Subscribe to the KeyDown event for both RichTextBox controls
            K9RichTextBox.KeyDown += new KeyEventHandler(RichTextBox_KeyDown);
            UWRichTextBox.KeyDown += new KeyEventHandler(RichTextBox_KeyDown);
            form2 = new Form2();
            form2.FormClosed += new FormClosedEventHandler(Form2_FormClosed);

            // Initial update of DataGridView
            UpdateForm2DataGridView();
        }
        private void InitializeUpdateTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000; // Update every second
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            if ((currentTime - lastUpdateTime).TotalSeconds >= 5) // Update every 5 seconds
            {
                UpdateForm2DataGridView();
                lastUpdateTime = currentTime;
            }
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
            K9_Clear_Btn.BringToFront();
            UW_Clear_Btn.BringToFront();
            Btn_CopyK9.BringToFront();
            Btn_CopyUW.BringToFront();
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
                DateTime panamaLocalTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, panamaTimeZone);
                string formattedPanamaTime = panamaLocalTime.ToString("dd/MM HH:mm:ss");
                LB_Time.Text = $"{formattedPanamaTime}";
            }
            catch (Exception ex)
            {
                LB_Time.Text = $"An error occurred: {ex.Message}";
            }
        }        // Override ProcessCmdKey to handle the Tab key
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
            lastUpdateTime = DateTime.Now.AddSeconds(-5); // Force update on next tick
        }
        private void UWRichTextBox_TextChanged(object sender, EventArgs e)
        {
            lastUpdateTime = DateTime.Now.AddSeconds(-5); // Force update on next tick
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
            if (form2 == null || form2.IsDisposed)
            {
                InitializeForm2();
            }

            if (form2.Visible)
            {
                form2.Hide();
            }
            else
            {
                form2.Show();
                UpdateForm2DataGridView(); // Update the DataGridView when showing Form2
            }
        }
        private List<Tuple<string, DateTime>> ParseETDDates(string text)
        {
            var result = new List<Tuple<string, DateTime>>();
            var lines = text.Split('\n');
            foreach (var line in lines)
            {
                int etdIndex = line.IndexOf("ETD");
                if (etdIndex != -1)
                {
                    string remainingText = line.Substring(etdIndex + 3).Trim();

                    // Try to match the pattern "DD/MM HH:MM" plus one space
                    var match = System.Text.RegularExpressions.Regex.Match(remainingText, @"(\d{2}/\d{2} \d{2}:)(\d{2}) ?");

                    if (match.Success)
                    {
                        string datePrefix = match.Groups[1].Value;
                        string minutes = match.Groups[2].Value;

                        // Replace "00" with "00"
                        string dateString = datePrefix + (minutes == "00" ? "00" : minutes);

                        if (DateTime.TryParseExact(dateString, "dd/MM HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            // Include the matched part plus one space (if available) in the trimmed line
                            string trimmedLine = line.Substring(0, etdIndex + 3) + dateString + (match.Value.EndsWith(" ") ? " " : "");
                            result.Add(new Tuple<string, DateTime>(trimmedLine, date));
                        }
                    }
                }
            }
            return result;
        }
        private void UpdateForm2DataGridView()
        {
            if (form2 != null && !form2.IsDisposed && form2.Visible)
            {
                var k9Dates = ParseETDDates(K9RichTextBox.Text);
                var uwDates = ParseETDDates(UWRichTextBox.Text);

                var allDates = k9Dates.Concat(uwDates)
                    .GroupBy(t => t.Item1)
                    .Select(g => g.First())
                    .OrderBy(t => t.Item2)
                    .ToList();

                DateTime currentPanamaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, panamaTimeZone);

                var processedDates = allDates.Select(t => new Tuple<string, bool>(
                    t.Item1,
                    (t.Item2 - currentPanamaTime).TotalHours < 12 && (t.Item2 - currentPanamaTime).TotalHours > 0
                )).ToList();

                form2.UpdateDataGridView(processedDates);
            }
        }
    }
}