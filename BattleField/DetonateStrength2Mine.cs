namespace BattleField
{
    using BattleField.Interfaces;

    public class DetonateStrength2Mine : DetonateMineStrategy
    {
        public override void DetonateMine(IGameField gameField, Mine mine)
        {
            IPosition[] arrayOfFieldsToBeDestroyed = new IPosition[8];

            // strength 1
            arrayOfFieldsToBeDestroyed[0] = new Position(mine.Position.X - 1, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[1] = new Position(mine.Position.X - 1, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[2] = new Position(mine.Position.X + 1, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[3] = new Position(mine.Position.X + 1, mine.Position.Y - 1);

            // strength 2
            arrayOfFieldsToBeDestroyed[4] = new Position(mine.Position.X, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[5] = new Position(mine.Position.X, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[6] = new Position(mine.Position.X + 1, mine.Position.Y);
            arrayOfFieldsToBeDestroyed[7] = new Position(mine.Position.X - 1, mine.Position.Y);

            Methods.DestroyFields(gameField, arrayOfFieldsToBeDestroyed);
        }
    }
}