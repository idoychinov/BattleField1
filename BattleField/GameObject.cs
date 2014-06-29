namespace BattleField
{
    public abstract class GameObject : IDrawable
    {
        private Position position;

        protected char graphicalRepresentation;

        protected GameObject(Position position) 
        {
            this.position = position;
            
            this.graphicalRepresentation = ' ';
        }

        public Position GetCurrentPosition()
        {
            return this.position;
        }

        public char GetGraphicalRepresentation()
        {
            return this.graphicalRepresentation;
        }
    }
}
