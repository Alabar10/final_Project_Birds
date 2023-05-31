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
    public partial class BirdSearch : Form
    {
        private List<Bird> birdData;
        public BirdSearch()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the LicenseContext
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BirdSearch_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with search criteria options
            comboBox1.Items.AddRange(new string[] { "Serial Number", "Gender", "Hatch Date", "Species" });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected search criteria and search text
            string searchCriteria = comboBox1.SelectedItem?.ToString();
            string searchText = textBox1.Text;

            // Perform the search based on the selected criteria
            List<Bird> searchResults = new List<Bird>();

            switch (searchCriteria)
            {
                case "Serial Number":
                    searchResults = birdData.Where(bird => bird.Serialnum == searchText).ToList();
                    break;
                case "Gender":
                    searchResults = birdData.Where(bird => bird.genderbird == searchText).ToList();
                    break;
                case "Hatch Date":
                    searchResults = birdData.Where(bird => bird.hatchdate == searchText).ToList();
                    break;
                case "Species":
                    searchResults = birdData.Where(bird => bird.speciesofbird == searchText).ToList();
                    break;
            }

            // Display the search results in the DataGridView
            dataGridView1.DataSource = searchResults;

            // Update the info TextBox with the first matching result (if any)
            /*if (searchResults.Count > 0)
            {
                birdS firstResult = searchResults[0];
                infoTextBox.Text = $"Serial Number: {firstResult.SerialNumber}{Environment.NewLine}" +
                                    $"Gender: {firstResult.Gender}{Environment.NewLine}" +
                                    $"Hatch Date: {firstResult.HatchDate}{Environment.NewLine}" +
                                    $"Species: {firstResult.Species}";
            }
            else
            {
                infoTextBox.Text = "No matching birds found.";
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Load bird data from Excel into a List or DataTable
            birdData = LoadBirdDataFromExcel();
        }
        private List<Bird> LoadBirdDataFromExcel()
        {
            List<Bird> birds = new List<Bird>();
            string filePath = @"C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["birds"]; // Replace "Sheet1" with your actual sheet name

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    Bird bird = new Bird();
                    bird.Serialnum = worksheet.Cells[row, 1].Value?.ToString();
                    bird.genderbird = worksheet.Cells[row, 5].Value?.ToString();
                    bird.hatchdate = worksheet.Cells[row, 4].Value?.ToString();
                    bird.speciesofbird = worksheet.Cells[row, 2].Value?.ToString();

                    birds.Add(bird);
                }
            }

            return birds;
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            // Sort the bird data by serial number in ascending order
            List<Bird> sortedBirds = birdData.OrderBy(bird => bird.Serialnum).ToList();

            // Display the sorted results in the DataGridView
            dataGridView1.DataSource = sortedBirds;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Get the selected search criteria and search text
            string searchCriteria = comboBox1.SelectedItem?.ToString();
            string searchText = textBox1.Text;

            // Perform the search based on the selected criteria
            List<Bird> searchResults = new List<Bird>();

            switch (searchCriteria)
            {
                case "Serial Number":
                    searchResults = birdData.Where(bird => bird.Serialnum == searchText).ToList();
                    break;
                case "Gender":
                    searchResults = birdData.Where(bird => bird.genderbird == searchText).ToList();
                    break;
                case "Hatch Date":
                    searchResults = birdData.Where(bird => bird.hatchdate == searchText).ToList();
                    break;
                case "Species":
                    searchResults = birdData.Where(bird => bird.speciesofbird == searchText).ToList();
                    break;
            }
            dataGridView1.DataSource = searchResults;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Load bird data from Excel into a List or DataTable
            birdData = LoadBirdDataFromExcel();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Sort the bird data by serial number in ascending order
            List<Bird> sortedBirds = birdData.OrderBy(bird => int.Parse(bird.Serialnum)).ToList();

            // Display the sorted results in the DataGridView
            dataGridView1.DataSource = sortedBirds;
        }
    }
}