using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiamedknuff
{
    public partial class Form1 : Form
    {
        player[] activeplayers;
        int dice;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            createplayers();
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
            Random random = new Random();
            dice = random.Next(1, 6);
            
            move(activeplayers[i],dice);
            if (i+1 < activeplayers.Count())
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
        private void move(player p, int d)
        {
            Random random = new Random();
            int choosenpiece = random.Next(0, p.pieces.Count());
            
            //välja vilken pjäs som ska flyttas. om 1/6 kan man flytta en från homex/y
            while (d > 0)
            {

                if (p.pieces[choosenpiece].Location.X > 200 && p.pieces[choosenpiece].Location.Y.Equals(281))
                {
                    p.pieces[choosenpiece].Location = new Point(p.pieces[choosenpiece].Location.X - 15, p.pieces[choosenpiece].Location.Y);
                }
                else if (p.pieces[choosenpiece].Location.X <= 200 && p.pieces[choosenpiece].Location.Y > 100)
                {

                    p.pieces[choosenpiece].Location = new Point(p.pieces[choosenpiece].Location.X, p.pieces[choosenpiece].Location.Y - 15);
                }
                else if (p.pieces[choosenpiece].Location.Y < 100 && p.pieces[choosenpiece].Location.X < 500)
                {
                    p.pieces[choosenpiece].Location = new Point(p.pieces[choosenpiece].Location.X + 15, p.pieces[choosenpiece].Location.Y);
                }
                else if (p.pieces[choosenpiece].Location.X >= 500 && p.pieces[choosenpiece].Location.Y < 300)
                {
                    p.pieces[choosenpiece].Location = new Point(p.pieces[choosenpiece].Location.X, p.pieces[choosenpiece].Location.Y + 15);
                }
                System.Threading.Thread.Sleep(500);
                d--;
            }
            checkpush(p.pieces[choosenpiece],p);
       
            
        }

        private void checkpush(PictureBox p, player pl)
        {
            foreach(player c in activeplayers){
                if(c.name.Equals(pl.name)){
                    continue;
                }
                foreach(PictureBox b in c.pieces)
                if (p.Location.X.Equals(b.Location.X) && p.Location.Y.Equals(b.Location.Y))
                {
                    b.Location = new Point(c.homex,c.homey);
                }
            }
        }
        private void createplayers()
        {
            PictureBox[] player1pieces = new PictureBox[] { player1piece1, player1piece2 };
            player player1 = new player("steve", 600, 100, player1pieces);

            PictureBox[] player2pieces = new PictureBox[] { player2piece1, player2piece2 };
            player player2 = new player("steve", 600, 100, player2pieces);

            PictureBox[] player3pieces = new PictureBox[] { player3piece1, player3piece2 };
            player player3 = new player("steve", 600, 100, player3pieces);


            activeplayers = new player[] { player1,player2, player3};
        }
    }
}
