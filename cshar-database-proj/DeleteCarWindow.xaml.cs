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
using System.Windows.Shapes;

namespace QuickCar
{
    /// <summary>
    /// Logika interakcji dla klasy DeleteCarWindow.xaml
    /// </summary>
    public partial class DeleteCarWindow : Window
    {
        public DeleteCarWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        public MainWindow MainWindow { get; }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            int index_listbox = MainWindow.ListBox_Cars.SelectedIndex;
            using (var context = new SQL_QuickCarEntities())
            {
                var car = context.Cars.ToList()[index_listbox];
                var relationcar = context.CarInUse.FirstOrDefault(c => c.CarID == car.CarID);
                var relationcarinservice = context.CarsInService.FirstOrDefault(c => c.CarID == car.CarID);
                if (relationcarinservice != null)
                {
                    throw new ArgumentException(String.Format("Samochód jest w serwisie!!!"));
                }
                else if (relationcar != null)
                {
                    throw new ArgumentException(String.Format("Samochód jest wypożyczony przez klienta!!!"));
                }
                else
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
                index_listbox++;
                MainWindow.LoadTable();
            }            
            this.Close();
        }
    }
}
