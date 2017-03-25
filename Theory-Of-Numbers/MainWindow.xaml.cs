using System;
using System.Collections.Generic;
using System.Data;
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

namespace TheoryOfNumbers
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool validationGGT = true;
        private bool validationKGV = true;
        private bool validationPrime = true;
        private bool validationPhi = true;
        private bool validationEEA = true;
        private bool validationPrimeFactorization = true;
        private bool afterInitialize = false;

        public bool ValidationGGT
        {
            get
            {
                return validationGGT;
            }
            set
            {
                validationGGT = value;
                this.lblValidationGGT.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
            }
        }

        public bool ValidationKGV
        {
            get
            {
                return validationKGV;
            }
            set
            {
                validationKGV = value;
                this.lblValidationKGV.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
            }
        }

        public bool ValidationPrime
        {
            get
            {
                return validationPrime;
            }
            set
            {
                validationPrime = value;
                this.lblValidationPrime.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
            }
        }

        public bool ValidationPhi
        {
            get
            {
                return validationPhi;
            }
            set
            {
                validationPhi = value;
                this.lblValidationPhi.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
            }
        }

        public bool ValidationPrimeFactorization
        {
            get
            {
                return this.validationPrimeFactorization;
            }
            set
            {
                this.validationPrimeFactorization = value;
                this.lblValidationPrimeFactorization.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
            }
        }

        public bool ValidationEEA
        {
            get
            {
                return this.validationEEA;
            }
            set
            {
                this.validationEEA = value;
                this.lblValidationEEA.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            afterInitialize = true;
        }

        private void btnCalculateGGT_Click(object sender, RoutedEventArgs e)
        {
            if (validationGGT)
                this.txtGGTResult.Text = MathAlgorithms.GGT(int.Parse(this.txtGGTa.Text), int.Parse(this.txtGGTb.Text)).ToString();
            else
                this.txtGGTResult.Text = string.Empty;
        }

        private void txtGGTa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!afterInitialize)
                return;

            // Do validation of ggT(a, b)
            // Event is called by both textboxes!
            int p1 = -1, p2 = -1;

            if (int.TryParse(this.txtGGTa.Text, out p1) && int.TryParse(this.txtGGTb.Text, out p2))
                ValidationGGT = (p1 > 0 && p2 > 0);
            else
                ValidationGGT = false;
        }

        private void txtKGVa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!afterInitialize)
                return;

            // Do validation of ggT(a, b)
            // Event is called by both textboxes!
            int p1 = -1, p2 = -1;

            if (int.TryParse(this.txtKGVa.Text, out p1) && int.TryParse(this.txtKGVb.Text, out p2))
                ValidationKGV = (p1 > 0 && p2 > 0);
            else
                ValidationKGV = false;
        }

        private void btnCalculateKGV_Click(object sender, RoutedEventArgs e)
        {
            if (validationKGV)
                this.txtKGVResult.Text = MathAlgorithms.KGV(int.Parse(this.txtKGVa.Text), int.Parse(this.txtKGVb.Text)).ToString();
            else
                this.txtKGVResult.Text = string.Empty;
        }

        private void txtPrime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!afterInitialize)
                return;

            int p1 = -1;

            if (int.TryParse(this.txtPrime.Text, out p1))
                ValidationPrime = p1 > 2;
            else
                ValidationPrime = false;
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (validationPrime)
            {
                List<int> lstPrime = new List<int>();
                for (int i = 2; i <= int.Parse(this.txtPrime.Text); i++)
                {
                    if (MathAlgorithms.IsPrimeNumber(i))
                        lstPrime.Add(i);
                }
                lstPrimeNumbers.ItemsSource = lstPrime;
            }
        }

        private void txtPhi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!afterInitialize)
                return;

            // Do validation of phi(a, b)
            // Event is called by both textboxes!
            int p1 = -1, p2 = -1;

            if (int.TryParse(this.txtPhiTo.Text, out p1) && int.TryParse(this.txtPhiA.Text, out p2))
                ValidationPhi = (p1 > 0 && p2 > 0 && p2 > p1);
            else
                ValidationPhi = false;
        }

        private void btnCalculatePhi_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationPhi)
            {
                List<string> lstValues = new List<string>();
                for (int i = int.Parse(this.txtPhiTo.Text); i <= int.Parse(this.txtPhiA.Text); i++)
                    lstValues.Add("phi(" + i + ") = " + MathAlgorithms.CalculatePhi(i));

                this.lstPhi.ItemsSource = lstValues;              
            }
        }

        private void txtPrimeFactorization_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!afterInitialize)
                return;

            int p1 = -1;
            ValidationPrimeFactorization = int.TryParse(this.txtPrimeFactorization.Text, out p1) && p1 > 0;
        }

        private void btnCalculatePrimeFactorization_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationPrimeFactorization)
            {
                int currentValue = int.Parse(this.txtPrimeFactorization.Text);
                List<Prime> result = MathAlgorithms.CalculatePrimeFactorization(currentValue);
                this.lblPrimeFactorizationResult.Text = currentValue + " = " + Prime.GenerateString(result);
            }
            else
                this.lblPrimeFactorizationResult.Text = string.Empty;
        }

        private void btnCalculateEEA_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidationEEA)
            {
                dgwGrid.Items.Clear();
                dgwGrid.Columns.Clear();

                int a = int.Parse(this.txtEEAa.Text);
                int b = int.Parse(this.txtEEAb.Text);

                if (b > a)
                {   // Swap, higher element has to be left-sided!
                    int temp = a;
                    a = b;
                    b = temp;

                    this.txtEEAa.Text = a.ToString();
                    this.txtEEAb.Text = b.ToString();
                }

                Result rst = MathAlgorithms.CalculateExtendedAlgo(a, b);
                string[] columns = new string[] { "a", "b", "q", "r", "x", "y" };

                for (int i = 0; i <= columns.Length - 1; i++)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.Header = columns[i];
                    column.Width = 100;
                    column.Binding = new Binding(columns[i]);
                    dgwGrid.Columns.Add(column);
                }

                // Adding the rows in datatable
                for (int i = 0; i <= rst.lstA.Count - 1; i++)
                {                  
                    dgwGrid.Items.Add(new DataItem() {  a = rst.lstA[i].ToString(),
                                                        b = rst.lstB[i].ToString(),
                                                        q = rst.lstQ[i].ToString(),
                                                        r = rst.lstR[i].ToString(),
                                                        x = rst.lstX[i].ToString(),
                                                        y = rst.lstY[i].ToString(),
                    });
                }
            }
        }

        private void chkUseGGT_Checked(object sender, RoutedEventArgs e)
        {
            if (chkUseGGT.IsChecked.HasValue && chkUseGGT.IsChecked.Value && this.ValidationEEA)
                this.txtEEAc.Text = MathAlgorithms.GGT(int.Parse(this.txtEEAa.Text), int.Parse(this.txtEEAb.Text)).ToString();
        }

        private void txtEEAc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!afterInitialize)
                return;

            // Do validation of phi(a, b)
            // Event is called by both textboxes!
            int p1 = -1, p2 = -1, p3 = - 1;

            if (int.TryParse(this.txtEEAa.Text, out p1) && int.TryParse(this.txtEEAb.Text, out p2) && int.TryParse(this.txtEEAc.Text, out p3))
                this.ValidationEEA = (p1 > 0 && p2 > 0 && p3 > 0);

            else
                this.ValidationEEA = false;

            if (chkUseGGT.IsChecked.HasValue && chkUseGGT.IsChecked.Value && this.ValidationEEA)
                this.txtEEAc.Text = MathAlgorithms.GGT(int.Parse(this.txtEEAa.Text), int.Parse(this.txtEEAb.Text)).ToString();
        }

        private void dgwGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            About frmAboutInstance = new About();
            frmAboutInstance.ShowDialog();
        }
    }

  
}
