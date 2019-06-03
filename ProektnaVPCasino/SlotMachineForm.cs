using ProektnaVPCasino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProektnaVPCasino
{
    public partial class SlotMachineForm : Form
    {
        private GlavnaForma parent;
        Random r;
        int[] SlotsValues;
        Timer timer1,timer2,timer3,timer4,timer5;
        int firstRow { get; set; }
        int secondRow { get; set; }
        int thirdRow { get; set; }
        int fourthRow { get; set; }
        int fifthRow { get; set; }
        List<Image> Sliki { get; set; }
        public int pariInt { get; set; }




        public SlotMachineForm(GlavnaForma parent, int startCash)
        {
            InitializeComponent();
            this.parent = parent;
            DoubleBuffered = true;
            SlotsValues = new int[15];
            firstRow = 0;
            secondRow = 0;
            thirdRow = 0;
            fourthRow = 0;
            fifthRow = 0;
            r = new Random();
            timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2 = new Timer();
            timer2.Interval = 50;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer3 = new Timer();
            timer3.Interval = 50;
            timer3.Tick += new EventHandler(timer3_Tick);
            timer4 = new Timer();
            timer4.Interval = 50;
            timer4.Tick += new EventHandler(timer4_Tick);
            timer5 = new Timer();
            timer5.Interval = 50;
            timer5.Tick += new EventHandler(timer5_Tick);
            for (int i = 0; i < 15; i++) {
                SlotsValues[i] = r.Next(1, 8);
            }
            Sliki = new List<Image>();
            Sliki.Add(Resources._1);
            Sliki.Add(Resources._2);
            Sliki.Add(Resources._3);
            Sliki.Add(Resources._4);
            Sliki.Add(Resources._5);
            Sliki.Add(Resources._6);
            Sliki.Add(Resources._7);

            Slot1.Image = Sliki[SlotsValues[0] - 1];
            Slot2.Image = Sliki[SlotsValues[1] - 1];
            Slot3.Image = Sliki[SlotsValues[2] - 1];
            Slot4.Image = Sliki[SlotsValues[3] - 1];
            Slot5.Image = Sliki[SlotsValues[4] - 1];
            Slot6.Image = Sliki[SlotsValues[5] - 1];
            Slot7.Image = Sliki[SlotsValues[6] - 1];
            Slot8.Image = Sliki[SlotsValues[7] - 1];
            Slot9.Image = Sliki[SlotsValues[8] - 1];
            Slot10.Image = Sliki[SlotsValues[9] - 1];
            Slot11.Image = Sliki[SlotsValues[10] - 1];
            Slot12.Image = Sliki[SlotsValues[11] - 1];
            Slot13.Image = Sliki[SlotsValues[12] - 1];
            Slot14.Image = Sliki[SlotsValues[13] - 1];
            Slot15.Image = Sliki[SlotsValues[14] - 1];
            this.pariInt = startCash;
            totalMoney.Text = pariInt.ToString();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            SlotsValues[3] = r.Next(1, 8);
            SlotsValues[8] = r.Next(1, 8);
            SlotsValues[13] = r.Next(1, 8);
           // SlotsValues[18] = r.Next(1, 8);
            Slot4.Image = Sliki[SlotsValues[3] - 1];
            Slot9.Image = Sliki[SlotsValues[8] - 1];
            Slot14.Image = Sliki[SlotsValues[13] - 1];
            //Slot19.Image = Image.FromFile(SlotsValues[18].ToString() + ".jpg");
            fourthRow++;
            if (fourthRow == 20)
            {

                timer4.Stop();
                fourthRow = 0;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            SlotsValues[4] = r.Next(1, 8);
            SlotsValues[9] = r.Next(1, 8);
            SlotsValues[14] = r.Next(1, 8);
           
            Slot5.Image = Sliki[SlotsValues[4] - 1];
            Slot10.Image = Sliki[SlotsValues[9] - 1];
            Slot15.Image = Sliki[SlotsValues[14] - 1];

            fifthRow++;
            if (fifthRow == 24)
            {

                timer5.Stop();
                fifthRow = 0;
                int Win = CalculateWin();
                WinTB.Text = Win.ToString();
                int tmp;
                int.TryParse(totalMoney.Text, out tmp);

                totalMoney.Text = (tmp + Win).ToString();
                pariInt = tmp + Win;
                SpinBtn.Enabled = true;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SlotsValues[2] = r.Next(1, 8);
            SlotsValues[7] = r.Next(1, 8);
            SlotsValues[12] = r.Next(1, 8);

            Slot3.Image = Sliki[SlotsValues[2] - 1];
            Slot8.Image = Sliki[SlotsValues[7] - 1];
            Slot13.Image = Sliki[SlotsValues[12] - 1];
            thirdRow++;
            if (thirdRow == 16)
            {

                timer3.Stop();
                thirdRow = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void SpinBtn_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
            if (parent.mform == null)
            {
                parent.mform = new MusicForm();
            }
            parent.mform.Show();
        }

        private void CashOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SlotsValues[1] = r.Next(1, 8);
            SlotsValues[6] = r.Next(1, 8);
            SlotsValues[11] = r.Next(1, 8);
           
            Slot2.Image = Sliki[SlotsValues[1] - 1];
            Slot7.Image = Sliki[SlotsValues[6] - 1];
            Slot12.Image = Sliki[SlotsValues[11] - 1];

            secondRow++;
            if (secondRow == 12)
            {

                timer2.Stop();
                secondRow = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            SlotsValues[0] = r.Next(1, 8);
            SlotsValues[5] = r.Next(1, 8);
            SlotsValues[10] = r.Next(1, 8);
           
            Slot1.Image = Sliki[SlotsValues[0] - 1];
            Slot6.Image = Sliki[SlotsValues[5] - 1];
            Slot11.Image = Sliki[SlotsValues[10] - 1];

            firstRow++;
            if(firstRow==8)
            {

                timer1.Stop();
                firstRow = 0; 
            }
        }

        private void SpinBtn_Click(object sender, EventArgs e)
        {
            WinTB.Text = "0";
            int flag;

            int.TryParse(totalMoney.Text, out flag);
            if ((int)Bet.Value <= flag && (int)Bet.Value>0)
            {
                pariInt = flag - (int)Bet.Value;
                totalMoney.Text = (flag - (int)Bet.Value).ToString();

                SpinBtn.Enabled = false;
               
                

                timer1.Start();
                timer2.Start();
                timer3.Start();
                timer4.Start();
                timer5.Start();
            }
          
        }
        private int CalculateWin() {
            int totalWin = 0;
            if (SlotsValues[0] == SlotsValues[1] && SlotsValues[0] == SlotsValues[2] && SlotsValues[0] == SlotsValues[3] && SlotsValues[0] == SlotsValues[4])
            {
                if (SlotsValues[0] == 1 || SlotsValues[0] == 2 || SlotsValues[0] == 3 || SlotsValues[0] == 4)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[0] == 5 || SlotsValues[0] == 6)
                {
                    totalWin += (int)Bet.Value * 100;
                }
                else if (SlotsValues[0] == 7)
                {
                    totalWin += (int)Bet.Value * 1000;
                }
                else {
                    totalWin += 0;
                }

            }
            else if (SlotsValues[0] == SlotsValues[1] && SlotsValues[0] == SlotsValues[2] && SlotsValues[0] == SlotsValues[3])
            {
                if (SlotsValues[0] == 1 || SlotsValues[0] == 2 || SlotsValues[0] == 3 || SlotsValues[0] == 4)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[0] == 5 || SlotsValues[0] == 6)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[0] == 7)
                {
                    totalWin += (int)Bet.Value * 200;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[0] == SlotsValues[1] && SlotsValues[0] == SlotsValues[2])
            {
                if (SlotsValues[0] == 1 || SlotsValues[0] == 2 || SlotsValues[0] == 3 || SlotsValues[0] == 4)
                {
                    totalWin += (int)Bet.Value * 4;
                }
                else if (SlotsValues[0] == 5 || SlotsValues[0] == 6)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[0] == 7)
                {
                    totalWin += (int)Bet.Value * 20;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else {
                totalWin += 0;
            }

            //Za VtorRED
            if (SlotsValues[5] == SlotsValues[6] && SlotsValues[5] == SlotsValues[7] && SlotsValues[5] == SlotsValues[8] && SlotsValues[5] == SlotsValues[9])
            {
                if (SlotsValues[5] == 1 || SlotsValues[5] == 2 || SlotsValues[5] == 3 || SlotsValues[5] == 4)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[5] == 5 || SlotsValues[5] == 6)
                {
                    totalWin += (int)Bet.Value * 100;
                }
                else if (SlotsValues[5] == 7)
                {
                    totalWin += (int)Bet.Value * 1000;
                }
                else
                {
                    totalWin += 0;
                }

            }
            else if (SlotsValues[5] == SlotsValues[6] && SlotsValues[5] == SlotsValues[7] && SlotsValues[5] == SlotsValues[8])
            {
                if (SlotsValues[5] == 1 || SlotsValues[5] == 2 || SlotsValues[5] == 3 || SlotsValues[5] == 4)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[5] == 5 || SlotsValues[5] == 6)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[5] == 7)
                {
                    totalWin += (int)Bet.Value * 200;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[5] == SlotsValues[6] && SlotsValues[5] == SlotsValues[7])
            {
                if (SlotsValues[5] == 1 || SlotsValues[5] == 2 || SlotsValues[5] == 3 || SlotsValues[5] == 4)
                {
                    totalWin += (int)Bet.Value * 4;
                }
                else if (SlotsValues[5] == 5 || SlotsValues[5] == 6)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[5] == 7)
                {
                    totalWin += (int)Bet.Value * 20;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else
            {
                totalWin += 0;
            }


            //TRET RED 
            if (SlotsValues[10] == SlotsValues[11] && SlotsValues[10] == SlotsValues[12] && SlotsValues[10] == SlotsValues[13] && SlotsValues[10] == SlotsValues[14])
            {
                if (SlotsValues[10] == 1 || SlotsValues[10] == 2 || SlotsValues[10] == 3 || SlotsValues[10] == 4)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[10] == 5 || SlotsValues[10] == 6)
                {
                    totalWin += (int)Bet.Value * 100;
                }
                else if (SlotsValues[10] == 7)
                {
                    totalWin += (int)Bet.Value * 1000;
                }
                else
                {
                    totalWin += 0;
                }

            }
            else if (SlotsValues[10] == SlotsValues[11] && SlotsValues[10] == SlotsValues[12] && SlotsValues[10] == SlotsValues[13])
            {
                if (SlotsValues[10] == 1 || SlotsValues[10] == 2 || SlotsValues[10] == 3 || SlotsValues[10] == 4)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[10] == 5 || SlotsValues[10] == 6)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[10] == 7)
                {
                    totalWin += (int)Bet.Value * 200;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[10] == SlotsValues[11] && SlotsValues[10] == SlotsValues[12])
            {
                if (SlotsValues[10] == 1 || SlotsValues[10] == 2 || SlotsValues[10] == 3 || SlotsValues[10] == 4)
                {
                    totalWin += (int)Bet.Value * 4;
                }
                else if (SlotsValues[10] == 5 || SlotsValues[10] == 6)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[10] == 7)
                {
                    totalWin += (int)Bet.Value * 20;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else
            {
                totalWin += 0;
            }

            //DIJAGONALNO
            if (SlotsValues[0] == SlotsValues[6] && SlotsValues[0] == SlotsValues[12] && SlotsValues[0] == SlotsValues[8] && SlotsValues[0] == SlotsValues[4])
            {
                if (SlotsValues[0] == 1 || SlotsValues[0] == 2 || SlotsValues[0] == 3 || SlotsValues[0] == 4)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[0] == 5 || SlotsValues[0] == 6)
                {
                    totalWin += (int)Bet.Value * 100;
                }
                else if (SlotsValues[0] == 7)
                {
                    totalWin += (int)Bet.Value * 1000;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[0] == SlotsValues[6] && SlotsValues[0] == SlotsValues[12] && SlotsValues[0] == SlotsValues[8])
            {
                if (SlotsValues[0] == 1 || SlotsValues[0] == 2 || SlotsValues[0] == 3 || SlotsValues[0] == 4)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[0] == 5 || SlotsValues[0] == 6)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[0] == 7)
                {
                    totalWin += (int)Bet.Value * 200;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[0] == SlotsValues[6] && SlotsValues[0] == SlotsValues[12])
            {
                if (SlotsValues[0] == 1 || SlotsValues[0] == 2 || SlotsValues[0] == 3 || SlotsValues[0] == 4)
                {
                    totalWin += (int)Bet.Value * 4;
                }
                else if (SlotsValues[0] == 5 || SlotsValues[0] == 6)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[0] == 7)
                {
                    totalWin += (int)Bet.Value * 20;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else { totalWin += 0;

            }

            //DRUGA DIJAGONALA
            if (SlotsValues[10] == SlotsValues[6] && SlotsValues[10] == SlotsValues[2] && SlotsValues[10] == SlotsValues[8] && SlotsValues[10] == SlotsValues[14])
            {
                if (SlotsValues[10] == 1 || SlotsValues[10] == 2 || SlotsValues[10] == 3 || SlotsValues[10] == 4)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[10] == 5 || SlotsValues[10] == 6)
                {
                    totalWin += (int)Bet.Value * 100;
                }
                else if (SlotsValues[10] == 7)
                {
                    totalWin += (int)Bet.Value * 1000;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[10] == SlotsValues[6] && SlotsValues[10] == SlotsValues[2] && SlotsValues[10] == SlotsValues[8])
            {
                if (SlotsValues[10] == 1 || SlotsValues[10] == 2 || SlotsValues[10] == 3 || SlotsValues[10] == 4)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[10] == 5 || SlotsValues[10] == 6)
                {
                    totalWin += (int)Bet.Value * 40;
                }
                else if (SlotsValues[10] == 7)
                {
                    totalWin += (int)Bet.Value * 200;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else if (SlotsValues[10] == SlotsValues[6] && SlotsValues[10] == SlotsValues[2])
            {
                if (SlotsValues[10] == 1 || SlotsValues[10] == 2 || SlotsValues[10] == 3 || SlotsValues[10] == 4)
                {
                    totalWin += (int)Bet.Value * 4;
                }
                else if (SlotsValues[10] == 5 || SlotsValues[10] == 6)
                {
                    totalWin += (int)Bet.Value * 10;
                }
                else if (SlotsValues[10] == 7)
                {
                    totalWin += (int)Bet.Value * 20;
                }
                else
                {
                    totalWin += 0;
                }
            }
            else {
                totalWin += 0;
            }
                

           


            return totalWin;


        }
    }
}
