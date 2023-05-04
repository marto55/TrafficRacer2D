using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CarRacingWPFApp.Models
{
    class BaseRectangle
    {
        Rectangle HitBox { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        protected ImageBrush Image = new ImageBrush();

        public BaseRectangle(int height, int width)
        {
            Height = height;
            Width = width;
            HitBox.Width = width;
            HitBox.Height = height;
        }
    }
}
