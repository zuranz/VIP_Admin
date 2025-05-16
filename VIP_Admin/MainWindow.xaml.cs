using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VIP_Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Application1> requests;
        private Application1 selectedRequests;


        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


        public Application1 SelectedRequests
        {
            get => selectedRequests; set
            {
                selectedRequests = value;
                Signal();
            }
        }

        public List<Application1> Requestes
        {
            get => requests;
            set
            {
                requests = value;
                Signal();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            GetRequests();
            DataContext = this;
        }

        public async Task GetRequests()
        {

            Requestes = await APIhost.GetInstance().GetAppls();
            await Task.CompletedTask;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void YES(object sender, RoutedEventArgs e)
        {
            SelectedRequests.IdStatus = 3;
            if (SelectedRequests.IdType == 2)
            {
                 APIhost.GetInstance().ReadyAppls(SelectedRequests);
            }

            Requestes = await APIhost.GetInstance().GetAppls();
        }

        private async void NO(object sender, RoutedEventArgs e)
        {
            SelectedRequests.IdStatus = 2;
            if (SelectedRequests.IdType == 2)
            {
                APIhost.GetInstance().ReadyAppls(SelectedRequests);
            }
            Requestes = await APIhost.GetInstance().GetAppls();
        }
    }
}