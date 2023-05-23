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
    public partial class AddBirds : Form
    {
        public List<Bird> birdsList = new List<Bird>();
        public AddBirds()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //private List<Bird> Getbirds()
        //{
        //    var list = new List<Bird>();
        //    list.Add(new Bird()
        //    {
        //        Serialnum = Convert.ToInt32(textBox1.Text),
        //        speciesofbird = textBox4.Text,
        //        subspecies = textBox5.Text,
        //        hatchdate = Convert.ToInt32(textBox9.Text),
        //        genderbird = textBox2.Text,
        //        cagenumber = textBox8.Text,
        //        fatherserialnumber = Convert.ToInt32(textBox10.Text),
        //        motherserialnumber =  Convert.ToInt32(textBox3.Text)

        //    });
        //    return list;
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          int Serialnum = Convert.ToInt32(textBox1.Text);
            string speciesofbird = textBox4.Text;
            string subspecies = textBox5.Text;
            int hatchdate = Convert.ToInt32(textBox9.Text);
            string genderbird = textBox2.Text;
           string  cagenumber = textBox8.Text;
            int fatherserialnumber = Convert.ToInt32(textBox10.Text);
            int motherserialnumber = Convert.ToInt32(textBox3.Text);
            Bird bi = new Bird(Serialnum, speciesofbird, subspecies, hatchdate, genderbird, cagenumber, fatherserialnumber, motherserialnumber);
            birdsList.Add(bi);
        }

        private void AddBirds_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = birdsList;

        }
    }
}
