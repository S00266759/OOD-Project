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


namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {

        // ObservableCollection to hold games
        private ObservableCollection<Game> Games = new ObservableCollection<Game>();

        public StoreWindow()
        {
            InitializeComponent();

            using (var context = new GamezExpressContext())
            {
                context.Games.Add(new Game
                {
                    Title = "CyberGame 2077",
                    Genre = "RPG",
                    Platform = "PC",
                    Description = "Futuristic RPG action game.",
                    
                });

                context.Games.Add(new Game 
                { 
                    Title = "Elden Ring", 
                    Genre = "Action", 
                    Platform = "PC", 
                    Description = "Epic open world fantasy adventure.", 
                   
                });

                context.Games.Add(new Game 
                { 
                    Title = "Halo Infinite", 
                    Genre = "Shooter", 
                    Platform = "Xbox", 
                    Description = "Classic sci-fi shooter experience.", 
                    
                });

                context.Games.Add(new Game 
                { 
                    Title = "Doom Eternal", 
                    Genre = "Shooter", 
                    Platform = "Xbox", 
                    Description = "Classic shooter experience.", 
                    
                });

                context.Games.Add(new Game 
                { 
                    Title = "The Legend of Zelda: Breath of the Wild", 
                    Genre = "Adventure", 
                    Platform = "Nintendo Switch", 
                    Description = "Open world adventure that battles the evil overlord, Ganondorf and his reign of darkness over Hyrule", 
                   
                });

                context.Games.Add(new Game 
                { 
                    Title = "The Legend of Zelda: Ocarina of Time", 
                    Genre = "Adventure", Platform = "Nintendo 64", 
                    Description = "Open world adventure that battles the evil overlord, Ganondorf and his reign of darkness over Hyrule", 
                    
                });

                context.Games.Add(new Game 
                { 
                    Title = "The Legend of Zelda: Majora's Mask", 
                    Genre = "Adventure", Platform = "Nintendo 64", 
                    Description = "Open world adventure that battles the evil overlord, Ganondorf and his reign of darkness over Hyrule", 
                    
                });

                context.SaveChanges();
            }

            //Loading from Database 


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

