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
using System.Threading.Tasks;
using System.Windows.Forms;
using User = final_Project_Birds.User;


namespace final_Project_Birds
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
        public void CreateYUser(AddUser user)
        {
            string filePath = Path.Combine(ExcelManager.GetProjectDirectory(), "Birds");
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Users"];

                int lastRow = worksheet.Dimension.End.Row;
                worksheet.Cells[lastRow + 1, 1].Value = user.Username;
                worksheet.Cells[lastRow + 1, 2].Value = user.Password;
                worksheet.Cells[lastRow + 1, 3].Value = user.ID;
                package.Save();

            }
            Console.WriteLine("User added successfully");

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
        //public bool IsUsernameValid(string username)
        //{
        //    if(username.Length<6||username.Length>8)
        //    {
        //        return false;
        //    }
        //    int digitcount = 0;
        //    int lettercount = 0;
        //    foreach(char.IsDigit(c))
        //    {
        //        digitcount++;
        //        if(digitcount>2)
        //        {
        //            return false;
        //        }
        //        else if(char.IsLetter(c))
        //        {
        //            lettercount++;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    if(lettercount<6)
        //    {
        //        return false;
        //    }
        //    return true;

        //}
    }
}
