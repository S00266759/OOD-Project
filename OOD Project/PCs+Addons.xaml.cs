using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for PCs_Addons.xaml
    /// </summary>
    public partial class PCs_Addons : Window
    {
        // Observable list
        ObservableCollection<AddonItem> Addons = new ObservableCollection<AddonItem>();
        public PCs_Addons()
        {
            InitializeComponent();

            Addons.Add(new AddonItem
            {
                Name = "Gaming Mouse",
                Description = "High precision RGB gaming mouse.",
                Price = 59.99
            });

            Addons.Add(new AddonItem
            {
                Name = "Mechanical Keyboard",
                Description = "RGB mechanical keyboard for gaming.",
                Price = 129.99
            });

            Addons.Add(new AddonItem
            {
                Name = "Cyberpunk DLC",
                Description = "Expansion pack with new missions.",
                Price = 19.99
            });

            // Binding to list
            lbxAddons.ItemsSource = Addons;
            lbxAddons.DisplayMemberPath = "Name";
        }

        private void lbxAddons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxAddons.SelectedItem is AddonItem selectedItem)
            {
                tblkItemName.Text = selectedItem.Name;
                tblkItemDescription.Text = selectedItem.Description;
                tblkItemPrice.Text = "Price: $" + selectedItem.Price.ToString();
            }
        }
    }
}
