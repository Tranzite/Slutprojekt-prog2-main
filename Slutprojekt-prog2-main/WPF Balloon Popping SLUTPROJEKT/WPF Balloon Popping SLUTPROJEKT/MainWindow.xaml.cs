using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Threading;
using WPF_Balloon_Popping_SLUTPROJEKT.Factory;

namespace WPF_Balloon_Popping_SLUTPROJEKT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        int speed = 5; // speed will be how fast the balloons are gonna be traveling through out the screen
        int intervals = 90; // how often this game is going to create a balloon
        Random rand = new Random();

        List<Rectangle> itemRemover = new List<Rectangle>(); // The balloons that are going to reach the top and no longer reachable are going to be added into this list and it will then remove it from the canvas

        List<String> balloonTags = new List<String> { "B1", "B2", "B3", "B4", "B5" };
        List<Balloons> balloonList = new List<Balloons>();

        ImageBrush backgroundImage = new ImageBrush(); // imports and add the background image(s)

        int balloonSkins;
        int i;

        int MissedBalloons;

        bool gameIsActive;

        int score;

        MediaPlayer player = new MediaPlayer();




        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += GameEngine; // links the timer to the game
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); // every 20 miliseconds a new balloon will spawn

            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Factory/files/background-Image.jpg")); //locates and sets the image from the "Files" folder
            MyCanvas.Background = backgroundImage; // sets the background to the image in the folder

            RestartGame();
        }

        private void PopBalloon(object sender, MouseButtonEventArgs e) // this method will stop the player from clicking on buttons whilst not playing the game
        {

            if (gameIsActive)
            {
                if (e.OriginalSource is Rectangle)
                {

                    Rectangle activeRec = (Rectangle)e.OriginalSource;

                    player.Open(new Uri("../../Factory/files/pop_sound.mp3", UriKind.RelativeOrAbsolute)); //finds the pop sound in the map 
                    player.Play();

                    MyCanvas.Children.Remove(activeRec); // removes the balloon from the canvas

                    score += 1;
                    if (score % 10 == 0) // every 10 popped balloons the speed will increase by 1.
                    {
                        speed++;
                    }

                }



            }




        }

        private void StartGame() // starts the game and "resets" all of the variables and scores etc
        {
            gameTimer.Start();

            MissedBalloons = 0;
            score = 0;
            gameIsActive = true;
            speed = 3;

        }
        private void GameEngine(object sender, EventArgs e)
        {
            

            scoreText.Content = "Score: " + score;

            intervals -= 10;

            if (intervals < 1) // This entire loop checks when intervals goes below 1 it creates a balloon with a skin and gives it a number
            {
                ImageBrush balloonImage = new ImageBrush();

                balloonSkins += 1; // this determines which balloon is gonna be sent, 1-5


                if (balloonSkins > 5)
                {
                    balloonSkins = 1;
                }
                
                Balloons balloon = BalloonFactory.GetBalloon(balloonSkins);

                Rectangle newBalloon = new Rectangle // defines the balloons properties, height,width and the image through the balloonfactory
                {
                    Tag = balloon.BalloonType,
                    Height = balloon.Height,
                    Width = balloon.Width,
                    Fill = balloon.BalloonImage,

                };
                

                Canvas.SetLeft(newBalloon, rand.Next(50, 400));
                Canvas.SetTop(newBalloon, 600);
                
                MyCanvas.Children.Add(newBalloon);

                intervals = rand.Next(90, 150);
            }

            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if (balloonTags.Contains(x.Tag))
                {
                    i = rand.Next(-5, 5);
                    switch (x.Tag)
                    {
                        case "B1" :
                            var B1 = new BalloonOne();
                            Canvas.SetTop(x, Canvas.GetTop(x) - B1.Speed); // This moves the balloon towards the top of the screen

                            Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1)); // This moves the balloon side to side.
                            break;

                        case "B2":
                            var B2 = new BalloonTwo();
                            Canvas.SetTop(x, Canvas.GetTop(x) - B2.Speed); // This moves the balloon towards the top of the screen

                            Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1)); // This moves the balloon side to side.

                            break;
                        case "B3":
                            var B3 = new BalloonThree();
                            Canvas.SetTop(x, Canvas.GetTop(x) - B3.Speed); // This moves the balloon towards the top of the screen

                            Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1)); // This moves the balloon side to side.

                            break;
                        case "B4":
                            var B4 = new BalloonFour();
                            Canvas.SetTop(x, Canvas.GetTop(x) - B4.Speed); // This moves the balloon towards the top of the screen

                            Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1)); // This moves the balloon side to side.

                            break;
                        case "B5":
                            var B5 = new BalloonFive();
                            Canvas.SetTop(x, Canvas.GetTop(x) - B5.Speed); // This moves the balloon towards the top of the screen

                            Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1)); // This moves the balloon side to side.

                            break;


                    }

                    

                }
                
                if(Canvas.GetTop(x) < 20) // if the balloon reaches the top of the screen this will run 
                {
                    itemRemover.Add(x); // removes the balloon

                    MissedBalloons++;
                }

            }



            foreach (Rectangle y in itemRemover) // any "Rectangle" that exists in the list ItemRemover will be removed from the canvas
            {
                MyCanvas.Children.Remove(y);
            }

            if (MissedBalloons > 10) // if you miss 10 balloons the game is gonna stop
            {
                gameIsActive = false;
                gameTimer.Stop();
                MessageBox.Show("Game over! You missed 10 characters from shrek!\nTo play again click OK");
                RestartGame();
            }

        }

        private void RestartGame()
        {
            foreach (var x in MyCanvas.Children.OfType<Rectangle>()) //adds the balloons that are missed to the list 
            {
                itemRemover.Add(x);
            }

            foreach (Rectangle y in itemRemover) // any "Rectangle" that exists in the list ItemRemover will be removed from the canvas
            {
                MyCanvas.Children.Remove(y);
            }

            itemRemover.Clear(); // Clears the list and removes all items and resets back to 0

            StartGame(); // restarts the game



        }

        
    }
}
