using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Balloon_Popping_SLUTPROJEKT.Factory
{
    abstract class Balloons
    {
        public abstract string BalloonType { get; }
        public abstract int Speed { get; set; }

    }
}
