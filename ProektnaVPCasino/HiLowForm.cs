using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProektnaVPCasino.Properties;
using System.Timers;
using System.Text.RegularExpressions;
using System.Media;
using System.Diagnostics;

namespace ProektnaVPCasino
{
    public partial class HiLowForm : Form
    {
        private GlavnaForma parent;
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
        public int pariInt { get; set; }
        SoundPlayer audio;
        public HiLowForm(GlavnaForma parent, int startCash)
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
            BackColor = Color.White;
            this.parent = parent;
            pariInt = startCash;
            betTip.Maximum = 100;
            timer1.Start();
            update();
            playAudio(0);
            DoubleBuffered = true;
        }
        private void playAudio(int tip)
        {
            audio = new SoundPlayer(ProektnaVPCasino.Properties.Resources.shuffleCards);
            if (tip == 1)
            {
                audio = new SoundPlayer(ProektnaVPCasino.Properties.Resources.winSound);
            }
            if (tip == 2)
            {
                audio = new SoundPlayer(ProektnaVPCasino.Properties.Resources.loseSound);
            }
            
            audio.Play();
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
            if (nextCard == 11)
            {
                generateNextCard();
                return;
            }

        }

        public void checkCards()
        {
            
            picBoxCurr.Image = cards[currCard - 1];

            //Proverue dali korisnikot odbral Visoka
            if((nextCardVal == 1 && nextCard>currCard)||(nextCardVal == 0 && nextCard < currCard))
            {
                playAudio(1);
                MessageBox.Show("Bravo");
                pogodeniKarti++;
                dobivka = (int)betTip.Value * pogodeniKarti + int.Parse(cashOutAmount.Text);
            }
            else
            {
                playAudio(2);
                MessageBox.Show("BOOOO");
                reset();
            }
            refreshImages();

        }

        //Refresh Card Images
        private void refreshImages()
        {
            cashOutAmount.Text = dobivka.ToString();
            pogodeni.Text = pogodeniKarti.ToString();
            currCard = nextCard;           
            picBoxCurr.Image = cards[currCard - 1];
            //picBoxNext.Image = picBoxNext.ErrorImage;
            playAudio(0);
            timer1.Start();
        }
        
        //Updates Value
        private void update()
        {
            pari.Text = pariInt.ToString();
            //betTip.Maximum = pariInt;
        }
        public void btnClickfunciton()
        {
            //Kod da zima pari za bettip
            if (pariInt < 0)
            {
                MessageBox.Show("Gi potrosivte vasite pari", "KRAJ IGRA", MessageBoxButtons.OK);
                endGame();
                return;
            }
            if (first)
            {
                pariInt = pariInt - (int)betTip.Value;
                first = false;
            }
            else
            {

                cashOutAmount.Text = (int.Parse(cashOutAmount.Text) - (int)betTip.Value).ToString();
                first = false;
            }
        }

        private void btnHi_Click(object sender, EventArgs e)
        {
            nextCardVal = 1;
            btnClickfunciton();
            betTip.Enabled = false;

            update();
            generateNextCard();
            checkCards();
            return;
        }
        private void btnLow_Click(object sender, EventArgs e)
        {
            nextCardVal = 0;
            btnClickfunciton();
            betTip.Enabled = false;
            update();
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
            betTip.Maximum = 100;
            cashOutAmount.Text = "0";
            betTip.Enabled = true;
            currCard = 7;
            picBoxCurr.Image = cards[currCard - 1];
            if (betTip.Minimum > pariInt)
            {
                betTip.Minimum = pariInt;
            }
            if (betTip.Maximum > pariInt)
            {
                betTip.Maximum = pariInt;
            }
        }

        private void cashOutbtn_Click(object sender, EventArgs e)
        {
            //Reset values
            pariInt = pariInt + dobivka;
            update();
            reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picBoxNext.Image = cards[rand.Next(MIN_SIZE, MAX_SIZE) - 1];
        }
        //Funkcija za zavrsuvanje na igra
        private void endGame()
        {
            pariInt = pariInt + dobivka;
            cashOutMoney = int.Parse(pari.Text);
            reset();
            this.Close();
        }
        private void endGamebtn_Click(object sender, EventArgs e)
        {
            endGame();
        }

        private void HiLowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pariInt = pariInt + dobivka;
            cashOutMoney = int.Parse(pari.Text);
            reset();
            audio.Stop();
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
            if (parent.mform == null)
            {
                parent.mform = new MusicForm();
            }
                parent.mform.Show();
        }

        private void betTip_ValueChanged(object sender, EventArgs e)
        {
            reset();
        }
    }
}
