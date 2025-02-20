using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int skor;
        int sayi;

        private void button1_Click(object sender, EventArgs e)
        {
            
            Random rndm = new Random();

            skor = 3; 
            label2.Text = skor.ToString();
            button5.Enabled = true;
            textBox1.Enabled = true;

            sayi = rndm.Next(1, 11); 
            MessageBox.Show("Aklımdan bir sayı tuttum. Tahmin et!","Sayı Tutuldu",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ResetButtons(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (int.TryParse(textBox1.Text, out int tahmin))
            {
                if (sayi < tahmin)
                {
                    MessageBox.Show("Tutalan Sayı Tahmin Ettiğiniz Sayıdan Küçük", "Küçük Sayı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    skor--;
                    HighlightRed(skor);
                }
                else if (sayi > tahmin)
                {
                    MessageBox.Show("Tutalan Sayı Tahmin Ettiğiniz Sayıdan Büyük", "Büyük Sayı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    skor--;
                    HighlightRed(skor);
                }
                else
                {
                    MessageBox.Show("Tebrikler, doğru tahmin!");
                    ResetGame();
                }

                if (skor == 0)
                {
                    MessageBox.Show($"Oyun bitti! Doğru sayı: {sayi}");
                    ResetGame();
                }

                label2.Text = skor.ToString();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayı giriniz!");
            }
        }

        private void HighlightRed(int remainingTries)
        {
            
            if (remainingTries == 2) button2.BackColor = Color.Red;
            else if (remainingTries == 1) button3.BackColor = Color.Red;
            else if (remainingTries == 0) button4.BackColor = Color.Red;
        }

        private void ResetButtons()
        {
            
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
        }

        private void ResetGame()
        {
           
            button5.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Clear();
            ResetButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ResetGame();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}


