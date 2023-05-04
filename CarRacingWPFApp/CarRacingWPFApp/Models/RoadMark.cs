using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacingWPFApp.Models
{
    class RoadMark : BaseRectangle
    {
        public RoadMark(int height, int width) : base(height, width)
        {
        }
        public override void OnLoop(GameClass game)
        {
            throw new NotImplementedException();
        }
    }
}
