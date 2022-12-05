using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuznechik
{
    public partial class Form1 : Form
    {
        string[] StrArr = null;
        string[] constant = {"94","20","85","10","C2","C0","01","FB","01","C0","C2","10","85","20","94","01"};
        
        public void PolinomUmnojenie()
        {
            for(int i = 0; i<textBox1.Text.Length;i++)
            {
                StrArr[i] = Convert.ToInt32(Convert.ToString(textBox1.Text[i], 2), 2);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = null;
            
            if (textBox1.Text.Length != 16)
            {
                label1.Text = "Колличество букв в строке не равно 16.";
                if(textBox1.Text.Length > 16)
                {
                    label1.Text += " Уберите " + (textBox1.Text.Length - 16) + " символов";
                }
                else
                {
                    label1.Text += " Добавьте " + (16- textBox1.Text.Length) + " символов";
                }
                return;
            }

            for (int i =0; i<textBox1.Text.Length;i++) 
            {
                textBox2.Text += Convert.ToString(Convert.ToInt32(constant[i], 16) ^ Convert.ToInt32(Convert.ToString(textBox1.Text[i],2), 2), 2)+" ";
            }
        }
    }
}
