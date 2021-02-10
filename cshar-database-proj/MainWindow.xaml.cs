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
using cshar_database_proj;

namespace QuickCar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void LoadTable()
        {
            using (var context = new SQL_QuickCarEntities())
            {
                //var StringNameCar = context.Cars.Select(x => x.NameCar);
                //int StringNameCarLength = StringNameCar.Count();

                //ListBox_Cars.Items.Clear();
                ////for (int i = 0; i < StringNameCarLength; i++)
                //foreach (var element in StringNameCar)
                //{
                //    ListBox_Cars.Items.Add(element);
                //}
                this.ListBox_Cars.ItemsSource = context.Cars.Select(x => x.NameCar).ToList();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadTable();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SQL_QuickCarEntities())
            {
                var StringNameCar = (from Cars in context.Cars
                                     select Cars.NameCar)
                                    .ToString();
                var StringYearCar = (from Cars in context.Cars
                                     select Cars.YearCar)
                                    .FirstOrDefault();
                //textBlok.Text = StringNameCar;
            }
        }
        */
        private void Button_EndProgram2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_AddCar(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource carsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carsViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // carsViewSource.Źródło = [ogólne źródło danych]
        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }
    }
}
