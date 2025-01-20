namespace PinPongFramework
{
    public class Ball
    {
        private int x, y;
        private int directionX = 1, directionY = 1;
        private int screenWidth, screenHeight;

        public Ball(int startX, int startY, int screenWidth, int screenHeight)
        {
            x = startX;
            y = startY;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void Move()
        {
            x += directionX;
            y += directionY;

            if (y <= 0 || y >= screenHeight - 1)
                directionY *= -1;
        }

        public void ChangeDirection()
        {
            directionX *= -1;
        }

        public bool CheckCollision(Paddle paddle)
        {
            return paddle.IsBallColliding(x, y);
        }

        public bool IsOutOfBounds()
        {
            return x <= 0 || x >= screenWidth - 1;
        }

        public void Draw(ScreenBuffer screenBuffer)
        {
            screenBuffer.SetPixel(x, y, 'O');
        }
    }
}