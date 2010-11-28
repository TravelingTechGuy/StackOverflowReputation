using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Controls;

namespace StackOverflow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StackAPI api;

        public MainWindow()
        {
            InitializeComponent();
            api = new StackAPI();
            foreach (string site in api.Sites.Keys)
            {
                comboSites.Items.Add(site);
            }
            comboSites.SelectedValue = "Stack Overflow";    //let's start with something familiar
        }

        private void buttonGetUser_Click(object sender, RoutedEventArgs e)
        {
            string selectedSite = comboSites.SelectedValue.ToString();
            string userId = textUserID.Text;
            if (userId != string.Empty)
            {
                if (api.GetUsers(selectedSite, userId))
                {
                    imageReputation.Source = new BitmapImage(api.CombinedReputationUrl);
                    imageReputation.Visibility = System.Windows.Visibility.Visible;
                    label2.Visibility = System.Windows.Visibility.Visible;
                    int i = 0;
                    foreach (var pair in api.Users)
                    {
                        //Load image from Flair Url
                        Image image = new Image();
                        image.Width = 208;
                        image.Height = 58;
                        image.Source = new BitmapImage(pair.Value.FlairUrl);
                        
                        //Add tooltip
                        ToolTip tt = new ToolTip();
                        tt.Content = pair.Key;
                        image.ToolTip = tt;
                        
                        //Position in the grid
                        int x = i % 3;
                        int y = (i / 3) % 3;
                        Grid.SetColumn(image, x);
                        Grid.SetRow(image, y);
                        grid1.Children.Add(image);
                        i++;
                        if (i > 11)    //we allow a maximum of 12 badges
                            break;
                    }
                    //grid1.InvalidateArrange();
                    grid1.Visibility = System.Windows.Visibility.Visible;
                    label3.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
    }
}
