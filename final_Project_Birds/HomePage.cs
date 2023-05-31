using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_Project_Birds
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddBirds rtt = new AddBirds();
            rtt.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BirdSearch r = new BirdSearch();
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCage r = new AddCage();
            r.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddChicks tt = new AddChicks();
            tt.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BirdColor r = new BirdColor();
            r.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CageSearch t = new CageSearch();
            t.Show();
        }
    }
}
