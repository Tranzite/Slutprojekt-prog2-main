using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Balloon_Popping_SLUTPROJEKT.Factory
{
    class BalloonOne : Balloons
    {
        
        public BalloonOne()
        {
           BalloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/balloon1.png"));
           Speed = 2;

        }
        public override string BalloonType
        {
            get { return "B1"; }
        }

        public override int Speed { get; set ; }
        public override ImageBrush BalloonImage { get; set; }
    }
}
