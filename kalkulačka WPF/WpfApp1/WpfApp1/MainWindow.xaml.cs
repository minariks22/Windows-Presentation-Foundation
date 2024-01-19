using System;
using System.Collections.Generic;
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

        private void CalculateSquareRoot()
        {

            if (double.TryParse(xd.Content.ToString(), out double currentValue))
            {
                xd.Content = Math.Sqrt(currentValue).ToString();
            }
        }

        private string Evaluate(string expression)
        {

            return "Implementujte vyhodnocení výrazu";
        }
    }
}
