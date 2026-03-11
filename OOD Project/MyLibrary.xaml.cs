using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for MyLibrary.xaml
    /// </summary>
    public partial class MyLibrary : Window
    {
        ObservableCollection<Game> Library = new ObservableCollection<Game>();
        public MyLibrary()
        {
            InitializeComponent();

            Library.Add(new Game
            {
                Title = "Cyberpunk 2077",
                Genre = "RPG",
                Platform = "PC",
                PurchaseDate = DateTime.Now
            });

            Library.Add(new Game
            {
                Title = "Halo Infinite",
                Genre = "Shooter",
                Platform = "Xbox",
                PurchaseDate = DateTime.Now
            });

            lbxLibrary.ItemsSource = Library;
            lbxLibrary.DisplayMemberPath = "Title";
        }

        private void lbxLibrary_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbxLibrary.SelectedItem is Game selectedGame)
            {
                MessageBox.Show($"Game: {selectedGame.Title}\nPlatform: {selectedGame.Platform}");
            }
        }
    }
}
