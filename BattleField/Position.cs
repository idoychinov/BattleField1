namespace BattleField
{
    using System;
    using BattleField.Interfaces;

    public class Position : IPosition
    {
        private int x;
        private int y;

        public Position()
        {
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // TODO: x or y <0 validation
        public int X 
        {
            get
            {
                return this.x;
            }

            set 
            {
                this.x = value;
            }
        }

        public int Y 
        {
            get
            {
                return this.y;
            }

            set 
            {
                this.y = value;
            }
        }

        public static bool operator ==(Position first, Position second)
        {
            if (object.ReferenceEquals(first, second))
            {
                return true;
            }

            if ((object)first == null || (object)second == null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Position first, Position second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position positionObj = obj as Position;

            if ((object)positionObj == null)
            {
                return false;
            }

            return this.X.Equals(positionObj.X) && this.Y.Equals(positionObj.Y);
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }
    }
}