using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CarRacingWPFApp.Models
{
    abstract class BaseRectangle
    {
        public Rectangle HitBox { get; set; }
        protected ImageBrush Image = new ImageBrush();
        public BaseRectangle(int height, int width)
        {
            HitBox = new Rectangle
            {
                Height = height,
                Width = width
            };
        }

        public abstract void OnLoop(GameClass game);
    }
}
