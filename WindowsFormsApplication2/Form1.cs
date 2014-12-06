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
        List<player> activeplayers = new List<player>();
        int dice;
        int i = 0;
        int winners = 0;
        public Form1()
        {
            InitializeComponent();
            createplayers();
            disablepieces();
            Console.WriteLine("test");
                Console.WriteLine(activeplayers.Count());
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            foreach (PictureBox b in activeplayers[i].pieces)
            {
                b.Enabled = true;
            }
            
            dice=throwdice();
            if (i+1 < activeplayers.Count())
            {
                i++;
            }
            else
            {
                i = 0;
            }
          
        }

        private int throwdice()
        {
            Random random = new Random();
            dice = random.Next(1, 7);          
            DiceBox.Image = Image.FromFile(@"..\\..\\Resources\\" + "Dice" + dice + ".png");
            return dice;
        }
        
        private void createplayers()
        {
            PictureBox[] player1pieces = new PictureBox[] { player1piece1, player1piece2, player1piece3, player1piece4 };
            activeplayers.Add( new player(0,"john",137,87,player1pieces));

            PictureBox[] player2pieces = new PictureBox[] { player2piece1, player2piece2, player2piece3, player2piece4 };
            activeplayers.Add(new player(0,"adam", 450, 87, player2pieces));

            PictureBox[] player4pieces = new PictureBox[] { player4piece1, player4piece2, player4piece3, player4piece4 };
            activeplayers.Add(new player(0,"jen", 450, 405, player4pieces));

            PictureBox[] player3pieces = new PictureBox[] { player3piece1, player3piece2, player3piece3, player3piece4 };
            activeplayers.Add(new player(0,"jens", 137, 405, player3pieces));
 
            
        }

        private void player1piece1_Click(object sender, EventArgs e)
        {
            movered(activeplayers[0],player1piece1);
        }

        private void player1piece2_Click(object sender, EventArgs e)
        {
            movered(activeplayers[0], player1piece2);
        }

        private void player1piece3_Click(object sender, EventArgs e)
        {
            movered(activeplayers[0], player1piece3);
        }

        private void player1piece4_Click(object sender, EventArgs e)
        {
            movered(activeplayers[0], player1piece4);
        }
        private void disablepieces()
        {
            foreach (player s in activeplayers)
            {
                foreach (PictureBox c in s.pieces)
                {
                    c.Enabled = false;
                }
            }
        }
        

        private void player2piece1_Click(object sender, EventArgs e)
        {
            moveyellow(activeplayers[1], player2piece1);
        }

        private void player2piece2_Click(object sender, EventArgs e)
        {
            moveyellow(activeplayers[1], player2piece2);
        }

        private void player2piece3_Click(object sender, EventArgs e)
        {
            moveyellow(activeplayers[1], player2piece3);
        }

        private void player2piece4_Click(object sender, EventArgs e)
        {
            moveyellow(activeplayers[1], player2piece4);
        }

        private void player3piece1_Click(object sender, EventArgs e)
        {
            moveblue(activeplayers[3], player3piece1);
        }

        private void player3piece2_Click(object sender, EventArgs e)
        {
            moveblue(activeplayers[3], player3piece2);
        }

        private void player3piece3_Click(object sender, EventArgs e)
        {
            moveblue(activeplayers[3], player3piece3);
        }

        private void player3piece4_Click(object sender, EventArgs e)
        {
            moveblue(activeplayers[3], player3piece4);
        }

        private void player4piece1_Click(object sender, EventArgs e)
        {
            movegreen(activeplayers[2], player4piece1);
        }

        private void player4piece2_Click(object sender, EventArgs e)
        {
            movegreen(activeplayers[2], player4piece2);
        }

        private void player4piece3_Click(object sender, EventArgs e)
        {
            movegreen(activeplayers[2], player4piece3);
        }

        private void player4piece4_Click(object sender, EventArgs e)
        {
            movegreen(activeplayers[2], player4piece4);
        }



        private void movered(player p, PictureBox pb)
        {

            while (dice > 0)
            {
               
                if (pb.Location.X.Equals(137) || pb.Location.X.Equals(204))
                {
                    if (dice == 1)
                    {
                        pb.Location = new Point(58, 240);
                    }
                    else if (dice == 6)
                    {
                        pb.Location = new Point(248, 240);
                    }

                    dice = 0;
                }
                if (dice > 0)
                {
                    if (pb.Location.X<287 && pb.Location.Y.Equals(278))
                    {
                        moveright(pb);
                        if (pb.Location.X.Equals(286))
                        {
                            goal(pb,p); //win move to winning spot. check if all p.pieces is at winning spot. if so, winner!
                        }
                    }
                    movearound(pb);
                }

                dice--;
            }
            checkpush(pb, p);
            disablepieces();


        }
        private void moveblue(player p, PictureBox pb)
        {

            while (dice > 0)
            {
               
                if (pb.Location.X.Equals(137) || pb.Location.X.Equals(204))
                {
                    if (dice == 1)
                    {
                        pb.Location = new Point(286, 544);
                    }
                    else if (dice == 6)
                    {
                        pb.Location = new Point(286, 354);
                    }

                    dice = 0;
                }
                if (dice > 0)
                {
                    movearound(pb);
                }

                dice--;
            }
            checkpush(pb, p);
            disablepieces();


        }
        private void movegreen(player p, PictureBox pb)
        {

            while (dice > 0)
            {
                
                if (pb.Location.X.Equals(450) || pb.Location.X.Equals(522))
                {
                    if (dice == 1)
                    {
                        pb.Location = new Point(590, 316);
                    }
                    else if (dice == 6)
                    {
                        pb.Location = new Point(400, 316);
                    }

                    dice = 0;
                }
                if (dice > 0)
                {
                    movearound(pb);
                }

                dice--;
            }
            checkpush(pb, p);
            disablepieces();


        }
        private void moveyellow(player p, PictureBox pb)
        {

            while (dice > 0)
            {
              
                if (pb.Location.X.Equals(450) || pb.Location.X.Equals(522))
                {
                    if (dice == 1)
                    {
                        pb.Location = new Point(362, 12);
                    }
                    else if (dice == 6)
                    {
                        pb.Location = new Point(362, 202);
                    }

                    dice = 0;
                }
                if (dice > 0)
                {
                    movearound(pb);
                }

                dice--;
            }
            checkpush(pb, p);
            disablepieces();


        }

        //moves around table
        private void movearound(PictureBox pb)
        {
            if (pb.Location.X.Equals(286) && pb.Location.Y > 280)
            {
                if (pb.Location.Y.Equals(316))
                {
                    moveleft(pb);
                }
                else
                {
                    moveup(pb);
                }

            }
            else if (pb.Location.Y.Equals(240) && pb.Location.X < 320)
            {
                if (pb.Location.X.Equals(286))
                {
                    moveup(pb);
                }
                else
                {
                    moveright(pb);
                }

            }
            else if (pb.Location.X.Equals(286) && pb.Location.Y < 280)
            {
                if (pb.Location.Y.Equals(12))
                {
                    moveright(pb);
                }
                else
                {
                    moveup(pb);
                }

            }
            else if (pb.Location.Y.Equals(12))
            {
                if (pb.Location.X.Equals(362))
                {
                    movedown(pb);
                }
                else
                {
                    moveright(pb);
                }

            }
            else if (pb.Location.X.Equals(362) && pb.Location.Y < 300)
            {
                if (pb.Location.Y.Equals(240)) 
                {
                    moveright(pb);
                }
                else
                {
                    movedown(pb);
                }

            }
            else if (pb.Location.Y.Equals(240) && pb.Location.X > 320)
            {
                if (pb.Location.X.Equals(590))
                {
                    movedown(pb);
                }
                else
                {
                    moveright(pb);
                }

            }
            else if (pb.Location.X.Equals(590))
            {
                if (pb.Location.Y.Equals(316))
                {
                    moveleft(pb);
                }
                else
                {
                    movedown(pb);
                }

            }
            else if (pb.Location.Y.Equals(316) && pb.Location.X > 330)
            {
                if (pb.Location.X.Equals(362))
                {
                    movedown(pb);
                }
                else
                {
                    moveleft(pb);
                }

            }
            else if (pb.Location.X.Equals(362) && pb.Location.Y > 320)
            {
                if (pb.Location.Y.Equals(544))
                {
                    moveleft(pb);
                }
                else
                {
                    movedown(pb);
                }

            }
            else if (pb.Location.Y.Equals(544))
            {
                if (pb.Location.X.Equals(286))
                {
                    moveup(pb);
                }
                else
                {
                    moveleft(pb);
                }

            }
            else if (pb.Location.Y.Equals(316) && pb.Location.X < 330)
            {
                if (pb.Location.X.Equals(58))
                {
                    moveup(pb);
                }
                else
                {
                    moveleft(pb);
                }

            }
            else if (pb.Location.Y.Equals(316) && pb.Location.X < 330)
            {
                if (pb.Location.X.Equals(286))
                {
                    moveup(pb);
                }
                else
                {
                    moveleft(pb);
                }

            }
            else if (pb.Location.X.Equals(58))
            {
                if (pb.Location.Y.Equals(240))
                {
                    moveright(pb);
                }
                else
                {
                    moveup(pb);
                }

            }
        }
        private void moveup(PictureBox pb)
        {
            pb.Location = new Point(pb.Location.X, pb.Location.Y - 38);
        }
        private void movedown(PictureBox pb)
        {
            pb.Location = new Point(pb.Location.X, pb.Location.Y + 38);
        }
        private void moveleft(PictureBox pb)
        {
            pb.Location = new Point(pb.Location.X - 38, pb.Location.Y);
        }
        private void moveright(PictureBox pb)
        {
            pb.Location = new Point(pb.Location.X + 38, pb.Location.Y);
        }



        private void checkpush(PictureBox p, player pl)
        {
            foreach (player c in activeplayers)
            {
                if (c.name.Equals(pl.name))
                {
                    continue;
                }
                foreach (PictureBox b in c.pieces)
                    if (p.Location.X.Equals(b.Location.X) && p.Location.Y.Equals(b.Location.Y))
                    {

                        b.Location = new Point(c.homex, c.homey);

                    }
            }
        }
        private void goal(PictureBox pb, player pl)
        {
            winners += 10;
            pb.Location = new Point(1+winners, 590);
            pl.f += 1;
            if (pl.f == 4)
            {
                endgame(pl);   
            }
        }

        private void endgame(player pl)
        {
            
        }

    }
}
