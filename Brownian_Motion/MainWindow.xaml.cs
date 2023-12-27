using ScottPlot;
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

namespace BrownianMotion
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int UserInput;
        float x, y, s, fi;
        string pointNumber;
        double[] dataX;
        double[] dataY;
        string[] label;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateBtn(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            float PI = 3.14159f;
            int NumberOfMoves = UserInput;
            x = 0; y = 0;


            for (int i = 0; i < NumberOfMoves; i++)
            {
                fi = (float)(rnd.NextDouble() * 2 * PI);
                x = x + (float)Math.Sin(fi);
                y = y + (float)Math.Cos(fi);

                label = new string[] { i.ToString() };
                dataX = new double[] { x };
                dataY = new double[] { y };

                NewPlot.Plot.AddScatter(dataX, dataY).DataPointLabels = label;
                NewPlot.Refresh();
            }
            s = (float)Math.Sqrt(x * x + y * y);

            ErrorMsg.Text = "";
            S_Val.Text = "The particle has \n moved a distance: " + s;
            CalculateButton.IsEnabled = false;
        }

        private void SaveInput(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInput = int.Parse(UserInputTxt.Text);
            }

            catch (Exception)
            {
                ErrorMsg.Text = "Pass an integer!";
            }
     
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = true;
            S_Val.Text = "";
            UserInputTxt.Text = "";
            x = 0;
            y = 0;
            dataX = new double[] { 0 };
            dataY = new double[] { 0 };
            fi = 0;
            NewPlot.Plot.Clear();
        }
    }
}
