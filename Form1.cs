using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace lab3
{
    public partial class Form1 : Form
    {
        private readonly IndexFile indexFile;
        const int TotalBlocks = 10;

        private Record? currentRecord = null;
        private bool isEditing = false;

        static void InitializeBlocks()
        {
            bool blocksExist = false;
            for (int i = 0; i < TotalBlocks; i++)
            {
                var blockFileName = $"block_{i}.txt";
                if (File.Exists(blockFileName))
                {
                    blocksExist = true;
                    break;
                }
            }

            if (!blocksExist)
            {
                var indexFile = new IndexFile();

                for (int i = 0; i < TotalBlocks; i++)
                {
                    var block = new Block();
                    Block.WriteBlockToDisk(i, block);

                    indexFile.AddIndexEntry(i * Block.BlockSize, i);
                }

                indexFile.WriteToFile("index.txt");
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitializeBlocks();
            indexFile = new IndexFile();
            indexFile.ReadFromFile("index.txt");
            RefreshDataGridView();
        }

        private void ShowRecs_button_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void EditRec_Button_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                try
                {
                    int key = int.Parse(key_textBox.Text);
                    currentRecord = FindRecord(key, indexFile).Item1;

                    firstName_label.Visible = true;
                    firstName_textBox.Visible = true;
                    panel_textBox2.Visible = true;
                    lastName_textBox.Visible = true;
                    lastName_label.Visible = true;
                    panel_textBox3.Visible = true;

                    if (currentRecord != null)
                    {
                        key_textBox.Text = currentRecord.Key.ToString();
                        firstName_textBox.Text = currentRecord.FirstName;
                        lastName_textBox.Text = currentRecord.LastName;
                        firstName_textBox.ForeColor = Color.FromArgb(3, 0, 42);
                        lastName_textBox.ForeColor = Color.FromArgb(3, 0, 42);
                        isEditing = true;
                        editRec_Button.Text = "SAVE CHANGES";
                    }
                    else
                    {
                        firstName_label.Visible = false;
                        firstName_textBox.Visible = false;
                        panel_textBox2.Visible = false;
                        lastName_textBox.Visible = false;
                        lastName_label.Visible = false;
                        panel_textBox3.Visible = false;
                        MessageBox.Show($"Record with key {key} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(firstName_textBox.Text) || string.IsNullOrWhiteSpace(lastName_textBox.Text) ||
                    firstName_textBox.Text == "Enter first name..." || lastName_textBox.Text == "Enter last name...")
                {
                    MessageBox.Show("First Name and Last Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentRecord != null)
                {
                    Record updRecord = new(currentRecord.Key, firstName_textBox.Text, lastName_textBox.Text);

                    UpdateRecord(updRecord);

                    isEditing = false;
                    currentRecord = null;
                    editRec_Button.Text = "EDIT RECORD";
                    RefreshDataGridView();

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    key_textBox.Text = "Enter key...";
                    firstName_textBox.Text = "Enter first name...";
                    lastName_textBox.Text = "Enter last name...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            }
        }

        private void AddRec_button_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(key_textBox.Text);
                string firstName = firstName_textBox.Text;
                string lastName = lastName_textBox.Text;

                var result = FindRecord(key, indexFile);
                if (result.Item1 != null)
                {
                    MessageBox.Show($"A record with key {key} already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key_textBox.Text = "Enter key...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    return;
                }

                var record = new Record(key, firstName, lastName);
                AddRecord(record, indexFile);
                key_textBox.Text = "Enter key...";
                firstName_textBox.Text = "Enter first name...";
                lastName_textBox.Text = "Enter last name...";
                key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                RefreshDataGridView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key_textBox.Text = "Enter key...";
                firstName_textBox.Text = "Enter first name...";
                lastName_textBox.Text = "Enter last name...";
                key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
            }
        }

        private void DeleteRec_button_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(key_textBox.Text);

                var record = FindRecord(key, indexFile).Item1;

                if (record != null)
                {
                    DeleteRecord(key);
                    RefreshDataGridView();
                    MessageBox.Show($"Record with key {key} deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    key_textBox.Text = "Enter key...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
                else
                {
                    MessageBox.Show($"Record with key {key} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key_textBox.Text = "Enter key...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key_textBox.Text = "Enter key...";
                key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
            }
        }

        private static bool AreThereAnyRecords
        {
            get
            {
                for (int i = 0; i < TotalBlocks; i++)
                {
                    var blockFileName = $"block_{i}.txt";

                    if (File.Exists(blockFileName))
                    {
                        var block = Block.ReadBlockFromDisk(i);

                        if (block.Records.Count > 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        private void DelAllRecs_button_Click(object sender, EventArgs e)
        {
            if (!AreThereAnyRecords)
            {
                MessageBox.Show("No records found to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete all records?",
                                  "Confirmation",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < TotalBlocks; i++)
                {
                    DeleteAllRecordsFromBlock(i);
                }

                RefreshDataGridView();
                MessageBox.Show("All records have been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FindRec_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(key_textBox.Text);

                var result = FindRecord(key, indexFile);

                Record? record = result.Item1;
                int recordComparisons = result.Item2;

                if (record != null)
                {
                    dataGridView1.Rows.Clear();

                    dataGridView1.Rows.Add(record.Key, record.FirstName, record.LastName);

                    Console.WriteLine($"Record with key {key} found and displayed.");
                    MessageBox.Show($"Record found. Number of comparisons to find the record: {recordComparisons}",
                        "Search result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    key_textBox.Text = "Enter key...";
                    firstName_textBox.Text = "Enter first name...";
                    lastName_textBox.Text = "Enter last name...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
                else
                {
                    MessageBox.Show("Record with the specified key not found.", "Search result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    key_textBox.Text = "Enter key...";
                    firstName_textBox.Text = "Enter first name...";
                    lastName_textBox.Text = "Enter last name...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                    lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key_textBox.Text = "Enter key...";
                firstName_textBox.Text = "Enter first name...";
                lastName_textBox.Text = "Enter last name...";
                key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
            }
        }

        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();

            var records = indexFile.GetAllRecords();

            foreach (var record in records)
            {
                dataGridView1.Rows.Add(record.Key, record.FirstName, record.LastName);
            }
        }

        private void GenRecs_button_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(genNumber_textBox.Text) ||
                genNumber_textBox.Text == "Enter the number of records..."))
            {
                int numberOfRecs = int.Parse(genNumber_textBox.Text);
                PopulateDatabase(numberOfRecs);
                RefreshDataGridView();
            }
        }

        private static void AddRecord(Record record, IndexFile indexFile)
        {
            var blockNumber = indexFile.FindBlockNumberForKeyBinary(record.Key, out _);

            if (blockNumber == -1)
            {
                return;
            }

            var block = Block.ReadBlockFromDisk(blockNumber);
            block.AddRecord(record);
            Block.WriteBlockToDisk(blockNumber, block);
        }

        public void DeleteRecord(int key)
        {
            var blockNumber = indexFile.FindBlockNumberForKeyBinary(key, out _);

            if (blockNumber == -1)
            {
                Console.WriteLine("Error: matching block not found.");
                return;
            }

            var block = Block.ReadBlockFromDisk(blockNumber);

            bool deleted = block.DeleteRecord(key);
            if (deleted)
            {
                Block.WriteBlockToDisk(blockNumber, block);
                Console.WriteLine($"Record with key {key} deleted from block {blockNumber}.");
            }
            else
            {
                Console.WriteLine($"No record with key {key} found to delete in block {blockNumber}.");
            }
        }

        private static void DeleteAllRecordsFromBlock(int blockNumber)
        {
            var block = Block.ReadBlockFromDisk(blockNumber);

            block.Records.Clear();

            Block.WriteBlockToDisk(blockNumber, block);
        }


        private static (Record?, int) FindRecord(int key, IndexFile indexFile)
        {
            var blockNumber = indexFile.FindBlockNumberForKeyBinary(key, out _);

            if (blockNumber == -1)
            {
                return (null, 0);
            }

            var block = Block.ReadBlockFromDisk(blockNumber);
            var record = block.FindRecordBinary(key, out var recordComparisonCount);

            return (record, recordComparisonCount);
        }


        private void UpdateRecord(Record record)
        {
            var blockNumber = indexFile.FindBlockNumberForKeyBinary(record.Key, out _);
            if (blockNumber == -1)
            {
                return;
            }

            var block = Block.ReadBlockFromDisk(blockNumber);
            block.DeleteRecord(record.Key);
            block.AddRecord(record);
            Block.WriteBlockToDisk(blockNumber, block);
        }

        private bool IsIndexExists(int key)
        {
            var blockIndex = indexFile.FindBlockNumberForKeyBinary(key, out _);
            if (blockIndex == -1)
            {
                return false;
            }

            var blockFileName = $"block_{blockIndex}.txt";
            if (File.Exists(blockFileName))
            {
                var block = Block.ReadBlockFromDisk(blockIndex);
                if (block.FindRecordBinary(key, out _) != null)
                    return true;
            }

            return false;
        }

        private void PopulateDatabase(int recsNumber)
        {
            var random = new Random();
            const int stringLength = 10;
            int addedRecords = 0;

            int i = 0;

            while (addedRecords < recsNumber)
            {
                var randomFirstName = GenerateRandomString(stringLength, random);
                var randomLastName = GenerateRandomString(stringLength, random);

                if (IsIndexExists(i))
                {
                    i++;
                    continue;
                }

                var record = new Record(i, randomFirstName, randomLastName);
                AddRecord(record, indexFile);

                addedRecords++;

                i++;
            }

            Console.WriteLine("Database populated with random records.");
        }

        static string GenerateRandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            RoundCorners(panel1, 30);

            RoundCorners(key_label, 15);
            RoundCorners(firstName_label, 15);
            RoundCorners(lastName_label, 15);
            RoundCorners(genNumber_panel, 15);

            RoundCorners(panel_textBox1, 8);
            RoundCorners(panel_textBox2, 8);
            RoundCorners(panel_textBox3, 8);
        }
        private static void RoundCorners(Control control, int cornerRadius)
        {
            GraphicsPath path = new();
            Rectangle rect = new(0, 0, control.Width, control.Height);

            path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            genNumber_panel.Visible = false;
            genNumber_textBox.Visible = false;

            key_textBox.Text = "Enter key...";
            key_textBox.ForeColor = Color.FromArgb(150, 140, 176);

            firstName_textBox.Text = "Enter first name...";
            firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);

            lastName_textBox.Text = "Enter last name...";
            lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);

            key_textBox.GotFocus += (s, ev) =>
            {
                if (key_textBox.Text == "Enter key...")
                {
                    key_textBox.Text = "";
                    key_textBox.ForeColor = Color.FromArgb(3, 0, 42);
                }
            };

            key_textBox.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(key_textBox.Text))
                {
                    key_textBox.Text = "Enter key...";
                    key_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            };

            firstName_textBox.GotFocus += (s, ev) =>
            {
                if (firstName_textBox.Text == "Enter first name...")
                {
                    firstName_textBox.Text = "";
                    firstName_textBox.ForeColor = Color.FromArgb(3, 0, 42);
                }
            };

            firstName_textBox.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(firstName_textBox.Text))
                {
                    firstName_textBox.Text = "Enter first name...";
                    firstName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            };

            lastName_textBox.GotFocus += (s, ev) =>
            {
                if (lastName_textBox.Text == "Enter last name...")
                {
                    lastName_textBox.Text = "";
                    lastName_textBox.ForeColor = Color.FromArgb(3, 0, 42);
                }
            };

            lastName_textBox.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(lastName_textBox.Text))
                {
                    lastName_textBox.Text = "Enter last name...";
                    lastName_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            };


            genNumber_textBox.Text = "Enter the number of records...";
            genNumber_textBox.ForeColor = Color.FromArgb(150, 140, 176);

            genNumber_textBox.GotFocus += (s, ev) =>
            {
                if (genNumber_textBox.Text == "Enter the number of records...")
                {
                    genNumber_textBox.Text = "";
                    genNumber_textBox.ForeColor = Color.FromArgb(3, 0, 42);
                }
            };

            genNumber_textBox.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(genNumber_textBox.Text))
                {
                    genNumber_textBox.Text = "Enter the number of records...";
                    genNumber_textBox.ForeColor = Color.FromArgb(150, 140, 176);
                }
            };
        }

        private void Key_textBox_TextChanged_1(object sender, EventArgs e)
        {
            if (!int.TryParse(key_textBox.Text, out _))
            {
                key_textBox.ForeColor = Color.Red;
            }
            else
            {
                key_textBox.ForeColor = Color.Black;
            }
        }

        private void Key_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void FirstName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void LastName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void EditRec_Button_MouseHover(object sender, EventArgs e)
        {
            if (editRec_Button.Text != "SAVE CHANGES")
            {
                firstName_label.Visible = false;
                firstName_textBox.Visible = false;
                lastName_label.Visible = false;
                lastName_textBox.Visible = false;
                panel_textBox2.Visible = false;
                panel_textBox3.Visible = false;
                genNumber_textBox.Visible = false;
                genNumber_panel.Visible = false;
            }
        }

        private void AddRec_button_MouseEnter(
            object sender, EventArgs e)
        {
            firstName_label.Visible = true;
            firstName_textBox.Visible = true;
            lastName_label.Visible = true;
            lastName_textBox.Visible = true;
            panel_textBox2.Visible = true;
            panel_textBox3.Visible = true;
            genNumber_textBox.Visible = false;
            genNumber_panel.Visible = false;
        }

        private void DeleteRec_button_MouseEnter(object sender, EventArgs e)
        {
            if (editRec_Button.Text != "SAVE CHANGES")
            {
                firstName_label.Visible = false;
                firstName_textBox.Visible = false;
                lastName_label.Visible = false;
                lastName_textBox.Visible = false;
                panel_textBox2.Visible = false;
                panel_textBox3.Visible = false;
                genNumber_textBox.Visible = false;
                genNumber_panel.Visible = false;
            }

        }

        private void FindRec_button_MouseEnter(object sender, EventArgs e)
        {
            if (editRec_Button.Text != "SAVE CHANGES")
            {
                firstName_label.Visible = false;
                firstName_textBox.Visible = false;
                lastName_label.Visible = false;
                lastName_textBox.Visible = false;
                panel_textBox2.Visible = false;
                panel_textBox3.Visible = false;
                genNumber_textBox.Visible = false;
                genNumber_panel.Visible = false;
            }
        }

        private void GenRecs_button_MouseEnter(object sender, EventArgs e)
        {
            genNumber_textBox.Visible = true;
            genNumber_panel.Visible = true;
        }

        private void DelRecs_button_MouseEnter(object sender, EventArgs e)
        {
            genNumber_textBox.Visible = false;
            genNumber_panel.Visible = false;
        }

        private void GenNumber_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void GenNumber_textBox_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(genNumber_textBox.Text, out _))
            {
                genNumber_textBox.ForeColor = Color.Red;
            }
            else
            {
                genNumber_textBox.ForeColor = Color.Black;
            }
        }
        private void ShowRecs_button_MouseLeave(object sender, EventArgs e)
        {
            showRecs_button.BackColor = Color.FromArgb(14, 0, 105);
            showRecs_button.ForeColor = Color.FromArgb(228, 250, 255);
        }

        private void ShowRecs_button_MouseEnter(object sender, EventArgs e)
        {
            showRecs_button.BackColor = Color.FromArgb(228, 250, 255);
            showRecs_button.ForeColor = Color.FromArgb(14, 0, 105);
        }

        private void ShowRecs_button_MouseDown(object sender, MouseEventArgs e)
        {
            showRecs_button.BackColor = Color.FromArgb(28, 0, 231);
            showRecs_button.ForeColor = Color.FromArgb(228, 250, 255);
        }

        private void ShowRecs_button_MouseUp(object sender, MouseEventArgs e)
        {
            showRecs_button.BackColor = Color.FromArgb(228, 250, 255);
            showRecs_button.ForeColor = Color.FromArgb(14, 0, 105);
        }
    }
}
