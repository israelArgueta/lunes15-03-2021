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

namespace lunes15_03_2021
{
    public partial class Form1 : Form
    {
        List<dueños> du = new List<dueños>();
        Boolean hallardu = false;
        int Du = 0;
        public Form1()
        {
            InitializeComponent();
        }
        void leerDueños()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "Dueños.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                dueños p = new dueños();
                p.Id = reader.ReadLine();
                p.Noms = reader.ReadLine();
                p.Ape = reader.ReadLine();
                du.Add(p);
            }
            reader.Close();
        }
        void replayPr()
        {
            while (hallardu == false && Du < du.Count)
            {
                if (du[Du].Id.CompareTo(textBox1.Text) == 0)
                {
                    hallardu = true;
                }
                else
                {
                    Du++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                leerDueños();
                Form2 f2 = new Form2();
                dueños p = new dueños();
                p.Id = textBox1.Text;
                replayPr();
                if (hallardu)
                {
                    f2.dpi = textBox1.Text;
                    f2.name = du[Du].Noms;
                    f2.surname = du[Du].Ape;
                    textBox1.Clear();
                    hallardu = false;
                    Du = 0;
                }
                else
                {
                    f2.dpi = textBox1.Text;
                    f2.textBox2.Enabled = true;
                    f2.textBox2.Focus();
                    f2.textBox3.Enabled = true;
                    textBox1.Clear();
                    Du = 0;
                }
                f2.Show();
                f2.button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Porfavor introduzca el Número de DPI");
            }
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerDueños();
        }
    }
}
