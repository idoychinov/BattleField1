using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleField.Interfaces;

namespace BattleField
{
    class DetonateStrength1Mine : DetonateMineStrategy
    {
        public override void DetonateMine(IGameField gameField, Mine mine)
        {
            IPosition[] arrayOfFieldsToBeDestroyed = new IPosition[4];
            //strength 1
            arrayOfFieldsToBeDestroyed[0] = new Position(mine.Position.X - 1, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[1] = new Position(mine.Position.X - 1, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[2] = new Position(mine.Position.X + 1, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[3] = new Position(mine.Position.X + 1, mine.Position.Y - 1);

            Methods.DestroyFields(gameField, arrayOfFieldsToBeDestroyed);
        }
    }
}
