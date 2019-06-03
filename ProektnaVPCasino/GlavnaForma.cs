using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ProektnaVPCasino
{ 
    public partial class GlavnaForma : Form
    {
        public MusicForm mform;
        private int vkupnoPari { get; set; }
        public GlavnaForma()
        {
            InitializeComponent();
           
            vkupnoPari = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            povikajHiLow();
        }
        private void povikajHiLow()
        {
            if (proverkaPari())
            {
                vkupnoPari = vkupnoPari - int.Parse(pariZaSlednaIgra.Text);
                HiLowForm HiLowForm1 = new HiLowForm(this,int.Parse(pariZaSlednaIgra.Text));
                HiLowForm1.Width = this.Width;
                HiLowForm1.Height = this.Height;
                HiLowForm1.StartPosition = FormStartPosition.Manual;
                HiLowForm1.Location = new Point(this.Location.X, this.Location.Y);
                this.Visible = false;
                if(mform != null)
                    mform.Hide();
                
                HiLowForm1.ShowDialog();
                vkupnoPari = vkupnoPari + HiLowForm1.cashOutMoney;
                update();
                this.Location = HiLowForm1.Location;
                this.Location = HiLowForm1.Location;
                this.Width = HiLowForm1.Width;
                this.Height = HiLowForm1.Height;
                this.Visible = true;
            }
        }
        private bool proverkaPari()
        {
            //Pravi proverki dali ima dovolno pari i dali e korekten inputot za da nema exception
            if (pariZaSlednaIgra.Text == "" || int.Parse(pariZaSlednaIgra.Text) == 0)
            {
                MessageBox.Show("Vnesete validna suma za sledna igra");
                return false;
            }
            else if (int.Parse(pariZaSlednaIgra.Text) > vkupnoPari)
            {
                MessageBox.Show("Nemate tolku pari");
                return false;
            }
            else return true;
        }

        private void uplatiPari_Click(object sender, EventArgs e)
        {
            UplataPariForm form = new UplataPariForm();
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                vkupnoPari = form.suma;
                update();
            }
        }
        private void update()
        {
            vkPari.Text = vkupnoPari.ToString();
        }


        private void GlavnaForma_Load(object sender, EventArgs e)
        {

        }

        private void musicFormBtn_Click(object sender, EventArgs e)
        {
          
           if(mform == null)
            {
                mform = new MusicForm();
            }
            mform.Show();
            
        }

        private void slotMachineBtn_Click(object sender, EventArgs e)
        {
            if (proverkaPari())
            {
                vkupnoPari = vkupnoPari - int.Parse(pariZaSlednaIgra.Text);
                SlotMachineForm slotMachineForm= new SlotMachineForm(this, int.Parse(pariZaSlednaIgra.Text));
                slotMachineForm.StartPosition = FormStartPosition.Manual;
                slotMachineForm.Location = new Point(this.Location.X, this.Location.Y);
                this.Visible = false;
                if (mform != null)
                    mform.Hide();

                slotMachineForm.ShowDialog();
                vkupnoPari = vkupnoPari + slotMachineForm.pariInt;
                update();
                this.Location = slotMachineForm.Location;
                this.Visible = true;
            }
        }
    }
}
