using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            imgFeaturedGame.Source = new BitmapImage(
        new Uri("/Images/doometernal.jpg", UriKind.Relative));
        }

        private void btn_Store_Click_1(object sender, RoutedEventArgs e)
        {
            StoreWindow store = new StoreWindow();
            store.Show();
        }

        private void btn_Library_Click_1(object sender, RoutedEventArgs e)
        {
            MyLibrary gamelibrary = new MyLibrary();
            gamelibrary.Show();
        }


        private void btn_Account_Rewards_Click_1(object sender, RoutedEventArgs e)
        {
            Account_Rewards accountRewards = new Account_Rewards();
            accountRewards.Show();
        }

    }
}
