using System;

namespace BattleField
{
    public class BaseGameEngine : IEngine
    {
        private BaseGameField gameField;

        //to remove 
        private int n;

        public BaseGameEngine()
        {
        }

        public void StartNewGame()
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            n = Convert.ToInt32(Console.ReadLine());
            while (n < 1 || n > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                n = Convert.ToInt32(Console.ReadLine());
            }

             gameField = new BaseGameField(n + 2, (n * 2) + 2);

            this.Run();
        }

        private void Run()
        {
            
            Methods.NapylniMasiva(n, gameField.Rows, gameField.Cols, gameField.field);
            Methods.PrintArray(gameField.Rows, gameField.Cols, gameField.field);
            int countPlayed = 0;
            Methods.VremeEIgrachaDaDeistva(n, gameField.Rows, gameField.Cols, gameField.field, countPlayed);
        }
    }
}