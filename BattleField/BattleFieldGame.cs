namespace BattleField
{
    using System;

    public class BattleFieldGame
    {
        public static void Main()
        {
            IRenderer renderer = new BaseRenderer();
            IEngine engine = new BaseGameEngine(renderer);
            engine.StartNewGame();
        }
    }
}
