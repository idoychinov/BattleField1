namespace BattleField
{
    using System;
    using System.Collections.Generic;
    public class BaseRenderer : IRenderer
    {
        //public BaseRenderer(I)
        public void DrawGameField(IGameField field)
        {
            Console.WriteLine();
            Console.Write("  ");
            for (int i = 0; i < field.Size; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write(' ');
            Console.WriteLine(new string('-',field.Size*2));

            Position position = new Position();
            for (int i = 0; i < field.Size; i++) 
            {
                position.X=i;
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < field.Size; j++)
                {
                    position.Y=j;
                    var objectRepresentation = field.GetObjectAtPosition(position).GetGraphicalRepresentation();
                    Console.Write(objectRepresentation + " ");
                }
                Console.WriteLine();
            }
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
    }
}
