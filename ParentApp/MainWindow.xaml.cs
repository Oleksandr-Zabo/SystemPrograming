using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ParentApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartChildProcess(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get user input
                string number1 = Number1TextBox.Text;
                string number2 = Number2TextBox.Text;
                string operation = OperationTextBox.Text;

                // Validate input
                if (string.IsNullOrWhiteSpace(number1) || string.IsNullOrWhiteSpace(number2) || string.IsNullOrWhiteSpace(operation))
                {
                    MessageBox.Show("Please provide valid input for both numbers and the operation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Parse numbers
                if (!double.TryParse(number1, out double num1) || !double.TryParse(number2, out double num2))
                {
                    MessageBox.Show("Please enter valid numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Perform operation
                double result = 0;
                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            MessageBox.Show("Division by zero is not allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid operation. Please use +, -, *, or /.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                // Write to a temporary file
                string tempFilePath = Path.Combine(Path.GetTempPath(), "CalculationResult.txt");
                string content = $"Number 1: {num1}\nNumber 2: {num2}\nOperation: {operation}\nResult: {result}";
                File.WriteAllText(tempFilePath, content);

                // Launch Notepad to display the file
                Process.Start("notepad.exe", tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
