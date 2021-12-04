﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SpaceInvaders.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SpaceInvaders.View.HighScoreBoard
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HighScoreBoardPage : Page
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HighScoreBoardPage" /> class.
        /// </summary>
        public HighScoreBoardPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.sortByScore();
        }

        private void sortByScore()
        {
            var list = HighScoreSettings.SortByScore();
            for (var i = 0; i < 10; i++)
            {
                this.FirstListView.Items.Add(list[i][0]);
                this.SecondListView.Items.Add(list[i][1]);
                this.ThirdListView.Items.Add(list[i][2]);
            }
        }

        private void sortByLevel()
        {
            var list = HighScoreSettings.SortByLevel();
            for (var i = 0; i < 10; i++)
            {
                this.FirstListView.Items.Add(list[i][2]);
                this.SecondListView.Items.Add(list[i][0]);
                this.ThirdListView.Items.Add(list[i][1]);
            }
        }

        private void sortByPlayer()
        {
            var list = HighScoreSettings.SortByPlayer();
            for (var i = 0; i < 10; i++)
            {
                this.FirstListView.Items.Add(list[i][1]);
                this.SecondListView.Items.Add(list[i][0]);
                this.ThirdListView.Items.Add(list[i][2]);
            }
        }

        private void sortByScoreButtonClick(object sender, RoutedEventArgs e)
        {
            this.clearViews();
            this.sortByScore();
        }

        private void sortByLevelButtonClick(object sender, RoutedEventArgs e)
        {
            this.clearViews();
            this.sortByLevel();
        }

        private void sortByPlayerButtonClick(object sender, RoutedEventArgs e)
        {
            this.clearViews();
            this.sortByPlayer();
        }

        private void clearViews()
        {
            this.FirstListView.Items.Clear();
            this.SecondListView.Items.Clear();
            this.ThirdListView.Items.Clear();
        }

        private void homeButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        #endregion
    }
}