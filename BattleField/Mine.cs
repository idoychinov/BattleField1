namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class Mine : GameObject, IInteractableObject
    {
        private const int CharNumberOffset = 48;
        private readonly int strength;
        private IInteractionStrategy interactionStrategy;

        internal Mine(IPosition position,int strength, IInteractionStrategy interactionStrategy) 
            : base(position,(char)(CharNumberOffset + strength))
        {
            if (strength < 1 && strength > 5)
            {
                throw new ArgumentOutOfRangeException("Strength must be between 1 and 5");
            }

            this.strength = strength;
            this.interactionStrategy = interactionStrategy;
        }

        public IEnumerable<IPosition> InteractionAffectedArea()
        {
            var area = this.interactionStrategy.GetAffectedArea(this.Position);
            return area;
        }

        public int GetStrength() 
        {
            return this.strength;
        }



    }
}