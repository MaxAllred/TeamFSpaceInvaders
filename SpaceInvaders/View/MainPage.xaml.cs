﻿using System;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using SpaceInvaders.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpaceInvaders.View
{
    /// <summary>
    ///     The main page for the game.
    /// </summary>
    public sealed partial class MainPage
    {
        #region Data members

        /// <summary>
        ///     The application height
        /// </summary>
        public const double ApplicationHeight = 480;

        /// <summary>
        ///     The application width
        /// </summary>
        public const double ApplicationWidth = 640;

        private int fireRate;

        private readonly GameManager gameManager;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            DispatcherTimer enemyTimer;
            this.InitializeComponent();
            enemyTimer = new DispatcherTimer();
            enemyTimer.Tick += this.timeTick;
            enemyTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            enemyTimer.Start();

            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));

            Window.Current.CoreWindow.KeyDown += this.coreWindowOnKeyDown;

            this.gameManager = new GameManager(ApplicationHeight, ApplicationWidth);
            this.gameManager.InitializeGame(this.theCanvas);
        }

        #endregion

        #region Methods

        private void coreWindowOnKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    this.gameManager.MovePlayerShipLeft();
                    break;
                case VirtualKey.Right:
                    this.gameManager.MovePlayerShipRight();
                    break;
                case VirtualKey.Space:
                    if (this.fireRate > 2)
                    {
                        this.gameManager.FirePlayerBullet();
                        this.fireRate = 0;
                    }

                    break;
            }
        }

        private void timeTick(object sender, object e)
        {
            this.fireRate++;
            var rand = new Random();
            if (rand.Next(10) == 1)
            {
                this.gameManager.EnemyManager.FireEnemyBullet();
            }

            if (this.gameManager.GameOver)
            {
                this.gameManager.HandleGameOver();
            }
            else
            {
                this.gameManager.MoveEnemyShips();

                this.gameManager.CheckForCollisions();
            }
        }

        #endregion
    }
}