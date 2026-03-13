using System.Windows;

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
            CurrentUser.Email = "playerone@email.com";
            CurrentUser.RewardPoints = 1250;

            // Display data in UI
            tblkUsername.Text = CurrentUser.Username;
            tblkEmail.Text = CurrentUser.Email;
            tblkPoints.Text = CurrentUser.RewardPoints.ToString();
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.RewardPoints >= 500)
            {
                CurrentUser.RewardPoints -= 500;
                tblkPoints.Text = CurrentUser.RewardPoints.ToString();

                MessageBox.Show("Reward Redeemed!");
            }
            else
            {
                MessageBox.Show("Not enough points.");
            }
        }
    }
}
