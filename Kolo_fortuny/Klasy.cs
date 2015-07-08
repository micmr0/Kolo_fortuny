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
    public class Pole : System.Windows.Forms.TextBox
    {
        public Pole()
        {
            this.Width = 40;
            this.Height = 40;
            this.BackColor = Color.White;
            this.Font = new Font("Georgia", 16);
            this.TextAlign = HorizontalAlignment.Center;
            this.ReadOnly = true;
            this.Enabled = false;
            this.UseSystemPasswordChar = true;
            this.ForeColor = Color.Black;
            this.Visible = true;
        }

        public Pole(string z)
        {
            this.Width = 40;
            this.Height = 40;
            this.BackColor = Color.White;
            this.Font = new Font("Georgia", 16);
            this.TextAlign = HorizontalAlignment.Center;
            this.ReadOnly = true;
            this.Enabled = false;
            this.UseSystemPasswordChar = true;
            this.ForeColor = Color.Black;
            this.Visible = true;
        }

        public Pole(Pole p)
        {
            this.Width = p.Width;
            this.Height = p.Height;
            this.BackColor = p.BackColor;
            this.Name = p.Name;
            this.Font = p.Font;
            this.TextAlign = HorizontalAlignment.Center;
            this.ReadOnly = true;
            this.Enabled = false;
            this.UseSystemPasswordChar = true;
            this.ForeColor = Color.Black;
            this.Visible = true;
        }
    }

    public class Haslo
    {
        public int size;
        public string password;
        public Pole[] pole;
        public int ileOdsloniete;

        public Haslo()
        {
            size = 0;
            pole = new Pole[password.Length];
            password = "0";
            ileOdsloniete = 0;
        }

        public Haslo(string s)
        {
            pole = new Pole[s.Length];
            size = s.Length;
            password = s;

            for (int i = 0; i < pole.Length; i++)
            {
                pole[i] = new Pole();
                pole[i].Name = "Literka "+i;
                pole[i].Location = new Point(60 * i + 80, 120);
                pole[i].Text = Convert.ToString(password[i]);      
            }
        }
    }

    public class Literka
    {
        public int x;
        public int y;
        public char znak;
        public int rozmiar;
        public bool stan;

        public Literka()
        {
            this.x = 0;
            this.y = 0;
            this.znak = '0';
            this.rozmiar = 40;
            this.stan = false;
        }

        public Literka(char z)
        {
            this.x = 0;
            this.y = 0;
            this.znak = z;
            this.rozmiar = 40;
            this.stan = false;
        }
    }

   
    
    public class Koło
    {
        public Bitmap obrazek;
        public Bitmap tempObrazek;
        public float kat;
        public int[] wartosciStanu;
        public int stan;

        public Koło()
        {
            tempObrazek = new Bitmap(Properties.Resources.kolo);
            obrazek = new Bitmap(Properties.Resources.kolo);        
            wartosciStanu = new int[] { 425, 225, 375, -1, 25, 275, 400, 325, 100, 0, 200, 50, 350, 3000, 175, 475, 300, 125, 75, 500};
            kat = 0.0f;
        }

    }

    class Gracz
    {
        public String imie;
        public int stanKonta;
        public bool zgadnieteHaslo;


        public Gracz(string i)
        {
            imie = i;
            stanKonta = 0;
            zgadnieteHaslo = false;
        }
    }

    class Gra
    {
        public int etap;
        public bool koniecGry;
        public string[] podpowiedz;
        public int odgadnietaSpolgloska;
        public int stawka;

        public Gra()
        {
            etap = 1;
            koniecGry = false;
            odgadnietaSpolgloska = 0;
            stawka = 0;
            podpowiedz = new string[] {"Kliknij koło, aby zakręcić" ,"Kup samogłoskę lub zakręć kołem", "Grasz o "+stawka, "Bankrut. Tracisz wszystko", "Brak litery w haśle"};
        }

        public void sprawdzStan()
        {
            
        }
    }

}



