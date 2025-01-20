namespace PinPongFramework
{
    public class Paddle
    {
        private int x, y;
        private int height;
        private int screenHeight;

        public Paddle(int x, int y, int screenHeight, int height = 4)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.screenHeight = screenHeight;
        }

        public void MoveUp()
        {
            if (y > 0) y--;
        }

        public void MoveDown()
        {
            if (y + height < screenHeight) y++;
        }

        public void Draw(ScreenBuffer screenBuffer)
        {
            for (int i = 0; i < height; i++)
            {
                screenBuffer.SetPixel(x, y + i, '|');
            }
        }

        public bool IsBallColliding(int ballX, int ballY)
        {
            return ballX == x && ballY >= y && ballY < y + height;
        }
    }
}