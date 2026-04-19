using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using OOD_Project.ProjectData;
using System.Linq;
using OOD_Project.Data;

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

            using (var context = new GamezExpressContext())
            {
                var ownedGames = context.Games
                    .Where(g => g.PurchaseDate != null)
                    .ToList();

                lbxLibrary.ItemsSource = ownedGames;
                lbxLibrary.DisplayMemberPath = "Title";
            }
        }

        private void lbxLibrary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxLibrary.SelectedItem is Game selectedGame)
            {
                tblkTitle.Text = selectedGame.Title;
                tblkGenre.Text = "Genre: " + selectedGame.Genre;
                tblkPlatform.Text = "Platform: " + selectedGame.Platform;

                if (selectedGame.PurchaseDate.HasValue)
                {
                    tblkDate.Text = "Purchased: " + selectedGame.PurchaseDate.Value.ToShortDateString();
                }
                else
                {
                    tblkDate.Text = "Not purchased yet";
                }
            }
        }
    }
}
