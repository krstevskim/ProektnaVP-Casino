﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SameFormTest.Properties;
using System.Timers;
using System.Text.RegularExpressions;

namespace SameFormTest
{
    public partial class HiLowForm : Form
    {

        //Hi-Low Logic

        Random rand;
        public static int MIN_SIZE = 1;
        public static int MAX_SIZE = 14;
        public int nextCard { get; set; }
        public int currCard = 7;
        public int nextCardVal { get; set; }
        public int pogodeniKarti = 0;
        public int multi = 1;
        public int dobivka = 0;
        public List<Image> cards;
        public bool first = true;
        public int i = 0;
        public int cashOutMoney { get; set; }

        public HiLowForm(int startCash)
        {
            InitializeComponent();
            rand = new Random();
            cards = new List<Image>();
            cards.Add(Resources.hearts_1);
            cards.Add(Resources.hearts_2);
            cards.Add(Resources.hearts_3);
            cards.Add(Resources.hearts_4);
            cards.Add(Resources.hearts_5);
            cards.Add(Resources.hearts_6);
            cards.Add(Resources.hearts_7);
            cards.Add(Resources.hearts_8);
            cards.Add(Resources.hearts_9);
            cards.Add(Resources.hearts_10);
            cards.Add(Resources.hearts_11);
            cards.Add(Resources.hearts_12);
            cards.Add(Resources.hearts_13);
            cards.Add(Resources.hearts_14);
            pari.Text = startCash.ToString();
            timer1.Start();
            DoubleBuffered = true;
                       
        }

        public void generateNextCard()
        {
                timer1.Stop();              
                nextCard = rand.Next(MIN_SIZE, MAX_SIZE);
                picBoxNext.Image = cards[nextCard - 1];

                if (nextCard == currCard)
                {
                    //nextCard = rand.Next(MIN_SIZE, MAX_SIZE);
                    generateNextCard();
                    return;
                }
        }

        public void checkCards()
        {
            
            picBoxCurr.Image = cards[currCard - 1];

            //Proverue dali korisnikot odbral Visoka
            if (nextCardVal == 1)
            {
                
                if (nextCard >= currCard)
                {
                    MessageBox.Show("Bravo");
                    pogodeniKarti++;
                    dobivka = (int)betTip.Value * pogodeniKarti + int.Parse(cashOutAmount.Text);
                }
                
                else
                {
                    MessageBox.Show("BOOOO");
                    reset();
                }
            }
            // Ili odbral niska
            else
            {
                if (nextCard <= currCard)
                {
                    MessageBox.Show("Bravo");
                    pogodeniKarti++;
                    dobivka = (int)betTip.Value * pogodeniKarti + int.Parse(cashOutAmount.Text);
                }
                else
                {
                    MessageBox.Show("BOOOO");
                    reset();
                }
            }
            
            cashOutAmount.Text = dobivka.ToString();
            refreshImages();

        }
        //Refresh Card Images
        private void refreshImages()
        {
            pogodeni.Text = pogodeniKarti.ToString();
            currCard = nextCard;           
            picBoxCurr.Image = cards[currCard - 1];      
            //picBoxNext.Image = picBoxNext.ErrorImage;
            timer1.Start();
        }
        

        
        private void btnHi_Click(object sender, EventArgs e)
        {
            nextCardVal = 1;
            //Kod da zima pari za bettip

            if (first)
            {
                pari.Text = (int.Parse(pari.Text) - (int)betTip.Value).ToString();
                first = false;
            }
            else
            {          
                cashOutAmount.Text = (int.Parse(cashOutAmount.Text) - (int)betTip.Value).ToString();
                first = false;
            }

            if (int.Parse(pari.Text) < 0)
            {
                MessageBox.Show("Gi potrosivte vasite pari","KRAJ IGRA", MessageBoxButtons.OK);
                endGame();
                return;
                
            }
            generateNextCard();
            checkCards();
            return;
        }

        private void btnLow_Click(object sender, EventArgs e)
        {
            nextCardVal = 0;
            //Kod da zima pari za bettip
            if (first)
            {
                pari.Text = (int.Parse(pari.Text) - (int)betTip.Value).ToString();
                first = false;
            }
            else
            {
                cashOutAmount.Text = (int.Parse(cashOutAmount.Text) - (int)betTip.Value).ToString();
                first = false;
            }
            if (int.Parse(pari.Text) < 0)
            {
                MessageBox.Show("Gi potrosivte vasite pari", "KRAJ IGRA", MessageBoxButtons.OK);
                endGame();
                return;
            }
            generateNextCard();
            checkCards();
            return;
        }
        //Resetira vrednosti
        private void reset()
        {
            dobivka = 0;
            pogodeniKarti = 0;
            pogodeni.Text = "0";
            betTip.Enabled = true;
            first = true;
            betTip.Maximum = int.Parse(pari.Text);
            cashOutAmount.Text = "0";
            
        }
        private void cashOutbtn_Click(object sender, EventArgs e)
        {
            //Reset values
            pari.Text = (int.Parse(pari.Text) + dobivka).ToString();
            reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            picBoxNext.Image = cards[rand.Next(MIN_SIZE, MAX_SIZE) - 1];
            
        }
        //Funkcija za zavrsuvanje na igra
        private void endGame()
        {
            pari.Text = (int.Parse(pari.Text) + dobivka).ToString();
            cashOutMoney = int.Parse(pari.Text);
            reset();
            this.Close();
        }
        private void endGamebtn_Click(object sender, EventArgs e)
        {
            endGame();

        }
    }
}
