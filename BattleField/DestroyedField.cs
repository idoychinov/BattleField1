namespace BattleField
{
    public class DestroyedField : GameObject
    {
        private const char symbol = 'X';
        public DestroyedField() 
            : base()
        {
            this.graphicalRepresentation = symbol;
        }
    }
}
