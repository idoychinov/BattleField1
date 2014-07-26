namespace BattleField
{
    using BattleField.Interfaces;

    public class BattleFieldGame
    {
        public static void Main()
        {
            IRenderer renderer = new BaseRenderer();
            IUserInterface userInterface = new KeyboardInterface();
            IEngine engine = new BaseGameEngine(renderer, userInterface);
            engine.StartNewGame();
        }
    }
}