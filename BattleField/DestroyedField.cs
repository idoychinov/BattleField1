namespace BattleField
{
    using System;
    using BattleField.Interfaces;

    public class DestroyedField : GameObject
    {
        private const char Symbol = 'X';

        public DestroyedField(IPosition position)
            : base(position, Symbol)
        {
        }
    }
}