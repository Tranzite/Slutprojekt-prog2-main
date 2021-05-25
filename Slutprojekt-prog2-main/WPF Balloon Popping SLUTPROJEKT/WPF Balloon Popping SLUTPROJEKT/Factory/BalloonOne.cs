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
           BalloonImage = new ImageBrush();
           BalloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Factory/files/balloon1.png"));
           Speed = 1;
           Height = 80;
           Width = 60;
        }
        public override string BalloonType
        {
            get { return "B1"; }
        }

        public override int Speed { get; set ; }
        public override ImageBrush BalloonImage { get; set; }
        public override int Height { get; set; }
        public override int Width { get; set; }
    }
}
