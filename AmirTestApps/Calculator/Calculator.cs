using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string input = string.Empty;
        string oprand1 = string.Empty;
        string oprand2 = string.Empty;
        char operation;
        double result = 0.0;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Allow the form to capture keyboard input
            this.textBox1.KeyDown += new KeyEventHandler(txtDisplay_KeyDown);  // Make sure this is attached
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Number(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += (sender as Button).Text;
            this.textBox1.Text+=input;
        }

        //private void dot(object sender, EventArgs e)
        //{

        //}

        private void C(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.input = string.Empty;
            this.oprand1 = string.Empty;
            this.oprand2 = string.Empty;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            oprand1 = input;
            operation = (sender as Button).Text[0];
            input = string.Empty;
        }

        //private void one(object sender, EventArgs e)
        //{

        //}

        //private void two(object sender, EventArgs e)
        //{

        //}

        //private void three(object sender, EventArgs e)
        //{

        //}

        //private void four(object sender, EventArgs e)
        //{

        //}

        //private void five(object sender, EventArgs e)
        //{

        //}

        //private void six(object sender, EventArgs e)
        //{

        //}

        //private void seven(object sender, EventArgs e)
        //{

        //}

        //private void eight(object sender, EventArgs e)
        //{

        //}

        //private void nine(object sender, EventArgs e)
        //{

        //}

        //private void multi(object sender, EventArgs e)
        //{

        //}

        //private void division(object sender, EventArgs e)
        //{

        //}

        //private void minus(object sender, EventArgs e)
        //{

        //}

        private void openParenthesis(object sender, EventArgs e)
        {
            // Add '(' to the input string
            input += "(";
            textBox1.Text = input;
        }

        private void closeParenthesis(object sender, EventArgs e)
        {
            // Add ')' to the input string
            input += ")";
            textBox1.Text = input;
        }

        private void sin(object sender, EventArgs e)
        {
            double angle = double.Parse(textBox1.Text);

            // Convert degrees to radians (Math.Sin expects radians)
            double radians = angle * Math.PI / 180;
            double result = Math.Sin(radians);

            textBox1.Text = result.ToString();
        }

        private void cos(object sender, EventArgs e)
        {
            double angle = double.Parse(textBox1.Text);

            // Convert degrees to radians (Math.Cos expects radians)
            double radians = angle * Math.PI / 180;
            double result = Math.Cos(radians);

            textBox1.Text = result.ToString();
        }

        private void tan(object sender, EventArgs e)
        {
            try
            {
                double angle = double.Parse(textBox1.Text); // Get the value from the TextBox

                // Convert the angle from degrees to radians
                double radians = angle * Math.PI / 180;

                // Calculate the tangent of the angle
                double result = Math.Tan(radians);

                // Display the result in the TextBox
                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cot(object sender, EventArgs e)
        {
            try
            {
                double angle = double.Parse(textBox1.Text); // Get the value from the TextBox

                // Convert the angle from degrees to radians
                double radians = angle * Math.PI / 180;

                // Calculate the tangent of the angle
                double tanResult = Math.Tan(radians);

                // Check if tan(x) is near 0 (i.e., undefined for cot(x))
                if (Math.Abs(tanResult) < 1e-10) // Epsilon for small values close to zero
                {
                    textBox1.Text = "Undefined"; // Display "Undefined" when cot(x) is undefined
                }
                else
                {
                    // Calculate cotangent (1 / tan(x))
                    double result = 1 / tanResult;
                    textBox1.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void equals(object sender, EventArgs e)
        {
            oprand2 = input;
            double num1, num2;
            double.TryParse(oprand1, out num1);
            double.TryParse(oprand2, out num2);
            this.textBox1.Text="";
            this.input = String.Empty;
            this.oprand1 = string.Empty;
            this.oprand2 = string.Empty;

            if (operation == '+')
            {
                result = num1 + num2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = num1 - num2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (num2 !=0)
                {
                    result = num1 /num2;
                    textBox1.Text = result.ToString();
                }
                else
                {
                    textBox1.Text = "DIV/Zero!";
                }
            }
            else if (operation == '*')
            {
                result = num1 * num2;
                textBox1.Text = result.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, operators (+, -, *, /), and the decimal point
            if (char.IsDigit(e.KeyChar) || "+-*/().".Contains(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Back)
            {
                // Allow these keys (backspace is handled by default)
                e.Handled = false;
            }
            else
            {
                // Block other characters
                e.Handled = true;
            }
        }

        private void txtDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            // If the Enter key is pressed, we evaluate the expression
            if (e.KeyCode == Keys.Enter)
            {
                // Get the expression from the TextBox
                string expression = textBox1.Text;

                // Sanitize (remove spaces) from the expression
                expression = expression.Replace(" ", "");

                try
                {
                    // Try to evaluate the expression
                    var result = EvaluateExpression(expression);

                    // Show the result in the TextBox
                    textBox1.Text = result.ToString();
                }
                catch (InvalidOperationException ex)
                {
                    // If there's an error (e.g., invalid expression), show a detailed error message
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Check if the "C" key is pressed (to clear the TextBox)
                if (e.KeyCode == Keys.C)
                {
                    // Clear the TextBox when "C" is pressed
                    textBox1.Clear();
                }

                // Check if Backspace key is pressed to remove the last character
                if (e.KeyCode == Keys.Back)
                {
                    if (textBox1.Text.Length > 0)
                    {
                        // Remove last character in TextBox
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    }
                }
            }
        }

        public object EvaluateExpression(string expression)
        {
            // 1. Check if the expression contains only valid characters (digits, operators, and parentheses).
            foreach (char c in expression)
            {
                if (!char.IsDigit(c) && !"+-*/().".Contains(c.ToString()))  // Valid characters: digits, operators, and parentheses
                {
                    throw new InvalidOperationException("The expression contains invalid characters.");
                }
            }

            // 2. Create a new DataTable instance to compute the expression
            DataTable table = new DataTable();

            try
            {
                // 3. Use DataTable.Compute to evaluate the expression
                return table.Compute(expression, string.Empty);
            }
            catch (Exception ex)
            {
                // 4. If an error occurs during evaluation, throw an exception
                throw new InvalidOperationException("Error in evaluating the expression: " + ex.Message);
            }
        }
    }
}
