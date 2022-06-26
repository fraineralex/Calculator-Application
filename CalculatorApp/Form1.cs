using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        //Default propertis of all buttons

        private Rectangle oneButtonDefaultRectangle;
        private Rectangle twoButtonDefaultRectangle;
        private Rectangle threeButtonDefaultRectangle;
        private Rectangle fourButtonDefaultRectangle;
        private Rectangle fiveButtonDefaultRectangle;
        private Rectangle sixButtonDefaultRectangle;
        private Rectangle sevenButtonDefaultRectangle;
        private Rectangle eightButtonDefaultRectangle;
        private Rectangle nineButtonDefaultRectangle;
        private Rectangle zeroButtonDefaultRectangle;
        private Rectangle backSpaceButtonDefaultRectangle;
        private Rectangle plusMinusButtonDefaultRectangle;
        private Rectangle clearButtonDefaultRectangle;
        private Rectangle decimalButtonDefaultRectangle;
        private Rectangle squareRootButtonDefaultRectangle;
        private Rectangle multiplyButtonDefaultRectangle;
        private Rectangle divideButtonDefaultRectangle;
        private Rectangle minusButtonDefaultRectangle;
        private Rectangle equalButtonDefaultRectangle;
        private Rectangle plusButtonDefaultRectangle;
        private Rectangle displayLabelDefaultRectangle;
        private Size defaultFormSize;

        public Calculator()
        {
            InitializeComponent();
        }

    private void Calculator_Load(object sender, EventArgs e)
        {
            // Setting button property values

            defaultFormSize = this.Size;
            oneButtonDefaultRectangle = new Rectangle(oneButton.Location.X, oneButton.Location.Y, oneButton.Width, oneButton.Height);
            twoButtonDefaultRectangle = new Rectangle(twoButton.Location.X, twoButton.Location.Y, twoButton.Width, twoButton.Height);
            threeButtonDefaultRectangle = new Rectangle(threeButton.Location.X, threeButton.Location.Y, threeButton.Width, threeButton.Height);
            fourButtonDefaultRectangle = new Rectangle(fourButton.Location.X, fourButton.Location.Y, fourButton.Width, fourButton.Height);
            fiveButtonDefaultRectangle = new Rectangle(fiveButton.Location.X, fiveButton.Location.Y, fiveButton.Width, fiveButton.Height);
            sixButtonDefaultRectangle = new Rectangle(sixButton.Location.X, sixButton.Location.Y, sixButton.Width, sixButton.Height);
            sevenButtonDefaultRectangle = new Rectangle(sevenButton.Location.X, sevenButton.Location.Y, sevenButton.Width, sevenButton.Height);
            eightButtonDefaultRectangle = new Rectangle(eightButton.Location.X, eightButton.Location.Y, eightButton.Width, eightButton.Height);
            nineButtonDefaultRectangle = new Rectangle(nineButton.Location.X, nineButton.Location.Y, nineButton.Width, nineButton.Height);
            zeroButtonDefaultRectangle = new Rectangle(zeroButton.Location.X, zeroButton.Location.Y, zeroButton.Width, zeroButton.Height);
            backSpaceButtonDefaultRectangle = new Rectangle(backSpaceButton.Location.X, backSpaceButton.Location.Y, backSpaceButton.Width, backSpaceButton.Height);
            plusMinusButtonDefaultRectangle = new Rectangle(plusMinusButton.Location.X, plusMinusButton.Location.Y, plusMinusButton.Width, plusMinusButton.Height);
            clearButtonDefaultRectangle = new Rectangle(clearButton.Location.X, clearButton.Location.Y, clearButton.Width, clearButton.Height);
            decimalButtonDefaultRectangle = new Rectangle(decimalButton.Location.X, decimalButton.Location.Y, decimalButton.Width, decimalButton.Height);
            squareRootButtonDefaultRectangle = new Rectangle(squareRootButton.Location.X, squareRootButton.Location.Y, squareRootButton.Width, squareRootButton.Height);
            multiplyButtonDefaultRectangle = new Rectangle(multiplyButton.Location.X, multiplyButton.Location.Y, multiplyButton.Width, multiplyButton.Height);
            divideButtonDefaultRectangle = new Rectangle(divideButton.Location.X, divideButton.Location.Y, divideButton.Width, divideButton.Height);
            minusButtonDefaultRectangle = new Rectangle(minusButton.Location.X, minusButton.Location.Y, minusButton.Width, minusButton.Height);
            equalButtonDefaultRectangle = new Rectangle(equalButton.Location.X, equalButton.Location.Y, equalButton.Width, equalButton.Height);
            plusButtonDefaultRectangle = new Rectangle(plusButton.Location.X, plusButton.Location.Y, plusButton.Width, plusButton.Height);
            displayLabelDefaultRectangle = new Rectangle(displayLabel.Location.X, displayLabel.Location.Y, displayLabel.Width, displayLabel.Height);


        }

        private void Calculator_Resize(object sender, EventArgs e)
        {
            // Sending properties and buttons to the method 'resizeControl'

            resizeControl(oneButtonDefaultRectangle, oneButton);
            resizeControl(twoButtonDefaultRectangle, twoButton);
            resizeControl(threeButtonDefaultRectangle, threeButton);
            resizeControl(fourButtonDefaultRectangle, fourButton);
            resizeControl(fiveButtonDefaultRectangle, fiveButton);
            resizeControl(sixButtonDefaultRectangle, sixButton);
            resizeControl(sevenButtonDefaultRectangle, sevenButton);
            resizeControl(eightButtonDefaultRectangle, eightButton);
            resizeControl(nineButtonDefaultRectangle, nineButton);
            resizeControl(zeroButtonDefaultRectangle, zeroButton);
            resizeControl(backSpaceButtonDefaultRectangle, backSpaceButton);
            resizeControl(plusMinusButtonDefaultRectangle, plusMinusButton);
            resizeControl(clearButtonDefaultRectangle, clearButton);
            resizeControl(decimalButtonDefaultRectangle, decimalButton);
            resizeControl(squareRootButtonDefaultRectangle, squareRootButton);
            resizeControl(multiplyButtonDefaultRectangle, multiplyButton);
            resizeControl(divideButtonDefaultRectangle, divideButton);
            resizeControl(minusButtonDefaultRectangle, minusButton);
            resizeControl(equalButtonDefaultRectangle, equalButton);
            resizeControl(plusButtonDefaultRectangle, plusButton);
            resizeControl(displayLabelDefaultRectangle, displayLabel);
        }

        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            // Method that resizes all objects

            float xAxis = (float)(this.Width) / (float)(defaultFormSize.Width);
            float yAxis = (float)(this.Height) / (float)(defaultFormSize.Height);

            int newXPosition = (int)(OriginalControlRect.X * xAxis);
            int newYPosition = (int)(OriginalControlRect.Y * yAxis);

            int newWidth = (int)(OriginalControlRect.Width * xAxis);
            int newHeight = (int)(OriginalControlRect.Height * yAxis);

            control.Location = new Point(newXPosition, newYPosition);
            control.Size = new Size(newWidth, newHeight);
        }

        // Vars of the calculator
        float num1, num2, result;
        char operation;
        bool dec = false;

        // Displaying the changes in the label
        private void deployLabel(int numPressed)
        {
            if (dec == true)
            {
                int decimalCount = 0;
                foreach (char c in displayLabel.Text)
                {
                    if (c == '.')
                    {
                        decimalCount++;
                    }
                }
                if (decimalCount < 1)
                {
                    displayLabel.Text = displayLabel.Text + ".";
                }
                dec = false;
            }
            else
            {
                if ((displayLabel.Text.Equals("0") == true && displayLabel.Text != null))
                {
                    displayLabel.Text = numPressed.ToString();
                }
                else if (displayLabel.Text.Equals("-0") == true)
                {
                    displayLabel.Text = "-" + numPressed.ToString();
                }
                else
                {
                    displayLabel.Text = displayLabel.Text + numPressed.ToString();
                }
            }

            if (equalButton.Focused != true)
            {
                equalButton.Focus();
            }
        }

        // Buttons values to deployLabel
        private void zeroButton_Click(object sender, EventArgs e)
        {
            deployLabel(0);
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            deployLabel(1);
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            deployLabel(2);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            deployLabel(3);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            deployLabel(4);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            deployLabel(5);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            deployLabel(6);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            deployLabel(7);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            deployLabel(8);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            deployLabel(9);
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            dec = true;
            deployLabel(0);
        }

        private void plusMinusButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = "-" + displayLabel.Text;
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            if (num1 > 0)
            {
                double sqrt = Math.Sqrt(num1);
                displayLabel.Text = sqrt.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = "0";
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = '\0';
            dec = false;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '*';
            displayLabel.Text = "";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '/';
            displayLabel.Text = "";
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '-';
            displayLabel.Text = "";
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '+';
            result = result + num1;
            displayLabel.Text = "";
        }

        // Method to receive keyboard input
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    oneButton.PerformClick();
                    break;
                case Keys.D1:
                    oneButton.PerformClick();
                    break;
                case Keys.NumPad2:
                    twoButton.PerformClick();
                    break;
                case Keys.D2:
                    twoButton.PerformClick();
                    break;
                case Keys.NumPad3:
                    threeButton.PerformClick();
                    break;
                case Keys.D3:
                    threeButton.PerformClick();
                    break;
                case Keys.NumPad4:
                    fourButton.PerformClick();
                    break;
                case Keys.D4:
                    fourButton.PerformClick();
                    break;
                case Keys.NumPad5:
                    fiveButton.PerformClick();
                    break;
                case Keys.D5:
                    fiveButton.PerformClick();
                    break;
                case Keys.NumPad6:
                    sixButton.PerformClick();
                    break;
                case Keys.D6:
                    sixButton.PerformClick();
                    break;
                case Keys.NumPad7:
                    sevenButton.PerformClick();
                    break;
                case Keys.D7:
                    sevenButton.PerformClick();
                    break;
                case Keys.NumPad8:
                    eightButton.PerformClick();
                    break;
                case Keys.D8:
                    eightButton.PerformClick();
                    break;
                case Keys.NumPad9:
                    nineButton.PerformClick();
                    break;
                case Keys.D9:
                    nineButton.PerformClick();
                    break;
                case Keys.Divide:
                    divideButton.PerformClick();
                    break;
                case Keys.Subtract:
                    minusButton.PerformClick();
                    break;
                case Keys.Add:
                    plusButton.PerformClick();
                    break;
                case Keys.Multiply:
                    multiplyButton.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            result = 0;
            if (displayLabel.Text.Equals("0") == false)
            {
                switch (operation)
                {
                    case '+':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 + num2;
                        break;
                    case '-':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 - num2;
                        break;
                    case '/':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 / num2;
                        break;
                    case '*':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 * num2;
                        break;
                    default:
                        break;
                }
            }
            displayLabel.Text = result.ToString();
        }

        private void backSpaceButton_Click(object sender, EventArgs e)
        {
            int stringLength = displayLabel.Text.Length;
            if (stringLength > 1)
            {
                displayLabel.Text = displayLabel.Text.Substring(0, stringLength - 1);
            }
            else
            {
                displayLabel.Text = "0";
            }
        }

    }


}
