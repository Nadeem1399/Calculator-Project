using System;
using System.Windows;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PerformOperation(Func<double, double, double> operation)
        {
            double operand1, operand2;

            // Check if input is valid
            if (!double.TryParse(operand1TextBox.Text, out operand1) ||
                !double.TryParse(operand2TextBox.Text, out operand2))
            {
                resultLabel.Content = "Invalid input";
                return;
            }

            // Perform the operation
            try
            {
                double result = operation(operand1, operand2);
                resultLabel.Content = "Result: " + result.ToString();
            }
            catch (DivideByZeroException)
            {
                resultLabel.Content = "Division by zero";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((a, b) => a + b);
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((a, b) => a - b);
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((a, b) => a * b);
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((a, b) =>
            {
                if (b == 0)
                    throw new DivideByZeroException();
                return a / b;
            });
        }
    }
}
