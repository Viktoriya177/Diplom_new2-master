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
using System.Text.RegularExpressions;

namespace Diplom_new
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // открыть файл и вывести данные на форму
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // вычисляем количество строк
            int count_str = richTextBox1.Lines.Length;
            // заменяем множественные пробелы на единичный
            Regex r = new Regex(@"\s+");
            richTextBox1.Lines[0] = r.Replace(richTextBox1.Lines[0], @" ");
            // записываем строку в массив
            string[] words = richTextBox1.Lines[0].Split(new char[] { ' ', '\t' });


           // richTextBox1.Text = richTextBox1.Text + "words.Length= " + words.Length + "\r\n";
            //for (int i = 0; i < words.Length; i++) {
            //    richTextBox1.Text = richTextBox1.Text + words[i] + "\r\n";
           // }

            // массив для хранения значений
            string[,] mass = new string[count_str, words.Length];

            richTextBox1.Text = richTextBox1.Text + "\r\n";
            // очистка массива 
            Array.Clear(words, 0, words.Length);

            // вывод массива на форму, чтобы проверить, что данные считаны корректно
            for (int i = 0; i < count_str; i++)
            {
                // считываем строку в массив - разделитель пробел и табуляция
                words = richTextBox1.Lines[i].Split(new char[] { ' ', '\t' });
                for (int j = 0; j < words.Length; j++)
                {
                    mass[i, j] = words[j];
                    // выводим значения элементов на форму
                    //richTextBox1.Text = richTextBox1.Text + "mass[" + i + "][" + j + "] = " + mass[i, j] + "\r\n";
                    richTextBox1.Text = richTextBox1.Text + "mass[" + i + "][" + j + "]" + mass[i, j] +  "\r\n";
                }
                // очистка массива 
                Array.Clear(words, 0, words.Length);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // очистить форму
            richTextBox1.Clear();
        }
    }

}
