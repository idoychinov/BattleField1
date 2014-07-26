namespace BattleField
{
    using BattleField.Interfaces;

    public abstract class DetonateMineStrategy
    {
        public abstract void DetonateMine(IGameField gameField, Mine mine);
    }
}