namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class DetonationStrategyWithOneStrenght : DetonationStrategy
    {
        public override IList<IPosition> GetAffectedArea(IPosition currentPosition)
        {
            var area = new List<IPosition>();
            area.Add(new Position(currentPosition.X - 1, currentPosition.Y - 1));
            area.Add(new Position(currentPosition.X - 1, currentPosition.Y + 1));
            area.Add(new Position(currentPosition.X + 1, currentPosition.Y + 1));
            area.Add(new Position(currentPosition.X + 1, currentPosition.Y - 1));

            return area;
        }
    }
}