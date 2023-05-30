using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace final_Project_Birds
{
    public partial class CageSearch : Form
    {
        private List<Cage> cageData;
        public CageSearch()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the LicenseContext
        }

        private void CageSearch_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with search criteria options
            searchCriteriaComboBox.Items.AddRange(new string[] { "Serial Number", "Material" });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the selected search criteria and search text
            string searchCriteria = searchCriteriaComboBox.SelectedItem?.ToString();
            string searchText = searchTextBox.Text;

            // Perform the search based on the selected criteria
            List<Cage> searchResults = new List<Cage>();

            switch (searchCriteria)
            {
                case "Serial Number":
                    searchResults = cageData.Where(bird => bird.SerialNumber == searchText).ToList();
                    break;
                case "Material":
                    searchResults = cageData.Where(bird => bird.Material == searchText).ToList();
                    break;
            }

            // Display the search results in the DataGridView
            dataGridView.DataSource = searchResults;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load bird data from Excel into a List or DataTable
            cageData = LoadBirdDataFromExcel();
        }

        private List<Cage> LoadBirdDataFromExcel()
        {
            List<Cage> cages = new List<Cage>();
            string filePath = @"C:\Users\rashe\Source\Repos\Alabar10\final_Project_Birds\final_Project_Birds\workbook_LogIn.xlsx";

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["cages"]; // Replace "Sheet1" with your actual sheet name

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    Cage cage = new Cage();
                    cage.SerialNumber = worksheet.Cells[row, 1].Value?.ToString();
                    cage.Material = worksheet.Cells[row, 5].Value?.ToString();

                    cages.Add(cage);
                }
            }
            return cages;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sort the bird data by serial number in ascending order
            List<Cage> sortedCages = cageData.OrderBy(cage => cage.SerialNumber).ToList();

            // Display the sorted results in the DataGridView
            dataGridView.DataSource = sortedCages;
        }
    }
}
