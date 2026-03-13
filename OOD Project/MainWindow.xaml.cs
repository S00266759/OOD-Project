using System.Windows;

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
        }

        private void btn_Store_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow store = new StoreWindow();
            store.Show();
        }

        private void btn_Library_Click(object sender, RoutedEventArgs e)
        {
            MyLibrary gamelibrary = new MyLibrary();
            gamelibrary.Show();
        }

        private void btn_PCs_Addons_Click(object sender, RoutedEventArgs e)
        {
             PCs_Addons pcsAddons = new PCs_Addons();
            pcsAddons.Show();
        }

        private void btn_Account_Rewards_Click(object sender, RoutedEventArgs e)
        {
            Account_Rewards accountRewards = new Account_Rewards();
            accountRewards.Show();
        }

    }
}
