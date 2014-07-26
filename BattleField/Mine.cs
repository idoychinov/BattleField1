namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class Mine : GameObject, IInteractableObject
    {
        private const int CharNumberOffset = 48;
        private readonly int strength;
        private IInteractionStrategy options;

        internal Mine(IPosition position,int strength, IInteractionStrategy options) 
            : base(position,(char)(CharNumberOffset + strength))
        {
            if (strength < 1 && strength > 5)
            {
                throw new ArgumentOutOfRangeException("Strength must be between 1 and 5");
            }

            this.strength = strength;
            this.options = options;
        }

        public IEnumerable<IPosition> InteractionAffectedArea()
        {
            var area = new List<IPosition>();

            return area;
        }

        public int GetStrength() 
        {
            return this.strength;
        }



    }
}