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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Plugboard commutation = new Plugboard();
            commutation.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string mes = textBox1.Text.ToLower();
                char[] message = mes.ToCharArray();
                Rotor r1 = new Rotor(comboBox9.Text, comboBox8.Text);
                Rotor r2 = new Rotor(comboBox6.Text, comboBox5.Text);
                Rotor r3 = new Rotor(comboBox1.Text, comboBox2.Text);
                r1.number = 1;
                r2.number = 2;
                r3.number = 3;
                Reflector reflector = new Reflector(comboBox10.Text.ToLower());
                for (int i = 0; i < message.Length; i++)
                {
                    if (Rotor.alph.Contains(message[i]))
                    {
                        Rotor r0 = new Rotor();
                        Rotor.stepping(r1, r2, r3);
                        message[i] = Rotor.alph[Array.IndexOf(Rotor.alphabet, message[i])];                        
                        message[i] = Rotor.transition(r0, r1, message[i]);
                        message[i] = r1.change_letter(r1, message[i]);
                        message[i] = Rotor.transition(r1, r2, message[i]);
                        message[i] = r2.change_letter(r2, message[i]);
                        message[i] = Rotor.transition(r2, r3, message[i]);
                        message[i] = r3.change_letter(r3, message[i]);
                        message[i] = reflector.transition(r3, ref message[i]);
                        message[i] = r3.revers_change_letter(r3, message[i]);
                        message[i] = Rotor.transition(r3, r2, message[i]);
                        message[i] = r2.revers_change_letter(r2, message[i]);
                        message[i] = Rotor.transition(r2, r1, message[i]);
                        message[i] = r1.revers_change_letter(r1, message[i]);
                        message[i] = Rotor.transition(r1, r0, message[i]);
                        message[i] = Rotor.alph[Array.IndexOf(Rotor.alphabet, message[i])];
                    }
                    textBox2.Text += message[i];
                    
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }            
        }
    }
}
