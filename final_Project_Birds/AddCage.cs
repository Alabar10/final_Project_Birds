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
    public partial class AddCage : Form
    {
        public AddCage()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            comboBox1.Items.Add("ברזל");
            comboBox1.Items.Add("עץ");
            comboBox1.Items.Add("פלסטיק");

        }
        private const string ExcelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";


        private void AddCage_Load(object sender, EventArgs e)
        {

        }
        private void RegisterUser(string Serialnum, string length, string width, string height, string material)
        {
            using (var package = new ExcelPackage(new FileInfo(ExcelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["cages"];

                int rowCount = worksheet.Dimension.Rows;
                int newRow = rowCount + 1;

                worksheet.Cells[newRow, 1].Value = Serialnum;
                worksheet.Cells[newRow, 2].Value = length;
                worksheet.Cells[newRow, 3].Value = width;
                worksheet.Cells[newRow, 4].Value = height;
                worksheet.Cells[newRow, 5].Value = material;
               



                package.Save();
            }

            MessageBox.Show("Bird Added successfully.");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Serialnum = textBox1.Text;
            string length = textBox4.Text;
            string width = textBox3.Text;
            string height = textBox2.Text;
            string material = comboBox1.Text;


            if (!ValidSerialnum(Serialnum))
            {
                MessageBox.Show("Invalid Serial number!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidSerialnum(length))
            {
                MessageBox.Show("Invalid length!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidSerialnum(width))
            {
                MessageBox.Show("Invalid width!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidSerialnum(height))
            {
                MessageBox.Show("Invalid height!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            RegisterUser(Serialnum, length, width, height, material);
        
    }
        public bool ValidSerialnum(string Serialnum)
        {
            Regex regex = new Regex(@"^[0-9]+$"); // Pattern to match digits only

            return regex.IsMatch(Serialnum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string excelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";
            string worksheetName = "cages"; // Replace with the actual worksheet name

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
