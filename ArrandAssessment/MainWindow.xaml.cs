using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ArrandAssessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] arrNum = null ;
        private int indexCount = 0;
        private int arrSize = 0 ;
       
        public MainWindow()
        {
            InitializeComponent();

            //fetching array size from xaml configuration
            arrSize = int.Parse(this.FindResource("arrCount").ToString());

            //initializing array with size
            arrNum = new int[arrSize];
        }

        //button action for validation and adding values to array
        private void Enterbtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (valtxt.Text != "" && int.TryParse(valtxt.Text, out int num))
            {

                if (arrNum.Where(x => x == int.Parse(valtxt.Text)).FirstOrDefault().Equals(int.Parse(valtxt.Text)))
                {
                    MessageBox.Show("Number already exists", "Info");
                }
                else if (int.Parse(valtxt.Text) > 0 && int.Parse(valtxt.Text) <= arrSize && indexCount < arrSize)
                {
                    try
                    {
                        arrNum[indexCount] = int.Parse(valtxt.Text);
                        indexCount++;
                        listArr.Items.Clear();
                        for (int i = 0; i < arrNum.Length; i++)
                        {
                            if (arrNum[i] > 0 && arrNum[i] <= arrSize)
                            {
                                listArr.Items.Add(arrNum[i]);
                            }

                        }

                    }
                    catch 
                    { }

                }
                else if(indexCount >= arrSize)
                {
                    MessageBox.Show("Array limit already reached", "Alert");
                }
                else
                {
                    if (int.Parse(valtxt.Text) < 1 || int.Parse(valtxt.Text) > arrSize)
                    {
                        MessageBox.Show("Value not within range", "Error");
                    }
                    else
                    {
                        MessageBox.Show("Integer value must be provided", "Error");
                    }
                }
            }
        }

        //button action for validation and generating random numbers
        private void Generatebtn_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(minValTxt.Text, out int num))
            {
                MessageBox.Show("Integer value must be provided", "Error");
            }
            else if (!int.TryParse(maxValTxt.Text, out int num2))
            {
                MessageBox.Show("Integer value must be provided", "Error");
            }
            else
            {
                if (int.Parse(minValTxt.Text) < int.Parse(maxValTxt.Text))
                {
                    resultTxt.Text = new RandomEvaluator().RandomGenerator(int.Parse(minValTxt.Text), int.Parse(maxValTxt.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("Maximum value must be greater than minimum value", "Error");
                }
            }
        }

        //validating for numbers
        private void valtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            valtxt.Text = Regex.Replace(valtxt.Text, "[^0-9]+", "");
        }

        //validating for numbers
        private void minValTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            minValTxt.Text = Regex.Replace(minValTxt.Text, "[^0-9]+", "");
        }

        //validating for numbers
        private void maxValTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            maxValTxt.Text = Regex.Replace(maxValTxt.Text, "[^0-9]+", "");
        }
    }
}
