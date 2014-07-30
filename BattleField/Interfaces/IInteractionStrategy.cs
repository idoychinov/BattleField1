namespace BattleField.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IInteractionStrategy
    {
        IList<IPosition> GetAffectedArea(IPosition currentPosition);
    }
}
