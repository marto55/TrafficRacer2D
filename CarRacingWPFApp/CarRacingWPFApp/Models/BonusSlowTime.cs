using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingWPFApp.Models
{
    class BonusSlowTime : BaseBonus
    {
        public BonusSlowTime(int height, int width, int duration, int coolDownTime) 
            : base(height, width, duration, coolDownTime)
        {
        }
    }
}
