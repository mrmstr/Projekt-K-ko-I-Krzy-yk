using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Gra_kółko_i_krzyżyk
{
    public partial class Form1 : Form
    {
        bool turn = true;
        bool against_computer = false;
        int turn_count = 0;
        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        // Informacje
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projekt zaliczeniowy - Piotr Boczek", "Informacje");
        }

        // Koniec gry
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Reakcja na przycisk
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }
      

    // Sprawdzanie wygranego lub remisu
    private void checkForWinner()
        {
            bool there_is_a_winner = false;

            // Rządy
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            // Kolumny
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            // Ukosy
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                String winner = "";
                if (turn)
                {
                    winner = player2;
                    o_win.Text = (Int32.Parse(o_win.Text) + 1).ToString();
                }
                else
                {
                    winner = player1;
                    x_win.Text = (Int32.Parse(x_win.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " Wygrywa!", "Gratulacje!");
                disableButtons();
            }
            else
            {
                if (turn_count == 9)
                {
                    draw.Text = (Int32.Parse(draw.Text) + 1).ToString();
                    MessageBox.Show("Remis!", "Koniec gry");
                }
            }

        }

        // Wyłączanie przycisków
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }
        // Nowa Gra
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
            
        }

        // Najazd myszką
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
         }

        // Wyjazd myszką
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        // Reset wyników
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            o_win.Text = "0";
            x_win.Text = "0";
            draw.Text = "0";
        }

        // Jak grać?
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracze obejmują pola na przemian dążąc do objęcia trzech pól w jednej linii, kolumnie bądź skosie przy jednoczesnym uniemożliwieniu tego samego przeciwnikowi. Pole może być objęte przez jednego gracza i nie zmienia swego właściciela przez cały przebieg gry.", "Jak grać?");
        }

        // Restart
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        // Ładowanie okienka
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label3.Text = player2;

            if (label3.Text.ToUpper() == "KOMPUTER")
                against_computer = true;
            else
                against_computer = false;
            
               
        }
    }
}


