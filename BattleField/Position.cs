namespace BattleField
{
    using BattleField.Interfaces;

    public class Position : IPosition
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // TODO: x or y <0 validation
        public int X { get; set; }

        public int Y { get; set; }

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