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
    public partial class KenoForm : Form
    {
        private GlavnaForma parent;
        public  int BrojUplateniBroevi { get; set; }
        public   List<int> OdigraniBroevi { get; set; }
        public  int Bet { get; set; }
        public  int TotalMoney { get; set; }
        List<Label> labels;

        public  KenoForm(GlavnaForma parent, int total=100)
        {
            InitializeComponent();
            this.parent = parent;
            OdigraniBroevi = new List<int>();
            labels = new List<Label>();
            BrojUplateniBroevi = 0;
            Bet = 0;
            TotalMoney = total;
            MoneyTb.Text = TotalMoney.ToString();
            
           
        }

        public  void NewGame(int Dobivka) {
            OdigraniBroevi = new List<int>();
            
            BrojUplateniBroevi = 0;
            Bet = 0;
            TotalMoney += Dobivka;
            MoneyTb.Text = TotalMoney.ToString();

        }

        void addLabel(Label l) {
            labels.Add(l);
        }
        void RemoveLabel(Label l) {
            labels.Remove(l);
        }
     

       

        void Remove(String s,Label l) {
            uplateniBroeviTB.Text = "";
            int tmp;
            int.TryParse(s, out tmp);
            OdigraniBroevi.Remove(tmp);
            l.BackColor = Control.DefaultBackColor;
            BrojUplateniBroevi--;
            RemoveLabel(l);
            if (OdigraniBroevi.Count > 0)
            {
                for (int i = 0; i < OdigraniBroevi.Count; i++)
                {
                    uplateniBroeviTB.Text += OdigraniBroevi[i].ToString() + " ";
                }
            }
            else {
                uplateniBroeviTB.Text = "";
            }

        }

        void Oznaci(String s,Label l) {
            uplateniBroeviTB.Text = "";
            int tmp;
            int.TryParse(s, out tmp);
            l.BackColor = Color.Green;
            BrojUplateniBroevi++;
            OdigraniBroevi.Add(tmp);
            addLabel(l);
            
            if (OdigraniBroevi.Count > 0) {
                for (int i = 0; i < OdigraniBroevi.Count; i++) {
                    uplateniBroeviTB.Text += OdigraniBroevi[i].ToString() + " ";
                }
            }

        }
                    



        private void Num1_Click(object sender, EventArgs e)
        {
            if (Num1.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                {
                    
                    Remove(Num1.Text,Num1);
                    
                   
                }

            }
            else
            {
                if (BrojUplateniBroevi < 10)
                {
                    
                    Oznaci(Num1.Text,Num1);
                    
                }

            }


        }

        private void Num2_Click(object sender, EventArgs e)
        {
            if (Num2.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                {
                    
                    Remove(Num2.Text,Num2);
                    
                }

            }
            else
            {
                if (BrojUplateniBroevi < 10)
                {
                    
                    Oznaci(Num2.Text,Num2);
                    
                }

            }
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            if (Num3.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                {
                   
                    Remove(Num3.Text,Num3);
                    
                }

            }
            else
            {
                if (BrojUplateniBroevi < 10)
                {
                    
                    Oznaci(Num3.Text,Num3);
                   
                }

            }
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            if (Num4.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                {
                    
                    Remove(Num4.Text,Num4);
                   

                }

            }
            else
            {
                if (BrojUplateniBroevi < 10)
                {
                    
                    Oznaci(Num4.Text,Num4);
                  
                }

            }
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            if (Num5.BackColor == Color.Green)
            {
                if(BrojUplateniBroevi>0)
                Remove(Num5.Text, Num5);
                
              
            }
            else {
                if(BrojUplateniBroevi<10)
                Oznaci(Num5.Text, Num5);
                
            }
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            if (Num6.BackColor == Color.Green)
            {
                if(BrojUplateniBroevi>0)
                Remove(Num6.Text, Num6);
            }
            else {
                if(BrojUplateniBroevi<10)
                Oznaci(Num6.Text, Num6);
            }
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            if (Num7.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num7.Text, Num7);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num7.Text, Num7);
            }
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            if (Num8.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num8.Text, Num8);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num8.Text, Num8);
            }
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            if (Num9.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num9.Text, Num9);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num9.Text, Num9);
            }
        }

        private void Num10_Click(object sender, EventArgs e)
        {
            if (Num10.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num10.Text, Num10);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num10.Text, Num10);
            }
        }

        private void Num11_Click(object sender, EventArgs e)
        {
            if (Num11.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num11.Text, Num11);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num11.Text, Num11);
            }
        }

        public  int Uplata() {
            
            int tmp;
            int.TryParse(uplataTB.Text, out tmp);
            return tmp;

                
            
        }

        private void uplataTB_Validating(object sender, CancelEventArgs e)
        {
            if (uplataTB.Text.Length <= 0)
            {
                errorProvider1.SetError(uplataTB, "Внесете ја вашата уплата!!!");
               // e.Cancel = true;

            }
            else if (uplataTB.Text.Length > 0)
            {
                foreach (char c in uplataTB.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        errorProvider1.SetError(uplataTB, "Уплатата се внесува само со цифри!!!");
                        e.Cancel = true;
                        return;
                    }
                }
            
            
            
                errorProvider1.SetError(uplataTB, null);
                e.Cancel = false;

            
            }
            
        }

        void NamaliPari() {
            int uplata;
            int pari;
            int.TryParse(uplataTB.Text, out uplata);
            int.TryParse(MoneyTb.Text, out pari);
            pari = pari - uplata;
            MoneyTb.Text=pari.ToString();
            TotalMoney = pari;
        }

      
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            int uplata;
            int Money;
            int.TryParse(uplataTB.Text, out uplata);
            int.TryParse(MoneyTb.Text, out Money);
            if (uplata > 0 && uplata <= Money && OdigraniBroevi.Count>=5) {
                Izvlekuvanje form = new Izvlekuvanje(this);
                Bet = Uplata();
                
                NamaliPari();
                uplataTB.Text = "";
                this.Visible = false;
               
                uplateniBroeviTB.Text = "";

                for (int i = labels.Count - 1; i >= 0; i--) {
                    labels[i].BackColor = DefaultBackColor;
                    labels.RemoveAt(i);
                }

                
                
                form.ShowDialog();
                
               
                
               
            }
        }

        private void Num12_Click(object sender, EventArgs e)
        {
            if (Num12.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num12.Text, Num12);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num12.Text, Num12);
            }
        }

        private void Num13_Click(object sender, EventArgs e)
        {
            if (Num13.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num13.Text, Num13);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num13.Text, Num13);
            }
        }

        private void Num14_Click(object sender, EventArgs e)
        {
            if (Num14.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num14.Text, Num14);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num14.Text, Num14);
            }
        }

        private void Num15_Click(object sender, EventArgs e)
        {
            if (Num15.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num15.Text, Num15);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num15.Text, Num15);
            }
        }

        private void Num16_Click(object sender, EventArgs e)
        {
            if (Num16.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num16.Text, Num16);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num16.Text, Num16);
            }
        }

        private void Num17_Click(object sender, EventArgs e)
        {
            if (Num17.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num17.Text, Num17);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num17.Text, Num17);
            }
        }

        private void Num18_Click(object sender, EventArgs e)
        {
            if (Num18.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num18.Text, Num18);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num18.Text, Num18);
            }
        }

        private void Num19_Click(object sender, EventArgs e)
        {
            if (Num19.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num19.Text, Num19);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num19.Text, Num19);
            }
        }

        private void Num20_Click(object sender, EventArgs e)
        {
            if (Num18.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num20.Text, Num20);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num20.Text, Num20);
            }
        }

        private void Num21_Click(object sender, EventArgs e)
        {
            if (Num21.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num21.Text, Num21);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num21.Text, Num21);
            }
        }

        private void Num22_Click(object sender, EventArgs e)
        {
            if (Num22.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num22.Text, Num22);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num22.Text, Num22);
            }
        }

        private void Num23_Click(object sender, EventArgs e)
        {
            if (Num23.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num23.Text, Num23);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num23.Text, Num23);
            }
        }

        private void Num24_Click(object sender, EventArgs e)
        {
            if (Num24.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num24.Text, Num24);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num24.Text, Num24);
            }
        }

        private void Num25_Click(object sender, EventArgs e)
        {
            if (Num25.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num25.Text, Num25);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num25.Text, Num25);
            }
        }

        private void Num26_Click(object sender, EventArgs e)
        {
            if (Num26.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num26.Text, Num26);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num26.Text, Num26);
            }
        }

        private void Num27_Click(object sender, EventArgs e)
        {
            if (Num27.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num27.Text, Num27);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num27.Text, Num27);
            }
        }

        private void Num28_Click(object sender, EventArgs e)
        {
            if (Num28.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num28.Text, Num28);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num28.Text, Num28);
            }
        }

        private void Num29_Click(object sender, EventArgs e)
        {
            if (Num29.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num29.Text, Num29);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num29.Text, Num29);
            }
        }

        private void Num30_Click(object sender, EventArgs e)
        {
            if (Num30.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num30.Text, Num30);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num30.Text, Num30);
            }
        }

        private void Num31_Click(object sender, EventArgs e)
        {
            if (Num31.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num31.Text, Num31);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num31.Text, Num31);
            }
        }

        private void Num32_Click(object sender, EventArgs e)
        {
            if (Num32.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num32.Text, Num32);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num32.Text, Num32);
            }
        }

        private void Num33_Click(object sender, EventArgs e)
        {
            if (Num33.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num33.Text, Num33);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num33.Text, Num33);
            }
        }

        private void Num34_Click(object sender, EventArgs e)
        {
            if (Num34.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num34.Text, Num34);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num34.Text, Num34);
            }
        }

        private void Num35_Click(object sender, EventArgs e)
        {
            if (Num35.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num35.Text, Num35);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num35.Text, Num35);
            }
        }

        private void Num36_Click(object sender, EventArgs e)
        {
            if (Num36.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num36.Text, Num36);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num36.Text, Num36);
            }
        }

        private void Num37_Click(object sender, EventArgs e)
        {
            if (Num37.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num37.Text, Num37);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num37.Text, Num37);
            }
        }

        

        private void Num38_Click(object sender, EventArgs e)
        {
            if (Num38.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num38.Text, Num38);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num38.Text, Num38);
            }
        }

        private void Num39_Click(object sender, EventArgs e)
        {
            if (Num39.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num39.Text, Num39);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num39.Text, Num39);
            }
        }

        private void Num40_Click(object sender, EventArgs e)
        {
            if (Num40.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num40.Text, Num40);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num40.Text, Num40);
            }
        }

        private void Num41_Click(object sender, EventArgs e)
        {
            if (Num41.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num41.Text, Num41);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num41.Text, Num41);
            }
        }

        private void Num42_Click(object sender, EventArgs e)
        {
            if (Num42.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num42.Text, Num42);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num42.Text, Num42);
            }
        }

        private void Num43_Click(object sender, EventArgs e)
        {
            if (Num43.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num43.Text, Num43);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num43.Text, Num43);
            }
        }

        private void Num44_Click(object sender, EventArgs e)
        {
            if (Num44.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num44.Text, Num44);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num44.Text, Num44);
            }
        }

        private void Num45_Click(object sender, EventArgs e)
        {
            if (Num45.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num45.Text, Num45);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num45.Text, Num45);
            }
        }

        private void Num46_Click(object sender, EventArgs e)
        {
            if (Num46.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num46.Text, Num46);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num46.Text, Num46);
            }
        }

        private void Num47_Click(object sender, EventArgs e)
        {
            if (Num47.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num47.Text, Num47);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num47.Text, Num47);
            }
        }

        private void Num48_Click(object sender, EventArgs e)
        {
            if (Num48.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num48.Text, Num48);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num48.Text, Num48);
            }
        }

        private void Num49_Click(object sender, EventArgs e)
        {
            if (Num49.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num49.Text, Num49);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num49.Text, Num49);
            }
        }

        private void Num50_Click(object sender, EventArgs e)
        {
            if (Num50.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num50.Text, Num50);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num50.Text, Num50);
            }
        }

        private void Num51_Click(object sender, EventArgs e)
        {
            if (Num51.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num51.Text, Num51);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num51.Text, Num51);
            }
        }

        private void Num52_Click(object sender, EventArgs e)
        {
            if (Num52.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num52.Text, Num52);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num52.Text, Num52);
            }
        }

        private void Num53_Click(object sender, EventArgs e)
        {
            if (Num53.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num53.Text, Num53);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num53.Text, Num53);
            }
        }

        private void Num54_Click(object sender, EventArgs e)
        {
            if (Num54.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num54.Text, Num54);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num54.Text, Num54);
            }
        }

        private void Num55_Click(object sender, EventArgs e)
        {
            if (Num55.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num55.Text, Num55);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num55.Text, Num55);
            }
        }

        private void Num56_Click(object sender, EventArgs e)
        {
            if (Num56.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num56.Text, Num56);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num56.Text, Num56);
            }
        }

        private void Num57_Click(object sender, EventArgs e)
        {
            if (Num57.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num57.Text, Num57);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num57.Text, Num57);
            }
        }

        private void Num58_Click(object sender, EventArgs e)
        {
            if (Num58.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num58.Text, Num58);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num58.Text, Num58);
            }
        }

        private void Num59_Click(object sender, EventArgs e)
        {
            if (Num59.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num59.Text, Num59);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num59.Text, Num59);
            }
        }

        private void Num60_Click(object sender, EventArgs e)
        {
            if (Num60.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num60.Text, Num60);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num60.Text, Num60);
            }
        }

        private void Num61_Click(object sender, EventArgs e)
        {
            if (Num61.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num61.Text, Num61);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num61.Text, Num61);
            }
        }

        private void Num62_Click(object sender, EventArgs e)
        {
            if (Num62.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num62.Text, Num62);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num62.Text, Num62);
            }
        }

        private void Num63_Click(object sender, EventArgs e)
        {
            if (Num63.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num63.Text, Num63);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num63.Text, Num63);
            }
        }

        private void Num64_Click(object sender, EventArgs e)
        {
            if (Num64.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num64.Text, Num64);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num64.Text, Num64);
            }
        }

        private void Num65_Click(object sender, EventArgs e)
        {
            if (Num65.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num65.Text, Num65);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num65.Text, Num65);
            }
        }

        private void Num66_Click(object sender, EventArgs e)
        {
            if (Num66.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num66.Text, Num66);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num66.Text, Num66);
            }
        }

        private void Num67_Click(object sender, EventArgs e)
        {
            if (Num67.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num67.Text, Num67);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num67.Text, Num67);
            }
        }

        private void Num68_Click(object sender, EventArgs e)
        {
            if (Num68.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num68.Text, Num68);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num68.Text, Num68);
            }
        }

        private void Num69_Click(object sender, EventArgs e)
        {
            if (Num69.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num69.Text, Num69);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num69.Text, Num69);
            }
        }

        private void Num70_Click(object sender, EventArgs e)
        {
            if (Num70.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num70.Text, Num70);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num70.Text, Num70);
            }
        }

        private void Num71_Click(object sender, EventArgs e)
        {
            if (Num71.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num71.Text, Num71);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num71.Text, Num71);
            }
        }

        private void Num72_Click(object sender, EventArgs e)
        {
            if (Num72.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num72.Text, Num72);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num72.Text, Num72);
            }
        }

        private void Num73_Click(object sender, EventArgs e)
        {
            if (Num73.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num73.Text, Num73);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num73.Text, Num73);
            }
        }

        private void Num74_Click(object sender, EventArgs e)
        {
            if (Num74.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num74.Text, Num74);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num74.Text, Num74);
            }
        }

        private void Num75_Click(object sender, EventArgs e)
        {
            if (Num75.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num75.Text, Num75);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num75.Text, Num75);
            }
        }

        private void Num76_Click(object sender, EventArgs e)
        {
            if (Num76.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num76.Text, Num76);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num76.Text, Num76);
            }
        }

        private void Num77_Click(object sender, EventArgs e)
        {
            if (Num77.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num77.Text, Num77);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num77.Text, Num77);
            }
        }

        private void Num78_Click(object sender, EventArgs e)
        {
            if (Num78.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num78.Text, Num78);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num78.Text, Num78);
            }
        }

        private void Num79_Click(object sender, EventArgs e)
        {
            if (Num79.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num79.Text, Num79);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num79.Text, Num79);
            }
        }

        private void Num80_Click(object sender, EventArgs e)
        {
            if (Num80.BackColor == Color.Green)
            {
                if (BrojUplateniBroevi > 0)
                    Remove(Num80.Text, Num80);
            }
            else
            {
                if (BrojUplateniBroevi < 10)
                    Oznaci(Num80.Text, Num80);
            }
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
            if(parent.mform == null)
            {
                parent.mform = new MusicForm();
            }
            parent.mform.Show();
        }
    }
}
