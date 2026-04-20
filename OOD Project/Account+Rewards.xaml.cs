using System.Windows;
using OOD_Project.Data;
using OOD_Project.ProjectData;
using System.Linq;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Account_Rewards.xaml
    /// </summary>
    public partial class Account_Rewards : Window
    {
        User CurrentUser = new User();

        public Account_Rewards()
        {
            InitializeComponent();

            // Example user data (later this will come from database)
            CurrentUser.Username = "PlayerOne";
            CurrentUser.Points = 1250;

            // Display data in UI
            tblkUsername.Text = CurrentUser.Username;
            tblkPoints.Text = CurrentUser.Points.ToString();
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Points >= 500)
            {
                CurrentUser.Points -= 500;
                tblkPoints.Text = CurrentUser.Points.ToString();

                MessageBox.Show("Reward Redeemed!");
            }
            else
            {
                MessageBox.Show("Not enough points.");
            }
        }
    }
}
