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
        
        TBMath_2 tbn;
        MplexMath_2 MXP;
        Buff_2 BUF;
        bool GA = false, SPA = false;
        public LinkedList<TabPage> TPe = new LinkedList<TabPage>();
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
        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            BUF = new Buff_2();
            button2.Enabled = false;
            Start_modelling.Enabled = false;
            cbPrevData.Enabled = false;
            comboBoxMethod.SelectedIndex = 0;
            GAPage = tabControl1.TabPages[1];
            SPAPage = tabControl1.TabPages[2];
            GAPage.Parent = null;
            SPAPage.Parent = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GAPage.Parent = null;
            SPAPage.Parent = null;
            button2.Enabled = true;
            Start_modelling.Enabled = true;

            TabPage newTabPage = new TabPage();
            newTabPage.Text = "TB" + (TPe.Count()+1);

            TB_Interface TI = new TB_Interface();
            /*
            TextBox Size_of_TB = new TextBox();
            Size_of_TB.Location = new Point(250, 30);
            Size_of_TB.Name = "Size_of_TB";
            Size_of_TB.Text = "1000";
            Size_of_TB.Width = 100;
            Size_of_TB.Height = 30;
            Size_of_TB.Size = new Size(115, 22);

            Label Size_of_TB_L = new Label();
            Size_of_TB_L.Location = new Point(20, 30);
            Size_of_TB_L.Name = "Size_of_TB_L";
            Size_of_TB_L.Text = "Максимальный объем Token Bucket";
            Size_of_TB_L.Width = 100;
            Size_of_TB_L.Height = 30;
            Size_of_TB_L.Size = new Size(200, 22);

            TextBox Weight_of_one_token = new TextBox();
            Weight_of_one_token.Location = new Point(250, 60);
            Weight_of_one_token.Name = "Weight_of_one_token";
            Weight_of_one_token.Text = "20";
            Weight_of_one_token.Width = 100;
            Weight_of_one_token.Height = 30;
            Weight_of_one_token.Size = new Size(115, 22);

            Label Weight_of_one_token_L = new Label();
            Weight_of_one_token_L.Location = new Point(20, 60);
            Weight_of_one_token_L.Name = "Weight_of_one_token_L";
            Weight_of_one_token_L.Text = "Вес одного токена";
            Weight_of_one_token_L.Width = 100;
            Weight_of_one_token_L.Height = 30;
            Weight_of_one_token_L.Size = new Size(200, 22);

            TextBox CIR = new TextBox();
            CIR.Location = new Point(250, 90);
            CIR.Name = "CIR";
            CIR.Text = "100";
            CIR.Width = 100;
            CIR.Height = 30;
            CIR.Size = new Size(115, 22);

            Label CIR_L = new Label()
            {
                Location = new Point(20, 90),
                Name = "CIR_L",
                Text = "Скорость поступления токенов",
                Width = 100,
                Height = 30,
                Size = new Size(200, 22)
            };

            TextBox Interval = new TextBox();
            Interval.Location = new Point(250, 120);
            Interval.Name = "Interval";
            Interval.Text = "1";
            Interval.Width = 100;
            Interval.Height = 30;
            Interval.Size = new Size(115, 22);

            Label Interval_L = new Label();
            Interval_L.Location = new Point(20, 120);
            Interval_L.Name = "Interval_L";
            Interval_L.Text = "Интервал рассмотрения";
            Interval_L.Width = 100;
            Interval_L.Height = 30;
            Interval_L.Size = new Size(200, 22);


            TextBox Help_Ro = new TextBox();
            Help_Ro.Location = new Point(0, 0);
            Help_Ro.Name = "Help_Ro";
            //Help_Ro.Text = "1000";
            Help_Ro.Width = 100;
            Help_Ro.Height = 30;
            Help_Ro.Size = new Size(115, 22);
            Help_Ro.Visible = false;


            */
            System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            //chart1.Anchor = (AnchorStyles.Right & AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Top);
            chart1.Location = new Point(10, 150);
            chart1.Name = "chart1";
            chart1.Anchor = (AnchorStyles.Right /*| AnchorStyles.Bottom */| AnchorStyles.Left | AnchorStyles.Top);
            chart1.Margin = new Padding(5,5,5,5);
            chart1.Width = 170;
            chart1.Height = 550;
            //chart1.Size = new Size(150, 50);
            
            /*
            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 100;
            chart1.ChartAreas["area"].AxisX.Interval = 2;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 20000;
            chart1.ChartAreas["area"].AxisY.Interval = 500;


            chart1.Series.Add("GTk");
            chart1.Series.Add("VTk");
            chart1.Series.Add("RoTk");

            chart1.Series["GTk"].Color = Color.Red;
            chart1.Series["VTk"].Color = Color.Green;
            chart1.Series["RoTk"].Color = Color.Blue;

            chart1.Series["GTk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["VTk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["RoTk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Legends.Add("legend");
            */
            /*
            chart1.Series["T"].Points.AddXY(0,0);
            chart1.Series["T"].Points.AddXY(50, 10);
            chart1.Series["T"].Points.AddXY(100, 10);
            chart1.Series["T"].Points.AddXY(200, 1);
            //chart1.Series["T"].Points.Clear();
            */
            /*
            newTabPage.Controls.Add(Size_of_TB);
            newTabPage.Controls.Add(Weight_of_one_token);
            newTabPage.Controls.Add(CIR);
            newTabPage.Controls.Add(Interval);
            newTabPage.Controls.Add(Size_of_TB_L);
            newTabPage.Controls.Add(Weight_of_one_token_L);
            newTabPage.Controls.Add(CIR_L);
            newTabPage.Controls.Add(Interval_L);
            newTabPage.Controls.Add(chart1);
            newTabPage.Controls.Add(Help_Ro);
            */
            TI.Graf_TB();

            //Предыдущее

            //newTabPage.Controls.Add(TI.Size_of_TB);            //0
            ////newTabPage.Controls.Add(TI.Weight_of_one_token);   //1
            ////newTabPage.Controls.Add(TI.CIR);                   //2
            //newTabPage.Controls.Add(TI.CIR);                   //2
            //newTabPage.Controls.Add(TI.Interval);              //3
            //newTabPage.Controls.Add(TI.Size_of_TB_L);          //4
            ////newTabPage.Controls.Add(TI.Weight_of_one_token_L); //5
            //newTabPage.Controls.Add(TI.CIR_L);                 //6
            //newTabPage.Controls.Add(TI.Interval_L);            //7
            //newTabPage.Controls.Add(TI.chart1);                //8
            //newTabPage.Controls.Add(TI.Help_Ro);               //9
            //newTabPage.Controls.Add(TI.RTB);                   //10
            //newTabPage.Controls.Add(TI.Weight_of_one_token_ED);//11
            //newTabPage.Controls.Add(TI.Size_of_TB_ED);         //12
            //newTabPage.Controls.Add(TI.CIR_ED);                //13
            //newTabPage.Controls.Add(TI.Generated_S);           //14
            //newTabPage.Controls.Add(TI.Generated_To);          //15
            //newTabPage.Controls.Add(TI.Generated_To_T);        //16
            //newTabPage.Controls.Add(TI.Generated_S_T);         //17
            //newTabPage.Controls.Add(TI.Generated_ED);          //18

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
            textBox1.Text = Convert.ToString(TPe.Count());
            if (GA)
                GAPage.Parent = tabControl1;
            if (SPA)
                SPAPage.Parent = tabControl1;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox2.Clear();
            
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            swatch.Start();

            Static.dataList = new List<Data>();
            MXP = new MplexMath_2(ref textBox2, ref richTextBox1, ref textBox4);

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

            progressBar1.Maximum = Convert.ToInt16(textBox3.Text)+1;
            progressBar1.Value = 0;
            
            int Time_To_Model = Convert.ToInt16(textBox3.Text);

            for (int k = 0; k <= Time_To_Model; k++)
            {
                Data data = new Data();
                data.tBs = new List<TBStruct>(TPe.Count);
                Vector vector = new Vector();
                progressBar1.Value++;
                //Инициализация структур маркерных корзин и мультиплексора
                for (int z = 0; z <= TPe.Count - 1; z++)
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
                        V = Static.prev_dataList[k].tBs[z].V;
                    //Console.WriteLine(V);
                    tBStruct.addInput(V);
                    
                    data.tBs.Add(tBStruct);
                }
                data.mult = new MultStruct();
                data.mult.addInit(MXP.Q, MXP.C_T);
                Static.dataList.Add(data);
                Console.WriteLine("ooo");
                
                if (comboBoxMethod.SelectedIndex == 1)
                {
                    GeneticAlgorithm algorithm = new GeneticAlgorithm(int.Parse(tbGA1.Text), TPe.Count, int.Parse(tbGA2.Text), Functions.J, Functions.genVector);
                    vector = new Vector(algorithm.result());
                }
                if (comboBoxMethod.SelectedIndex == 2)
                {
                    SwarmParticlesAlgorithm algorithm = new SwarmParticlesAlgorithm(int.Parse(tbSPA1.Text), TPe.Count, int.Parse(tbSPA2.Text), double.Parse(tbSPA3.Text), double.Parse(tbSPA4.Text), Functions.J, Functions.genVector);
                    vector = new Vector(algorithm.result());
                }

                //Старое

                //for (int z = 0, v = 0; z <= TPe.Count - 1; z++, v+=2)
                //{



                //    TBStruct tBStruct = data.tBs[z];

                //    T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                //    Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[3]).Text);
                //    V = tBStruct.V;
                //    //Console.WriteLine(z);
                //    //Console.WriteLine(V);

                //    if (comboBoxMethod.SelectedIndex == 0)
                //    {
                //        CIR = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[2]).Text);
                //        Nt = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[1]).Text);
                //    }
                //    else
                //    {
                //        CIR = vector[v];
                //        Nt = vector[v + 1];
                //    }
                //    tBStruct.addOptimized(CIR, Nt);
                //    data.tBs[z] = tBStruct;







                //    ch = tbn.M(CIR, Tk, T, Nt, RoTk_1, V);
                //    ((TextBox)TPe.ElementAt(z).Controls[9]).Text = Convert.ToString(ch[3]);
                //    //RoTk_1 = ch[3];

                //    R = ch[4];//потери на z токенбакете

                //    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["GTk"].Points.AddXY(k, ch[0]);
                //    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["VTk"].Points.AddXY(k, ch[1]);
                //    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["RoTk"].Points.AddXY(k, ch[2]);

                //    Gi[z] = ch[0];

                //    richTextBox2.Text += "Момент: " + k + "; TB№" + (TPe.Count - z) + " GTk = " + ch[0];
                //    richTextBox2.Text += '\n';

                //    tBStruct.addDecision(ch[0], ch[3], ch[4]);
                //    //RoTk_1 = ch[3];
                //    data.tBs[z] = tBStruct;


                //}
                //Console.WriteLine("ooo");
                //foreach (TBStruct tBStruct in data.tBs)
                //{
                //    Console.WriteLine("kkk");
                //    Console.WriteLine(tBStruct.V);
                //}

                //Новое

                for (int z = 0; z <= TPe.Count - 1; z++)
                {



                    TBStruct tBStruct = data.tBs[z];

                    T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                    Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[2]).Text);
                    V = tBStruct.V;

                    if (comboBoxMethod.SelectedIndex == 0)
                    {
                        U = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[1]).Text);
                        
                    }
                    else
                    {
                        U = vector[z];
                    }
                    tBStruct.addOptimized(U);
                    data.tBs[z] = tBStruct;







                    //ch = tbn.M(CIR, Tk, T, Nt, RoTk_1, V);
                    ch = tbn.M(Tk, T, U, RoTk_1, V);
                    ((TextBox)TPe.ElementAt(z).Controls[7]).Text = Convert.ToString(ch[3]);
                    //RoTk_1 = ch[3];

                    R = ch[4];//потери на z токенбакете

                    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["GTk"].Points.AddXY(k, ch[0]);
                    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["VTk"].Points.AddXY(k, ch[1]);
                    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[6]).Series["RoTk"].Points.AddXY(k, ch[2]);

                    Gi[z] = ch[0];

                    richTextBox2.Text += "Момент: " + k + "; TB№" + (TPe.Count - z) + " GTk = " + ch[0];
                    richTextBox2.Text += '\n';

                    tBStruct.addDecision(ch[0], ch[3], ch[4]);
                    //RoTk_1 = ch[3];
                    data.tBs[z] = tBStruct;


                }

                data.mult.addInput(Gi);
                OPT = MXP.MX(Gi);
                data.mult.addDecision(OPT[1], OPT[0]);
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

            double inPackages = Static.dataList.Sum(x => x.tBs.Sum(y => y.V));
            double outPackages = Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + Static.dataList.Sum(x => x.mult.L);
            MessageBox.Show("Моделирование закончено \nВремя моделирования: " + swatch.Elapsed.ToString() + "\nПоступило бит: " + inPackages + "\nОтброшено бит: " + outPackages);
            Static.prev_dataList = new List<Data>(Static.dataList);
            Static.dataList = new List<Data>();
            cbPrevData.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Count != 0)
            {
                
                GAPage.Parent = null;
                SPAPage.Parent = null;
                Dequeue_F();
                tabControl1.TabPages.RemoveAt(TPe.Count() + 1);
                //tabControl1.TabPages.Remove(TPe.Last());
                
                
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
            }
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMethod.SelectedIndex == 1)
            {
                GAPage.Parent = tabControl1;
                GA = true;
                SPA = false;
                SPAPage.Parent = null;
            }

            if (comboBoxMethod.SelectedIndex == 2)
            {
                SPAPage.Parent = tabControl1;
                SPA = true;
                GA = false;
                GAPage.Parent = null;
            }
        }
    }
}
