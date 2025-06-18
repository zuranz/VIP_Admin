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
        private List<Club> clubs;
        private Club selectedClub;
        private TypeOfClub selectedTypeOfClub;
        private List<TypeOfClub> typesAppls;

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
        public List<Club> Clubs
        {
            get => clubs;
            set
            {
                clubs = value;
                Signal();
            }
        }

        public Club SelectedClub
        {
            get => selectedClub; set
            {
                selectedClub = value;
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

        public TypeOfClub SelectedType
        {
            get => selectedTypeOfClub;
            set
            {
                selectedTypeOfClub = value;
                Signal();

            }
        }

        public List<TypeOfClub> TypeOfClubs
        {
            get => typesAppls; set
            {
                typesAppls = value;
                Signal();
            }
        }

        public async Task GetRequests()
        {

            Requestes = await APIhost.GetInstance().GetAppls();
            Clubs = await APIhost.GetInstance().GetClubs();
            TypeOfClubs = await APIhost.GetInstance().GetTypesOfClubs();
            TypeOfClubs.Insert(0, new TypeOfClub { Id = 0, Title = "Все типы" });
            SelectedType = TypeOfClubs[0];
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

        private void OpenFullApple(object sender, MouseButtonEventArgs e)
        {
            FullApple fullApple = new FullApple(SelectedRequests);
            fullApple.Show();
            Close();
        }

        private void Notifications(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFull(object sender, MouseButtonEventArgs e)
        {
            FullClub fullClub = new FullClub(SelectedClub);
            fullClub.Show(); Close();   
        }
    }
}