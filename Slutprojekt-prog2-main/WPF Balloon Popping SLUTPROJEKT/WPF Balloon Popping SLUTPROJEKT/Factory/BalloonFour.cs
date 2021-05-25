using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Balloon_Popping_SLUTPROJEKT.Factory
{
    class BalloonFour : Balloons
    {
        
        public BalloonFour()
        {
            BalloonImage = new ImageBrush();

            BalloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Factory/files/balloon4.png"));
            Speed = 4;
            Height = 80;
            Width = 60;
        }
        public override string BalloonType
        {
            get { return "B4"; }
        }

        public override int Speed { get; set ; }
        public override ImageBrush BalloonImage { get; set; }
        public override int Height { get; set; }
        public override int Width { get; set; }
    }
}
