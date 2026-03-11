using System.Collections.ObjectModel;
using System.Windows;


namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        // Sample Game class - for testing only, will make proper one later on.
        public class Game
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public string Platform { get; set; }
            public string Description { get; set; }
        }

        // ObservableCollection to hold games
        private ObservableCollection<Game> Games = new ObservableCollection<Game>();

        public StoreWindow()
        {
            InitializeComponent();

            // Adding some sample games - again temporary
            Games.Add(new Game { Title = "CyberGame 2077", Genre = "RPG", Platform = "PC", Description = "Futuristic RPG action game." });
            Games.Add(new Game { Title = "Elden Ring", Genre = "Action", Platform = "PC", Description = "Epic open world fantasy adventure." });
            Games.Add(new Game { Title = "Halo Infinite", Genre = "Shooter", Platform = "Xbox", Description = "Classic sci-fi shooter experience." });

            // Binding to the ListBox
            lstGames.ItemsSource = Games;
            lstGames.DisplayMemberPath = "Title";

            // Setting default selected
            if (lstGames.Items.Count > 0)
                lstGames.SelectedIndex = 0;
        }


        private void lstGames_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstGames.SelectedItem is Game selectedGame)
            {
                tblkGameTitle.Text = selectedGame.Title;
                tblkGameDescription.Text = selectedGame.Description;
                //will add code to display the actual image later.
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // For now, just a placeholder message
            MessageBox.Show("Search clicked! Later this will filter the games.");
        }
    }
}

