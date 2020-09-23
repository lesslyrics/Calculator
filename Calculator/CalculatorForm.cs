using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private string _input = ""; 

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void ButtonOneClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "1";
                _input = "1";
            }
            else
            {
                textboxResult.Text += "1";
                _input += "1";
            }
        }
        
        private void ButtonTwoClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "2";
                _input = "2";
            }
            else
            {
                textboxResult.Text += "2";
                _input += "2";
            }
        }

        private void ButtonThreeClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "3";
                _input = "3";
            }
            else
            {
                textboxResult.Text += "3";
                _input += "3";
            }
        }
        
        private void ButtonFourClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "4";
                _input = "4";
            }
            else
            {
                textboxResult.Text += "4";
                _input += "4";
            }
        }
        
        private void ButtonFiveClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "5";
                _input = "5";
            }
            else
            {
                textboxResult.Text += "5";
                _input += "5";
            }
        }
        
        private void ButtonSixClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "6";
                _input = "6";
            }
            else
            {
                textboxResult.Text += "6";
                _input += "6";
            }
        }

        private void ButtonSevenClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "7";
                _input = "7";
            }
            else
            {
                textboxResult.Text += "7";
                _input += "7";
            }
        }

        private void ButtonEightClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "8";
                _input = "8";
            }
            else
            {
                textboxResult.Text += "8";
                _input += "8";
            }
        }


        private void ButtonNineClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "9";
                _input = "9";
            }
            else
            {
                textboxResult.Text += "9";
                _input += "9";
            }
        }

        
        private void ButtonZeroClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text != "0" && textboxResult.Text != null)
            {
                textboxResult.Text += "0";
                _input += "0";
            }
            if(textboxResult.Text == "0")
            {
                _input = "0";
            }
        }

        private void ButtonDivideClickAction(object sender, EventArgs e)
        {
            if (_input != ""  && textboxResult.Text != null)
            {
                textboxResult.Text += "/";
                _input += "/";
            }
        }

        private void ButtonStarClickAction(object sender, EventArgs e)
        {
            if (_input != "" && textboxResult.Text != null)
            {
                textboxResult.Text += "*";
                _input += "*";
            }
        }

        private void ButtonMinusClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "-";
                _input = "-";
            }
            else
            {
                textboxResult.Text += "-";
                _input += "-";
            }
        }

        private void ButtonPlusClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text != "0" && textboxResult.Text != null)
            {
                textboxResult.Text += "+";
                _input += "+";
            }
        }

        private void ButtonLeftBrClickAction(object sender, EventArgs e)
        {
            if (textboxResult.Text == "0" && textboxResult.Text != null || _input == "")
            {
                textboxResult.Text = "(";
                _input = "(";
            }
            else
            {
                textboxResult.Text += "(";
                _input += "(";
            }
        }

        private void ButtonRigttBrClickAction(object sender, EventArgs e)
        {
            if (_input != "" && textboxResult.Text != null)
            {
                textboxResult.Text += ")";
                _input += ")";
            }
        }


        private void ButtonEqualClickAction(object sender, EventArgs e)
        {
            CalculatorTask task = new CalculatorTask();
            string[] notation = task.FormatToPostfix(_input);
            string result = CalculatorTask.Calculate(notation);
            showResultLabel.Text = _input + " = " + result;
            textboxResult.Text = "0";
            _input = "";
        }

        private void ButtonCClickAction(object sender, EventArgs e)
        {
            textboxResult.Text = "0";
            _input = "";
        }

        private void ButtonDelClickAction(object sender, EventArgs e)
        {
            if (_input.Length == 0 || _input.Length == 1)
            {
                textboxResult.Text = "0";
                _input = "";
            }
            else
            {
                textboxResult.Text = _input.Remove(_input.Length - 1);
                _input = _input.Remove(_input.Length - 1);
            }
        }
    }
}

