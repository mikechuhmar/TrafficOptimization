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
    public partial class MP : Form
    {
        MplexMath MXP;
        Buff BUF;
        public MP()
        {
            InitializeComponent();            
        }

        private void MP_Load(object sender, EventArgs e)
        {            
            MXP = new MplexMath(ref textBox1,ref richTextBox1, ref textBox2, ref progressBar1);
            BUF = new Buff();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MXP.MX();
            /*
            BUF._items.Clear();
            int i = 0;
            while (i < 100)
            {
                BUF.Enqueue(i);
                i++;
            }
            i = 0;
            double sum = BUF.summ();
            richTextBox1.Text += sum;
            richTextBox1.Text += '\n';
            while (i < 100)
            {
                richTextBox1.Text += Convert.ToString(BUF.Dequeue());
                richTextBox1.Text += '\n';
                i++;
            }
            */
        }
      
    }
}
