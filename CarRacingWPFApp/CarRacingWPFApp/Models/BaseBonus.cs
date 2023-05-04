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
        public int Duration { get; }
        
        public BaseBonus() : base(50, 50)
        {
            Duration = 400;
        }
    }
}
