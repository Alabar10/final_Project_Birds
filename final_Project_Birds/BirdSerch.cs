using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace final_Project_Birds
{
    public partial class BirdSerch : Form
    {
        public BirdSerch()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            comboBox1.Items.Add("זכר");
            comboBox1.Items.Add("נקבה");
        }
        private const string ExcelFilePath = "C:\\Users\\alabr\\source\\repos\\final_Project_Birds\\final_Project_Birds\\workbook_LogIn.xlsx";


        private void BirdSerch_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
