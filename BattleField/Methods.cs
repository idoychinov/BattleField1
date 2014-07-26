namespace BattleField
{
    using BattleField.Interfaces;

    public static class Methods
    {
        public static void DestroyFields(IGameField gameField, IPosition[] positions)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (IsPositionInsideField(gameField, positions[i]))
                {
                    gameField.RemoveObjectFromInteractableObjects(positions[i]);
                    gameField.RemoveObjectFromAllObjects(positions[i]);
                    gameField.AddObjectToAllObjects(positions[i], new DestroyedField(positions[i]));
                }
            }
        }

        public static bool IsPositionInsideField(IGameField gameField, IPosition position)
        {
            if ((position.X >= 0 && position.X <= gameField.Size) && (position.Y >= 0 && position.Y <= gameField.Size))
            {
                return true;
            }

            return false;
        }

        // tuk e magiqta!!!!
        // we got the POWER
    }
}