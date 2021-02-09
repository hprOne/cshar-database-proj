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
        public MainWindow()
        {
            InitializeComponent();
            using (var context = new SQL_QuickCarEntities())
            {
                var StringNameCar = (from Cars in context.Cars
                                     select Cars.NameCar)
                                    .ToArray();
                int StringNameCarLength = StringNameCar.Count();

                for (int i = 0; i<StringNameCarLength; i++)
                {
                    ListBox_Cars.Items.Add(StringNameCar[i]);
                }
                


                //ListBox_Cars.Items.Add = StringNameCar[0];
                                     //.ToArray();
                //textBlok.Text = string.Join(",", StringNameCar);                                
            }
            
        }
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
        private void Button_EndProgram2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
