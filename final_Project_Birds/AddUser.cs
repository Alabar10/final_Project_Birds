using Microsoft.VisualBasic.ApplicationServices;
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
using User = final_Project_Birds.User;


namespace final_Project_Birds
{
    public partial class AddUser : Form
    {
        private const string ExcelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";

        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = addusername.Text;
            string password = addpassword.Text;
            string id =addID.Text;
            if (!ValidateUsername(username))
            {
                MessageBox.Show("Invalid username! Username should contain between 6 and 8 characters, with at most 2 digits and all the rest letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePassword(password))
            {
                MessageBox.Show("Invalid password! Password should contain between 8 and 10 characters, with at least one letter, one digit, and one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateID(id))
            {
                MessageBox.Show("Invalid ID! ID should be a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idNumber = Convert.ToInt32(id);


            RegisterUser(username, password, idNumber);

        }
        private bool ValidateUsername(string username)
        {
            if (username.Length < 6 || username.Length > 8)
                return false;

            int digitCount = 0;
            foreach (char c in username)
            {
                if (Char.IsDigit(c))
                    digitCount++;
                else if (!Char.IsLetter(c))
                    return false;
            }

            return digitCount <= 2;
        }
        private bool ValidatePassword(string password)
        {
            if (password.Length < 8 || password.Length > 10)
                return false;

            bool hasLetter = false;
            bool hasDigit = false;
            bool hasSpecialCharacter = false;

            foreach (char c in password)
            {
                if (Char.IsLetter(c))
                    hasLetter = true;
                else if (Char.IsDigit(c))
                    hasDigit = true;
                else if (!Char.IsWhiteSpace(c))
                    hasSpecialCharacter = true;
            }

            return hasLetter && hasDigit && hasSpecialCharacter;
        }
        private bool ValidateID(string id)
        {
            return Regex.IsMatch(id, "^[0-9]+$");
        }

        private void RegisterUser(string username, string password, int id)
        {
            using (var package = new ExcelPackage(new FileInfo(ExcelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["login"];

                int rowCount = worksheet.Dimension.Rows;
                int newRow = rowCount + 1;

                worksheet.Cells[newRow, 1].Value = username;
                worksheet.Cells[newRow, 2].Value = password;
                worksheet.Cells[newRow, 3].Value = id.ToString();


                package.Save();
            }

            MessageBox.Show("User registered successfully.");
            
           
        }
    }

    
}
        
    

