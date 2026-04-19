using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using OOD_Project.ProjectData;

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
