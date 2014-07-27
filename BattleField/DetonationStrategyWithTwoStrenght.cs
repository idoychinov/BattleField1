namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class DetonationStrategyWithTwoStrenght : DetonationStrategyWithOneStrenght
    {
        public override IList<IPosition> GetAffectedArea(IPosition currentPosition)
        {
            var area = base.GetAffectedArea(currentPosition);
            area.Add(new Position(currentPosition.X, currentPosition.Y - 1));
            area.Add(new Position(currentPosition.X, currentPosition.Y + 1));
            area.Add(new Position(currentPosition.X - 1, currentPosition.Y));
            area.Add(new Position(currentPosition.X + 1, currentPosition.Y));

            return area;
        }
    }
}