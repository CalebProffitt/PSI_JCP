﻿using System;
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
            int sex = SexValue(rdoMale);
            int temp = TempValue(rdoCelcius, txtTemp.Text);
            int BUN = BUNValue(rdoBUNmg_dL, txtBUN.Text);
            int glucose = GlucoseValue(rdoGLUCOSEmg_dL, txtGlucose.Text);
            int PPO = PPOValue(rdoPPOmmHg, txtPPO.Text);


            int intOutput = age + sex + RR + SBP + temp + pulse + pH + BUN + sodium + glucose + hema + PPO;

            if (intOutput == 0)
            {
                MessageBox.Show("Class 1: Recommend outpatient care");
            }
            else if (intOutput <= 70)
            {
                MessageBox.Show("Class 2: Recommend outpatient care");
            }
            else if (intOutput >= 71 && intOutput <= 90)
            {
                MessageBox.Show("Class 3: Recommend outpatient or observation admission");
            }
            else if (intOutput >= 91 && intOutput <= 130)
            {
                MessageBox.Show("Class 4: Recommend inpatient admission");
            }
            else if (intOutput > 130)
            {
                MessageBox.Show("Class 5: Recommend inpatient admission (check for sepsis");
            }
            else
            {
                MessageBox.Show("Data error");
            }

            txtblkOutput.Text = "Total calculated PSI number: " + Convert.ToString(intOutput);
        }

        static int AgeValue(string txtAge)
        {
            int age = Convert.ToInt32(txtAge);
            return age;
        }

        static int SexValue(RadioButton rdoMale)
        {
            if (rdoMale.IsChecked == true)
            {
                return 0;
            }
            else
            {
                return -10;
            }
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

        static int TempValue(RadioButton rdoCelcius, string txtTemp)
        {
            int tempVal = Convert.ToInt32(txtTemp);
            if (rdoCelcius.IsChecked == true && (tempVal < 35 || tempVal > 39.9))
            {
                return 15;
            }
            else if (rdoCelcius.IsChecked == false && (tempVal < 95 || tempVal > 103.8))
            {
                return 15;
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

        static int BUNValue(RadioButton rdoBUNmg_dL, string txtBUN)
        {
            int BUNVal = Convert.ToInt32(txtBUN);
            if (rdoBUNmg_dL.IsChecked == true && BUNVal >= 30)
            {
                return 20;
            }
            else if (rdoBUNmg_dL.IsChecked == false && BUNVal >= 11)
            {
                return 20;
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

        static int GlucoseValue(RadioButton rdoGLUCOSEmg_dL, string txtGlucose)
        {
            int GlucoseVal = Convert.ToInt32(txtGlucose);
            if (rdoGLUCOSEmg_dL.IsChecked == true && GlucoseVal >= 250)
            {
                return 10;
            }
            else if (rdoGLUCOSEmg_dL.IsChecked == false && GlucoseVal >= 14)
            {
                return 10;
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

        static int PPOValue(RadioButton rdoPPOmmHg, string txtPPO)
        {
            int PPOVal = Convert.ToInt32(txtPPO);
            if (rdoPPOmmHg.IsChecked == true && PPOVal < 60)
            {
                return 10;
            }
            else if (rdoPPOmmHg.IsChecked == false && PPOVal < 8)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }

        private void cbNHR_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void cbND_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbLD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbCHF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbCD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbRD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbAMS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbPE_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
