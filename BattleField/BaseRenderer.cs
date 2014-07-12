namespace BattleField
{
    using System;
    using System.Collections.Generic;
    public class BaseRenderer : IRenderer
    {
        //public BaseRenderer(I)
        public void DrawGameField(string[,]field, int rows, int cols){

            PrintArray(rows, cols, field);

        }

        public void DrawGameStats()
        {
           
        }

        public void DrawGameObjects()
        {

        }

        private void PrintArray(int rows, int cols, string[,] workField)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(workField[i, j]);
                }

                Console.WriteLine();
            }
        }


        public void PrintMessage(string message)
        {
            Console.Write(message);
        }
    }
}
