using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Balloon_Popping_SLUTPROJEKT.Factory
{
    class BalloonFactory
    {
        public static Balloons GetBalloon(int type)
        {
            switch (type)
            {
                case 1:
                    return new BalloonOne();
                case 2:
                    return new BalloonTwo();
                case 3:
                    return new BalloonThree();
                case 4:
                    return new BalloonFour();
                case 5:
                    return new BalloonFive();
                default:
                    return new BalloonOne();

            }
        }
    }
}
