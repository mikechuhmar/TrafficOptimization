using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дипломчик
{
    public partial class Form1 : Form
    {
        const int K= 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (K==0)
            {
                TB tb = new TB();
                tb.ShowDialog(this);
                tb.Dispose();
            }
            else
            {
                MP mp = new MP();
                mp.ShowDialog(this);
                mp.Dispose();
            }
        }
    }
}
