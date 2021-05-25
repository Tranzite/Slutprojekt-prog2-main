using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Balloon_Popping_SLUTPROJEKT.Factory
{
    // To do, create a list with the balloons that are going to be sent and then give them their respective speed depending on which type of balloon they are.
    class BalloonFactory
    {
        public static Balloons GetBalloon(int type) // inherits a balloon from each respective class 1-5 and runs that code
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
