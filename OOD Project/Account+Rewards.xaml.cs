using System.Windows;
using OOD_Project.Data;
using OOD_Project.ProjectData;
using System.Linq;
using System;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Account_Rewards.xaml
    /// </summary>
    public partial class Account_Rewards : Window
    {
        private User CurrentUser;
        public Account_Rewards()
        {
            InitializeComponent();

            using (var context = new GamezExpressContext())
            {
                CurrentUser = context.Users.FirstOrDefault();

                if (CurrentUser == null)
                {
                    CurrentUser = new User
                    {
                        Username = "PlayerOne",
                        Points = 0
                    };

                    context.Users.Add(CurrentUser);
                    context.SaveChanges();
                }

                tblkUsername.Text = CurrentUser.Username;
                tblkPoints.Text = CurrentUser.Points.ToString();
            }
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e)
        {
            try //Exception Handling/Defensive Coding - Protecting Redeem Button
            {
                using (var context = new GamezExpressContext())
                {
                    var user = context.Users.FirstOrDefault();

                    if (user != null)
                    {
                        if (user.Points >= 500)
                        {
                            user.Points -= 500;
                            context.SaveChanges();

                            tblkPoints.Text = user.Points.ToString();
                            MessageBox.Show("Reward Redeemed!");
                        }
                        else
                        {
                            MessageBox.Show("Not enough points.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error redeeming reward: " + ex.Message);
            }
        }
    }
}

