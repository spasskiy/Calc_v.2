using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Calc_v._2
{
    public partial class Form1 : Form
    {
        string mainDisplayValue = "0";
        string upperDisplayValue = "";

        int bracketsCounter = 0;

        bool commaInCurrentNumber = false;

        bool ChecMainDisplayValue()
        {
            if (Regex.IsMatch(mainDisplayValue, @"[\sa-zа-ё]+\d*", RegexOptions.IgnoreCase) || mainDisplayValue.Contains('∞'))
                return false;
            return true;
        }
        void Reset()
        {
            Display.Reset(mainDisplay, upperDisplay, ref mainDisplayValue, ref upperDisplayValue, ref commaInCurrentNumber);
        }
        void UpMoveDown()
        {
            Display.UpperValueMoveDown(mainDisplay, upperDisplay, ref mainDisplayValue, ref upperDisplayValue, ref commaInCurrentNumber);
        }
        void Show()
        {
            Display.DisplayShow(mainDisplay, upperDisplay, ref mainDisplayValue, ref upperDisplayValue);
        }

        void presNumberButton(char input)
        {

            if (radioButtonNormalMode.Checked)
            {
                if (!ChecMainDisplayValue())
                    mainDisplayValue = "0";
                Display.AddNumber(mainDisplay, ref mainDisplayValue, input);
            }
            if (radioButtonPolandMode.Checked)
            {
                Display.AddNumber(mainDisplay, ref mainDisplayValue, input);
            }

           
        }

        void inputPolandElement(char input)
        {
            Display.AddPolandElement(mainDisplay, ref mainDisplayValue, input);
        }
       
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButtonNormalMode_CheckedChanged(object sender, EventArgs e)
        {
            parenthesisLeftButton.Enabled = false;
            parenthesisRightButton.Enabled = false;
            plusMinusButton.Enabled = true;
            Reset();
        }

        private void buttonTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButtonPolandMode_CheckedChanged(object sender, EventArgs e)
        {
            parenthesisLeftButton.Enabled = true;
            parenthesisRightButton.Enabled = true;
            plusMinusButton.Enabled = false;
            Reset();
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
            mainDisplay.Text = mainDisplayValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presNumberButton('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presNumberButton('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            presNumberButton('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            presNumberButton('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            presNumberButton('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            presNumberButton('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            presNumberButton('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            presNumberButton('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            presNumberButton('9');
        }

        private void button0_Click(object sender, EventArgs e)
        {
            presNumberButton('0');
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (radioButtonNormalMode.Checked)
            {
                if (commaInCurrentNumber == false)
                {
                    if (!ChecMainDisplayValue())
                    {
                        mainDisplayValue = "0";
                    }

                    commaInCurrentNumber = true;
                    mainDisplayValue += ',';
                    Show();
                }
            }
            if (radioButtonPolandMode.Checked)
            {
                if (mainDisplayValue == "0")
                {
                    if (commaInCurrentNumber == false)
                    {
                        mainDisplayValue += ",";
                        commaInCurrentNumber = true;
                        Show();
                        Display.DisplayCoursoreShift(mainDisplay, mainDisplayValue);
                    }
                }
                else if (char.IsNumber(mainDisplayValue[mainDisplayValue.Length - 1]))
                {
                    if (commaInCurrentNumber == false)
                    {
                        mainDisplayValue += ',';
                        commaInCurrentNumber = true;
                        Show();
                    }
                }
                else
                {
                    if (commaInCurrentNumber == false)
                    {
                        mainDisplayValue += "0,";
                        commaInCurrentNumber = true;
                        Show();
                    }
                }
                    
            }            
        }
        void actionButton(char action)
        {         
            
            if (radioButtonNormalMode.Checked)
            {
                if (upperDisplayValue == "")
                {
                    upperDisplayValue = mainDisplayValue + action;
                    mainDisplayValue = "0";
                    Show();
                    commaInCurrentNumber = false;
                }
                else
                {
                    OrdinaryCalculate.Calculate(ref mainDisplayValue, ref upperDisplayValue);
                    upperDisplayValue += action;
                    commaInCurrentNumber = false;
                    Show();
                }
            }
            if (radioButtonPolandMode.Checked)
            {
                inputPolandElement(action);
                commaInCurrentNumber = false;               

            }
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            actionButton('+');
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            actionButton('-');
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            actionButton('*');
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            actionButton('/');
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            if (radioButtonNormalMode.Checked)
            {
                OrdinaryCalculate.CalculateSqrt(ref mainDisplayValue);
                if (mainDisplayValue.Contains(','))
                    commaInCurrentNumber = true;
                Show();
            }
            if (radioButtonPolandMode.Checked)
            {

            }
        }

        private void degreeButton_Click(object sender, EventArgs e)
        {
            actionButton('^');
        }


        private void parenthesisLeftButton_Click(object sender, EventArgs e)
        {
            inputPolandElement('(');
            bracketsCounter++;
        }

        private void parenthesisRightButton_Click(object sender, EventArgs e)
        {
            if(bracketsCounter > 0) 
            {
                inputPolandElement(')');
                bracketsCounter--;
            }
        }

        private void upperDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (radioButtonNormalMode.Checked)
            {
                Reset();
            }
            if (radioButtonPolandMode.Checked)
            {
                Reset();
                bracketsCounter = 0;
            }
            
        }

        private void plusMinusButton_Click(object sender, EventArgs e)
        {
            if(mainDisplayValue != "0") 
            { 
                if (mainDisplayValue[0] != '-')
                    mainDisplayValue = '-' + mainDisplayValue;
                else
                    mainDisplayValue = mainDisplayValue.Substring(1);
                mainDisplay.Text = mainDisplayValue;
            }
        }

        private void resultButton_Click(object sender, EventArgs e)
        {

            if (radioButtonNormalMode.Checked)
            {
                if (upperDisplayValue != "")
                {
                    OrdinaryCalculate.Calculate(ref mainDisplayValue, ref upperDisplayValue);

                    UpMoveDown();

                    Show();
                }
            }
            if (radioButtonPolandMode.Checked)
            {

            }


        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            if (radioButtonNormalMode.Checked)
            {
                if (mainDisplayValue != "" && mainDisplayValue != "0")
                {
                    if (!ChecMainDisplayValue())
                    {
                        mainDisplayValue = "0";
                    }
                    else
                    {
                        if (mainDisplayValue.Length == 2 && mainDisplayValue[0] == '-')
                        {
                            mainDisplayValue = "0";
                        }
                        else
                        {
                            if (mainDisplayValue[mainDisplayValue.Length - 1] == ',')
                                commaInCurrentNumber = false;
                            mainDisplayValue = mainDisplayValue.Substring(0, mainDisplayValue.Length - 1);
                            if (mainDisplayValue == "")
                                mainDisplayValue = "0";
                        }
                    }
                    Show();
                }
            }
            if (radioButtonPolandMode.Checked)
            {

            }

        }
    }
}