using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiamedknuff
{
    class player
    {
       
        public player(string _name, int _homex, int _homey, PictureBox[] _pieces)
        {

           string name = _name;
           int homex = _homex;
            int  homey = _homey;
           PictureBox[] pieces = _pieces;

        }
        public int homex { get; set; }
        public int homey { get; set; }
        public string name { get; set; }
        public PictureBox[] pieces { get; set; }
      
    }
}
