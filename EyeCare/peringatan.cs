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
    public partial class peringatan : Form
    {
        Thread tab;
        int TotalSeconds;
        int menit;
        int detik;
        int waktu_game = 0;

        public peringatan()
        {
            InitializeComponent();
            btnClose1.Enabled = false;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        public void homeform(object ob)
        {
            Application.Run(new Form1());
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
            tab = new Thread(homeform);
            tab.SetApartmentState(ApartmentState.STA);
            tab.Start();
        }

        private void timer_peringatan_Tick(object sender, EventArgs e)
        {
            if (TotalSeconds > 0)
            {
                TotalSeconds--;
                menit = TotalSeconds / 60;
                detik = TotalSeconds - (menit * 60);
                lblTimer1.Text = menit.ToString().PadLeft(2, '0') + ":" + detik.ToString().PadLeft(2, '0');
            }
            else
            {
                this.timer_peringatan.Stop();
                DialogResult dialogResult = MessageBox.Show("Do you want to continue work?", "Dialog", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tab = new Thread(homeform);
                    tab.SetApartmentState(ApartmentState.STA);
                    tab.Start();
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            menit = waktu_game;
            detik = 60; //test
            TotalSeconds = (menit * 60) + detik;
            timer_peringatan.Enabled = true;
        }
        protected override void OnShown(EventArgs e)
        {
            this.ShowInTaskbar = false;
            base.OnShown(e);
            this.btnAction.PerformClick();
        }

    }
}
