﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace CarRacingWPFApp.Models
{
    class GameClass
    {
        DispatcherTimer gameTimer = new DispatcherTimer(); // create a new instance of the dispatcher time called gameTimer
        public List<Rectangle> itemRemover = new List<Rectangle>(); // make a new list called item remove, this list will be used to remove any unused rectangles in the game 
        public List<BaseRectangle> objectRemover = new List<BaseRectangle>();
        Random rand = new Random(); // make a new instance of the random class called rand
        public ImageBrush playerImage = new ImageBrush(); // create a new image brush for the player
        
        public Rect playerHitBox; // this rect object will be used to calculate the player hit area with other objects
        // set the game integers including, speed for the traffic and road markings, player speed, car numbers, star counter and power mode counter
        public int speed = 5;
        public int playerSpeed = 5;
        public int carNum;
        public int previousLeftCoordinate = 0;
        public int newLeftCoordinate;
        int starCounter = 30;
        public int powerModeCounter = 400;
        // create two doubles one for score and other called i, this one will be used to animate the player car when we reach the power mode
        double score;
        double i;
        // we will need 4 boolean altogether for this game, since all of them will be false at the start we are defining them in one line. 
        public bool moveLeft, moveRight, gameOver, invulnerable;
        public BaseBonus? currentBonus;



        public GameWindow w;
        public List<BaseRectangle> objects = new List<BaseRectangle>();
        public GameClass(GameWindow window)
        {
            this.w = window;
            w.myCanvas.Focus(); // set the main focus of the program to the my canvas element, with this line it wont register the keyboard events
            gameTimer.Tick += GameLoop; // link the game timer event to the game loop event
            gameTimer.Interval = TimeSpan.FromMilliseconds(10); // this timer will run every 10 milliseconds
            StartGame();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            score += .02; // increase the score by .1 each tick of the timer
            starCounter -= 1; // reduce 1 from the star counter each tick
            w.scoreText.Content = "Score: " + score.ToString("#.#"); // this line will show the seconds passed in decimal numbers in the score text label
            playerHitBox = new Rect(Canvas.GetLeft(w.player), Canvas.GetTop(w.player), w.player.Width, w.player.Height); // assign the player hit box to the player
            // below are two if statements that are checking the player can move or right in the scene. 
            if (moveLeft == true && Canvas.GetLeft(w.player) > 11)
            {
                Canvas.SetLeft(w.player, Canvas.GetLeft(w.player) - playerSpeed);
            }
            if (moveRight == true && Canvas.GetLeft(w.player) + 80 < this.w.Width)
            {
                Canvas.SetLeft(w.player, Canvas.GetLeft(w.player) + playerSpeed);
            }
            // if the star counter integer goes below 1 then we run the make star function and also generate a random number inside of the star counter integer
            if (starCounter < 1)
            {
                MakeBonus();
                starCounter = rand.Next(1200, 1500);
            }
            // below is the main game loop, inside of this loop we will go through all of the rectangles available in this game
            foreach (var x in w.myCanvas.Children.OfType<Rectangle>())
            {
                // first we search through all of the rectangles in this game
                // then we check if any of the rectangles has a tag called road marks
                if ((string)x.Tag == "roadMarks")
                {
                    // if we find any of the rectangles with the road marks tag on it then 
                    Canvas.SetTop(x, Canvas.GetTop(x) + speed); // move it down using the speed variable
                    // if the road marks goes below the screen then move it back up top of the screen
                    if (Canvas.GetTop(x) > 510)
                    {
                        Canvas.SetTop(x, -152);
                    }
                } // end of the road marks if statement
                // if we find a rectangle with the car tag on it
                if ((string)x.Tag == "Car")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + speed - 2); // move the rectangle down using the speed variable
                    // if the car has left the scene then run then run the change cars function with the current x rectangle inside of it
                    if (Canvas.GetTop(x) > 500)
                    {
                        ChangeCars(x);
                    }
                    // create a new rect called car hit box and assign it to the x which is the cars rectangle
                    Rect carHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    // if the player hit box and the car hit box collide and the power mode is ON
                    if (playerHitBox.IntersectsWith(carHitBox) && invulnerable == true)
                    {
                        // run the change cars function with the cars rectangle X inside of it
                        ChangeCars(x);
                    }
                    else if (playerHitBox.IntersectsWith(carHitBox) && invulnerable == false)
                    {
                        // if the power is OFF and car and the player collide then

                        gameTimer.Stop(); // stop the game timer
                        w.scoreText.Content += " Press Enter to replay"; // add this text to the existing text on the label
                        gameOver = true; // set game over boolean to true
                    }
                } // end of car if statement

            } // end of for each loop

            // below are the score and speed configurations for the game
            // as you progress in the game you will score higher and traffic speed will go up
            speed = 5 + (int)score / 10;

            foreach (var x in objects)
            {
                x.OnLoop(this);
            }

            
            // each item we find inside of the item remove we will remove it from the canvas
            foreach (Rectangle y in itemRemover)
            {
                w.myCanvas.Children.Remove(y);
            }
            foreach (BaseRectangle y in objectRemover)
            {
                objects.Remove(y);
            }
            
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            // key down function will listen for you the user to press the left or right key and it will change the designated boolean to true
            if (e.Key == Key.Left)
            {
                moveLeft = true;
            }
            if (e.Key == Key.Right)
            {
                moveRight = true;
            }
        }
        public void OnKeyUP(object sender, KeyEventArgs e)
        {
            // when the player releases the left or right key it will set the designated boolean to false
            if (e.Key == Key.Left)
            {
                moveLeft = false;
            }
            if (e.Key == Key.Right)
            {
                moveRight = false;
            }
            // in this case we will listen for the enter key aswell but for this to execute we will need the game over boolean to be true
            if (e.Key == Key.Enter && gameOver == true)
            {
                // if both of these conditions are true then we will run the start game function
                StartGame();
            }
        }

        private void StartGame()
        {
            // this is the start game function, this function to reset all of the values back to their default state and start the game
            speed = 5; // set speed to 5
            starCounter = 30;
            gameTimer.Start(); // start the timer
            Canvas.SetTop(w.roadMark1, -152);
            Canvas.SetTop(w.roadMark2, 10);
            Canvas.SetTop(w.roadMark3, 176);
            Canvas.SetTop(w.roadMark4, 348);
            // set all of the boolean to false
            moveLeft = false;
            moveRight = false;
            gameOver = false;
            invulnerable = false;
            // set score to 0
            score = 0;
            // set the score text to its default content
            w.scoreText.Content = "Survived: 0 Seconds";
            // set up the player image and the star image from the images folder
            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/playerImage.png"));
            // assign the player image to the player rectangle from the canvas
            w.player.Fill = playerImage;
            // set the default background colour to gray
            w.myCanvas.Background = Brushes.Gray;

            // remove all obstacles before the start of the game and the star if it was present at the end of the previous game
            w.myCanvas.Children.OfType<Rectangle>().Where(r => (string)r.Tag == "Car").ToList().ForEach(x => { ChangeCars(x); });
            objects.Where(r => r is BaseBonus).ToList().ForEach(x => { w.myCanvas.Children.Remove(x.HitBox); });
            objects.Clear();
        }

        private void ChangeCars(Rectangle car)
        {
            // we want the game to change the traffic car images as they leave the scene and come back to it again
            carNum = rand.Next(1, 6); // to start lets generate a random number between 1 and 6
            ImageBrush carImage = new ImageBrush(); // create a new image brush for the car image 
            // the switch statement below will see what number have generated for the car num integer and 
            // based on that number it will assign a different image to the car rectangle
            switch (carNum)
            {
                case 1:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/car1.png"));
                    break;
                case 2:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/car2.png"));
                    break;
                case 3:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/car3.png"));
                    break;
                case 4:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/car4.png"));
                    break;
                case 5:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/car5.png"));
                    break;
                case 6:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/car6.png"));
                    break;
            }
            car.Fill = carImage; // assign the chosen car image to the car rectangle
            // set a random top and left position for the traffic car
            Canvas.SetTop(car, (rand.Next(100, 400) * -1));
            do
            {
                newLeftCoordinate = rand.Next(0, 430);
            } while (previousLeftCoordinate - 50 < newLeftCoordinate && newLeftCoordinate < previousLeftCoordinate + 50);

            Canvas.SetLeft(car, newLeftCoordinate);
            previousLeftCoordinate = newLeftCoordinate;
        }
        private void MakeBonus()
        {   
            int j = rand.Next();
            if (j%2 == 0){ BonusInvulnerable newStar = new BonusInvulnerable(this); }
            else { BonusSlowTime newStar = new BonusSlowTime(this); }
        }
    }
}
