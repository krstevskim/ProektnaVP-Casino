using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProektnaVPCasino
{
    public partial class RoulleteForm : Form
    {
        public static List<RoulleteNumbers> numbers = new List<RoulleteNumbers>()
        {
            new RoulleteNumbers(0,Color.Green),new RoulleteNumbers(32,Color.Red),new RoulleteNumbers(15,Color.Black),new RoulleteNumbers(19,Color.Red),
            new RoulleteNumbers(4,Color.Black),new RoulleteNumbers(21,Color.Red),new RoulleteNumbers(2,Color.Black),new RoulleteNumbers(25,Color.Red),
            new RoulleteNumbers(17,Color.Black),new RoulleteNumbers(34,Color.Red),new RoulleteNumbers(6,Color.Black),new RoulleteNumbers(27,Color.Red),
            new RoulleteNumbers(13,Color.Black),new RoulleteNumbers(36,Color.Red),new RoulleteNumbers(11,Color.Black),new RoulleteNumbers(30,Color.Red),
            new RoulleteNumbers(8,Color.Black),new RoulleteNumbers(23,Color.Red),new RoulleteNumbers(10,Color.Black),new RoulleteNumbers(5,Color.Red),
            new RoulleteNumbers(24,Color.Black),new RoulleteNumbers(16,Color.Red),new RoulleteNumbers(33,Color.Black),new RoulleteNumbers(1,Color.Red),
            new RoulleteNumbers(20,Color.Black),new RoulleteNumbers(14,Color.Red),new RoulleteNumbers(31,Color.Black),new RoulleteNumbers(9,Color.Red),
            new RoulleteNumbers(22,Color.Black),new RoulleteNumbers(18,Color.Red),new RoulleteNumbers(29,Color.Black),new RoulleteNumbers(7,Color.Red),
            new RoulleteNumbers(28,Color.Black),new RoulleteNumbers(12,Color.Red),new RoulleteNumbers(35,Color.Black),new RoulleteNumbers(3,Color.Red),
            new RoulleteNumbers(26,Color.Black)
        };
        
        private GlavnaForma parent;
        public List<Label> clickedLabels;
        public int pozicija { get; set; }
        public List<RoulleteNumbers> temp;
        Timer timer1;
        public static Random r = new Random();
        public int timeRotate;
        public int elapsedTime;
        public int pariInt { get; set; }
        public int betSize { get; set; }
        public int multiSize { get; set; }
        public int BROJ_BET_BROJKI = 0;
        private bool isRunning = false;
        public RoulleteForm(GlavnaForma parent,int startCash)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.parent = parent;
            temp = new List<RoulleteNumbers>();
            timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(timer1_Tick);
            timeRotate = 6800;
            elapsedTime = 0;
            pozicija = r.Next(5, 36);
            int i = pozicija-5;
            pariInt = startCash;
            totalMoney.Text = pariInt.ToString();
            multiSize = 1;
            clickedLabels = new List<Label>();
            while (i< pozicija) {
                    temp.Add(numbers[i]);
                i++;
                }
            uplateniBroevi.Text = "";
            uplateniBroeviTip.Text = "";
            refreshImages();
            //timer1.Start();
        }
        public void refreshImages()
        {
            //Refreshes image after rotation
            num1.Text = temp[0].number.ToString();num1.BackColor = temp[0].color;
            num2.Text = temp[1].number.ToString(); num2.BackColor = temp[1].color;
            num3.Text = temp[2].number.ToString(); num3.BackColor = temp[2].color;
            num4.Text = temp[3].number.ToString(); num4.BackColor = temp[3].color;
            num5.Text = temp[4].number.ToString(); num5.BackColor = temp[4].color;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Checks if the time has elapsed
            if (elapsedTime > timeRotate)
            {
                timer1.Stop();
                
                calcWin();
                return;
            }
            elapsedTime += timer1.Interval;
            rotate();
            refreshImages();
            
        }
        private void playAudio(int tip)
        {
            SoundPlayer audio = new SoundPlayer(ProektnaVPCasino.Properties.Resources.rouletteSpin_DropBall_8S);
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

        private void reset()
        {
            //Resets all values 
            betTip.Value = 0;
            foreach(RoulleteNumbers num in numbers)
            {
                num.bet = 0;
            }
            clickedLabels = new List<Label>();
            evenNUD.Value = 0;oddNUD.Value = 0;blackNUD.Value = 0;redNUD.Value = 0;lowNUD.Value = 0;highNUD.Value = 0;
            BROJ_BET_BROJKI = 0;
            beginBtn.Enabled = true;
            elapsedTime = 0;
            uplateniBroevi.Text = "";
            uplateniBroeviTip.Text = "";
            timer1.Interval = 50;
            vkVlogTxt.Text = "0";
            endGameBtn.Enabled = true;
            isRunning = false;
            enableBtns();
        }

        private void calcWin()
        {
            //Calculates Win!
            RoulleteNumbers winNum = temp[2];
            int win = 0;
            if(BROJ_BET_BROJKI !=0)
            foreach(RoulleteNumbers num in numbers)
            {
                if (num == winNum)
                {
                        win += num.bet * 36;
                }
            }

            if (evenNUD.Value > 0 && winNum.number % 2 == 0)
            {
                win = win + (int)evenNUD.Value*2;
            }
            if (oddNUD.Value > 0 && winNum.number % 2 != 0)
            {
                win = win + (int)oddNUD.Value*2;
            }
            if (blackNUD.Value > 0 && winNum.color == Color.Black)
            {
                win = win + (int)blackNUD.Value*2;
            }
            if (redNUD.Value > 0 && winNum.color == Color.Red)
            {
                win = win + (int)redNUD.Value*2;
            }
            if (lowNUD.Value > 0 && winNum.number < 19)
            {
                win = win + (int)lowNUD.Value*2;
            }
            if (highNUD.Value > 0 && winNum.number >=19)
            {
                win = win + (int)highNUD.Value*2;
            }
            if (win > 0)
            {
                playAudio(1);
            }
            else
            {
                playAudio(2);
            }
            pariInt += win;
            totalMoney.Text = pariInt.ToString();
            dobivkaTxt.Text = win.ToString();
            resetBtn.Enabled = true;
            reset();

        }

        public void rotate()
        {
            //Rotates the numbers
            RoulleteNumbers temp2;
            if (pozicija > 36)
                pozicija = 0;
            temp2 = temp[4];
            temp[4] = numbers[pozicija];
            temp[0] = temp[1];
            temp[1] = temp[2];
            temp[2] = temp[3];
            temp[3] = temp2;

            pozicija++;
            if(elapsedTime>timeRotate/4&& elapsedTime<timeRotate/2)
                timer1.Interval += 5;
            if (elapsedTime > timeRotate / 2)
                timer1.Interval += 10;
        }

        public bool validate()
        {
            //Validates if there is a bet
            bool checkTemp = false;
            foreach(RoulleteNumbers num in numbers)
            {
                if (num.bet > 0)
                {
                    checkTemp = true;
                    
                }
                
            }
            
            if (evenNUD.Value > 0 || oddNUD.Value > 0 || blackNUD.Value > 0 || redNUD.Value > 0 || lowNUD.Value > 0 || highNUD.Value > 0)
            {
                checkTemp = true;
            }

            return checkTemp;
        }

        private void enableBtns()
        {
            betTip.Enabled = true;
            evenNUD.Enabled = true;
            oddNUD.Enabled = true;
            blackNUD.Enabled = true;
            redNUD.Enabled = true;
            highNUD.Enabled = true;
            lowNUD.Enabled = true;
        }

        private void disableBtns()
        {
            betTip.Enabled = false;
            betTip.Value = 0;
            evenNUD.Enabled = false;
            oddNUD.Enabled = false;
            blackNUD.Enabled = false;
            redNUD.Enabled = false;
            highNUD.Enabled = false;
            lowNUD.Enabled = false;
        }

        private void beginBtn_Click(object sender, EventArgs e)
        {
            //Begins game
            if (validate())
            {
                timer1.Start();
                playAudio(0);
                disableBtns();
                beginBtn.Enabled = false;
                resetBtn.Enabled = false;
                pariInt -= (int)(evenNUD.Value + oddNUD.Value + blackNUD.Value + redNUD.Value + lowNUD.Value + highNUD.Value);

            }
            else
            {
                MessageBox.Show("Stavete oblog");
            }

        }

        private void vkupenVlog()
        {
            
            //Calculates vkupenVlog and updates necessery fiels
            int vkupenVlog1 = 0;
            int vkupenVlog = 0;
            uplateniBroevi.Text = "";
            uplateniBroeviTip.Text = "";
            foreach(RoulleteNumbers num in numbers)
            {
                vkupenVlog1 += num.bet;
                if (num.bet > 0)
                {
                   
                    uplateniBroevi.Text += num.number.ToString() + " ";
                    uplateniBroeviTip.Text += num.bet.ToString() + " ";
                }
            }

            vkupenVlog += (int)(evenNUD.Value + oddNUD.Value + blackNUD.Value + redNUD.Value + lowNUD.Value + highNUD.Value);
            if (vkupenVlog > pariInt)
            {
                beginBtn.Enabled = false;
            }
            else beginBtn.Enabled = true;
            if (vkupenVlog + vkupenVlog1 > 0)
            {
                endGameBtn.Enabled = false;
                isRunning = true;
            }
            else
            {
                isRunning = false;
                endGameBtn.Enabled = true;
            }
            vkVlogTxt.Text = (vkupenVlog + vkupenVlog1).ToString();
            totalMoney.Text = pariInt.ToString();
            
        }
        
        private bool getMoney()
        {
            //Checks if there is enough money to place a bet on a number and also takes 
            //money for the ammount that was selected
            if (pariInt - (int)betTip.Value >= 0)
            {
                pariInt -= (int)betTip.Value;
                BROJ_BET_BROJKI++;
                return true;
            }
            else
            {
                MessageBox.Show("Nemate dovolno pari");
                return false;
            }
            
        }
        //Below are all the DoubleClick events for the numbers
        private void label0_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 0);
            if (!clickedLabels.Contains(label0))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label0);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label0);
            }
            vkupenVlog();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 1);
            if (!clickedLabels.Contains(label1)) { 
            if (getMoney()) result.bet = (int)betTip.Value;
            clickedLabels.Add(label1);
            
        }
            else
            {
                pariInt += result.bet;result.bet = 0;
                clickedLabels.Remove(label1);
            }
            vkupenVlog();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 2);
            if (!clickedLabels.Contains(label2))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label2);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label2);
            }
            vkupenVlog();
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 3);
            if (!clickedLabels.Contains(label3))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label3);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label3);
            }
            vkupenVlog();
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 4);
            if (!clickedLabels.Contains(label4))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label4);

            }
            else
            {
                
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label4);
            }
            vkupenVlog();
        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 5);
            if (!clickedLabels.Contains(label5))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label5);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label5);
            }
            vkupenVlog();
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 6);
            if (!clickedLabels.Contains(label6))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label6);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label6);
            }
            vkupenVlog();
        }

        private void label7_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 7);
            if (!clickedLabels.Contains(label7))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label7);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label7);
            }
            vkupenVlog();
        }

        private void label8_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 8);
            if (!clickedLabels.Contains(label8))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label8);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label8);
            }
            vkupenVlog();
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 9);
            if (!clickedLabels.Contains(label9))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label9);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label9);
            }
            vkupenVlog();
        }

        private void label10_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 10);
            if (!clickedLabels.Contains(label10))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label10);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label10);
            }
            vkupenVlog();
        }

        private void label11_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 11);
            if (!clickedLabels.Contains(label11))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label11);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label11);
            }
            vkupenVlog();
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 12);
            if (!clickedLabels.Contains(label12))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label12);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label12);
            }
            vkupenVlog();
        }

        private void label13_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 13);
            if (!clickedLabels.Contains(label13))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label13);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label13);
            }
            vkupenVlog();
        }

        private void label14_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 14);
            if (!clickedLabels.Contains(label14))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label14);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label14);
            }
            vkupenVlog();
        }

        private void label15_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 15);
            if (!clickedLabels.Contains(label15))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label15);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label15);
            }
            vkupenVlog();
        }

        private void label16_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 16);
            if (!clickedLabels.Contains(label16))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label16);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label16);
            }
            vkupenVlog();
        }

        private void label17_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 17);
            if (!clickedLabels.Contains(label17))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label17);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label17);
            }
            vkupenVlog();
        }

        private void label18_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 18);
            if (!clickedLabels.Contains(label18))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label18);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label18);
            }
            vkupenVlog();
        }

        private void label19_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 19);
            if (!clickedLabels.Contains(label19))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label19);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label19);
            }
            vkupenVlog();
        }

        private void label20_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 20);
            if (!clickedLabels.Contains(label20))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label20);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label20);
            }
            vkupenVlog();
        }

        private void label21_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 21);
            if (!clickedLabels.Contains(label21))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label21);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label21);
            }
            vkupenVlog();
        }

        private void label22_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 22);
            if (!clickedLabels.Contains(label22))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label22);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label22);
            }
            vkupenVlog();
        }

        private void label23_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 23);
            if (!clickedLabels.Contains(label23))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label23);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label23);
            }
            vkupenVlog();
        }

        private void label24_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 24);
            if (!clickedLabels.Contains(label24))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label24);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label24);
            }
            vkupenVlog();
        }

        private void label25_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 25);
            if (!clickedLabels.Contains(label25))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label25);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label25);
            }
            vkupenVlog();
        }

        private void label26_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 26);
            if (!clickedLabels.Contains(label26))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label26);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label26);
            }
            vkupenVlog();
        }

        private void label27_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 27);
            if (!clickedLabels.Contains(label27))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label27);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label27);
            }
            vkupenVlog();
        }

        private void label28_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 28);
            if (!clickedLabels.Contains(label28))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label28);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label28);
            }
            vkupenVlog();
        }

        private void label29_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 29);
            if (!clickedLabels.Contains(label29))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label29);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label29);
            }
            vkupenVlog();
        }

        private void label30_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 30);
            if (!clickedLabels.Contains(label30))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label30);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label30);
            }
            vkupenVlog();
        }

        private void label31_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 31);
            if (!clickedLabels.Contains(label31))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label31);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label31);
            }
            vkupenVlog();
        }

        private void label32_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 32);
            if (!clickedLabels.Contains(label32))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label32);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label32);
            }
            vkupenVlog();
        }

        private void label33_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 33);
            if (!clickedLabels.Contains(label33))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label33);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label33);
            }
            vkupenVlog();
        }

        private void label34_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 34);
            if (!clickedLabels.Contains(label34))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label34);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label34);
            }
            vkupenVlog();
        }

        private void label35_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 35);
            if (!clickedLabels.Contains(label35))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label35);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label35);
            }
            vkupenVlog();
        }

        private void label36_DoubleClick(object sender, EventArgs e)
        {
                RoulleteNumbers result = numbers.Find(x => x.number == 36);
            if (!clickedLabels.Contains(label36))
            {
                if (getMoney()) result.bet = (int)betTip.Value;
                clickedLabels.Add(label36);

            }
            else
            {
                pariInt += result.bet; result.bet = 0;
                clickedLabels.Remove(label36);
            }
            vkupenVlog();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void evenNUD_ValueChanged(object sender, EventArgs e) 
        {
            vkupenVlog();
        }

        private void oddNUD_ValueChanged(object sender, EventArgs e)
        {
            vkupenVlog();
        }

        private void blackNUD_ValueChanged(object sender, EventArgs e)
        {
            vkupenVlog();
        }

        private void redNUD_ValueChanged(object sender, EventArgs e)
        {
            vkupenVlog();
        }

        private void lowNUD_ValueChanged(object sender, EventArgs e)
        {
            vkupenVlog();
        }

        private void highNUD_ValueChanged(object sender, EventArgs e)
        {
            vkupenVlog();
        }

        
        private void endGameBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoulleteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
                e.Cancel = true;
            else e.Cancel = false;
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
            if (parent.mform == null)
            {
                parent.mform = new MusicForm();
            }
            parent.mform.Show();
        }
    }
}
