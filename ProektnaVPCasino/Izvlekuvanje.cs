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
    public partial class Izvlekuvanje : Form
    {
        public  List<int> IzvleceniBroevi { get; set; }
        public List<int> MozniBroevi { get; set; }
        public  KenoForm parent;
        Random r;
        public int BrIzvlekuvanje;
        int tmp;
        Timer timer;
        
        public Izvlekuvanje( KenoForm p)
        {
            InitializeComponent();
            parent = p;
            IzvleceniBroevi = new List<int>();
            MozniBroevi = new List<int>();
            for (int i = 0; i < 80; i++) {
                MozniBroevi.Add(i + 1);
            }
            r = new Random();
            BrIzvlekuvanje = 0;
          
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            
            tmp = 0;
        }

        private void Timer2_tick(object sender, EventArgs e)
        {
            

        }
        private void playAudio()
        {
            SoundPlayer audio = new SoundPlayer(ProektnaVPCasino.Properties.Resources.odbranaBrojka);
            
            audio.Play();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            int p = r.Next(0, MozniBroevi.Count);
            tmp++;
            MomBroj.Text = MozniBroevi[p].ToString();
            
            if (tmp % 10==0) {
                BrIzvlekuvanje++;
                if (BrIzvlekuvanje == 1)
                {
                    label3.Text = "ПРВ БРОЈ";
                    
                    I1.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I1.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                  
                    
                   
                }
                else if (BrIzvlekuvanje == 2)
                {
                    label3.Text = "ВТОР БРОЈ";
                   
                    I2.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I2.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                    

                }
                else if (BrIzvlekuvanje == 3)
                {
                    label3.Text = "ТРЕТ БРОЈ";
                    
                    I3.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I3.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                    
                }
                else if (BrIzvlekuvanje == 4)
                {
                    label3.Text = "ЧЕТБРТИ БРОЈ";
                    I4.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I4.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                }
                else if (BrIzvlekuvanje == 5)
                {
                    label3.Text = "ПЕТТИ БРОЈ";
                    I5.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I5.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                }
               
                else if (BrIzvlekuvanje == 6)
                {
                    label3.Text = "ШЕСТИ БРОЈ";
                    I6.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I6.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                }
                else if (BrIzvlekuvanje == 7)
                {
                    label3.Text = "СЕДМИ БРОЈ";
                    I7.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I7.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                }
                else if (BrIzvlekuvanje == 8)
                {
                    label3.Text = "ОСМИ БРОЈ";
                    I8.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I8.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                }
                else if (BrIzvlekuvanje == 9)
                {
                    label3.Text = "ДЕВЕТТИ БРОЈ";
                    I9.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I9.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                }
                else
                {
                    label3.Text = "ДЕСЕТИ БРОЈ";
                    I10.Text = MozniBroevi[p].ToString();
                    brojTB.Text = I10.Text;
                    IzvleceniBroevi.Add(MozniBroevi[p]);
                    ShowResult.Enabled = true;
                    timer.Stop();
                }
                playAudio();



                MozniBroevi.RemoveAt(p);



                
            }
        }

        private void ShowResult_Click(object sender, EventArgs e)
        {
            Statistika sForm = new Statistika(this);
            
            sForm.Show();
            this.Visible = false;
            

        }

        private void Izvlekuvanje_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            parent.Visible = true;
        }

        private void Izvlekuvanje_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
    }
}
