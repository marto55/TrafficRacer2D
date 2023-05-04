using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarRacingWPFApp.Models
{
    class BonusInvulnerable : BaseBonus
    {
        public BonusInvulnerable(int height, int width, int duration, int coolDownTime) 
            : base(height, width, duration, coolDownTime)
        {
            this.Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/star.png"));
        }
    }
}
