namespace BattleField
{
    using System;
    using BattleField.Interfaces;

    public class MineFactory
    {
        public Mine CreateMine(IPosition position,int mineStrength)
        {
            switch (mineStrength)
            {
                case 1:
                    return new Mine(position,mineStrength,new DetonationStrategyWithOneStrenght());
                case 2:
                    return new Mine(position,mineStrength,new DetonationStrategyWithTwoStrenght());
                case 3:
                    return new Mine(position,mineStrength,new DetonationStrategyWithThreeStrenght());
                case 4:
                    return new Mine(position,mineStrength,new DetonationStrategyWithFourStrenght());
                case 5:
                    return new Mine(position,mineStrength,new DetonationStrategyWithFiveStrenght());
                    
                default:
                    throw new ArgumentOutOfRangeException("Incorect mine strength");
            }
        }
    }
}
