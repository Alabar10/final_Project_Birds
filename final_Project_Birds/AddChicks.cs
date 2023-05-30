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
    public partial class AddChicks : Form
    {
        public AddChicks()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the LicenseContext

            comboBox1.Items.Add("זכר");
            comboBox1.Items.Add("נקבה");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
        private const string ExcelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";


        private void button2_Click(object sender, EventArgs e)
        {
            string worksheetName = "birds"; // Replace with the actual worksheet name

            // Create a new DataTable to store the data
            DataTable dataTable = new DataTable();

            // Load the Excel file using EPPlus
            using (ExcelPackage package = new ExcelPackage(new FileInfo(ExcelFilePath)))
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

        private void AddChicks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Serialnum = textBox2.Text;
            string hatchdate = dateTimePicker1.Text;
            string genderbird = comboBox1.Text;
            string parentNumber = textBox1.Text; // Number of the parent bird

            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(ExcelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["birds"]; // Replace with the actual worksheet name

                    if (worksheet != null)
                    {
                        int totalRows = worksheet.Dimension.Rows;

                        // Find the row in the Excel file that matches the parent bird's number
                        for (int rowIndex = 2; rowIndex <= totalRows; rowIndex++)
                        {
                            // Check if the number in the first column matches the parent number
                            if (worksheet.Cells[rowIndex, 1].Value != null && worksheet.Cells[rowIndex, 1].Value.ToString() == parentNumber)
                            {
                                // Retrieve the parent's details from the Excel file
                                string speciesofbird = worksheet.Cells[rowIndex, 2].Value?.ToString();
                                string subspecies = worksheet.Cells[rowIndex, 3].Value?.ToString();
                                string cagenumber = worksheet.Cells[rowIndex, 6].Value?.ToString();
                                string parentSpecies = worksheet.Cells[rowIndex, 8].Value?.ToString();
                                string fatherserialnumber = worksheet.Cells[rowIndex, 7].Value?.ToString();

                                // Get the remaining details of the new chick
                                string chickSerialNum = Serialnum; // Serial number of the new chick
                                string chickHatchDate = hatchdate; // Hatch date of the new chick
                                string chickGender = genderbird; // Gender of the new chick

                                // Add the new chick to the bird
                                int newRow = totalRows + 1;
                                worksheet.Cells[newRow, 1].Value = chickSerialNum;
                                worksheet.Cells[newRow, 2].Value = speciesofbird;
                                worksheet.Cells[newRow, 3].Value = subspecies;
                                worksheet.Cells[newRow, 6].Value = cagenumber;
                                worksheet.Cells[newRow, 4].Value = chickHatchDate;
                                worksheet.Cells[newRow, 5].Value = chickGender;
                                worksheet.Cells[newRow, 7].Value = fatherserialnumber;
                                worksheet.Cells[newRow, 8].Value = parentSpecies;

                                // Save the changes to the Excel file
                                package.Save();

                                // Display a message to indicate the successful addition of the chick
                                MessageBox.Show($"Chick '{chickSerialNum}' has been added to bird '{parentSpecies}'.");
                                return;
                            }
                            else
                            {
                                MessageBox.Show($"Parent bird with number '{parentNumber}' not found in the Excel file.");
                                return;
                            }
                        }

                        MessageBox.Show($"Parent bird with number '{parentNumber}' not found in the Excel file.");
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



            if (!ValidSerialnum(Serialnum))
            {
                MessageBox.Show("Invalid Serial number!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            


            RegisterUser(Serialnum, hatchdate, genderbird, parentNumber);
        }
        public bool ValidSerialnum(string Serialnum)
        {
            Regex regex = new Regex(@"^[0-9]+$"); // Pattern to match digits only

            return regex.IsMatch(Serialnum);
        }
        private void RegisterUser(string Serialnum, string hatchdate, string genderbird, string parentNumber)
        {
            using (var package = new ExcelPackage(new FileInfo(ExcelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["birds"];

                int rowCount = worksheet.Dimension.Rows;
                int newRow = rowCount + 1;

                worksheet.Cells[newRow, 1].Value = Serialnum;
                //worksheet.Cells[newRow, 2].Value = speciesofbird;
               // worksheet.Cells[newRow, 3].Value = subspecies;
                worksheet.Cells[newRow, 4].Value = hatchdate;
                worksheet.Cells[newRow, 5].Value = genderbird;
                //worksheet.Cells[newRow, 6].Value = cagenumber;
               // worksheet.Cells[newRow, 7].Value = fatherserialnumber;
                worksheet.Cells[newRow, 8].Value = parentNumber;



                package.Save();
            }

            MessageBox.Show("Bird Added successfully.");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
