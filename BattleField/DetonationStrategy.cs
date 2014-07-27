namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public abstract class DetonationStrategy : IInteractionStrategy
    {
        public abstract IList<IPosition> GetAffectedArea(IPosition currentPosition);
    }
}