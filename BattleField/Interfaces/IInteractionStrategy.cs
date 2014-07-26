namespace BattleField.Interfaces
{
    using System;
    using System.Collections.Generic;

    interface IInteractionStrategy
    {
        IList<IPosition> GetAffectedArea(IPosition currentPosition);
    }
}
