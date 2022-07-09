using Core.Models;

namespace Core.NewModels
{
    public class Ball : BaseElement
    {
        public Ball(int x, int y) : base(x, y)
        {

        }
        public void Move(Direction direction, bool eat = false)
        {
            Clear(X,Y);

            var (dx, dy) = DirectionsDictionary.directions[direction];
            X += dx;
            Y += dy;

            Draw();
        }

        public void Action(ref Map map, Direction currentDirection)
        {
            int ballX = this.X, ballY = this.Y;
            this.Move(currentDirection);
            map[ballX, ballY] = new Empty(ballX, ballY);
            map[this.X, this.Y] = new Ball(this.X, this.Y);
        }

        public void Teleport(ref Map map, int x, int y)
        {
            map[this.X, this.Y] = new Empty(this.X, this.Y);
            this.X = x;
            this.Y = y;
        }
    }
}
