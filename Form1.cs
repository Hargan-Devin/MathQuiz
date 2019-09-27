using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
            dateLabel.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }
        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.",
                    "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }

        private void Sum_ValueChanged(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
                SystemSounds.Beep.Play();
        }

        private void Difference_ValueChanged(object sender, EventArgs e)
        {
           if (minuend - subtrahend == difference.Value)
            SystemSounds.Beep.Play();
        }

        private void Product_ValueChanged(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
                SystemSounds.Beep.Play();
        }

        private void Quotient_ValueChanged(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
                SystemSounds.Beep.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }
    }
}
