﻿namespace Дипломчик
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.cbPrevData = new System.Windows.Forms.CheckBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Start_modelling = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGA2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbGA1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSPA4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSPA3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSPA2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSPA1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboBoxMethod);
            this.tabPage1.Controls.Add(this.cbPrevData);
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.Start_modelling);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(893, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(693, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Метод оптимизации";
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Items.AddRange(new object[] {
            "Нет",
            "Генетический алгоритм",
            "Алгоритм роя частиц"});
            this.comboBoxMethod.Location = new System.Drawing.Point(693, 303);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMethod.TabIndex = 17;
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethod_SelectedIndexChanged);
            // 
            // cbPrevData
            // 
            this.cbPrevData.AutoSize = true;
            this.cbPrevData.Location = new System.Drawing.Point(343, 168);
            this.cbPrevData.Name = "cbPrevData";
            this.cbPrevData.Size = new System.Drawing.Size(307, 38);
            this.cbPrevData.TabIndex = 16;
            this.cbPrevData.Text = "Использовать значения пакетов трафика\r\n из предыдущего моделирования";
            this.cbPrevData.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(669, 26);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(188, 172);
            this.richTextBox2.TabIndex = 15;
            this.richTextBox2.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 290);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры Мультиплексора";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(65, 86);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(96, 22);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "5000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Q";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 137);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(585, 147);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(268, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(323, 110);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "C";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(65, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(96, 22);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "500";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(434, 140);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(216, 22);
            this.progressBar1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Время моделирования";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(540, 39);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(63, 22);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "50";
            // 
            // Start_modelling
            // 
            this.Start_modelling.Location = new System.Drawing.Point(379, 76);
            this.Start_modelling.Name = "Start_modelling";
            this.Start_modelling.Size = new System.Drawing.Size(118, 42);
            this.Start_modelling.TabIndex = 4;
            this.Start_modelling.Text = "Начать моделирование";
            this.Start_modelling.UseVisualStyleBackColor = true;
            this.Start_modelling.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(71, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 51);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить TB";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить TB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(168, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "число TB";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbGA2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbGA1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Генетический алгоритм";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Количество поколений";
            // 
            // tbGA2
            // 
            this.tbGA2.Location = new System.Drawing.Point(454, 161);
            this.tbGA2.Name = "tbGA2";
            this.tbGA2.Size = new System.Drawing.Size(100, 22);
            this.tbGA2.TabIndex = 2;
            this.tbGA2.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Число особей в популяции";
            // 
            // tbGA1
            // 
            this.tbGA1.Location = new System.Drawing.Point(454, 117);
            this.tbGA1.Name = "tbGA1";
            this.tbGA1.Size = new System.Drawing.Size(100, 22);
            this.tbGA1.TabIndex = 0;
            this.tbGA1.Text = "10";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.tbSPA4);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.tbSPA3);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.tbSPA2);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.tbSPA1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(893, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Алгоритм роя частиц";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(238, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "alfa2";
            // 
            // tbSPA4
            // 
            this.tbSPA4.Location = new System.Drawing.Point(500, 234);
            this.tbSPA4.Name = "tbSPA4";
            this.tbSPA4.Size = new System.Drawing.Size(100, 22);
            this.tbSPA4.TabIndex = 10;
            this.tbSPA4.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "alfa1";
            // 
            // tbSPA3
            // 
            this.tbSPA3.Location = new System.Drawing.Point(500, 190);
            this.tbSPA3.Name = "tbSPA3";
            this.tbSPA3.Size = new System.Drawing.Size(100, 22);
            this.tbSPA3.TabIndex = 8;
            this.tbSPA3.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Количество итераций";
            // 
            // tbSPA2
            // 
            this.tbSPA2.Location = new System.Drawing.Point(500, 146);
            this.tbSPA2.Name = "tbSPA2";
            this.tbSPA2.Size = new System.Drawing.Size(100, 22);
            this.tbSPA2.TabIndex = 6;
            this.tbSPA2.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Число частиц";
            // 
            // tbSPA1
            // 
            this.tbSPA1.Location = new System.Drawing.Point(500, 102);
            this.tbSPA1.Name = "tbSPA1";
            this.tbSPA1.Size = new System.Drawing.Size(100, 22);
            this.tbSPA1.TabIndex = 4;
            this.tbSPA1.Text = "10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 46);
            this.button1.TabIndex = 19;
            this.button1.Text = "Удалить LB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(71, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 46);
            this.button4.TabIndex = 20;
            this.button4.Text = "Добавить LB";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(80, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "число LB";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(168, 140);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(51, 22);
            this.textBox5.TabIndex = 22;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Start_modelling;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.CheckBox cbPrevData;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGA2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbGA1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSPA2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSPA1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSPA4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSPA3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}