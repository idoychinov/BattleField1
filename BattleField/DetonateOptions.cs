namespace BattleField
{
    using BattleField.Interfaces;

    public class DetonateOptions
    {
        private readonly DetonateMineStrategy strategy;

        // Constructor 
        public DetonateOptions(DetonateMineStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Detonate(IGameField gameField, Mine mine)
        {
            this.strategy.DetonateMine(gameField, mine);
        }
    }
}