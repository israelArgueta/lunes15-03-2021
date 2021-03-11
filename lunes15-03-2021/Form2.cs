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
    public partial class Form2 : Form
    {
        int cP = 1;
        public string dpi;
        public string name;
        public string surname;
        List<dueños> du = new List<dueños>();
        List<Casas> casa = new List<Casas>();
        List<usuarios> us = new List<usuarios>();
        List<Cpropiedades> cp = new List<Cpropiedades>();
        List<coutas> may = new List<coutas>();
        Boolean hallarPd = false;
        int Pd = 0;
        Boolean hallarPr = false;
        int Pr = 0;
        Boolean hallarUP = false;
        int Up = 0;
        Boolean hallarCP = false;
        int cont = 0;
        Boolean hallarM = false;
        int cm = 0;
        public Form2()
        {

            InitializeComponent();
        }
        void escDueños()
        {
            FileStream stream = new FileStream("propietarios.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var p in du)
            {
                write.WriteLine(p.Id);
                write.WriteLine(p.Noms);
                write.WriteLine(p.Ape);
            }
            write.Close();
        }
        void analizarDueños()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "propietarios.txt";
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
        void escCasas()
        {
            FileStream stream = new FileStream("propiedades.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var p in casa)
            {
                write.WriteLine(p.Dpi);
                write.WriteLine(p.Nocasa);
                write.WriteLine(p.Mantener);
            }
            write.Close();
        }
        void leerCasas()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);
            while (read.Peek() > -1)
            {
                Casas p = new Casas();
                p.Dpi = read.ReadLine();
                p.Nocasa = read.ReadLine();
                p.Mantener = Convert.ToDouble(read.ReadLine());
                casa.Add(p);
            }
            read.Close();
        }
        void escUs()
        {
            FileStream stream = new FileStream("usp.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var u in us)
            {
                write.WriteLine(u.Nombre);
                write.WriteLine(u.Apellido);
                write.WriteLine(u.No);
                write.WriteLine(u.Manten);
            }
            write.Close();
        }
        void leerUs()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "usp.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                usuarios u = new usuarios();
                u.Nombre = reader.ReadLine();
                u.Apellido = reader.ReadLine();
                u.No = reader.ReadLine();
                u.Manten = Convert.ToDouble(reader.ReadLine());
                us.Add(u);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = us;
                dataGridView1.Refresh();
            }
            reader.Close();
        }
        void replayPd()
        {
            while (hallarPd == false && Pd < casa.Count)
            {
                if (casa[Pd].Nocasa.CompareTo(textBox4.Text) == 0)
                {
                    hallarPd = true;
                }
                else
                {
                    Pd++;
                }
            }
        }

        void replayPr()
        {
            while (hallarPr == false && Pr < du.Count)
            {
                if (du[Pr].Id.CompareTo(textBox1.Text) == 0)
                {
                    hallarPr = true;
                }
                else
                {
                    Pr++;
                }
            }
        }

        void replayUP()
        {
            while (hallarUP == false && Up < us.Count)
            {
                if (us[Up].No.CompareTo(textBox4.Text) == 0)
                {
                    hallarUP = true;
                }
                else
                {
                    Up++;
                }
            }
        }

        void replayCP()
        {
            while (hallarCP == false && cont < cp.Count)
            {
                if (cp[cont].Nom.CompareTo(textBox2.Text) == 0 && cp[cont].Apellido.CompareTo(textBox3.Text) == 0)
                {
                    hallarCP = true;
                }
                else
                {
                    cont++;
                }
            }
        }
        void escribirCantidad()
        {
            FileStream stream = new FileStream("cantidad.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var c in cp)
            {
                write.WriteLine(c.Nom);
                write.WriteLine(c.Apellido);
                write.WriteLine(c.Cant);
            }
            write.Close();
        }
        void leerCantidad()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "cantidad.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);
            while (read.Peek() > -1)
            {
                Cpropiedades c = new Cpropiedades();
                c.Nom = read.ReadLine();
                c.Apellido = read.ReadLine();
                c.Cant = Convert.ToInt32(read.ReadLine());
                cp.Add(c);
            }
            read.Close();
        }
        void escribirMayor()
        {
            FileStream stream = new FileStream("mayor.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var m in may)
            {
                write.WriteLine(m.Perso);
                write.WriteLine(m.Ap);
                write.WriteLine(m.Man);
            }
            write.Close();
        }

        void leerMayor()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "mayor.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);
            while (read.Peek() > -1)
            {
                coutas m = new coutas();
                m.Perso = read.ReadLine();
                m.Ap = read.ReadLine();
                m.Man = Convert.ToDouble(read.ReadLine());
                may.Add(m);
            }
            read.Close();
        }

        void repetidosMayor()
        {
            while (hallarM == false && cm < may.Count)
            {
                if (may[cm].Perso.CompareTo(textBox2.Text) == 0 && may[cm].Ap.CompareTo(textBox3.Text) == 0)
                {
                    hallarM = true;
                }
                else
                {
                    cm++;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = dpi;
            textBox2.Text = name;
            textBox3.Text = surname;
            textBox2.Focus();
            analizarDueños();
            leerCasas();
            leerUs();
            leerCantidad();
            leerMayor();
            if (cp.Count >= 1)
            {
                mayor();
            }
            if (casa.Count >= 3)
            {
                mayorM();
                menorM();
            }

            if (may.Count >= 1)
            {
                mayorT();
            }
        }

        void mayor()
        {
            if (cp.Count >= 1)
            {
                textBox6.Clear();
                cp = cp.OrderByDescending(c => c.Cant).ToList();
                textBox6.AppendText(cp[0].Nom + " " + cp[0].Apellido);
            }
        }

        void mayorM()
        {
            if (casa.Count >= 3)
            {
                listBox1.Items.Clear();
                casa = casa.OrderByDescending(p => p.Mantener).ToList();
                listBox1.Items.Insert(0, casa [0].Mantener);
                listBox1.Items.Insert(1, casa[1].Mantener);
                listBox1.Items.Insert(2, casa[2].Mantener);
            }
        }

        void menorM()
        {
            if (casa.Count >= 3)
            {
                listBox2.Items.Clear();
                casa = casa.OrderBy(p => p.Mantener).ToList();
                listBox2.Items.Insert(0, casa[0].Mantener);
                listBox2.Items.Insert(1, casa[1].Mantener);
                listBox2.Items.Insert(2, casa[2].Mantener);
            }
        }

        void mayorT()
        {
            if (may.Count >= 1)
            {
                label12.Text.Remove(0);
                may = may.OrderByDescending(m => m.Man).ToList();
                label12.Text = may[0].Perso + " " + may[0].Ap + " es el propietario con la cuota de mantenimiento más alta con " +
                    may[0].Man;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                Cpropiedades c = new Cpropiedades();
                replayPr();
                if (hallarPr)
                {
                    replayCP();
                    if (hallarCP)
                    {
                        c.Nom = textBox2.Text;
                        c.Apellido = textBox3.Text;
                        cp[cont].Cant += 1;
                        c.Cant = cp[cont].Cant;
                        cp.Add(c);
                        cp.RemoveAt(cont);
                        escribirCantidad();
                        hallarCP = false;
                        cont = 0;
                    }
                    else
                    {
                        cont = 0;
                    }

                    hallarPr = false;
                    Pr = 0;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                }
                else
                {
                    dueños p = new dueños();
                    p.Id = textBox1.Text;
                    p.Noms = textBox2.Text;
                    p.Ape = textBox3.Text;
                    du.Add(p);
                    escDueños();
                    c.Nom = textBox2.Text;
                    c.Apellido = textBox3.Text;
                    c.Cant = cP;
                    cp.Add(c);
                    escribirCantidad();
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    Pr = 0;
                }
                textBox4.Focus();
                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && Convert.ToDouble(textBox5.Text) > 0)
            {
                Casas p = new Casas();
                usuarios uss = new usuarios();
                coutas m = new coutas();
                p.Nocasa = textBox4.Text;
                replayUP();
                if (hallarUP)
                {
                    MessageBox.Show("El número de casa introducido ya no está disponible");
                    textBox4.Clear();
                    hallarUP = false;
                    Up = 0;
                }
                else
                {
                    p.Dpi = textBox1.Text;
                    p.Mantener = Convert.ToDouble(textBox5.Text);
                    casa.Add(p);
                    escCasas();
                    uss.Nombre = textBox2.Text;
                    uss.Apellido = textBox3.Text;
                    uss.No = textBox4.Text;
                    uss.Manten = Convert.ToDouble(textBox5.Text);
                    us.Add(uss);
                    escUs();
                    repetidosMayor();
                    if (hallarM)
                    {
                        m.Perso = textBox2.Text;
                        m.Ap = textBox3.Text;
                        m.Man = may[cm].Man + Convert.ToDouble(textBox5.Text);
                        may.Add(m);
                        may.RemoveAt(cm);
                        escribirMayor();
                        hallarM = false;
                        cm = 0;
                    }
                    else
                    {
                        m.Perso = textBox2.Text;
                        m.Ap = textBox3.Text;
                        m.Man = Convert.ToDouble(textBox5.Text);
                        may.Add(m);
                        escribirMayor();
                        cm = 0;
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = us;
                    dataGridView1.Refresh();
                    MessageBox.Show("Propiedad asignada exitósamente");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    button2.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            mayor();
            mayorM();
            menorM();
            mayorT();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            us = us.OrderByDescending(u => u.Manten).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = us;
            dataGridView1.Refresh();
        }
    }
}
