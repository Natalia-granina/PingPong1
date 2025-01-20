using System;

namespace PinPongFramework
{
    public class ScreenBuffer
    {
        private (char, ConsoleColor) [,] currentBuffer;
        private char[,] previousBuffer;
        private int width, height;
        private Random random;

        public ScreenBuffer(int width, int height)
        {
            random = new Random();
            this.width = width;
            this.height = height;
            currentBuffer = new (char, ConsoleColor) [width, height];
            previousBuffer = new char[width, height];
        }

        public void SetPixel(int x, int y, char c)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                //TODO: A new feature can be added: each pixel will be colored in a random color.
                currentBuffer[x, y] = (c, (ConsoleColor)random.Next(1, 15));
            }
        }

        public void Clear()
        {
            Array.Clear(currentBuffer, 0, currentBuffer.Length);
        }

        public void Render()
        {
            //TODO: Change the render color of all elements.
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (currentBuffer[x, y].Item1 != previousBuffer[x, y])
                    {
                         Console.ForegroundColor = currentBuffer[x, y].Item2;
                        Console.SetCursorPosition(x, y);
                        Console.Write(currentBuffer[x, y].Item1 == '\0' ? ' ' : currentBuffer[x, y].Item1);
                        previousBuffer[x, y] = currentBuffer[x, y].Item1;
                       
                    }
                }
            }
        }
    }
}