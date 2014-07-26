namespace BattleField.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IInteractableObject : IGameObject
    {
        IEnumerable<IPosition> InteractionAffectedArea();
    }
}