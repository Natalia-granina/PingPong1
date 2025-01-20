using System;
using System.Threading;

namespace PinPongFramework
{
    public class Game
    {
        private readonly int gameSpeed;
        private Paddle paddle1;
        private Paddle paddle2;
        private Ball ball;
        private ScreenBuffer screenBuffer;
        private bool gameRunning;
        private int screenWidth = 80, screenHeight = 20;

        public Game(int gameSpeed = 150)
        {
            this.gameSpeed = gameSpeed;
            Console.CursorVisible = false;
            Console.SetWindowSize(screenWidth, screenHeight);

            // TODO: The paddles should appear at a random height.
            paddle1 = new Paddle(2, 5, screenHeight);
            paddle2 = new Paddle(screenWidth - 3, 5, screenHeight);
            ball = new Ball(screenWidth / 2, screenHeight / 2, screenWidth, screenHeight);
            screenBuffer = new ScreenBuffer(screenWidth, screenHeight);
            gameRunning = true;
        }

        public void Start()
        {
            var inputThread = new Thread(InputHandler);
            inputThread.Start();

            while (gameRunning)
            {                        //TODO: Fix the bug in element rendering.
                DrawGame();
                UpdateGame();
                Thread.Sleep(gameSpeed); //TODO: Create a separate variable to control the game speed.
            }
        }

        private void InputHandler()
        {
            while (gameRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.W:
                            paddle1.MoveUp();
                            break;
                        case ConsoleKey.S:
                            paddle1.MoveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            paddle2.MoveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            paddle2.MoveDown();
                            break;
                        case ConsoleKey.Escape:
                            gameRunning = false;
                            break;
                    }
                }
            }
        }

        private void DrawGame()
        {
            screenBuffer.Clear();

            paddle1.Draw(screenBuffer);
            paddle2.Draw(screenBuffer);
            ball.Draw(screenBuffer);

            screenBuffer.Render();
        }

        private void UpdateGame()
        {
            ball.Move();

            if (ball.CheckCollision(paddle1) || ball.CheckCollision(paddle2))
            {
                ball.ChangeDirection();
            }

            if (ball.IsOutOfBounds())
            {
                gameRunning = false;
                Console.Clear();
                Console.SetCursorPosition(screenWidth / 2 - 5, screenHeight / 2);
                Console.WriteLine("Game Over");
                Thread.Sleep(2000);
            }
        }
    }
}