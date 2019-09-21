using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Runtime.InteropServices;

namespace FirstLaba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool matrixIsFill = false;
        private int[][] matrix;
        private SoundPlayer sndplayr = new
                         SoundPlayer(Properties.Resources.Y2K_bbno_Lalala_kissvk_com);
        public MainWindow()
        {
            InitializeComponent();

            changeVisible(Visibility.Hidden);
            musicBtn.Visibility = Visibility.Visible;
        }

        private void changeVisible(Visibility v)
        {
            foreach (UIElement c in mainGrid.Children)
            {
                c.Visibility = v;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            matrix = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                matrix[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    matrix[i][j] = rand.Next(0, 99);
                }
            }

            this.matrixIsFill = true;

            matrixGrid.DataContext = matrix;
        }

        private void MaxButtonOfRow_Click(object sender, RoutedEventArgs e)
        {
            if (!matrixIsFill)
            {
                MessageBox.Show("Сначала заполните матрицу");
                return;
            }
       
            int max = int.MinValue;
            int numerOfRow = maxOfRowBox.SelectedIndex;
            for (int i = 0; i < matrix.Length; i++)
            {
                int elementValue = matrix[numerOfRow][i];

                max = (elementValue > max) ? elementValue : max;
            }

            MessageBox.Show(Convert.ToString(max));
        }

        private void MinOfColumnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!matrixIsFill)
            {
                MessageBox.Show("Сначала заполните матрицу");
                return;
            }

            int min = int.MaxValue;
            int numerOfColumn = minOfColumnBox.SelectedIndex;
            for (int i = 0; i < matrix.Length; i++)
            {
                int elementValue = matrix[i][numerOfColumn];

                min = (elementValue < min) ? elementValue : min;
            }

            MessageBox.Show(Convert.ToString(min));
        }

        private void MaxOfMatrixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!matrixIsFill)
            {
                MessageBox.Show("Сначала заполните матрицу");
                return;
            }

            int max = int.MinValue;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int elementValue = matrix[i][j];
                    max = (elementValue > max) ? elementValue : max;
                }
            }

            MessageBox.Show(Convert.ToString(max));
        }

        private void MusicBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sndplayr.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace.ToString(),
                               "Error");
            }

            changeVisible(Visibility.Visible);
            musicBtn.Visibility = Visibility.Hidden;
        }

        private void StopMusicBtn_Click(object sender, RoutedEventArgs e)
        {
            sndplayr.Stop();
        }
    }
}
