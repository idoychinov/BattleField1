namespace BattleField
{
    public abstract class GameObject : IDrawable
    {

        protected char graphicalRepresentation;

        protected GameObject() 
        {
            this.graphicalRepresentation = ' ';
        }

        public string GetGraphicalRepresentation()
        {
            return this.graphicalRepresentation.ToString();
        }

        public virtual bool IsInteractable()
        {
            return false;
        }
    }
}
