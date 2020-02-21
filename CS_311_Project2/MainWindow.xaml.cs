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

namespace CS_311_Project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int age = AgeValue(txtAge.Text);
            int RR = RRValue(txtRR.Text);
            int SBP = SBPValue(txtSBP.Text);
            int pulse = PulseValue(txtPulse.Text);
            int pH = Convert.ToInt32(PHValue(txtPH.Text));
            int sodium = SodiumValue(txtSodium.Text);
            int hema = HemaValue(txtHema.Text);

            int intOutput = age + RR + SBP + pulse + pH + sodium + hema;
            txtblkOutput.Text = Convert.ToString(intOutput);
        }

        static int AgeValue(string txtAge)
        {
            int age = Convert.ToInt32(txtAge);
            return age;
        }

        static int RRValue(string txtRR)
        {
            int RR = Convert.ToInt32(txtRR);
            if (RR >= 30)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }

        static int SBPValue(string txtSBP)
        {
            int SBP = Convert.ToInt32(txtSBP);
            if (SBP < 90)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }

        static int PulseValue(string txtPulse)
        {
            int pulse = Convert.ToInt32(txtPulse);
            if (pulse >= 125)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }

        static double PHValue(string txtPH)
        {
            double pH = Convert.ToDouble(txtPH);
            if (pH < 7.35)
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

        static int SodiumValue(string txtSodium)
        {
            int sodium = Convert.ToInt32(txtSodium);
            if (sodium < 130)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }

        static int HemaValue(string txtHema)
        {
            int hema = Convert.ToInt32(txtHema);
            if (hema < 30)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
    }
}
