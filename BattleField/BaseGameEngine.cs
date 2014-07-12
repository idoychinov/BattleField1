namespace BattleField
{
    using System;

    public class BaseGameEngine : IEngine
    {
        private const int MinFieldSize = 1;
        private const int MaxFieldSize = 10;

        private IGameField gameField;

        private IRenderer renderer;

        // to remove 
        private int fieldSize;

        public BaseGameEngine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
        }

        public static bool Krai(int rows, int cols, string[,] полето)
        {
            bool край = true;

            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (полето[i, j] == "1" || полето[i, j] == "2" || полето[i, j] == "3" || полето[i, j] == "4" || полето[i, j] == "5")
                    {
                        край = false;
                        break;
                    }
                }
            }

            return край;
        }

        public void StartNewGame()
        {
            this.renderer.PrintMessage("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            this.fieldSize = Convert.ToInt32(Console.ReadLine());

            while (this.fieldSize < MinFieldSize || this.fieldSize > MaxFieldSize)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                this.fieldSize = Convert.ToInt32(Console.ReadLine());
            }

            this.gameField = new BaseGameField(this.fieldSize, this.fieldSize + 2, (this.fieldSize * 2) + 2);

            this.Run();
        }

        private void Run()
        {
            this.renderer.DrawGameField(this.gameField.Field, this.gameField.Rows, this.gameField.Cols);
            int countPlayed = 0;
            this.VremeEIgrachaDaDeistva(this.fieldSize, this.gameField.Rows, this.gameField.Cols, this.gameField.Field, countPlayed);
        }

        private void VremeEIgrachaDaDeistva(int n, int rows, int cols, string[,] workField, int countPlayed)
        {
            countPlayed++;
            Console.WriteLine("Please enter coordinates: ");
            string xy = Console.ReadLine();
            int x = int.Parse(xy.Substring(0, 1));
            int y = int.Parse(xy.Substring(2, 1));

            while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
            {
                Console.WriteLine("Invalid move !");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));
            }

            x += 2;
            y = (2 * y) + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    xy = Console.ReadLine();
                    x = int.Parse(xy.Substring(0, 1));
                    y = int.Parse(xy.Substring(2, 1));
                }

                x += 2;
                y = (2 * y) + 2;
            }

            int hitCoordinate = Convert.ToInt32(workField[x, y]);

            switch (hitCoordinate)
            {
                case 1:
                    this.HitOne(x, y, rows, cols, workField);
                    break;
                case 2:
                    this.PrasniDvama(x, y, rows, cols, workField);
                    break;
                case 3:
                    this.HitThree(x, y, rows, cols, workField);
                    break;
                case 4:
                    this.HitFour(x, y, rows, cols, workField);
                    break;
                case 5:
                    this.HitFive(x, y, rows, cols, workField);
                    break;
            }

            this.renderer.DrawGameField(this.gameField.Field, this.gameField.Rows, this.gameField.Cols);

            if (!Krai(rows, cols, workField))
            {
                this.VremeEIgrachaDaDeistva(n, rows, cols, workField, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }
        }

        private void HitOne(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";

            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = "X";
            }

            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = "X";
            }

            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = "X";
            }

            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = "X";
            }
        }

        private void PrasniDvama(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";
            this.HitOne(x, y, rows, cols, workField);

            if (y - 2 > 1)
            {
                workField[x, y - 2] = "X";
            }

            if (y < cols - 2)
            {
                workField[x, y + 2] = "X";
            }

            if (x - 1 > 1)
            {
                workField[x - 1, y] = "X";
            }

            if (x < rows - 1)
            {
                workField[x + 1, y] = "X";
            }
        }

        private void HitThree(int x, int y, int rows, int cols, string[,] workField)
        {
            this.PrasniDvama(x, y, rows, cols, workField);

            if (x - 2 > 1)
            {
                workField[x - 2, y] = "X";
            }

            if (x < rows - 2)
            {
                workField[x + 2, y] = "X";
            }

            if (y - 4 > 1)
            {
                workField[x, y - 4] = "X";
            }

            if (y == 18)
            {
                workField[x, y + 2] = "X";
            }
            else if (y == 20)
            {
                workField[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = "X";
                }
            }
        }

        private void HitFour(int x, int y, int rows, int cols, string[,] workField)
        {
            this.HitThree(x, y, rows, cols, workField);

            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = "X";
            }

            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = "X";
            }

            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = "X";
            }

            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = "X";
            }

            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = "X";
                }
            }
        }

        private void HitFive(int x, int y, int rows, int cols, string[,] poleZaRabota)
        {
            this.HitFour(x, y, rows, cols, poleZaRabota);

            if (x - 2 > 1 && y - 4 > 1)
            {
                poleZaRabota[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                poleZaRabota[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    poleZaRabota[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    poleZaRabota[x - 2, y + 4] = "X";
                }
            }
        }
    }
}