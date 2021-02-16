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
        MainWindow mainWindow = new MainWindow();
        public DeleteCarWindow()
        {
            InitializeComponent();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
