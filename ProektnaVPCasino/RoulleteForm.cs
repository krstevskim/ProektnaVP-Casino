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
        public RoulleteForm()
        {
            temp = new List<RoulleteNumbers>();
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(timer1_Tick);
            timeRotate = r.Next(7, 9) * 1000;
            elapsedTime = 0;
            pozicija = r.Next(5, 36);
            int i = pozicija-5;
            pariInt = 10000;
            totalMoney.Text = pariInt.ToString();
            multiSize = 1;
            while (i< pozicija) {
                    temp.Add(numbers[i]);
                i++;
                }

            refreshImages();
            //timer1.Start();
        }
        public void refreshImages()
        {
            num1.Text = temp[0].number.ToString();num1.BackColor = temp[0].color;
            num2.Text = temp[1].number.ToString(); num2.BackColor = temp[1].color;
            num3.Text = temp[2].number.ToString(); num3.BackColor = temp[2].color;
            num4.Text = temp[3].number.ToString(); num4.BackColor = temp[3].color;
            num5.Text = temp[4].number.ToString(); num5.BackColor = temp[4].color;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime += timer1.Interval;
            rotate();
            refreshImages();
            if (elapsedTime > timeRotate)
            {
                timer1.Stop();
                
                calcWin();
            }
            
            
        }
        private void reset()
        {
            betTip.Value = 0;
            foreach(RoulleteNumbers num in numbers)
            {
                num.bet = 0;
            }
            evenNUD.Value = 0;oddNUD.Value = 0;blackNUD.Value = 0;redNUD.Value = 0;lowNUD.Value = 0;highNUD.Value = 0;
            BROJ_BET_BROJKI = 0;
            beginBtn.Enabled = true;
            elapsedTime = 0;
        }
        private void calcWin()
        {
            RoulleteNumbers winNum = temp[3];
            int win = 0;
            if(BROJ_BET_BROJKI !=0)
            foreach(RoulleteNumbers num in numbers)
            {
                if (num == winNum)
                {
                    win = num.bet * 36/BROJ_BET_BROJKI;
                }
            }

            if (evenNUD.Value > 0 && winNum.number % 2 == 0)
            {
                win = win + (int)evenNUD.Value;
            }
            if (oddNUD.Value > 0 && winNum.number % 2 != 0)
            {
                win = win + (int)oddNUD.Value;
            }
            if (blackNUD.Value > 0 && winNum.color ==Color.Black)
            {
                win = win + (int)blackNUD.Value;
            }
            if (redNUD.Value > 0 && winNum.color == Color.Red)
            {
                win = win + (int)redNUD.Value;
            }
            if (lowNUD.Value > 0 && winNum.number < 19)
            {
                win = win + (int)lowNUD.Value;
            }
            if (highNUD.Value > 0 && winNum.number >=19)
            {
                win = win + (int)highNUD.Value;
            }

            pariInt += win;
            totalMoney.Text = pariInt.ToString();
            resetBtn.Enabled = true;
            reset();

        }
        public void rotate()
        {
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
            timer1.Interval += 10;
        RoulleteNumbers result = numbers.Find(x => x.number == 1);
        result.bet = 10;
        }
        public bool validate()
        {
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
        
        private void beginBtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                timer1.Start();
                beginBtn.Enabled = false;
                resetBtn.Enabled = false;

            }
            else
            {
                MessageBox.Show("Stavete oblog");
            }

        }

        private void singleCB_CheckedChanged(object sender, EventArgs e)
        {
            validate();
        }
        private bool getMoney()
        {
            if (pariInt - (int)betTip.Value >= 0)
            {
                pariInt -= (int)betTip.Value;
                totalMoney.Text = pariInt.ToString();
                BROJ_BET_BROJKI++;
                return true;
            }
            else
            {
                MessageBox.Show("Nemate dovolno pari");
                return false;
            }
        }
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 1);
            if (getMoney()) result.bet = (int)betTip.Value;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 1);
            if (getMoney()) if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 1);
            if (getMoney()) if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 2);
            if (getMoney()) if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 3);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 4);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 5);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 6);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label7_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 7);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label8_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 8);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 9);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label10_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 10);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label11_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 11);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 12);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label13_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 13);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label14_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 14);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label15_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 15);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label16_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 16);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label17_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 17);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label18_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 18);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label19_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 19);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label20_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 20);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label21_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 21);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label22_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 22);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label23_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 23);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label24_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 24);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label25_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 25);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label26_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 26);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label27_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 27);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label28_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 28);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label29_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 29);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label30_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 30);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label31_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 31);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label0_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 0);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label32_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 32);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label33_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 33);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label34_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 34);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label35_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 35);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void label36_DoubleClick(object sender, EventArgs e)
        {
            RoulleteNumbers result = numbers.Find(x => x.number == 36);
            if (getMoney()) result.bet = (int)betTip.Value;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
