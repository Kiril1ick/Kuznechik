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
        string Msg = null;
        string[] StrArr = new string [16];
        string[] constant = {"94","20","85","10","C2","C0","01","FB","01","C0","C2","10","85","20","94","01"};
        
        public Form1()
        {
            InitializeComponent();
        }

        public void PolinomUmnojenie(string Msg)
        {
            for(int i = 0; i<textBox1.Text.Length;i++)
            {
                StrArr[i] = Convert.ToString(Convert.ToInt32(constant[i], 16) * Convert.ToInt32(Convert.ToString(Msg[i], 2), 2), 2);
                if (StrArr[i].Length>8)
                {
                    StrArr[i] = UmenshenieBit(StrArr[i]);
                }
            }
        }

        public string UmenshenieBit(string simbol)
        {
            char [] chislo = "111000011".ToCharArray();
            char[] result = simbol.ToCharArray();

            while (result.Length>8)
            {
                for (int j = 0; j<chislo.Length;j++)
                {
                    if (simbol[j] != chislo[j])
                    {
                        result[j] = '1';
                    }
                    else
                    {
                        result[j] = '0';
                    }
                }

                while (result[0] == '0')
                {
                    if (result[0] == '0')
                    {
                        for (int j = 0; j < result.Length - 1; j++)
                        {
                            result[j] = result[j + 1];
                        }
                        Array.Resize(ref result, result.Length - 1);
                    }
                }
            }
            simbol = null;
            for (int i=0; i<result.Length;i++)
            {
                simbol+=result[i];
            }

            return simbol;
        }

        public void SlojeniePoModuly2()
        {
            string result=null;
            for (int i = 0;i<StrArr.Length-1;i++)
            {
                result = Convert.ToString(Convert.ToInt32(StrArr[i],2)^ Convert.ToInt32(StrArr[i+1], 2), 2);
            }

            for (int i = StrArr.Length; i < 1; i--)
            {
                StrArr[i] = StrArr[i-1];
            }
            StrArr[0] = result;
        }

        public void PerevodVZnak()
        {
            for (int i = 0;i<StrArr.Length;i++)
            {
                StrArr[i] = Convert.ToString((char)(Convert.ToInt32(StrArr[i], 2)));
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

            Msg = textBox1.Text;
            for (int i = 0; i<16;i++)
            {
                PolinomUmnojenie(Msg);
                SlojeniePoModuly2();
            }
            PerevodVZnak();
            for (int i =0; i<textBox1.Text.Length;i++) 
            {
                textBox2.Text += StrArr[i];
            }
        }
    }
}
