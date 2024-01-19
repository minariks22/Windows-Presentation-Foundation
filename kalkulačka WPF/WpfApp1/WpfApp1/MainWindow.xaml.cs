using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Klik(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string buttonContent = clickedButton.Content.ToString();

                switch (buttonContent)
                {
                    case "=":
                        EvaluateExpression();
                        break;
                    case "1/x":
                        // Inverzní hodnota
                        CalculateInverse();
                        break;
                    case "x2":
                        // Druhá mocnina
                        CalculateSquare();
                        break;
                    case "2√x":
                        // Odmocnina
                        CalculateSquareRoot();
                        break;
                    case "+/-":
                        ChangeSign();
                        break;
                    case "%":
                        ApplyPercentage();
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        AppendOperator(buttonContent);
                        break;
                    case ",":
                        AppendDecimalSeparator();
                        break;
                    case "C":
                        ClearContent();
                        break;
                    case "CE":
                        ClearContent();
                        break;
                    case "<--":
                        Backspace();
                        break;
                    default:
                        xd.Content += buttonContent;
                        break;
                }
            }
        }

        private void EvaluateExpression()
        {
            try
            {
            
                xd.Content = Evaluate(xd.Content.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vyhodnocování výrazu: " + ex.Message);
            }
        }

        private void CalculateInverse()
        {
 
            if (double.TryParse(xd.Content.ToString(), out double currentValue))
            {
                xd.Content = (1 / currentValue).ToString();
            }
        }

        private void CalculateSquare()
        {
          
            if (double.TryParse(xd.Content.ToString(), out double currentValue))
            {
                xd.Content = (currentValue * currentValue).ToString();
            }
        }

        private void Backspace()
        {
            if (xd.Content.ToString().Length > 0)
            {
                // Odstraní poslední znak
                xd.Content = xd.Content.ToString().Substring(0, xd.Content.ToString().Length - 1);
            }
        }

        private void CalculateSquareRoot()
        {

            if (double.TryParse(xd.Content.ToString(), out double currentValue))
            {
                xd.Content = Math.Sqrt(currentValue).ToString();
            }
        }

        private void AppendDecimalSeparator()
        {
            // Zkontroluje, zda výraz již neobsahuje desetinný oddělovač
            if (!xd.Content.ToString().Contains("."))
            {
                // Pokud neobsahuje, přidá čárku
                xd.Content += ".";
            }
        }

            private void ChangeSign()
        {
            if (double.TryParse(xd.Content.ToString(), out double currentValue))
            {
                xd.Content = (-currentValue).ToString();
            }
        }

        private void ApplyPercentage()
        {
            if (double.TryParse(xd.Content.ToString(), out double currentValue))
            {
                xd.Content = (currentValue / 100).ToString();
            }
        }

        private void AppendOperator(string operatorSymbol)
        {
            // Přidá operátor k obsahu labelu
            xd.Content += operatorSymbol;
        }

        private void ClearContent()
        {
            // Vymaže obsah labelu
            xd.Content = string.Empty;
        }

        private string Evaluate(string expression)
        {
            try
            {
                // Nahradí čárky tečkami, aby bylo možné správně vyhodnotit výraz
                expression = expression.Replace(",", ".");

                DataTable table = new DataTable();
                return Convert.ToDouble(table.Compute(expression, string.Empty)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vyhodnocování výrazu: " + ex.Message);
                return "Chyba";
            }
        }
    }
}
