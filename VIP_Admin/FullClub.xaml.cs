﻿using System;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace VIP_Admin
{
    /// <summary>
    /// Логика взаимодействия для FullClub.xaml
    /// </summary>
    public partial class FullClub : Window, INotifyPropertyChanged
    {
        private Club club;
        private TypeOfClub selectedTypeOfClub;

        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<TypeOfClub> TypeOfClubs
        {
            get => typesAppls; set
            {
                typesAppls = value;
                Signal();
            }
        }
        public Club Club
        { get => club;
            set {
                    club = value;
                Signal();
                }
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



        public List<TypeOfClub> typesAppls { get;  set; }

        public FullClub(Club club)
        {
            InitializeComponent();
            Club = club;
            GetRequests();
            SelectedType = club.IdTypeNavigation;
            DataContext = this;
        }

        public async Task GetRequests()
        {

            TypeOfClubs = await APIhost.GetInstance().GetTypesOfClubs();
       
            await Task.CompletedTask;
        }
        private void BackToTheFuture(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {

        }

        private void AddImage(object sender, RoutedEventArgs e)
        {

        }
    }
}
