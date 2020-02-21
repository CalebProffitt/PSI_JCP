using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using CsvHelper;

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
            //collect and store input data

            //base
            int age = AgeValue(txtAge.Text);
            int RR = RRValue(txtRR.Text);
            int SBP = SBPValue(txtSBP.Text);
            int pulse = PulseValue(txtPulse.Text);
            int pH = Convert.ToInt32(PHValue(txtPH.Text));
            int sodium = SodiumValue(txtSodium.Text);
            int hema = HemaValue(txtHema.Text);
            //radio buttons
            int sex = SexValue(rdoMale);
            int temp = TempValue(rdoCelcius, txtTemp.Text);
            int BUN = BUNValue(rdoBUNmg_dL, txtBUN.Text);
            int glucose = GlucoseValue(rdoGLUCOSEmg_dL, txtGlucose.Text);
            int PPO = PPOValue(rdoPPOmmHg, txtPPO.Text);
            //checkboxes
            int NHR = NHRValue(cbNHR);
            int ND = NDValue(cbND);
            int LD = LDValue(cbLD);
            int CHF = CHFValue(cbCHF);
            int CD = CDValue(cbCD);
            int RD = RDValue(cbRD);
            int AMS = AMSValue(cbAMS);
            int PE = PEValue(cbPE);

            //calculate total PSI number
            int intOutput = age + sex + RR + SBP + temp + pulse + pH + BUN + sodium + glucose + hema + PPO + NHR + ND + LD + CHF + CD + RD + AMS + PE;

            //determine the class level
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
                MessageBox.Show("Class 5: Recommend inpatient admission (check for sepsis)");
            }
            else
            {
                MessageBox.Show("Data error");
            }

            txtblkOutput.Text = "Total calculated PSI number: " + Convert.ToString(intOutput);

            //write data to csv
            //I couldn't get .\ or C: to work so I just used my desktop. This bit will have to be edited for the file to appear
            string strFilePath = @"C:\Users\caleb\Desktop\data.csv"; 
            string strSeperator = ",";
            StringBuilder sbOutput = new StringBuilder();

            string[][] inaOutput = new string[][]{
            new string[]{txtAge.Text, txtSex.Text, txtRR.Text, txtSBP.Text, txtTemp.Text, txtPulse.Text, txtPH.Text, txtBUN.Text, txtSodium.Text, txtGlucose.Text, txtHema.Text, txtPPO.Text},
            };
            int ilength = inaOutput.GetLength(0);
            for (int i = 0; i < ilength; i++)
            sbOutput.AppendLine(string.Join(strSeperator, inaOutput[i]));

            // Create and write the csv file
            File.WriteAllText(strFilePath, sbOutput.ToString());

            //methods for basic and radio button
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

            //methods for checkboxes
            static int NHRValue(CheckBox cbNHR)
            {
                if (cbNHR.IsChecked == true)
                {
                    return 10;
                }
                else
                {
                    return 0;
                }
            }

            static int NDValue(CheckBox cbND)
            {
                if (cbND.IsChecked == true)
                {
                    return 30;
                }
                else
                {
                    return 0;
                }
            }

            static int LDValue(CheckBox cbLD)
            {
                if (cbLD.IsChecked == true)
                {
                    return 20;
                }
                else
                {
                    return 0;
                }
            }

            static int CHFValue(CheckBox cbCHF)
            {
                if (cbCHF.IsChecked == true)
                {
                    return 10;
                }
                else
                {
                    return 0;
                }
            }

            static int CDValue(CheckBox cbCD)
            {
                if (cbCD.IsChecked == true)
                {
                    return 10;
                }
                else
                {
                    return 0;
                }
            }

            static int RDValue(CheckBox cbRD)
            {
                if (cbRD.IsChecked == true)
                {
                    return 10;
                }
                else
                {
                    return 0;
                }
            }

            static int AMSValue(CheckBox cbAMS)
            {
                if (cbAMS.IsChecked == true)
                {
                    return 20;
                }
                else
                {
                    return 0;
                }
            }

            static int PEValue(CheckBox cbPE)
            {
                if (cbPE.IsChecked == true)
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
}