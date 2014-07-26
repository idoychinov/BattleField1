namespace BattleField
{
    using System;
    using BattleField.Interfaces;

    public class BaseRenderer : IRenderer
    {
        // public BaseRenderer(I)
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
            Console.WriteLine(new string('-', field.Size * 2));

            Position position = new Position();

            for (int i = 0; i < field.Size; i++)
            {
                position.X = i;
                Console.Write(i.ToString() + "|");

                for (int j = 0; j < field.Size; j++)
                {
                    position.Y = j;
                    var objectToDraw = field.GetObjectAtPosition(position);

                    if (objectToDraw == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(objectToDraw.GetGraphicalRepresentation() + " ");
                    }
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

        public void PrintMessage(string message)
        {
            Console.Write(message);
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