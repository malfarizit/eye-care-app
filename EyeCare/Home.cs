using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EyeCare
{
    public partial class Form1 : Form
    {
        public Button btn;
        public static Form1 form1Instance;
        private int TotalSeconds;
        int menit;
        int detik;
        int waktu_game = 0;
        Thread tab;

        public Form1()
        {
            InitializeComponent();
            btn = btngame;
            btnreset.Enabled = false;
        }
        public void disablebtn()
        {
            btngame.Enabled = false;
            btnreset.Enabled = false;
        }

        public void enablebtn()
        {
            btngame.Enabled = true;
            btnreset.Enabled = true;
        }

        private void btngame_Click(object sender, EventArgs e)
        {
            btngame.Enabled = false;
            btnreset.Enabled = true;
            menit = waktu_game;
            detik = 60; //test
            TotalSeconds = (menit * 60) + detik;
            timer1.Enabled = true;

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            TotalSeconds = 0;
            btngame.Enabled = true;
            btnreset.Enabled = false;
            menit = TotalSeconds / 60;
            detik = TotalSeconds - (menit * 60);
            lbltimer.Text = detik.ToString().PadLeft(2, '0') + ":" + detik.ToString().PadLeft(2, '0');
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TotalSeconds > 0)
            {
                TotalSeconds--;
                menit = TotalSeconds / 60;
                detik = TotalSeconds - (menit * 60);
                lbltimer.Text = menit.ToString().PadLeft(2, '0') + ":" + detik.ToString().PadLeft(2, '0');
            }
            else
            {
                this.timer1.Stop();
                //MessageBox.Show("Time's up");
                //Console.Beep();
                enablebtn();
                this.Close();
                tab = new Thread(peringatanform);
                tab.SetApartmentState(ApartmentState.STA);
                tab.Start();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void peringatanform(object ob)
        {
            Application.Run(new peringatan());
        }
    }
}
