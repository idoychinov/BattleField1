namespace BattleField
{
    using System;

    public class BattleFieldGame
    {
        public static void Main()
        {
            IEngine engine = new BaseGameEngine();
            engine.StartNewGame();
        }
    }
}
