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
        private void Button_AddCar_Click(object sender, RoutedEventArgs e)
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

        private void ListBox_Cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new SQL_QuickCarEntities())
            {
                var index = ListBox_Cars.SelectedIndex;
                var car = context.Cars.ToList()[index];
                var relationcar = context.CarInUse.FirstOrDefault(c => c.CarID == car.CarID);
                if (relationcar == null)
                {
                    IsUsingCheckBox.IsChecked = false;
                    Text_ClientName.Text = "*brak klienta*";
                    Text_ClientSurname.Text = "*brak klienta*";
                    Text_StartTime.Text = "**-**-****";
                    Text_StopTime.Text = "**-**-****";
                }
                else
                {
                    IsUsingCheckBox.IsChecked = true;
                    var relationclient = context.Clients.FirstOrDefault(c => c.ClientID == relationcar.ClientID);
                    Text_ClientName.Text = relationclient.ClientName.ToString();
                    Text_ClientSurname.Text = relationclient.ClientSurname.ToString();
                    Text_StartTime.Text = relationcar.StartTime.ToString();
                    Text_StopTime.Text = relationcar.StopTime.ToString();
                }
                Text_YearCar.Text = car.YearCar.ToString();
            }
        }

        private void AllowEdit_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Text_ClientName.IsEnabled = true;
            Text_ClientSurname.IsEnabled = true;
            Text_Comment.IsEnabled = true;
            Text_StartTime.IsEnabled = true;
            Text_StopTime.IsEnabled = true;
            Text_YearCar.IsEnabled = true;
            IsRepairingCheckBox.IsEnabled = true;
            IsUsingCheckBox.IsEnabled = true;
            Button_SaveEdit.IsEnabled = true;
            Text_Comment.IsEnabled = true;
        }

        private void AllowEdit_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Text_ClientName.IsEnabled = false;
            Text_ClientSurname.IsEnabled = false;
            Text_Comment.IsEnabled = false;
            Text_StartTime.IsEnabled = false;
            Text_StopTime.IsEnabled = false;
            Text_YearCar.IsEnabled = false;
            IsRepairingCheckBox.IsEnabled = false;
            IsUsingCheckBox.IsEnabled = false;
            Button_SaveEdit.IsEnabled = false;
            Text_Comment.IsEnabled = false;
        }

        private void Button_DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            DeleteCarWindow deleteCarWindow = new DeleteCarWindow();
            deleteCarWindow.Show();
        }
    }
}
