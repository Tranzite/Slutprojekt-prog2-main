using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Balloon_Popping_SLUTPROJEKT.Factory
{
    class BalloonOne : Balloons
    {
        private readonly string _balloonType;
        public BalloonOne(int Speed)
        {
            _balloonType = "MoneyBack";
           
        }
        public override string BalloonType
        {
            get { return _balloonType; }
        }
    }
}
