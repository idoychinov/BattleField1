namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class DetonationStrategyWithFiveStrenght : DetonationStrategyWithFourStrenght
    {
        public override IList<IPosition> GetAffectedArea(IPosition currentPosition)
        {
            var area = base.GetAffectedArea(currentPosition);
            area.Add(new Position(currentPosition.X - 2, currentPosition.Y - 2));
            area.Add(new Position(currentPosition.X - 2, currentPosition.Y + 2));
            area.Add(new Position(currentPosition.X + 2, currentPosition.Y - 2));
            area.Add(new Position(currentPosition.X + 2, currentPosition.Y + 2));

            return area;
        }
    }
}