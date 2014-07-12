namespace BattleField
{
    public class DestroyedField : GameObject
    {
        private const char Symbol = 'X';

        public DestroyedField(Position position)
            : base(position)
        {
            this.graphicalRepresentation = Symbol;
        }
    }
}