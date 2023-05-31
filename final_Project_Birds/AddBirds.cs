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
using Excel = Microsoft.Office.Interop.Excel;
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


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddBirds_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void עריכה_Click(object sender, EventArgs e)
        {
            string excelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx"; // Replace with the path to your Excel file

            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["birds"]; // Replace with the actual worksheet name

                    if (worksheet != null)
                    {
                        int rowIndex = 2; // Start from the second row (assuming the headers are in the first row)

                        while (true)
                        {
                            DataGridViewRow row = dataGridView1.Rows[rowIndex - 2];

                            // Check if the row is empty or if the first cell is null or empty
                            if (row.IsNewRow || string.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                                break;

                            for (int colIndex = 1; colIndex <= 3; colIndex++) // Assuming there are three columns
                            {
                                string value = Convert.ToString(row.Cells[colIndex - 1].Value);
                                worksheet.Cells[rowIndex, colIndex].Value = value;
                            }

                            rowIndex++;
                        }

                        worksheet.Cells.AutoFitColumns(0);

                        package.Save();
                        MessageBox.Show("Bird details updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Worksheet not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the serial number from the TextBox
            string cagenumber = textBox8.Text;

            // Initialize Excel Application object
            Excel.Application excelApp = new Excel.Application();

            // Open the workbook
            Excel.Workbook workbook = excelApp.Workbooks.Open("C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx");

            // Get the source and target sheets
            Excel.Worksheet sourceSheet = workbook.Sheets["birds"];
            Excel.Worksheet targetSheet = workbook.Sheets["cages"];

            // Find the serial number in the source sheet
            Excel.Range serialRange = sourceSheet.UsedRange.Columns[1];
            Excel.Range foundCell = serialRange.Find(cagenumber, Type.Missing,
                                                     Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole,
                                                     Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, false, Type.Missing);

            // Check if the serial number was found
            if (foundCell != null)
            {
                // Get the corresponding color from the source sheet
                Excel.Range colorCell = sourceSheet.Cells[foundCell.Row, 2]; // Assuming the color is in the second column

                // Get the color value
                string colorValue = colorCell.Value;

                // Enter the serial number in the target sheet
                Excel.Range targetCell = targetSheet.Cells[targetSheet.UsedRange.Rows.Count + 1, 1];
                targetCell.Value = cagenumber;

                // Set the color of the target cell
                targetCell.Interior.Color = Color.FromName(colorValue);

                // Display success message
                MessageBox.Show("cage number found and entered !");
            }
            else
            {
                // Display error message
                MessageBox.Show("cage number not found!");
            }

            // Close the workbook and release Excel COM objects
            workbook.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

    
        

