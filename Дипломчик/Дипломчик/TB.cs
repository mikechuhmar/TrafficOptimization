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
    public partial class TB : Form
    {
        TBMath tbn;

        public TB()
        {
            InitializeComponent();
        }

        private void TB_Load(object sender, EventArgs e)
        {
            tbn = new TBMath(ref textBox8, ref richTextBox1, ref progressBar1);
        }
            

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {           

            double T = Convert.ToDouble(textBox7.Text);
            double CIR = Convert.ToDouble(textBox1.Text);
            double Tk = Convert.ToDouble(textBox2.Text);
            double Nt = Convert.ToDouble(textBox8.Text);
            
            tbn.M(CIR, Tk, T, Nt);

        }

    }
}
