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
        public BonusInvulnerable() : base()
        {
            ImageBrush starImage = new ImageBrush();
            starImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/star.png"));
            HitBox.Fill = starImage;
        }
    }
}
