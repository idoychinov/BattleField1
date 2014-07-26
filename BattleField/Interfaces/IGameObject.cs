namespace BattleField.Interfaces
{
    public interface IGameObject : IDrawable
    {
        IPosition Position { get; }
    }
}