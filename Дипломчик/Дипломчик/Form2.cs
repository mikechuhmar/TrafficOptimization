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

    public partial class Form2 : Form
    {

        public static int LB_COUNT = 0;
        public static int TB_COUNT = 0;
        TBMath_2 tbn;
        MplexMath_2 MXP;
        Buff_2 BUF;
        bool GA = false, SPA = false, SLA = false;
        bool start = true;
        public static LinkedList<TabPage> TPe = new LinkedList<TabPage>();
        //public List<TabPage> TPe = new List<TabPage>();
        public void Enqueue(TabPage value)//Добавляет элемент в очередь.
        {
            TPe.AddFirst(value);
        }
        public TabPage Dequeue()//Удаляет первый помещенный элемент из очереди и возвращает его. 
        {
            if (TPe.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            TabPage last = TPe.Last.Value;
            TPe.RemoveLast();
            return last;
        }
        public TabPage Pop()// первый помещенный элемент из очереди и возвращает его. 
        {
            if (TPe.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            TabPage last = TPe.Last.Value;
            return last;
        }
        public TabPage Dequeue_F()//Удаляет последний помещенный элемент из очереди и возвращает его. 
        {
            if (TPe.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            TabPage last = TPe.First.Value;
            TPe.RemoveFirst();
            return last;
        }
        public int Count
        {
            get
            {return TPe.Count;}
        }

        public Form2()
        {
            InitializeComponent();
        }
        
        TabPage GAPage;
        TabPage SPAPage;
        TabPage SLAPage;
        private void Form2_Load(object sender, EventArgs e)
        {

            
            BUF = new Buff_2();
            button2.Enabled = false;
            Start_modelling.Enabled = false;
            cbPrevData.Enabled = false;
            comboBoxMethod.SelectedIndex = 0;
            
            button1.Enabled = false;
            textBox5.Enabled = false;
            //MXP.Graph();
            Graph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GAPage.Parent = null;
            SPAPage.Parent = null;
            SLAPage.Parent = null;
            button2.Enabled = true;
            Start_modelling.Enabled = true;

            TabPage newTabPage = new TabPage();
            newTabPage.Text = "TB" + (Count_Of_Page("TB") + 1);

            TB_Interface TI = new TB_Interface();
           
            /*
            System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            //chart1.Anchor = (AnchorStyles.Right & AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Top);
            chart1.Location = new Point(10, 150);
            chart1.Name = "chart1";
            chart1.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            chart1.Margin = new Padding(5,5,5,5);
            chart1.Width = 170;
            chart1.Height = 550;
            //chart1.Size = new Size(150, 50);
            */
            
            TI.Graf_TB();

            
            //Новое

            newTabPage.Controls.Add(TI.Size_of_TB);            //0            
            newTabPage.Controls.Add(TI.U);                   //1
            newTabPage.Controls.Add(TI.Interval);              //2
            newTabPage.Controls.Add(TI.Size_of_TB_L);          //3
            newTabPage.Controls.Add(TI.U_L);                 //4
            newTabPage.Controls.Add(TI.Interval_L);            //5
            newTabPage.Controls.Add(TI.chart1);                //6
            newTabPage.Controls.Add(TI.Help_Ro);               //7
            newTabPage.Controls.Add(TI.RTB);                   //8
            newTabPage.Controls.Add(TI.Size_of_TB_ED);         //9
            newTabPage.Controls.Add(TI.CIR_ED);                //10
            newTabPage.Controls.Add(TI.Generated_S);           //11
            newTabPage.Controls.Add(TI.Generated_To);          //12
            newTabPage.Controls.Add(TI.Generated_To_T);        //13
            newTabPage.Controls.Add(TI.Generated_S_T);         //14
            newTabPage.Controls.Add(TI.Generated_ED);          //15


            Enqueue(newTabPage);
            tabControl1.TabPages.Add(TPe.ElementAt(0));
            textBox1.Text = Convert.ToString(Count_Of_Page("TB"));
            if (GA)
                GAPage.Parent = tabControl1;
            if (SPA)
                SPAPage.Parent = tabControl1;
            if (SLA)
                SLAPage.Parent = tabControl1;
            //MessageBox.Show(Static.TB_Count.ToString());
            try
            {
                if (Static.prev_dataList != null)
                {
                    if (int.Parse(textBox3.Text) != Static.prev_dataList.Count - 1 || Static.TB_Count != Static.prev_dataList.Last().tBs.Count || Static.LB_Count != Static.prev_dataList.Last().lBs.Count)
                    {
                        cbPrevData.Checked = false;
                        cbPrevData.Enabled = false;
                    }
                    else
                    {
                        cbPrevData.Enabled = true;
                    }
                }
            }
            catch
            {
                cbPrevData.Checked = false;
                cbPrevData.Enabled = false;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Static.alpha = int.Parse(tBalpha.Text);
            Static.beta = int.Parse(tBbeta.Text);
            Static.gamma = int.Parse(tBgamma.Text);
            Static.delta = int.Parse(tBdelta.Text);
            Static.epsilon = int.Parse(tBepsilon.Text);
            richTextBox1.Clear();

            richTextBox2.Clear();

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();


            for (int z = 0; z <= TPe.Count - 1; z++)
            {


                if (TPe.ElementAt(z).Text.Contains("TB"))
                {
                    ((RichTextBox)TPe.ElementAt(z).Controls[8]).Clear();                   
                }
                if (TPe.ElementAt(z).Text.Contains("LB"))
                {
                    ((RichTextBox)TPe.ElementAt(z).Controls[10]).Clear();
                }


            }

            
            for (int z = 0; z <= TPe.Count - 1; z++)
            {
                int k=0;
                if (TPe.ElementAt(z).Text.Contains("TB"))
                {
                    k = 6;
                }
                if (TPe.ElementAt(z).Text.Contains("LB"))
                {
                    k = 8;
                }

                ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[k]).Series[0].Points.Clear();
                ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[k]).Series[1].Points.Clear();
                ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[k]).Series[2].Points.Clear();
                ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[k]).Series[3].Points.Clear();
            }
                //chart1.Series[0].Points.Clear();


            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            swatch.Start();
            System.Diagnostics.Stopwatch swatch1 = new System.Diagnostics.Stopwatch();
            Static.dataList = new List<Data>();
            MXP = new MplexMath_2(ref textBox2, ref richTextBox1, ref textBox4, ref chart1);
            Leaky_Bucket_Algoritm lbn = new Leaky_Bucket_Algoritm();
            //MXP.Graph();

            Static.dataList = new List<Data>();
            tbn = new TBMath_2();
            Random rand = new Random();
            
            double T = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[0]).Text);
            //double Nt = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[1]).Text);
            //double CIR = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[2]).Text);
            double U = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[1]).Text);
            //tbn = new TBMath_2(CIR, Nt, T);
            tbn = new TBMath_2(U, T);
            //double Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[3]).Text);
            double Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[2]).Text);
            double V;
            double RoTk_1=0;
            double[] ch = new double[5];
            double R;


            int Gen_Hight, Gen_Low;

            double[] OPT = new double[2];

            double[] Gi = new double[TPe.Count];
            LinkedList<double> Gi_f = new LinkedList<double>();

            progressBar1.Maximum = Convert.ToInt16(textBox3.Text)+1;
            progressBar1.Value = 0;
            
            int Time_To_Model = Convert.ToInt16(textBox3.Text);

            bool flag = true;
            double RoTk_LB = 0;

            LinkedList<double>[] masp = new LinkedList<double>[LB_COUNT];///////
            richTextBox2.Text += "LB - количество" +LB_COUNT;
            richTextBox2.Text += '\n';
            for (int ikj = 0; ikj < LB_COUNT; ikj++)
            {
                //LinkedList<double> k = new LinkedList<double>();
                masp[ikj] = new LinkedList<double>();
            }
            double V_SUMM = 0, Ro_SUMM = 0;
            Vector max = new Vector(Static.LB_Count + Static.TB_Count);
            for (int k = 0; k <= Time_To_Model; k++)
            {
                Data data = new Data();
                data.tBs = new List<TBStruct>(TPe.Count);
                Vector vector = new Vector();
                progressBar1.Value++;

                int lb_count = LB_COUNT;
                Gi_f.Clear();

                //Инициализация структур маркерных корзин, текущих вёдер и мультиплексора
                for (int z = 0, t = 0, l = 0; z <= TPe.Count - 1; z++)
                {
                    if (TPe.ElementAt(z).Text.Contains("TB"))
                    {
                        TBStruct tBStruct = new TBStruct();



                        T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                        if (k == 0) RoTk_1 = T / 2;
                        //else RoTk_1 = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[9]).Text);
                        else RoTk_1 = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[7]).Text);
                        tBStruct.addInit(T, RoTk_1);
                        //data.tBs[z] = tBStruct;
                        //Gen_Hight = Convert.ToInt32(((TextBox)TPe.ElementAt(z).Controls[16]).Text);
                        //Gen_Low = Convert.ToInt32(((TextBox)TPe.ElementAt(z).Controls[17]).Text);

                        Gen_Hight = Convert.ToInt32(((TextBox)TPe.ElementAt(z).Controls[13]).Text);
                        Gen_Low = Convert.ToInt32(((TextBox)TPe.ElementAt(z).Controls[14]).Text);

                        if (!cbPrevData.Checked)
                            V = rand.Next(Gen_Low, Gen_Hight);
                        else
                            V = Static.prev_dataList[k].tBs[t].V;
                        //Console.WriteLine(V);
                        tBStruct.addInput(V);

                        data.tBs.Add(tBStruct);
                        max[t] = T;
                        t++;
                        
                    }
                    if (TPe.ElementAt(z).Text.Contains("LB"))
                    {

                        LBStruct lBStruct = new LBStruct();
                        T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                        //Nt = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[1]).Text);
                        //double CIR = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[2]).Text);
                        Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[3]).Text);

                        lBStruct.addInit(T, masp[lb_count - 1], Gi_f);

                        Gen_Hight = Convert.ToInt32(((TextBox)TPe.ElementAt(z).Controls[16]).Text);
                        Gen_Low = Convert.ToInt32(((TextBox)TPe.ElementAt(z).Controls[17]).Text);

                        //((RichTextBox)TPe.ElementAt(z).Controls[10]).Text += "Шаг: " + k;
                        if (!cbPrevData.Checked)
                            V = rand.Next(Gen_Low, Gen_Hight);
                        else
                            V = Static.prev_dataList[k].lBs[l].V;

                        lBStruct.addInput(V);

                        data.lBs.Add(lBStruct);
                        max[t + l] = T;
                        l++;
                        
                    }
                    
                }
                data.mult = new MultStruct();
                data.mult.addInit(MXP.Q, MXP.C_T);
                Static.dataList.Add(data);
                Console.WriteLine("ooo");
                
                if (comboBoxMethod.SelectedIndex == 1)
                {
                    swatch1.Start();
                    GeneticAlgorithm algorithm = new GeneticAlgorithm(int.Parse(tbGA1.Text), Static.LB_Count + Static.TB_Count, int.Parse(tbGA2.Text), Functions.J, Functions.genVector, max);
                    vector = new Vector(algorithm.result());
                    swatch1.Stop();
                }
                if (comboBoxMethod.SelectedIndex == 2)
                {
                    swatch1.Start();
                    SwarmParticlesAlgorithm algorithm = new SwarmParticlesAlgorithm(int.Parse(tbSPA1.Text), Static.LB_Count + Static.TB_Count, int.Parse(tbSPA2.Text), double.Parse(tbSPA3.Text), double.Parse(tbSPA4.Text), Functions.J, Functions.genVector, max);
                    vector = new Vector(algorithm.result());
                    swatch1.Stop();
                }
                if (comboBoxMethod.SelectedIndex == 3)
                {
                    swatch1.Stop();
                    StochasticLiftAlgorithm algorithm = new StochasticLiftAlgorithm(Static.LB_Count + Static.TB_Count, int.Parse(tbSLA1.Text), int.Parse(tbSLA2.Text), Functions.J, Functions.genVector, max);
                    vector = new Vector(algorithm.result());
                    swatch1.Stop();
                }


                //Вычисление выходящего трафика и потерь

                for (int z = 0, t = 0, l = 0; z <= TPe.Count - 1; z++)
                {


                    if (TPe.ElementAt(z).Text.Contains("TB"))
                    {
                        TBStruct tBStruct = data.tBs[t];

                        T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                        Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[2]).Text);
                        V = tBStruct.V;

                        if (comboBoxMethod.SelectedIndex == 0)
                        {
                            U = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[1]).Text);

                        }
                        else
                        {
                            U = vector[t];
                        }
                        tBStruct.addOptimized(U);
                        data.tBs[t] = tBStruct;
                        ch = tbn.M(Tk, T, U, RoTk_1, V);
                        ((TextBox)TPe.ElementAt(z).Controls[7]).Text = Convert.ToString(ch[3]);
                        //RoTk_1 = ch[3];

                        R = ch[4];//потери на z токенбакете

                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["GTk"].Points.AddXY(k, ch[0]);
                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["VTk"].Points.AddXY(k, ch[1]);
                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["RoTk"].Points.AddXY(k, ch[2]);
                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["потери"].Points.AddXY(k, (ch[1]- ch[0]));

                        ((RichTextBox)TPe.ElementAt(z).Controls[8]).Text += "Шаг: " + k;
                        ((RichTextBox)TPe.ElementAt(z).Controls[8]).Text += "GTk: " + ch[0] + "; " + "VTk: " + ch[1] + "; " + "RoTk" + ch[2] + "; ";
                        ((RichTextBox)TPe.ElementAt(z).Controls[8]).Text += '\n';

                        Gi[z] = ch[0];

                        richTextBox2.Text += "Момент: " + k + "; TB№" + (TPe.Count - z) + " GTk = " + ch[0];
                        richTextBox2.Text += '\n';

                        tBStruct.addDecision(ch[0], ch[3], ch[4]);
                        //RoTk_1 = ch[3];
                        data.tBs[t] = tBStruct;
                        t++;
                        //Gi_f.AddLast(ch[0]);
                        V_SUMM += V;
                        Ro_SUMM += (V - ch[0]);
                    }
                    if (TPe.ElementAt(z).Text.Contains("LB"))
                    {

                        LBStruct lBStruct = data.lBs[l];

                        
                        T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                        Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[3]).Text);
                        V = lBStruct.V;
                        if (comboBoxMethod.SelectedIndex == 0)
                        {
                            U = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[2]).Text);

                        }
                        else
                        {
                            U = vector[l];
                        }

                        lBStruct.addOptimized(U);
                        data.lBs[l] = lBStruct;
                        
                        ch = lbn.LM(U, Tk, T, RoTk_LB, V, ref masp[lb_count - 1], ref Gi_f);

                        ((RichTextBox)TPe.ElementAt(z).Controls[10]).Text += "Шаг: " + k;

                        //richTextBox2.Text += "индекс передаваемого элемента "+(lb_count - 1);
                        //richTextBox2.Text += '\n';
                        lb_count--;////*****

                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["GTk"].Points.AddXY(k, ch[0]);
                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["VTk"].Points.AddXY(k, ch[1]);
                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["заполнение LB"].Points.AddXY(k, ch[2]);
                        ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["потери"].Points.AddXY(k, ch[3]);


                        ((RichTextBox)TPe.ElementAt(z).Controls[10]).Text += " GTk: " + ch[0] + "; " + " VTk: " + ch[1] + "; " + "заполнение LB: " + ch[2] + "; " + "Потери" + ch[3];
                        ((RichTextBox)TPe.ElementAt(z).Controls[10]).Text += '\n';


                        Gi[z] = ch[0];
                        lBStruct.addDecision(ch[0], ch[3], ch[2]);
                        //RoTk_1 = ch[3];
                        data.lBs[l] = lBStruct;
                        l++;
                        //Gi_f.AddLast(ch[0]);
                        richTextBox2.Text += /*"Шаг: " + k + */"LB" + (TPe.Count - z) + " GTk = " + ch[0];
                        richTextBox2.Text += '\n';
                        V_SUMM += V;
                        Ro_SUMM += (V - ch[0]);
                    }


                }

                data.mult.addInput(Gi);
                OPT = MXP.MX(Gi);
                
                double q_prev = 0;
                if (Static.dataList.Count > 1)
                    q_prev = Static.dataList[Static.dataList.Count - 2].mult.q;
                double outGi = MplexMath_2.res(Gi, MXP.Q, MXP.C_T, q_prev)[3];
                data.mult.addDecision(OPT[1], OPT[0], outGi);
                //Console.WriteLine(Static.dataList.IndexOf(data));
                Console.WriteLine(data.output());
                Console.WriteLine(data.J);
                cbPrevData.Show();
            }

            
            //foreach (Data data in Static.dataList)
            //{
            //    Console.WriteLine(Static.dataList.IndexOf(data));
            //    Console.WriteLine(data.output());
            //    Console.WriteLine(data.J);
            //}

            swatch.Stop();

            double inTB = Static.dataList.Sum(x => x.tBs.Sum(y => y.V));
            double inLB = Static.dataList.Sum(x => x.lBs.Sum(y => y.V));
            double outPackages = Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + Static.dataList.Sum(x => x.mult.L);

            double delay = Static.dataList.Sum(x => x.mult.q);
            double J = Static.alpha * Static.dataList.Sum(x => x.mult.L) + Static.beta * Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + Static.gamma * Static.dataList.Sum(x => x.lBs.Sum(y => y.R)) + Static.delta * Static.dataList.Sum(x => x.lBs.Sum(y => y.b)) + Static.epsilon * Static.dataList.Sum(x => x.mult.q);
            //MessageBox.Show("Моделирование закончено \nВремя моделирования: " + swatch.Elapsed.ToString() + "\nПоступило бит: " + inPackages + "\nОтброшено бит: " + outPackages + "\nЗадержки: " + delay + "\nL: " + L);
            string str = "Поступило бит на корзины: " + inTB + "\nОтброшено на корзинах: " + Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + "\nПоступило бит на вёдра: " + inLB + "\nОтброшено на вёдрах: " + Static.dataList.Sum(x => x.lBs.Sum(y => y.R)) + "\nЗадержки на вёдрах: " + Static.dataList.Sum(x => x.lBs.Sum(y => y.b)) + "\nОтброшено на мультиплексоре: " + Static.dataList.Sum(x => x.mult.L) + "\nЗадержки: " + delay + "\nJ: " + J + "\nВышло" + Static.dataList.Sum(x => x.mult.outG);
            str = "Потери на всех TB: " + Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + "\nПотери на всех LB: " + Static.dataList.Sum(x => x.lBs.Sum(y => y.R)) + "\nСумма очередей в LB: " + Static.dataList.Sum(x => x.lBs.Sum(y => y.b)) + "\nПотери на мультиплексоре: " + Static.dataList.Sum(x => x.mult.L) + "\nСумма очередей в мультиплексоре: " + delay + "\nJ: " + J;
            MessageBox.Show("Моделирование закончено \nВремя моделирования: " + swatch1.Elapsed.ToString() + "\n" + str);
            richTextBox1.Text = str;
            Static.prev_dataList = new List<Data>(Static.dataList);
            Static.dataList = new List<Data>();
            cbPrevData.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ind = Index_Of_Page_OnList("TB");
            int indp = Index_Of_Page_OnTab("TB");
            if ((Count != 0)&& (ind != -1))
            {
                
                GAPage.Parent = null;
                SPAPage.Parent = null;
                SLAPage.Parent = null;
                //Dequeue_F();
                //tabControl1.TabPages.RemoveAt(TPe.Count() + 1);
                //tabControl1.TabPages.Remove(TPe.Last());

                tabControl1.TabPages.RemoveAt(indp);
                TPe.Remove(TPe.ElementAt(ind));
                if (Count == 0)
                {
                    button2.Enabled = false;
                    Start_modelling.Enabled = false;
                }
                if (Count_Of_Page("TB") == 0)
                {
                    button2.Enabled = false;
                }

                textBox1.Text = Convert.ToString(TPe.Count());
                if (Count == 0)
                {
                    button2.Enabled = false;
                    Start_modelling.Enabled = false;
                }
                if(GA)
                    GAPage.Parent = tabControl1;
                if (SPA)
                    SPAPage.Parent = tabControl1;
                if (SLA)
                    SLAPage.Parent = tabControl1;
            }
            try
            {
                if (Static.prev_dataList != null)
                {
                    if (int.Parse(textBox3.Text) != Static.prev_dataList.Count - 1 || Static.TB_Count != Static.prev_dataList.Last().tBs.Count || Static.LB_Count != Static.prev_dataList.Last().lBs.Count)
                    {
                        cbPrevData.Checked = false;
                        cbPrevData.Enabled = false;
                    }
                    else
                    {
                        cbPrevData.Enabled = true;
                    }
                }
            }
            catch
            {
                cbPrevData.Checked = false;
                cbPrevData.Enabled = false;
            }
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBoxMethod.SelectedIndex == 0)
            {
                if (start)
                {
                    GAPage = tabControl1.TabPages[1];
                    SPAPage = tabControl1.TabPages[2];
                    SLAPage = tabControl1.TabPages[3];
                    GA = false;

                    GAPage.Parent = null;
                    SPA = false;
                    SPAPage.Parent = null;
                    SLA = false;
                    SLAPage.Parent = null;
                    start = false;
                }
                else
                {
                    GA = false;

                    GAPage.Parent = null;
                    SPA = false;
                    SPAPage.Parent = null;
                    SLA = false;
                    SLAPage.Parent = null;
                }
                
            }
            if (comboBoxMethod.SelectedIndex == 1)
            {
                GAPage.Parent = tabControl1;
                GA = true;
                SPA = false;
                SPAPage.Parent = null;
                SLA = false;
                SLAPage.Parent = null;
            }

            if (comboBoxMethod.SelectedIndex == 2)
            {
                SPAPage.Parent = tabControl1;
                SPA = true;
                GA = false;
                GAPage.Parent = null;
                SLA = false;
                SLAPage.Parent = null;
            }
            if (comboBoxMethod.SelectedIndex == 3)
            {
                SLAPage.Parent = tabControl1;
                SLA = true;
                GA = false;
                GAPage.Parent = null;
                SPA = false;
                SPAPage.Parent = null;
            }
        }

        public int Index_Of_Page_OnList(string vs)
        {
            string IP = vs + Count_Of_Page(vs);
            int index_of_P = -1;
            for (int i = Count - 1; i >= 0; i--)
            {
                string st = Convert.ToString(TPe.ElementAt(i).Text);

                if (st == IP)
                    index_of_P = i;
                //richTextBox2.Text += IP + "/ " + st + "/ " + index_of_P + "/" + i + ";";
                //richTextBox2.Text += '\n';

            }
            return index_of_P;
        }

        public int Index_Of_Page_OnTab(string vs)
        {
            string IP = vs + Count_Of_Page(vs);
            int index_of_P = -1;
            for (int i = tabControl1.TabPages.Count - 1; i >= 0; i--)
            {
                string st = Convert.ToString(tabControl1.TabPages[i].Text);

                if (st == IP)
                    index_of_P = i;
                //richTextBox2.Text += IP + "* " + st + "* " + index_of_P + "*" + i + ";";
                //richTextBox2.Text += '\n';

            }
            return index_of_P;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GAPage.Parent = null;
            SPAPage.Parent = null;
            SLAPage.Parent = null;
            button1.Enabled = true;
            Start_modelling.Enabled = true;


            LB_COUNT = LB_COUNT + 1;

            TabPage newTabPage = new TabPage();
            newTabPage.Text = "LB" + (Count_Of_Page("LB") + 1);


            LB_Inretface LI = new LB_Inretface();

            LI.Graf_LB();


            newTabPage.Controls.Add(LI.Size_of_TB);            //0
            newTabPage.Controls.Add(LI.Weight_of_one_token);   //1
            newTabPage.Controls.Add(LI.CIR);                   //2
            newTabPage.Controls.Add(LI.Interval);              //3
            newTabPage.Controls.Add(LI.Size_of_TB_L);          //4
            newTabPage.Controls.Add(LI.Weight_of_one_token_L); //5
            newTabPage.Controls.Add(LI.CIR_L);                 //6
            newTabPage.Controls.Add(LI.Interval_L);            //7
            newTabPage.Controls.Add(LI.chart1);                //8
            newTabPage.Controls.Add(LI.Help_Ro);               //9
            newTabPage.Controls.Add(LI.RTB);                   //10
            newTabPage.Controls.Add(LI.Weight_of_one_token_ED);//11
            newTabPage.Controls.Add(LI.Size_of_TB_ED);         //12
            newTabPage.Controls.Add(LI.CIR_ED);                //13
            newTabPage.Controls.Add(LI.Generated_S);           //14
            newTabPage.Controls.Add(LI.Generated_To);          //15
            newTabPage.Controls.Add(LI.Generated_To_T);        //16
            newTabPage.Controls.Add(LI.Generated_S_T);         //17
            newTabPage.Controls.Add(LI.Generated_ED);          //18

            Enqueue(newTabPage);
            tabControl1.TabPages.Add(TPe.ElementAt(0));
            textBox5.Text = Convert.ToString(Count_Of_Page("LB"));
            if (GA)
                GAPage.Parent = tabControl1;
            if (SPA)
                SPAPage.Parent = tabControl1;
            if (SLA)
                SLAPage.Parent = tabControl1;
            //MessageBox.Show(Static.LB_Count.ToString());
            try
            {
                if (Static.prev_dataList != null)
                {
                    if (int.Parse(textBox3.Text) != Static.prev_dataList.Count - 1 || Static.TB_Count != Static.prev_dataList.Last().tBs.Count || Static.LB_Count != Static.prev_dataList.Last().lBs.Count)
                    {
                        cbPrevData.Checked = false;
                        cbPrevData.Enabled = false;
                    }
                    else
                    {
                        cbPrevData.Enabled = true;
                    }
                }
            }
            catch
            {
                cbPrevData.Checked = false;
                cbPrevData.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ind = Index_Of_Page_OnList("LB");
            int indp = Index_Of_Page_OnTab("LB");

            if ((Count != 0) && (ind != -1))
            {
                //GAPage.Parent = null;
                //SPAPage.Parent = null;
                tabControl1.TabPages.RemoveAt(indp);
                TPe.Remove(TPe.ElementAt(ind));
                LB_COUNT = LB_COUNT - 1;
                if (Count == 0)
                {
                    button1.Enabled = false;
                    Start_modelling.Enabled = false;
                }
                if (Count_Of_Page("LB") == 0)
                {
                    button1.Enabled = false;
                }
                //if (GA)
                //    GAPage.Parent = tabControl1;
                //if (SPA)
                //    SPAPage.Parent = tabControl1;
            }
            textBox5.Text = Convert.ToString(Count_Of_Page("LB"));
            try
            {
                if (Static.prev_dataList != null)
                {
                    if (int.Parse(textBox3.Text) != Static.prev_dataList.Count - 1 || Static.TB_Count != Static.prev_dataList.Last().tBs.Count || Static.LB_Count != Static.prev_dataList.Last().lBs.Count)
                    {
                        cbPrevData.Checked = false;
                        cbPrevData.Enabled = false;
                    }
                    else
                    {
                        cbPrevData.Enabled = true;
                    }
                }
            }
            catch
            {
                cbPrevData.Checked = false;
                cbPrevData.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Static.prev_dataList != null)
                {
                    if (int.Parse(textBox3.Text) != Static.prev_dataList.Count - 1 || Static.TB_Count != Static.prev_dataList.Last().tBs.Count || Static.LB_Count != Static.prev_dataList.Last().lBs.Count)
                    {
                        cbPrevData.Checked = false;
                        cbPrevData.Enabled = false;
                    }
                    else
                    {
                        cbPrevData.Enabled = true;
                    }
                }
            }
            catch
            {
                cbPrevData.Checked = false;
                cbPrevData.Enabled = false;
            }
                    

        }

        public int Count_Of_Page(string vs)
        {
            int Count_of_P = 0;
            for (int i = Count - 1; i >= 0; i--)
            {
                string st = Convert.ToString(TPe.ElementAt(i).Text);
                if (st.Contains(vs))
                    Count_of_P += 1;
            }
            return Count_of_P;
        }
        public void Graph()
        {
            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 1;
            chart1.ChartAreas["area"].AxisX.Maximum = 101;
            chart1.ChartAreas["area"].AxisX.Interval = 2;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 20000;
            chart1.ChartAreas["area"].AxisY.Interval = 1000;

            chart1.Series.Add("Сумма входных пакетов");
            chart1.Series.Add("Объем пакетов в буффере");
            chart1.Series.Add("Объем вышедших пакетов");
            chart1.Series.Add("Потери на входе мультиплексора");

            chart1.Series["Сумма входных пакетов"].Color = System.Drawing.Color.Red;
            chart1.Series["Объем пакетов в буффере"].Color = System.Drawing.Color.Green;
            chart1.Series["Объем вышедших пакетов"].Color = System.Drawing.Color.Blue;
            chart1.Series["Потери на входе мультиплексора"].Color = System.Drawing.Color.Purple;

            chart1.Series["Сумма входных пакетов"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Объем пакетов в буффере"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Объем вышедших пакетов"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Потери на входе мультиплексора"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Legends.Add("legend");

        }

    }
}
