using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var Class = new JaggedMatrix(double.Parse(textBox2.Text), double.Parse(textBox3.Text), int.Parse(textBox1.Text));
                var arr = Class.PrintStrings();

                for (int i = 0; i < arr.Length; i++)
                {
                    richTextBox1.Text += arr[i] + "\n";
                }


            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат входных данных");
            }
        }
    }
}
