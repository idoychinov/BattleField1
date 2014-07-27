using System.Collections.Generic;
namespace BattleField.Interfaces
{
    public interface IGameField
    {
        int Size { get; }

        IGameObject GetObjectAtPosition(IPosition position);

        IDictionary<IPosition, IGameObject> AllObjects { get; }

        IDictionary<IPosition, IInteractableObject> InteractableObjects { get; }

        IInteractableObject GetInteractableObjectAtPosition(IPosition position);

        void AddObjectToAllObjects(IPosition position, IGameObject objToBeAdded);

        void RemoveObjectFromAllObjects(IPosition position);

        void AddObjectToInteractableObjects(IPosition position, IInteractableObject objToBeAdded);

        void RemoveObjectFromInteractableObjects(IPosition position);

        int GetInteractableObjectsCount();

        int GetObjectsCount();
    }
}