using System.Collections.ObjectModel;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

//For Database
using OOD_Project.Data;
using OOD_Project.ProjectData;
using System.Linq;
using System;
using System.Runtime.Remoting.Contexts;
using System.Windows.Controls;


namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {

        public StoreWindow()
        {
            InitializeComponent();

            using (var context = new GamezExpressContext())
            {
                MessageBox.Show(context.Games.Count().ToString()); //testing - checking if database holds amount of games specified (had multiple entries)

                // Only adding games if DB is empty
                if (!context.Games.Any())
                {
                    context.Games.Add(new Game
                    {
                        Title = "CyberPunk 2077",
                        Genre = "RPG",
                        Platform = "PC",
                        Description = "Futuristic RPG action game.",
                        ImagePath = "/Images/cyberpunk.jpg"

                    });

                    context.Games.Add(new Game
                    {
                        Title = "Elden Ring",
                        Genre = "Action",
                        Platform = "PC",
                        Description = "Epic open world fantasy adventure.",
                        ImagePath = "/Images/eldenring.jpg"

                    });

                    context.Games.Add(new Game
                    {
                        Title = "Halo Infinite",
                        Genre = "Shooter",
                        Platform = "Xbox",
                        Description = "Classic sci-fi shooter experience.",
                        ImagePath = "/Images/haloinfinite.jpg"

                    });

                    context.Games.Add(new Game
                    {
                        Title = "Doom Eternal",
                        Genre = "Shooter",
                        Platform = "Xbox",
                        Description = "Classic shooter experience.",
                        ImagePath = "/Images/doometernal.jpg"

                    });

                    context.Games.Add(new Game
                    {
                        Title = "The Legend of Zelda: Breath of the Wild",
                        Genre = "Adventure",
                        Platform = "Nintendo Switch",
                        Description = "Open world adventure that battles the evil overlord, Ganondorf and his reign of darkness over Hyrule",
                        ImagePath = "/Images/zeldabotw.jpg"

                    });

                    context.Games.Add(new Game
                    {
                        Title = "The Legend of Zelda: Ocarina of Time",
                        Genre = "Adventure",
                        Platform = "Nintendo 64",
                        Description = "Open world adventure that battles the evil overlord, Ganondorf and his reign of darkness over Hyrule",
                        ImagePath = "/Images/zeldaoot.jpg"

                    });

                    context.Games.Add(new Game
                    {
                        Title = "The Legend of Zelda: Majora's Mask",
                        Genre = "Adventure",
                        Platform = "Nintendo 64",
                        Description = "Open world adventure that battles the evil overlord, Ganondorf and his reign of darkness over Hyrule",
                        ImagePath = "/Images/zeldamm.jpg"

                    });

                    context.SaveChanges();
                }


                //Loading from Database (unowned games, not in MyLibrary)
                lstGames.ItemsSource = context.Games
                .Where(g => g.PurchaseDate == null)
                .ToList();

                

            }
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
            using (var context = new GamezExpressContext())
            {
                string searchText = txtSearch.Text.ToLower();

                string selectedPlatform = (cbxPlatform.SelectedItem as ComboBoxItem)?.Content.ToString();
                string selectedGenre = (cbxGenre.SelectedItem as ComboBoxItem)?.Content.ToString();

                var query = context.Games.Where(g => g.PurchaseDate == null);

                // Search filter
                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(g => g.Title.ToLower().Contains(searchText));
                }

                // Platform filter
                if (selectedPlatform != "All" && !string.IsNullOrEmpty(selectedPlatform))
                {
                    query = query.Where(g => g.Platform.Contains(selectedPlatform));
                }

                // Genre filter
                if (selectedGenre != "All" && !string.IsNullOrEmpty(selectedGenre))
                {
                    query = query.Where(g => g.Genre.Contains(selectedGenre));
                }

                lstGames.ItemsSource = query.ToList();
            }
        }
        

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (lstGames.SelectedItem is Game selectedGame)
            {
                using (var context = new GamezExpressContext())
                {
                    // Find the game in DB
                    var game = context.Games.Find(selectedGame.GameId);

                    if (game != null)
                    {
                        game.PurchaseDate = DateTime.Now; // mark as purchased
                        context.SaveChanges();

                        MessageBox.Show("Game added to your library!");
                    }
                }
            }
        }
    }
}

