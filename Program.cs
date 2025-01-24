using System;
/*
I made a simple game structure.
These are the classes:
    MOVING CLASS
    Gravity Class
    preventing the character to go out of boundries
    Questions Class
    ValidationClass for questions

    BUT THIS SHOULD BE THE STARTING BASE OF THE GAME
*/
using System;

namespace MovingCharacterGame
{
    // PLAYER CLASS FOR MOVEMENTS ADN ALSO STATE (WHERE THE PLAYER IS)
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsJumping { get; set; }

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
            IsJumping = false;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "UP":
                    if (!IsJumping) 
                    {
                        IsJumping = true;
                        Y--; 
                    }
                    break;
                case "DOWN":
                    Y++; 
                    break;
                case "LEFT":
                    X--; 
                    break;
                case "RIGHT":
                    X++; 
                    break;
            }
        }

        public void ApplyGravity()
        {
            if (IsJumping)
            {
                if (Y < 5)
                    Y++;
                else
                    IsJumping = false;
            }
        }

        public void PreventOutOfBounds()
        {
            X = Math.Max(0, Math.Min(X, Console.WindowWidth - 1));
            Y = Math.Max(0, Math.Min(Y, Console.WindowHeight - 1));
        }
    }

    // Class to handle the game logic (questions, answers, etc.)
    public class GameLogic
    {
        public static string GetQuestion(int level)
        {
            return level switch
            {
                1 => "What is 2 + 2?",
                2 => "What is the capital of France?",
                3 => "What is the square root of 16?",
                4 => "Name the programming language this game is written in.",
                5 => "What is the answer to life, the universe, and everything?",
                _ => "Unknown question."
            };
        }

        public static bool ValidateAnswer(int level, string answer)
        {
            return level switch
            {
                1 => answer == "4",
                2 => answer == "paris",
                3 => answer == "4",
                4 => answer == "c#",
                5 => answer == "42",
                _ => false
            };
        }
    }

    // Class to handle player lives
    public class Lives
    {
        public int RemainingLives { get; set; }

        public Lives(int initialLives)
        {
            RemainingLives = initialLives;
        }

        // Decrease a life and check if player is dead
        public bool LoseLife()
        {
            RemainingLives--;
            return RemainingLives > 0;
        }

        public void DisplayLives()
        {
            Console.WriteLine($"Remaining Lives: {RemainingLives}");
        }
    }

    // Main Game Class that integrates everything
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game!");
            Console.WriteLine("Controls: Arrow keys or WASD to move, SPACE to jump.");

            int level = 1;
            bool gameRunning = true;
            Random random = new Random();

            // This CREATES A PLAYER with 3 lives, and the coordinates of the player
            Player player = new Player(10, 5);
            Lives lives = new Lives(3);

            // THIS IS THE loop of the game / where it starts
            while (gameRunning && level <= 5)
            {
                Console.Clear();
                Console.WriteLine($"Level {level}");

                

                // // Display player position and lives
                Console.SetCursorPosition(player.X, player.Y);
                Console.WriteLine("O");
                // Random head position for obstacles
                bool headOnLeft = random.Next(2) == 0;
                Console.WriteLine($"Head position: {(headOnLeft ? "Left" : "Right")}");

                lives.DisplayLives();

                // Get user input for movement
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    string direction = key switch
                    {
                        ConsoleKey.W => "UP",
                        ConsoleKey.UpArrow => "UP",
                        ConsoleKey.S => "DOWN",
                        ConsoleKey.DownArrow => "DOWN",
                        ConsoleKey.A => "LEFT",
                        ConsoleKey.LeftArrow => "LEFT",
                        ConsoleKey.D => "RIGHT",
                        ConsoleKey.RightArrow => "RIGHT",
                        ConsoleKey.Spacebar => "JUMP",
                        _ => ""
                    };

                    if (!string.IsNullOrEmpty(direction))
                    {
                        player.Move(direction);
                        Console.WriteLine($"Going {direction}!");
                    }
                }

                // Apply gravity to the player: look at this function you can use this for water gravity as well
                player.ApplyGravity();

                // Prevent character from moving out of bounds you can adjust this as you want depends on the matrix of the game
                player.PreventOutOfBounds();

            

                System.Threading.Thread.Sleep(10); // Pace of the loop YOU CAN SLOW THIS FOR SLOWER GAME

                // End of level question and validation
                Console.WriteLine($"You reached the end of Level {level}!");
                string question = GameLogic.GetQuestion(level);
                Console.WriteLine(question);

                string answer = Console.ReadLine()?.Trim().ToLower();
                if (GameLogic.ValidateAnswer(level, answer))
                {
                    Console.WriteLine("Correct! Level unlocked.");
                    level++;
                }
                else
                {
                    Console.WriteLine("Wrong answer! Try again.");
                }

                if (level > 5)
                {
                    Console.WriteLine("Congratulations! You completed all levels.");
                    gameRunning = false;
                }
            }

            Console.WriteLine("Game Over. Thanks for playing!");
        }
    }
}

