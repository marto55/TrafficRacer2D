using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace CarRacingWPFApp.Models
{
    class BonusSlowTime : BaseBonus
    {
        public BonusSlowTime(GameClass game) : base(game, 300)
        {
            ImageBrush starImage = new ImageBrush();
            starImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/blueStar.png"));
            HitBox.Fill = starImage;
        }

        public override void OnLoop(GameClass game)
        {
            if (game.currentBonus == this)
            {
                this.Duration -= 1; // reduce 1 from the power mode counter 
                flashCarColor();
                game.speed = (int)(game.speed*0.66);
                // if the power mode counter goes below 1 
                if (this.Duration < 1)
                {
                    game.objectRemover.Add(this);
                    game.playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/playerImage.png"));
                    game.w.myCanvas.Background = Brushes.Gray;
                }
            }
            else
            {
                if(base.MoveAndCheckForColision(game))
                {
                    // change the background to light coral colour
                    game.w.myCanvas.Background = Brushes.LightSteelBlue;
                }
            }
        }
    }
}
