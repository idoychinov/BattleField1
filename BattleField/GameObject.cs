namespace BattleField
{
    using BattleField.Interfaces;

    public abstract class GameObject : IGameObject
    {

        protected char graphicalRepresentation;
        private IPosition position;

        protected GameObject(IPosition position) :
            this(position,' ')
        {
        }

        protected GameObject(IPosition position, char graphicalRepresentation) 
        {
            this.Position = position;
            this.graphicalRepresentation = graphicalRepresentation;
        }

        public IPosition Position 
        {
            get
            {
                return this.position;
            }

            private set
            {
                this.position = value;
            }
        }

        public string GetGraphicalRepresentation()
        {
            return this.graphicalRepresentation.ToString();
        }

    }
}
