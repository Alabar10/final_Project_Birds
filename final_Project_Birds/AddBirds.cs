using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace final_Project_Birds
{
    public partial class AddBirds : Form
    {
        public List<Bird> birdsList = new List<Bird>();

        public AddBirds()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the LicenseContext
            birdComboBox.Items.Add("גולדיאן אמריקאי");
            birdComboBox.Items.Add("גולדיאן אירופאי");
            birdComboBox.Items.Add("גולדיאן אוסטרלי");
            comboBox1.Items.Add("זכר");
            comboBox1.Items.Add("נקבה");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

        }
        private const string ExcelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Serialnum = textBox1.Text;
            string speciesofbird = birdComboBox.Text;
            string subspecies = subspeciesComboBox.Text;
            string hatchdate = dateTimePicker1.Text;
            string genderbird = comboBox1.Text;
            string cagenumber = textBox8.Text;
            string fatherserialnumber = textBox10.Text;
            string motherserialnumber = textBox3.Text;
            if (!ValidSerialnum(Serialnum))
            {
                MessageBox.Show("Invalid Serial number!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidSerialnum(fatherserialnumber))
            {
                MessageBox.Show("Invalid father serial number!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidSerialnum(motherserialnumber))
            {
                MessageBox.Show("Invalid mother serial number!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            RegisterUser(Serialnum, speciesofbird, subspecies, hatchdate, genderbird, cagenumber, fatherserialnumber, motherserialnumber);
        }
       
        public bool ValidSerialnum(string Serialnum)
        {
            Regex regex = new Regex(@"^[0-9]+$"); // Pattern to match digits only

            return regex.IsMatch(Serialnum);
        }
        

        private void RegisterUser(string Serialnum, string speciesofbird, string subspecies, string hatchdate, string genderbird, string cagenumber, string fatherserialnumber, string motherserialnumber)
        {
            using (var package = new ExcelPackage(new FileInfo(ExcelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["birds"];

                int rowCount = worksheet.Dimension.Rows;
                int newRow = rowCount + 1;

                worksheet.Cells[newRow, 1].Value = Serialnum;
                worksheet.Cells[newRow, 2].Value = speciesofbird;
                worksheet.Cells[newRow, 3].Value = subspecies;
                worksheet.Cells[newRow, 4].Value = hatchdate;
                worksheet.Cells[newRow, 5].Value = genderbird;
                worksheet.Cells[newRow, 6].Value = cagenumber;
                worksheet.Cells[newRow, 7].Value = fatherserialnumber;
                worksheet.Cells[newRow, 8].Value = motherserialnumber;



                package.Save();
            }

            MessageBox.Show("Bird Added successfully.");


        }

        private void AddBirds_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string excelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";
            string worksheetName = "birds"; // Replace with the actual worksheet name

            // Create a new DataTable to store the data
            DataTable dataTable = new DataTable();

            // Load the Excel file using EPPlus
            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                // Get the specified worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];

                // Check if the worksheet exists
                if (worksheet != null)
                {
                    // Loop through the rows and columns to read the data
                    for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                    {
                        DataRow dataRow = null;

                        // If it's the first row, create the columns in the DataTable
                        if (row == 1)
                        {
                            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                            {
                                string columnName = Convert.ToString(worksheet.Cells[row, col].Value);
                                dataTable.Columns.Add(columnName);
                            }
                        }
                        else
                        {
                            dataRow = dataTable.NewRow();

                            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                            {
                                dataRow[col - 1] = Convert.ToString(worksheet.Cells[row, col].Value);
                            }

                            dataTable.Rows.Add(dataRow);
                        }
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Worksheet not found.");
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void birdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the existing items in the subspeciesComboBox
            subspeciesComboBox.Items.Clear();

            // Get the selected bird species from birdComboBox
            string selectedBird = birdComboBox.SelectedItem.ToString();

            // Populate the subspeciesComboBox based on the selected bird
            if (selectedBird == "גולדיאן אמריקאי")
            {
                subspeciesComboBox.Items.Add("צפון אמריקה");
                subspeciesComboBox.Items.Add("מרכז אמריקה");
                subspeciesComboBox.Items.Add("דרום אמריקה");

            }
            else if (selectedBird == "גולדיאן אירופאי")
            {
                subspeciesComboBox.Items.Add("מזרח אירופה");
                subspeciesComboBox.Items.Add("מערב אירופה");
                // Add more subspecies for Hawk as needed
            }
            else if (selectedBird == "גולדיאן אוסטרלי")
            {
                subspeciesComboBox.Items.Add("מרכז אוסטרליה");
                subspeciesComboBox.Items.Add("ערי חוף");
                // Add more subspecies for Owl as needed
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
