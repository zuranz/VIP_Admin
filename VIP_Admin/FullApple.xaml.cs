using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace VIP_Admin
{
    /// <summary>
    /// Логика взаимодействия для FullApple.xaml
    /// </summary>
    public partial class FullApple : Window, INotifyPropertyChanged
    {
        private Application1 application;

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public Application1 Application
        {
            get => application;
            set 
            { 
                application = value;
                Signal();
            }
        }
        public FullApple(Application1 application)
        {
            InitializeComponent();
            Application = application;
        }

        private void BackToTheFuture(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void YES(object sender, RoutedEventArgs e)
        {

        }

        private void NO(object sender, RoutedEventArgs e)
        {

        }
    }
}
