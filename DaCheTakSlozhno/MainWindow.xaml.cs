using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.ComponentModel;
using OxyPlot;
using OxyPlot.Series;
using System.Data;
using org.mariuszgromada.math.mxparser;
using System.Windows.Threading;

namespace DaCheTakSlozhno
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model = new Model();
        public string Xmin
        {
            get => model.Xmin;
            set => model.Xmin = value;
        }
        public string Xmax
        {
            get => model.Xmax;
            set => model.Xmax = value;
        }
        public string userFormula
        {
            get => model.userFormula;
            set => model.userFormula = value;
        }
        public string A
        {
            get => model.A;
            set => model.A = value;
        }
        public string B
        {
            get => model.B;
            set => model.B = value;
        }
        public string C
        {
            get => model.C;
            set => model.C = value;
        }

        public List<DataPoint> Points { get; }

        int loadText = 0;
        int count = 0;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            Points = new List<DataPoint>();
            DataContext = this;
            Loading();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            Generation();
            
        }
        private void Generation()
        {
            if (Convert.ToInt32(Xmin) >= Convert.ToInt32(Xmax))
            {
                MessageBox.Show("Неверно введенные данные");
            }
            else
            {
                Title = "Your graphic";
                Points.Clear();
                for (int i = Convert.ToInt32(Xmin); i <= Convert.ToInt32(Xmax); i++)
                {
                    Points.Add(new DataPoint(i, model.PointY(i)));
                }
                oxy.InvalidatePlot(true);
            }

        }
        private void timer_tick(object sender, EventArgs e)
        {
            count++;
            if (count == 13)
            {
                timer.Stop();
                loadUp.Visibility = Visibility.Hidden;
                loadDown.Visibility = Visibility.Hidden;
                oxy.Visibility = Visibility.Visible;
            }

            if (loadText == 0)
            {

                load.Text = "LOADING";
            }
            if (loadText == 1)
            {
                load.Text = "LOADING.";
            }
            if (loadText == 2)
            {
                load.Text = "LOADING..";
            }
            if (loadText == 3)
            {
                load.Text = "LOADING...";
            }
            if(loadText <=2)
            {
                loadText++;
            }
            else
            {
                loadText = 0;
            }
        }
        void Loading()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            userFormula = selectedItem.Content.ToString();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down) 
            {
                userFormula = userFormula + "-1";
                Generation();
                e.Handled = true;
            }
            if (e.Key == Key.Up)
            {
                userFormula = userFormula + "+1";
                Generation();
                e.Handled = true;
            }
            if (e.Key == Key.Left)
            {
                minX.Text = (Convert.ToInt32(minX.Text) - 1).ToString();
                Xmin = minX.Text;
                maxX.Text = (Convert.ToInt32(maxX.Text) - 1).ToString();
                Xmax = maxX.Text;
                Generation();
                e.Handled = true;

            }
            if (e.Key == Key.Right)
            {
                minX.Text = (Convert.ToInt32(minX.Text) + 1).ToString();
                Xmin = minX.Text;
                maxX.Text = (Convert.ToInt32(maxX.Text) + 1).ToString();
                Xmax = maxX.Text;
                Generation();
                e.Handled = true;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Grid_KeyDown;
            this.Focusable = true;
            this.Focus();
        }
    }
    


        
}
