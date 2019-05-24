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
    public partial class Start_Form : Form
    {
        const int K= 2;
        public Start_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (K == 0)
            {
                TB tb = new TB();
                tb.ShowDialog(this);
                tb.Dispose();
            }
            if (K == 1)
            {
                MP mp = new MP();
                mp.ShowDialog(this);
                mp.Dispose();
            }
            if (K == 2)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog(this);
                f2.Dispose();
                Close();
            }
        }
    }
}
