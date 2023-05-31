using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace final_Project_Birds
{
    public partial class LogInPage : Form
    {
        



        public LogInPage()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the LicenseContext

        }
      
        private bool AuthenticateUser(string username, string password)
        {
            string excelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";

            FileInfo fileInfo = new FileInfo(excelFilePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["login"]; // Replace "Sheet1" with the actual name of your worksheet

                if (worksheet != null)
                {
                    int rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++) // Assuming the data starts from the second row
                    {
                        string storedUsername = worksheet.Cells[row,1].Value?.ToString();
                        string storedPassword = worksheet.Cells[row, 2].Value?.ToString();

                        if (username == storedUsername && password == storedPassword)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }





        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                LogInPage t = new LogInPage();
                t.Close();
                //MessageBox.Show("Login successful!");
                var homepage = new HomePage();
                homepage.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogInPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUser uo = new AddUser();
            uo.Show();
        }
    }
}
