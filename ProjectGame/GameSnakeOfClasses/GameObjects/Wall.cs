using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializeWallBorder();
        }

        private const char wallsymbol = '\u25A0';

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallsymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallsymbol);
            }
        }

        private void InitializeWallBorder()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }
    }
}
