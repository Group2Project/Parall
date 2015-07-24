using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Arithmetic;

namespace Dispatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LinkedList<mStruct> mStr = new LinkedList<mStruct>();
        Stream oStruct;
        String fileName;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open File";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл структуры(spp)|*.spp";
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            try
            {
                oStruct = File.Open(fileName, FileMode.Open);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Необходимо выбрать файл.");
                return;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            mStr = (LinkedList<mStruct>)formatter.Deserialize(oStruct);
            foreach(mStruct current_el in mStr)
            {
                textBox1.Text = textBox1.Text + current_el.getMethodName();

                for (int i = 0; i < 2; i++)
                    textBox1.Text = textBox1.Text +(current_el.getArg(i)).ToString();

                textBox1.Text += "\r\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void выполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
