using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gra_kółko_i_krzyżyk
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((p1.Text == "") || (p2.Text == ""))
            {
                MessageBox.Show("Podaj imiona graczy zanim rozpoczniesz grę!\n Wpisz komputer w miejsce imienia dla drugiego gracza jeśli chcesz zagrać przeciwko komputerowi");
            }
            else
            {
                Form1.setPlayerNames(p1.Text, p2.Text);
                this.Close();
            }
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {

        }

        private void p1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
