using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CountDown
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t; //класс таймера
        int h, m, s;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer(); //создаем таймер
            t.Interval = 500; //устанавливаем интервал в одну секунду
            t.Elapsed += OnTimeEvent; //по истечении времени генерится событие
        }
        //обработчик события OnTimeEvent
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
             {                 
                 s += 1;
                if (s == 60) //если количество секунд 60
                {
                    s = 0; //обнулить счетчик секунд
                    m += 1; //и увеличить минуты на 1
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1; //увеличить часы на 1
                }
                textResult.Text = string.Format("{}:{}:{}", h.ToString().PadLeft(2, '0'),
                    m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')); 
                    
              }));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            t.Start();
        }       

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }

        private void textResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
