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
using cshar_database_proj;

namespace QuickCar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public void LoadTable()
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
           AddCarWindow addCarWindow = new AddCarWindow(this);
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

        public int index_listbox = 0;
        private void ListBox_Cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new SQL_QuickCarEntities())
            {
                index_listbox = ListBox_Cars.SelectedIndex;
                if (index_listbox < 0)
                {
                    index_listbox = 0;
                }
                var car = context.Cars.ToList()[index_listbox];
                Text_YearCar.Text = car.YearCar.ToString();
                var relationcar = context.CarInUse.FirstOrDefault(c => c.CarID == car.CarID);
                var relationcarinservice = context.CarsInService.FirstOrDefault(c => c.CarID == car.CarID);
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
                    Text_StartTime.Text = relationcar.StartTime.Value.ToString("dd-MM-yyyy");
                    Text_StopTime.Text = relationcar.StopTime.ToString("dd-MM-yyyy");
                }
                if (relationcarinservice == null)
                {
                    IsRepairingCheckBox.IsChecked = false;
                    Text_StartTimeRepair.Text = "**-**-****";
                    Text_StopTimeRepair.Text = "**-**-****";
                    Text_Comment.Text = "Wpisz komentarz...";
                }
                else
                {
                    IsRepairingCheckBox.IsChecked = true;
                    Text_StartTimeRepair.Text = relationcarinservice.StartServTime.Value.ToString("dd-MM-yyyy");
                    Text_StopTimeRepair.Text = relationcarinservice.StopServTime.Value.ToString("dd-MM-yyyy");
                    Text_Comment.Text = relationcarinservice.Comments.ToString();
                }
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
            DeleteCarWindow deleteCarWindow = new DeleteCarWindow(this);
            deleteCarWindow.Show();
        }

        private void Button_SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (IsRepairingCheckBox.IsChecked is true && 
                IsUsingCheckBox.IsChecked is true)
            {
                throw new ArgumentException(String.Format("Samochód nie może być jednocześnie w serwisie i u klienta!!!"));
            }

            int testYear;
            bool isNumeric = int.TryParse(Text_YearCar.Text, out testYear);
            if (isNumeric is false)
            {
                throw new ArgumentException(String.Format("Wprowadzono złą wartość Roku produkcji!!!"));
            }

            var parseResult = DateTime.TryParse(Text_StartTime.Text, out _) &
                DateTime.TryParse(Text_StartTime.Text, out _) &
                DateTime.TryParse(Text_StartTimeRepair.Text, out _) &
                DateTime.TryParse(Text_StopTimeRepair.Text, out _);
            if (parseResult is false && 
                Text_StartTime.Text != "**-**-****" && 
                Text_StopTime.Text != "**-**-****" && 
                Text_StartTimeRepair.Text != "**-**-****" && 
                Text_StopTimeRepair.Text != "**-**-****")
            {
                throw new ArgumentException(String.Format("Wprowadzono złą datę!!!"));
            }

            using (var context = new SQL_QuickCarEntities())
            {
                
            }
        }
    }
}
