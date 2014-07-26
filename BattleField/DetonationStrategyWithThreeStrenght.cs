namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class DetonationStrategyWithThreeStrenght : DetonationStrategyWithTwoStrenght
    {
        public override IList<IPosition> GetAffectedArea(IPosition currentPosition)
        {
            var area = base.GetAffectedArea(currentPosition);
            area.Add(new Position(currentPosition.X, currentPosition.Y - 2));
            area.Add(new Position(currentPosition.X, currentPosition.Y + 2));
            area.Add(new Position(currentPosition.X - 2, currentPosition.Y));
            area.Add(new Position(currentPosition.X + 2, currentPosition.Y));

            return area;
        }
    }
}