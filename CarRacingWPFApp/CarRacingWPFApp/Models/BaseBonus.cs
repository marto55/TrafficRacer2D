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

namespace CarRacingWPFApp.Models
{
    class BaseBonus : BaseRectangle
    {
        public int Duration { get; }
        
        public BaseBonus() : base(50, 50)
        {
            Duration = 400;
        }

        public override void OnLoop(GameClass game)
        {
            // move it down the screen 3 pixels at a time
            Canvas.SetTop(HitBox, Canvas.GetTop(HitBox) + 3);
            // create a new rect with for the star and pass in the star X values inside of it
            Rect starHitBox = new Rect(Canvas.GetLeft(HitBox), Canvas.GetTop(HitBox), HitBox.Width, HitBox.Height);
            // if the player and the star collide then
            if (game.playerHitBox.IntersectsWith(starHitBox))
            {
                // add the star to the item remover list
                game.itemRemover.Add(HitBox);
                game.objectRemover.Add(this);
                // set power mode to true
                game.powerMode = true;
                // set power mode counter to 200
                game.powerModeCounter = 300;
            }
            // if the star goes beyon 400 pixels then add it to the item remover list
            if (Canvas.GetTop(HitBox) > 500)
            {
                game.itemRemover.Add(HitBox);
                game.objectRemover.Add(this);
            }
        }
    }
}
