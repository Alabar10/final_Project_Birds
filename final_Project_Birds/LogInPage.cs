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

namespace final_Project_Birds
{
    public partial class LogInPage : Form
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection gg = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C: //Users//alabr//OneDrive//שולחן העבודה//workbook1.xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'");
            gg.Open();
            OleDbCommand r = new OleDbCommand("SELECT * FROM [Users] where username=@user and password=@pass", gg);
            r.Parameters.AddWithValue("user", txtUsername.Text);
            r.Parameters.AddWithValue("pass", txtPassword.Text);
            OleDbDataReader read;
            read = r.ExecuteReader();
            if (read.Read())
            {
                int resultcomp = string.Compare(txtPassword.Text, read.GetValue(1).ToString());
                if (resultcomp == 0)
                {
                    MessageBox.Show("welcome");
                }
                else
                {
                    MessageBox.Show("incorrect");
                }
            }
            else
            {
                MessageBox.Show("incor");
            }
            gg.Close();
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

        }
    }
}
