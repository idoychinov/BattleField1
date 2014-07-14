namespace BattleField.Interfaces
{
    public interface IGameField
    {
        IGameObject GetObjectAtPosition(IPosition position);

        IInteractableObject GetInteractableObjectAtPosition(IPosition position);

        int Size { get; }
    }
}