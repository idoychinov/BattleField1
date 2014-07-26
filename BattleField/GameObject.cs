namespace BattleField
{
    using BattleField.Interfaces;

    public abstract class GameObject : IGameObject
    {
        private char graphicalRepresentation;

        protected GameObject(IPosition position) :
            this(position, ' ')
        {
        }

        protected GameObject(IPosition position, char graphicalRepresentation)
        {
            this.Position = position;
            this.graphicalRepresentation = graphicalRepresentation;
        }

        public IPosition Position { get; private set; }

        public string GetGraphicalRepresentation()
        {
            return this.graphicalRepresentation.ToString();
        }
    }
}