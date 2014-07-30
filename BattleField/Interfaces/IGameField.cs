namespace BattleField.Interfaces
{
    using System.Collections.Generic;

    public interface IGameField
    {
        int Size { get; }

        IDictionary<IPosition, IGameObject> AllObjects { get; }

        IDictionary<IPosition, IInteractableObject> InteractableObjects { get; }

        IInteractableObject GetInteractableObjectAtPosition(IPosition position);

        IGameObject GetObjectAtPosition(IPosition position);

        void AddObjectToAllObjects(IGameObject objToBeAdded);

        void RemoveObjectFromAllObjects(IPosition position);

        void AddObjectToInteractableObjects(IInteractableObject objToBeAdded);

        void RemoveObjectFromInteractableObjects(IPosition position);

        int GetInteractableObjectsCount();

        int GetObjectsCount();
    }
}