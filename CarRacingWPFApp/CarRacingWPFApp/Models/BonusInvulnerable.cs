using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CarRacingWPFApp.Models
{
    class BonusInvulnerable : BaseBonus
    {
        private int originalGameSpeed;
        private double i = 0;
        public BonusInvulnerable(GameClass game) : base(game, 400)
        {
            ImageBrush starImage = new ImageBrush();
            starImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/star.png"));
            HitBox.Fill = starImage;
        }

        public override void OnLoop(GameClass game)
        {
            if(game.currentBonus == this)
            {
                this.Duration -= 1; // reduce 1 from the power mode counter 
                flashCarColor();
                // if the power mode counter goes below 1 
                if (this.Duration < 1)
                {
                    game.objectRemover.Add(this);
                    game.invulnerable = false;
                    game.playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/playerImage.png"));
                    game.w.myCanvas.Background = Brushes.Gray;
                }
            }
            else
            {
                if (base.MoveAndCheckForColision(game))
                {
                    // change the background to light coral colour
                    game.w.myCanvas.Background = Brushes.LightCoral;

                    game.invulnerable = true;
                }
            }
        }
    }
}
