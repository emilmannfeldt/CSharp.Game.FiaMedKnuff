using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiamedknuff
{
    public class player
    {
       
        public player(int _f, string _name, int _homex, int _homey, PictureBox[] _pieces)
        {
            this.f = _f;
           this.name = _name;
           this.homex = _homex;
            this.homey = _homey;
           this.pieces = _pieces;

        }
        public int homex { get; set; }
        public player()
        {

        }
        public int f { get; set; }
        public int homey { get; set; }
        public string name { get; set; }
        public PictureBox[] pieces { get; set; }
      
    }
}
