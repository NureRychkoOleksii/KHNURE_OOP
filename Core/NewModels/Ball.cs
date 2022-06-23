﻿using Core.Models;

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

            Draw(X, Y);
        }
    }
}