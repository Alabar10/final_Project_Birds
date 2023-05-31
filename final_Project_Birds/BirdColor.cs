using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace final_Project_Birds
{
    public partial class BirdColor : Form
    {
        public BirdColor()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the LicenseContext
            comboBox1.Items.Add("אדום");
            comboBox1.Items.Add("שחור");
            comboBox1.Items.Add("צהוב");
            comboBox2.Items.Add("לבן");
            comboBox2.Items.Add("סגול");
            comboBox2.Items.Add("ורוד");
            comboBox3.Items.Add("ירוק");
            comboBox3.Items.Add("צהוב");
            comboBox3.Items.Add("צהוב-ירוק");
            comboBox3.Items.Add("כחול");
            comboBox3.Items.Add("צהוב-ירוק-כחול");
            comboBox3.Items.Add("כסף");





        }
        private const string ExcelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";


        private void BirdColor_Load(object sender, EventArgs e)
        {

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the serial number from the TextBox
            string serialNumber = textBox1.Text;

            // Initialize Excel Application object
            Excel.Application excelApp = new Excel.Application();

            // Open the workbook
            Excel.Workbook workbook = excelApp.Workbooks.Open("C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx");

            // Get the source and target sheets
            Excel.Worksheet sourceSheet = workbook.Sheets["color"];
            Excel.Worksheet targetSheet = workbook.Sheets["birds"];

            // Find the serial number in the source sheet
            Excel.Range serialRange = sourceSheet.UsedRange.Columns[1];
            Excel.Range foundCell = serialRange.Find(serialNumber, Type.Missing,
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
                targetCell.Value = serialNumber;

                // Set the color of the target cell
                targetCell.Interior.Color = Color.FromName(colorValue);

                // Display success message
                MessageBox.Show("Serial number found and entered in color!");
            }
            else
            {
                // Display error message
                MessageBox.Show("Serial number not found!");
            }

            // Close the workbook and release Excel COM objects
            workbook.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
        private void RegisterUser(string Serialnum, string headcolor, string chestcolo, string bodycolo)
        {
            using (var package = new ExcelPackage(new FileInfo(ExcelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["color"];

                int rowCount = worksheet.Dimension.Rows;
                int newRow = rowCount + 1;

                worksheet.Cells[newRow, 1].Value = Serialnum;
                worksheet.Cells[newRow, 2].Value = headcolor;
                worksheet.Cells[newRow, 3].Value = chestcolo;
                worksheet.Cells[newRow, 4].Value = bodycolo;
              



                package.Save();
            }

            MessageBox.Show("Bird Added successfully.");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string excelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";
            string worksheetName = "color"; // Replace with the actual worksheet name

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

        private void button2_Click(object sender, EventArgs e)
        {
            string Serialnum = textBox1.Text;
            string headcolor = comboBox1.Text;
            string chestcolo = comboBox2.Text;
            string bodycolo = comboBox3.Text;
            RegisterUser(Serialnum, headcolor, chestcolo, bodycolo);



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
