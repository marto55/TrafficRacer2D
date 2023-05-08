using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Media.Imaging;

namespace CarRacingWPFApp.Models
{
    class BaseBonus : BaseRectangle
    {
        public int Duration { get; set; }
        protected GameClass game;
        private double i = 0;
        
        public BaseBonus(GameClass game, int duration) : base(50, 50)
        {
            this.game = game;
            Duration = duration;

            Random rand = new Random();
            // set a random left and top position for the star
            Canvas.SetLeft(HitBox, rand.Next(0, 430));
            Canvas.SetTop(HitBox, (rand.Next(100, 400) * -1));

            game.objects.Add(this);
            // finally add the new star to the canvas to be animated and to interact with the player
            game.w.myCanvas.Children.Add(this.HitBox);
        }

        protected bool MoveAndCheckForColision(GameClass game)
        {
            // move it down the screen 3 pixels at a time
            Canvas.SetTop(HitBox, Canvas.GetTop(HitBox) + game.speed*0.6);
            // create a new rect with for the star and pass in the star X values inside of it
            Rect starHitBox = new Rect(Canvas.GetLeft(HitBox), Canvas.GetTop(HitBox), HitBox.Width, HitBox.Height);
            // if the player and the star collide then
            if (game.playerHitBox.IntersectsWith(starHitBox))
            {
                // add the star to the item remover list
                game.itemRemover.Add(HitBox);
                // set power mode to true
                game.currentBonus = this;
                
                return true;
            }
            // if the star goes beyon 400 pixels then add it to the item remover list
            if (Canvas.GetTop(HitBox) > 500)
            {
                game.itemRemover.Add(HitBox);
                game.objectRemover.Add(this);
            }

            return false;
        }

        protected void flashCarColor()
        {
            i += 0.25; // increase i by .25
                       // if i is greater than 4 then reset i back to 1
            if (i > 4.78)
            {
                i = 1;
            }
            // with each increment of the i we will change the player image to one of the 4 images below
            switch (i)
            {
                case 1:
                    game.playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/powermode1.png"));
                    break;
                case 2:
                    game.playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/powermode2.png"));
                    break;
                case 3:
                    game.playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/powermode3.png"));
                    break;
                case 4:
                    game.playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/powermode4.png"));
                    break;
            }
        }
    }
}
