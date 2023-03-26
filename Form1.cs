using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRNote_Plus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool sayac = false;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!sayac)
            {
                this.Opacity += 0.009;
            }
            if (this.Opacity == 1.0)
            {
                sayac = true;
            }
            if (sayac)
            {
                this.Opacity -= 0.009;
                if (this.Opacity == 0)
                {
                    timer1.Enabled = false;
                    this.Close();
                    HRNote yenigirisekrani = new HRNote();
                    yenigirisekrani.Show();

                }
            }
        }
    }
}
