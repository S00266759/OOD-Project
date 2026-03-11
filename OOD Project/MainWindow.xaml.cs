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
    }
}
