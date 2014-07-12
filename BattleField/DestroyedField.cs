namespace BattleField
{
    public class DestroyedField : GameObject
    {
        private const char Symbol = 'X';
        public DestroyedField() 
            : base()
        {
            this.graphicalRepresentation = Symbol;
        }
    }
}