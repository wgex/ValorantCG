using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValorantCG
{
    public partial class Form1 : Form
    {
        public static int lines = 0;

        public static Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists("codes.txt"))
            {
                var stream = File.Create("codes.txt");
                stream.Close();
            }
            else
            {
                string[] readedlines = File.ReadAllLines("codes.txt");
                lines = readedlines.Count();
                label1.Text = "Generated Line Count: " + lines;
            }
        }

        private void cgtimer_Tick(object sender, EventArgs e)
        {
            lines++;
            string kod = kodyap(16);

            textBox1.AppendText("REP-TR-12800-" + kod + "\r\n");

            using (StreamWriter sw = File.AppendText("codes.txt"))
            {
                sw.WriteLine("REP-TR-12800-" + kod);
            }

            label1.Text = "Generated Line Count: " + lines;

        }

        public static string kodyap(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            cgtimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            cgtimer.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
