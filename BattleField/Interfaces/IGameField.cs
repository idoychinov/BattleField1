namespace BattleField.Interfaces
{
    public interface IGameField
    {
        IGameObject GetObjectAtPosition(IPosition position);

        IInteractableObject GetInteractableObjectAtPosition(IPosition position);

        void AddObjectToAllObjects(IPosition position, IGameObject objToBeAdded);

        void RemoveObjectFromAllObjects(IPosition position);


        void AddObjectToInteractableObjects(IPosition position, IInteractableObject objToBeAdded);

        void RemoveObjectFromInteractableObjects(IPosition position);

        int GetInteractableObjectsCount();


        int Size { get; }
    }
}