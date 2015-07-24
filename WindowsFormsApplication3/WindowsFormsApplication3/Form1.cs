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

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        /*[Serializable()]
        class mStruct
        {
            String className;
            String methodName;
            List<object> arguments;
            LinkedList<object[]> par;
            object result;
            public mStruct(string clN, string mtN, List<object> arg)
            {
                className = clN;
                methodName = mtN;
                arguments = arg;
            }
        } */

        public Form1()
        {
            InitializeComponent();
        }

        StreamReader readFile;
        string fileName,fileMeans,tempMeans;
        int slashPos;
        LinkedList<mStruct> mainStruct = new LinkedList<mStruct>();
        char[] delSimbols = {' ','\n','\t','\r'};//Удаляемые символы
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                openFileDialog1.Title = "Open File";
                openFileDialog1.FileName = "";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.ValidateNames == false)
                {
                    MessageBox.Show("Неправильное имя файла.");
                    return;
                }
                                
                readFile = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                fileName = openFileDialog1.FileName;

                for (int i = fileName.Length - 1; i > 0; i--)
                    if (fileName[i] == '\\')
                    {
                        slashPos = i + 1;
                        break;
                    }

                textBox1.Text = fileName.Substring(slashPos,fileName.Length - slashPos);//Взятие имени файла
                fileMeans = readFile.ReadToEnd();
                tempMeans = fileMeans;

                richTextBox1.Clear();

                if (fileMeans == "")
                    richTextBox1.Text = "Файл пуст!";
                else
                    richTextBox1.Text = fileMeans;

                foreach (char s in delSimbols)
                    tempMeans = tempMeans.Replace(s.ToString(),"");

                int count = 0;
                for (int i = 0; i < tempMeans.Length; i++)//Запись в структуру из файла
                {
                    int a = tempMeans.Length;
                    if (tempMeans[i] == '>')
                    {
                        count++;
                    }

                    if (count == 2)
                    {
                        string tempStr = tempMeans.Substring(0,i+1);
                        List<object> tempList = new List<object>();
                        string tempMtName = null;
                        int countSim = 0;
                       /* for(int j=0;j<tempStr.Length;j++)
                            if (tempStr[j] == '.')
                            {
                                for(int k=j+1;k>0;k--)
                                    if (tempStr[k] == '>')
                                    {
                                        tempClName = tempStr.Substring(k+1,j-k-1);
                                        break;
                                    }

                                for(int k=j-1;k<tempStr.Length;k++)
                                    if (tempStr[k] == '(')
                                    {
                                        tempMtName = tempStr.Substring(j+1,k-j-1);
                                        int l = k+1;

                                        while(tempStr[l]!=')'){

                                            l++;
                                        }

                                        string tempArg = tempStr.Substring(k+1,l-k-1);
                                        tempArg = tempArg.Insert(l-k-1,",");

                                        while (tempArg.IndexOf(',') != -1)
                                        {

                                            tempList.Add(tempArg.Substring(0,tempArg.IndexOf(',')));
                                            tempArg = tempArg.Remove(0,tempArg.IndexOf(',')+1);
                                        }

                                        break;   
                                    }
                                         
                            }*/
                        if (tempStr.Substring(1, tempStr.IndexOf('>') - 1) == "process")
                        {
                            countSim = tempStr.Length;
                            tempStr = tempStr.Substring(tempStr.IndexOf('>')+1, tempStr.LastIndexOf('<') - tempStr.IndexOf('>')-1);
                            tempMtName = tempStr.Substring(0, tempStr.IndexOf('('));
                            string tempArg = tempStr.Substring(tempStr.IndexOf('(')+1,tempStr.IndexOf(')')-tempStr.IndexOf('(')-1);
                            tempArg = tempArg.Insert(tempArg.Length, ",");
                            while (tempArg.IndexOf(',') != -1)
                            {

                                tempList.Add(tempArg.Substring(0, tempArg.IndexOf(',')));
                                tempArg = tempArg.Remove(0, tempArg.IndexOf(',') + 1);
                            }

                        }

                        if (tempMtName != null) 
                        {
                            mStruct temp = new mStruct(tempMtName,tempList);
                            mainStruct.AddLast(temp);
                        }
                        count = 0;
                        tempMeans =  tempMeans.Remove(0,countSim);
                        i = 0;
                    }
                }
                Stream newFile = newFile = File.Create("structura.spp");//Запись структуры в файл
                BinaryFormatter ser = new BinaryFormatter();
                ser.Serialize(newFile,mainStruct);
                newFile.Close();
                       
            }
            catch(IOException ex){
                MessageBox.Show(ex.ToString());
            }
            catch(ArgumentOutOfRangeException){
                MessageBox.Show("Ты не прав.");
            }
            catch(ArgumentException){

            }
            finally
            {
                readFile.Close(); 
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileMeans != null)
                richTextBox1.Text = fileMeans;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

