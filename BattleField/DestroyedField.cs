namespace BattleField
{
    public class DestroyedField : GameObject
    {
        private const char symbol = 'X';
        public DestroyedField(Position position) 
            : base(position)
        {
            this.graphicalRepresentation = symbol;
        }
    }
}
