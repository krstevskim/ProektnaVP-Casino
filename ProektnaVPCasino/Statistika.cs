using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProektnaVPCasino
{
    public partial class Statistika : Form
    {
        private  Izvlekuvanje parent;
        private int Dobivka { get; set; }
        private int count { get; set; }

        public Statistika(Izvlekuvanje p)
        {
            
            InitializeComponent();
            Dobivka = 0;
            count = 0;
            parent = p;
            showIzvleceni();
            showOdigrani();
            showPogodeni();
            showUplata();
            CalculteWin();
            showDobivka();
        }

        void showIzvleceni() {
            foreach (int l in parent.IzvleceniBroevi) {
                IzvleceniTB.Text += l.ToString() + " ";
            }
        }

        void showOdigrani() {
            foreach (int l in parent.parent.OdigraniBroevi) {
                OdigraniTB.Text += l.ToString() + " ";
            }
        }
        void showPogodeni() {
            
            for (int i = 0; i < parent.parent.OdigraniBroevi.Count; i++) {
                for (int j = 0; j < parent.IzvleceniBroevi.Count; j++) {
                    if (parent.parent.OdigraniBroevi[i] == parent.IzvleceniBroevi[j]) {
                        count++;
                    }
                }
            }
            int total = parent.parent.BrojUplateniBroevi;

            PogodeniTB.Text=count.ToString() + "/" + total.ToString();

        }

        void showUplata() {
            uplataTB.Text = parent.parent.Bet.ToString();
        }

        void showDobivka() {
            DobivkaTB.Text = Dobivka.ToString();
        }

        private void YesBTN_Click(object sender, EventArgs e)
        {


            parent.parent.NewGame(Dobivka); 
            parent.parent.Visible = true;


            
            this.Close();
            parent.Close();
          
            

        }
        private void CalculteWin() {
            int BrojOdigraniBroevi = parent.parent.BrojUplateniBroevi;
            int Uplata = parent.parent.Bet;
            if (BrojOdigraniBroevi == 5) {
                if (count == 3)
                {
                    Dobivka = 3 * Uplata;
                }
                else if (count == 4)
                {
                    Dobivka = 3 * 3 * Uplata;
                }
                else if (count == 5)
                {
                    Dobivka = 3 * 3 * 3 * Uplata;

                }
                else
                {
                    Dobivka = 0;
                }
            }

            if (BrojOdigraniBroevi == 6)
            {
                if (count == 4)
                {
                    Dobivka = 4 * Uplata;
                }
                else if (count == 5)
                {
                    Dobivka = 4 * 4 * Uplata;
                }
                else if (count == 6)
                {
                    Dobivka = 4 * 4 * 4 * Uplata;
                }
                else
                {
                    Dobivka = 0;
                }
            }

            else if (BrojOdigraniBroevi == 7)
            {
                if (count == 5)
                {
                    Dobivka = 5 * Uplata;
                }
                else if (count == 6)
                {
                    Dobivka = 5 * 5 * Uplata;
                }
                else if (count == 7)
                {
                    Dobivka = 5 * 5 * 5 * Uplata;
                }
                else
                {
                    Dobivka = 0;
                }

            }

            else if (BrojOdigraniBroevi == 8)
            {
                if (count == 5)
                {
                    Dobivka = 6 * Uplata;

                }
                else if (count == 6)
                {
                    Dobivka = 6 * 6 * Uplata;
                }
                else if (count == 7)
                {
                    Dobivka = 6 * 6 * 6 * Uplata;
                }
                else if (count == 8)
                {
                    Dobivka = 6 * 6 * 6 * 6 * Uplata;
                }
                else
                {
                    Dobivka = 0;
                }
            }
            else if (BrojOdigraniBroevi == 9)
            {
                if (count == 6)
                {
                    Dobivka = 7 * Uplata;
                }
                else if (count == 7)
                {
                    Dobivka = 7 * 7 * Uplata;
                }
                else if (count == 8)
                {
                    Dobivka = 7 * 7 * 7 * Uplata;
                }
                else if (count == 9)
                {
                    Dobivka = 7 * 7 * 7 * 7 * Uplata;
                }
                else {
                    Dobivka = 0;
                }
            }
            else {
                if (count == 7)
                {
                    Dobivka = 8 * Uplata;
                }
                else if (count == 8)
                {
                    Dobivka = 8 * 8 * Uplata;
                }
                else if (count == 9)
                {
                    Dobivka = 8 * 8 * 8 * Uplata;
                }
                else if (count == 10)
                {
                    Dobivka = 8 * 8 * 8 * 8 * Uplata;
                }
                else {
                    Dobivka = 0;
                }
            }


        }
    }
}
