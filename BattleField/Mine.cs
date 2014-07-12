﻿namespace BattleField
{
    using System;

    public class Mine : GameObject
    {
        private int strength;
        public Mine(int strength) 
            : base()
        {
            if (strength < 1 && strength > 5)
            {
                throw new ArgumentOutOfRangeException("Strength must be between 1 and 5");
            }

            this.strength = strength;
            this.graphicalRepresentation = (char)(48 + strength);
        }

        public override bool IsInteractable()
        {
            return true;
        }
    }
}