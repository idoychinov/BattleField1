namespace BattleField
{
    using BattleField.Interfaces;

    public class DetonateStrength5Mine : DetonateMineStrategy
    {
        public override void DetonateMine(IGameField gameField, Mine mine)
        {
            IPosition[] arrayOfFieldsToBeDestroyed = new IPosition[24];

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

            // strength 3
            arrayOfFieldsToBeDestroyed[8] = new Position(mine.Position.X - 2, mine.Position.Y);
            arrayOfFieldsToBeDestroyed[9] = new Position(mine.Position.X + 2, mine.Position.Y);
            arrayOfFieldsToBeDestroyed[10] = new Position(mine.Position.X, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[11] = new Position(mine.Position.X, mine.Position.Y + 2);

            // strength 4
            arrayOfFieldsToBeDestroyed[12] = new Position(mine.Position.X - 2, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[13] = new Position(mine.Position.X - 1, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[14] = new Position(mine.Position.X + 1, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[15] = new Position(mine.Position.X + 2, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[16] = new Position(mine.Position.X - 2, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[17] = new Position(mine.Position.X - 1, mine.Position.Y + 2);
            arrayOfFieldsToBeDestroyed[18] = new Position(mine.Position.X + 1, mine.Position.Y + 2);
            arrayOfFieldsToBeDestroyed[19] = new Position(mine.Position.X + 2, mine.Position.Y + 1);

            // strength 5
            arrayOfFieldsToBeDestroyed[20] = new Position(mine.Position.X - 2, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[21] = new Position(mine.Position.X + 2, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[22] = new Position(mine.Position.X - 2, mine.Position.Y + 2);
            arrayOfFieldsToBeDestroyed[23] = new Position(mine.Position.X + 2, mine.Position.Y + 2);

            Methods.DestroyFields(gameField, arrayOfFieldsToBeDestroyed);
        }
    }
}