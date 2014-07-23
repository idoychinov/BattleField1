using BattleField.Interfaces;

namespace BattleField
{
    abstract class DetonateMineStrategy
    {
        public abstract void DetonateMine(IGameField gameField, Mine mine);
    }
}
