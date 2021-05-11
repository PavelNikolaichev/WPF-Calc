using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{ 
    public partial class MainWindow : Window
    {
        private double num1 = 0, num2 = 0;
        private string operand = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNum(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();
            if (inputOutputField.Text == "0")
                inputOutputField.Text = num;
            else
                inputOutputField.Text += num;

            if (operand == "")
            {
                num1 = double.Parse(inputOutputField.Text);
            }
            else
            {
                num2 = double.Parse(inputOutputField.Text);
            }
        }

        private void ChangeOperation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operand = button.Content.ToString();
            inputOutputField.Text = "0";
        }

        private void Equal(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (operand)
            {
                case "%": result = num1 * (num2 / 100); break;
                case "/": result = num1 / num2; break;
                case "*": result = num1 * num2; break;
                case "-": result = num1 - num2; break;
                case "+": result = num1 + num2; break;
            }
            num1 = result;
            operand = "";
            num2 = 0;
            inputOutputField.Text = num1.ToString();
        }

        private void ConvertToDouble(object sender, RoutedEventArgs e)
        {
            if (operand == "")
                SetComma(num1);
            else
                SetComma(num2);
        }

        private void SetComma(double num)
        {
            if (!inputOutputField.Text.Contains('.'))
                inputOutputField.Text += '.';
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operand = "";
            inputOutputField.Text = num1.ToString();
        }
    }
}
