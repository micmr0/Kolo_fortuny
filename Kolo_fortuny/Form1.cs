using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolo_fortuny
{
    public partial class Form1 : Form
    {
        Haslo haselko;
        Pole[] pole;
        Koło koloFortuny;
        bool wheelIsMoved;
        float startWheelTimes;
        float wheelTimes;
        Timer gameTimer;
        Timer wheelTimer;
        Button[] przycisk;
        Button[] samogloska;
        Button[] spolgloska;
        String[] hasla = { "OCEANARIUM", "UNIWERSYTET", "TITANIC", "KRAJOBRAZ", "MEDYCYNA", "TELEWIZOR" };
        Random rand;
        int los;

        Gra gra;
        Gracz gracz1;

        public Form1()
        {
            rand = new Random();
            los = rand.Next(0, hasla.Length);
            koloFortuny = new Koło();
            haselko = new Haslo(hasla[los]);
            pole = new Pole[haselko.size];
            gracz1 = new Gracz("player");
            wheelIsMoved = false;
            wheelTimes = 100;
            InitializeComponent();
            rysujHaslo();
            wheelTimer = new Timer();
            wheelTimer.Interval = 10;
            wheelTimer.Tick += wheelTimer_Tick;
            

            przycisk = new Button[35];
            samogloska = new Button[9];
            spolgloska = new Button[26];

            przycisk[0] = button1;
            przycisk[1] = button2;
            przycisk[2] = button3;
            przycisk[3] = button4;
            przycisk[4] = button5;
            przycisk[5] = button6;
            przycisk[6] = button7;
            przycisk[7] = button8;
            przycisk[8] = button9;
            przycisk[9] = button10;
            przycisk[10] = button11;
            przycisk[11] = button12;
            przycisk[12] = button13;
            przycisk[13] = button14;
            przycisk[14] = button15;
            przycisk[15] = button16;
            przycisk[16] = button17;
            przycisk[17] = button18;
            przycisk[18] = button19;
            przycisk[19] = button20;
            przycisk[20] = button21;
            przycisk[21] = button22;
            przycisk[22] = button23;
            przycisk[23] = button24;
            przycisk[24] = button25;
            przycisk[25] = button26;
            przycisk[26] = button27;
            przycisk[27] = button28;
            przycisk[28] = button29;
            przycisk[29] = button30;
            przycisk[30] = button31;
            przycisk[31] = button32;
            przycisk[32] = button33;
            przycisk[33] = button34;
            przycisk[34] = button35;

            samogloska[0] = button1;
            samogloska[1] = button2;
            samogloska[2] = button7;
            samogloska[3] = button8;
            samogloska[4] = button12;
            samogloska[5] = button20;
            samogloska[6] = button21;
            samogloska[7] = button28;
            samogloska[8] = button32;



            spolgloska[0] = button3;
            spolgloska[1] = button4;
            spolgloska[2] = button5;
            spolgloska[3] = button6;
            spolgloska[4] = button9;
            spolgloska[5] = button10;
            spolgloska[6] = button11;
            spolgloska[7] = button13;
            spolgloska[8] = button14;
            spolgloska[9] = button15;
            spolgloska[10] = button16;
            spolgloska[11] = button17;
            spolgloska[12] = button18;
            spolgloska[13] = button19;
            spolgloska[14] = button22;
            spolgloska[15] = button23;
            spolgloska[16] = button24;
            spolgloska[17] = button25;
            spolgloska[18] = button26;
            spolgloska[19] = button27;
            spolgloska[20] = button29;
            spolgloska[21] = button30;
            spolgloska[22] = button31;
            spolgloska[23] = button33;
            spolgloska[24] = button34;
            spolgloska[25] = button35;

            for (int i = 0; i < 34; i++ )
            {
                przycisk[i].IsAccessible = true;    //juz wybrana
                przycisk[i].Enabled = true;         //aktywna albo wygaszona
                przycisk[i].Visible = false;        // widoczna lub nie
            }

            gra = new Gra();

            gameTimer = new Timer();
            gameTimer.Interval = 100;
            gameTimer.Tick += gameTimer_Tick;
            label4.Text = gra.podpowiedz[0];

            gameTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void obsluzButton(object sender, EventArgs e)
        {
            Boolean ifExist = false;
            Button obiekt = (Button)sender;
            for(int i=0; i<haselko.size; i++ )
            {
                if ((haselko.pole[i].Text).Equals((obiekt.Text)))
                {
                    haselko.pole[i].UseSystemPasswordChar = false;
                    obiekt.IsAccessible = false;
                    
                    if (obiekt.Text.Equals("A") || obiekt.Text.Equals("Ą")
                        || obiekt.Text.Equals("E") || obiekt.Text.Equals("Ę")
                        || obiekt.Text.Equals("I") || obiekt.Text.Equals("O")
                        || obiekt.Text.Equals("U") || obiekt.Text.Equals("Ó")
                        || obiekt.Text.Equals("Y") )
                    {
                        gracz1.stanKonta -= 300;
                        label6.Text = Convert.ToString(gracz1.stanKonta);
                    }
                    else
                    {
                        gra.odgadnietaSpolgloska += 1;
                        gracz1.stanKonta += gra.stawka;
                        label6.Text = Convert.ToString(gracz1.stanKonta);
                        gra.etap = 3;
                    }

                    ifExist = true;
                    haselko.ileOdsloniete++;
                }
            }

            if( !ifExist )
            {
                label4.Text = gra.podpowiedz[4];
                gra.odgadnietaSpolgloska = 0;
                gra.etap = 1;
            }

        }
        
        public Bitmap rotateImage()
        {
            Bitmap rotatedImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((pictureBox1.Width / 2), pictureBox1.Height / 2); //set the rotation point as the center into the matrix
                g.RotateTransform(koloFortuny.kat); //rotate
                g.TranslateTransform(-pictureBox1.Width / 2, -pictureBox1.Height / 2); //restore rotation point into the matrix
                g.DrawImage(koloFortuny.tempObrazek, new Point(0, 0)); //draw the image on the new bitmap
            }
            return rotatedImage;
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            label4.Visible = false;

            if (wheelIsMoved && wheelTimes > 0)
            {
                koloFortuny.kat += wheelTimes/10;
                koloFortuny.kat = koloFortuny.kat % 360;
                RotateImage(pictureBox1, koloFortuny.obrazek, koloFortuny.kat);
                wheelTimes--;
            }

            koloFortuny.stan = Convert.ToInt32(Math.Ceiling(koloFortuny.kat / 18));

            if (koloFortuny.stan == 0)
            {
                koloFortuny.stan = 0;
            }
            else
            {
                koloFortuny.stan -= 1;
            }

            label1.Text = Convert.ToString(koloFortuny.kat);
            label2.Text = Convert.ToString(koloFortuny.stan);
            label3.Text = Convert.ToString(koloFortuny.wartosciStanu[koloFortuny.stan]);

            gra.stawka = koloFortuny.wartosciStanu[koloFortuny.stan];
            gra.podpowiedz[2] = "Grasz o " + gra.stawka;

            if (wheelTimes == 0)
            {
                wheelIsMoved = false;

                for (int i = 0; i < przycisk.Length;i++ )
                {
                    if (przycisk[i].IsAccessible)
                    {
                        przycisk[i].Visible = true;
                    }
                }

                if(koloFortuny.wartosciStanu[koloFortuny.stan] == 0)
                {
                    gracz1.stanKonta = 0;
                    gra.etap = 1;
                }
                else
                {
                    gra.etap = 2;
                }

                wheelTimer.Stop();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            switch (gra.etap)
            {
                case 1:
                    etap1();
                    break;
                case 2:
                    etap2();
                    break;
                case 3:
                    etap3();
                    break;
            }

            if(haselko.ileOdsloniete>0 && haselko.ileOdsloniete == haselko.size)
            {
                gracz1.zgadnieteHaslo = true;
                haselko.ileOdsloniete =0;
            }

            if(gracz1.zgadnieteHaslo)
            {
                gameTimer.Stop();

                if (DialogResult.OK == MessageBox.Show("Wygrałeś!. Wygrana kwota to " + gracz1.stanKonta + ". Rozpocząć kolejną grę? ", "Alert"
                              , MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    this.Close();
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                }
                gracz1.zgadnieteHaslo = false;

            }

        }

        public void etap1()
        {
            label4.Visible = true;
            
            pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);

            for (int i = 0; i < przycisk.Length; i++)
            {
                przycisk[i].Visible = false;
            }

        }

        public void etap2()
        {
            label4.Visible = true;
            label4.Text = gra.podpowiedz[2];
            pictureBox1.Click -= new System.EventHandler(this.pictureBox1_Click);


                    for (int i = 0; i < samogloska.Length; i++)
                    {
                         if (samogloska[i].IsAccessible)
                         {
                             samogloska[i].Enabled = false;
                         }
                    
                    } 


            for (int i = 0; i < spolgloska.Length; i++)
            {
                if(spolgloska[i].IsAccessible)
                {
                   spolgloska[i].Enabled = true;
                   spolgloska[i].Visible = true;
                }
                else
                {
                   spolgloska[i].Enabled = false;
                   spolgloska[i].Visible = false;
                }
            }

           
        }

        public void etap3()
        {
            label4.Text = gra.podpowiedz[1];
            pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);

            for (int i = 0; i < spolgloska.Length; i++) spolgloska[i].Enabled = false;


            if (gracz1.stanKonta >= 300)
            {
                for (int i = 0; i < samogloska.Length; i++) samogloska[i].Enabled = true;
            }
            else
            {
                for (int i = 0; i < samogloska.Length; i++) samogloska[i].Enabled = false;
            }

            for (int i = 0; i < spolgloska.Length; i++)
            {
                spolgloska[i].Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200);
            startWheelTimes = wheelTimes;

            for (int i = 0; i < przycisk.Length; i++)
            {
                przycisk[i].Visible = false;
            }
            wheelTimer.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

   

    }
}
