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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int num1 = 0, num2 = 0;
        private string operand = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNum(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int input = int.Parse(button.Content.ToString());
            if (operand == "")
            {
                num1 = num1 * 10 + input;
                inputOutputField.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + input;
                inputOutputField.Text = num2.ToString();
            }
        }

        private void ChangeOperation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string input = button.Content.ToString();
            operand = input;
        }

        private void Equal(object sender, RoutedEventArgs e)
        {
            int result = 0;
            switch (operand)
            {
                //TODO: Make percent great again
                case "%": result = num1 + num2; break;
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

        private void Clear(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operand = "";
            inputOutputField.Text = num1.ToString();
        }
    }
}
