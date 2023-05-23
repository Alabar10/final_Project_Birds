using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_Project_Birds
{
    public class Bird
    {
        public int Serialnum { get; set; }
        public string speciesofbird { get; set; }
        public string subspecies { get; set; }
        public int hatchdate { get; set; }
        public string genderbird { get; set; }
        public string cagenumber { get; set; }
        public int fatherserialnumber { get; set; }
        public int motherserialnumber { get; set; }
        public Bird(int serialnu,string speciesofbir,string subspecie, int hatchdat, string genderbir, string cagenumbe, int fatherserialnumbe, int motherserialnumbe)
        {
            Serialnum = serialnu;
            speciesofbird = speciesofbir;
            subspecies = subspecie;
            hatchdate = hatchdat;
            genderbird = genderbir;
            cagenumber = cagenumbe;
            fatherserialnumber = fatherserialnumbe;
            motherserialnumber = motherserialnumbe;


        }
        public Bird()
        {

        }
    }
}
