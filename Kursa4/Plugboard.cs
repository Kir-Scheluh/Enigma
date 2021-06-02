using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursa4
{
    public partial class Plugboard : Form
    {
        char[] alph = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public Plugboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] text = textBox1.Text.ToCharArray();
            bool flag = true;
            if (text.Length > 39) flag = false;   
            for (int i = 2; i<text.Length; i+=3)
            {
                if (text[i] != ' ') flag = false;
            }
            for (int i = 0; i<text.Length; i++)
            {
                for (int j = i+1; j<text.Length; j++)
                {
                    if ((text[i] == text[j]) && (text[i]!= ' ')) flag = false;
                }
            }
            
            if (flag)
            {
                for (int i = 0; i < text.Length - 1; i += 3)
                {
                    char buf = alph[Array.IndexOf(alph, text[i])];
                    Rotor.alph[Array.IndexOf(alph, text[i])] = Rotor.alph[Array.IndexOf(alph, text[i + 1])];
                    Rotor.alph[Array.IndexOf(alph, text[i + 1])] = buf;
                }
                this.Close();
            }
            else MessageBox.Show("Введены некорректные данные");            
        }
    }
}
