using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CarRacingWPFApp.Models
{
    class BaseBonus : BaseRectangle
    {
        public int Duration { get; set; }
        public int CoolDownTime { get; set; }
        
        public BaseBonus(int height, int width, int duration, int coolDownTime) : base(height, width)
        {
            Duration = duration;
            CoolDownTime = coolDownTime;
        }
    }
}
