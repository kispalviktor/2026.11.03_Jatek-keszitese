using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2026._11._03_Jatek
{
    public partial class Form1 : Form
    {
        int jatekosPont = 0;
        int botPont = 0;

        Random veletlen = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Lepes(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Lepes(btn2);

        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            Lepes(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Lepes(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Lepes(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Lepes(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Lepes(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Lepes(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Lepes(btn9);
        }

        // A játékos lépése
        void Lepes(Button gomb)
        {
            if (gomb.Text == "")
            {
                gomb.Text = "X";

                if (Ellenorzes("X"))
                {
                    jatekosPont++;
                    lblEredmeny.Text = "Nyertél!";
                    lblEredmeny.ForeColor = Color.Green;
                    Pontszam();
                    Vege();
                }
                else if (Dontetlen())
                {
                    lblEredmeny.Text = "Döntetlen!";
                    lblEredmeny.ForeColor = Color.Orange;
                    Vege();
                }
                else
                {
                    BotLepes();
                }
            }
        }

        // A bot lépése
        void BotLepes()
        {
            List<Button> uresMezok = new List<Button>();

            foreach (Control elem in this.Controls)
            {
                if (elem is Button)
                {
                    Button gomb = (Button)elem;

                    if (gomb.Text == "" && gomb != btnUjra)
                    {
                        uresMezok.Add(gomb);
                    }
                }
            }

            if (uresMezok.Count > 0)
            {
                int szam = veletlen.Next(uresMezok.Count);

                uresMezok[szam].Text = "O";
            }

            if (Ellenorzes("O"))
            {
                botPont++;
                lblEredmeny.Text = "A bot nyert!";
                lblEredmeny.ForeColor = Color.Red;
                Pontszam();
                Vege();
            }
            else if (Dontetlen())
            {
                lblEredmeny.Text = "Döntetlen!";
                Vege();
            }
        }

        // Megnézi, hogy van-e nyertes
        bool Ellenorzes(string jel)
        {
            if (btn1.Text == jel && btn2.Text == jel && btn3.Text == jel)
                return true;

            if (btn4.Text == jel && btn5.Text == jel && btn6.Text == jel)
                return true;

            if (btn7.Text == jel && btn8.Text == jel && btn9.Text == jel)
                return true;

            if (btn1.Text == jel && btn4.Text == jel && btn7.Text == jel)
                return true;

            if (btn2.Text == jel && btn5.Text == jel && btn8.Text == jel)
                return true;

            if (btn3.Text == jel && btn6.Text == jel && btn9.Text == jel)
                return true;

            if (btn1.Text == jel && btn5.Text == jel && btn9.Text == jel)
                return true;

            if (btn3.Text == jel && btn5.Text == jel && btn7.Text == jel)
                return true;

            return false;
        }

        // Megnézi, hogy döntetlen-e
        bool Dontetlen()
        {
            if (btn1.Text != "" &&
                btn2.Text != "" &&
                btn3.Text != "" &&
                btn4.Text != "" &&
                btn5.Text != "" &&
                btn6.Text != "" &&
                btn7.Text != "" &&
                btn8.Text != "" &&
                btn9.Text != "")
            {
                return true;
            }

            return false;
        }

        // A pontszámok frissítése
        void Pontszam()
        {
            lblJatekos.Text = "Játékos: " + jatekosPont;
            lblBot.Text = "Bot: " + botPont;
        }

        // A játék vége
        void Vege()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        // Új játék
        private void btnUjra_Click(object sender, EventArgs e)
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;

            lblEredmeny.Text = "";
        }

    }
}
