﻿using Windows.UI.Xaml;
using SpaceInvaders.View.Sprites;

namespace SpaceInvaders.Model
{
    public abstract class EnemyShip : GameObject
    {
        protected const int SpeedXDirection = 8;
        protected const int SpeedYDirection = 5;

        public bool CanShoot { get; protected set; }
        public int PointValue { get; protected set; }

        public BaseSprite Sprite1 { get; protected set; }
        public BaseSprite Sprite2 { get; protected set; }

        public void Animate()
        {
            if (Sprite.Equals(this.Sprite1))
            {
                Sprite = this.Sprite2;
                this.Sprite1.Visibility = Visibility.Collapsed;
                this.Sprite2.Visibility = Visibility.Visible;
            }
            else
            {
                Sprite = this.Sprite1;
                this.Sprite2.Visibility = Visibility.Collapsed;
                this.Sprite1.Visibility = Visibility.Visible;
            }
        }
    }
}
