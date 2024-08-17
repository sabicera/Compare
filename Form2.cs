namespace Compare
{
    public partial class Form2 : Form
    {
        private bool blinkState = false;
        public Form2()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "ETD Lines";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Enable double buffering
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null,
                dataGridView1,
                new object[] { true });
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            blinkState = !blinkState;
            dataGridView1.Invalidate();
        }

        public void UpdateDataGridView(List<Tuple<string, bool>> lines)
        {
            dataGridView1.SuspendLayout();

            try
            {
                int firstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;

                dataGridView1.Rows.Clear();

                foreach (var item in lines)
                {
                    int rowIndex = dataGridView1.Rows.Add(item.Item1);
                    if (item.Item2)
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                }

                if (firstDisplayedScrollingRowIndex >= 0 && firstDisplayedScrollingRowIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                }
            }
            finally
            {
                dataGridView1.ResumeLayout();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UpdateRowColors();
        }
        private void UpdateRowColors()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Tag is int hoursUntilETD)
                {
                    if (hoursUntilETD < 6)
                    {
                        row.DefaultCellStyle.BackColor = blinkState ? Color.Red : Color.White;
                        row.DefaultCellStyle.ForeColor = blinkState ? Color.White : Color.Black;
                    }
                    else if (hoursUntilETD < 12)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
                    }
                }
            }
        }
    }
}
