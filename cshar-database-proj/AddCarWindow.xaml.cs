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
using cshar_database_proj;

namespace QuickCar
{
    /// <summary>
    /// Logika interakcji dla klasy AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        SQL_QuickCarEntities db = new SQL_QuickCarEntities();
        public AddCarWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        public MainWindow MainWindow { get; }

        private void Button_ExitNewCar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_SaveNewCar_Click(object sender, RoutedEventArgs e)
        {
            Cars newCar = new Cars()
            {
                NameCar = AddCar_Name.Text,
                YearCar = int.Parse(AddCar_Year.Text),
            };
            db.Cars.Add(newCar);
            db.SaveChanges();
            MainWindow.LoadTable();
            this.Close();
        }
    }
}
