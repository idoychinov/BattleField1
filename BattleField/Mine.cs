namespace BattleField
{
    using System;
    using BattleField.Interfaces;

    public class Mine : GameObject, IInteractableObject
    {
        private const int CharNumberOffset = 48;
        private int strength;
        public Mine(IPosition position,int strength) 
            : base(position,(char)(CharNumberOffset + strength))
        {
            if (strength < 1 && strength > 5)
            {
                throw new ArgumentOutOfRangeException("Strength must be between 1 and 5");
            }

            this.strength = strength;
        }

    }
}