using System.Windows;
using OOD_Project.Data;
using OOD_Project.ProjectData;
using System.Linq;
using System;
using System.Net.NetworkInformation;
using System.Windows.Controls;

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

                prgPoints.Value = CurrentUser.Points;
            }
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e)
        {
            try //Exception Handling/Defensive Coding - Protecting Redeem Button
            {
                using (var context = new GamezExpressContext())
                {
                    var user = context.Users.FirstOrDefault();

                    if (user != null && cbxRewards.SelectedItem != null)
                    {
                        string selectedReward = (cbxRewards.SelectedItem as ComboBoxItem).Content.ToString();

                        int cost = 0;

                        if (selectedReward.Contains("500")) cost = 500;
                        else if (selectedReward.Contains("1000")) cost = 1000;
                        else if (selectedReward.Contains("3500")) cost = 3500;
                        else if (selectedReward.Contains("5000")) cost = 5000;

                        if (user.Points >= cost)
                        {
                            user.Points -= cost;
                            context.SaveChanges();
                            
                            tblkPoints.Text = user.Points.ToString();
                            prgPoints.Value = CurrentUser.Points;
                            MessageBox.Show( selectedReward + "Redeemed! Enjoy!");
                        }
                        else
                        {
                            MessageBox.Show("Not enough points.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a reward.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error redeeming reward: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new GamezExpressContext())
                {
                    var user = context.Users.FirstOrDefault();

                    if (user != null)
                    {
                        user.Points = 0;
                        context.SaveChanges();

                        tblkPoints.Text = user.Points.ToString();

                        MessageBox.Show("Points reset for testing.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting points: " + ex.Message);
            }
        }

        private void cbxRewards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxRewards.SelectedItem is ComboBoxItem selectedItem)
            {
                string reward = selectedItem.Content.ToString();

                if (reward.Contains("10%"))
                {
                    tblkRewardPreview.Text = "Get 10% off your next game purchase.";
                }
                else if (reward.Contains("20%"))
                {
                    tblkRewardPreview.Text = "Get 20% off your next game purchase.";
                }
                else if (reward.Contains("50%"))
                {
                    tblkRewardPreview.Text = "Massive 50% discount on any game!";
                }
                else if (reward.Contains("Free"))
                {
                    tblkRewardPreview.Text = "Unlock a random free game from the store!";
                }
            }
        }
    }
}

