namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class Mine : GameObject, IInteractableObject
    {
        private const int MinDetonationStrength = 1;
        private const int MaxDetonationStrength = 5;

        private const int CharNumberOffset = (int)'0';
        private readonly int strength;
        private IInteractionStrategy interactionStrategy;

        internal Mine(IPosition position, int strength, IInteractionStrategy interactionStrategy)
            : base(position, (char)(CharNumberOffset + strength))
        {
            if (MinDetonationStrength > strength || strength > MaxDetonationStrength)
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