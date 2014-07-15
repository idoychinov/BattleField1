namespace BattleField
{
    using System;
    using BattleField.Interfaces;

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

        public static bool EndGame(IGameField gamefield)
        {
            bool endGame = true;

            if (gamefield.GetInteractableObjectsCount() != 0)
            {
                endGame = false;
            }
            return endGame;
        }

            //for (int i = 2; i < rows; i++)
            //{
            //    for (int j = 2; j < cols; j++)
            //    {
            //        if (полето[i, j] == "1" || полето[i, j] == "2" || полето[i, j] == "3" || полето[i, j] == "4" || полето[i, j] == "5")
            //        {
            //            край = false;
            //            break;
            //        }
            //    }
            //}
            //
            //return край;
            //}

        public void StartNewGame()
        {
            this.renderer.PrintMessage("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            this.fieldSize = Convert.ToInt32(Console.ReadLine());

            while (this.fieldSize < MinFieldSize || this.fieldSize > MaxFieldSize)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                this.fieldSize = Convert.ToInt32(Console.ReadLine());
            }

            gameField = new BaseGameField(fieldSize);



            this.Run();
        }

        private void Run()
        {
            this.renderer.DrawGameField(gameField);
            int countPlayed = 0;
            this.VremeEIgrachaDaDeistva(countPlayed);
        }

        private void VremeEIgrachaDaDeistva(int countPlayed)
        {

            while (true)
            {
                countPlayed++;
                Console.WriteLine("Please enter coordinates: ");
                string xy = Console.ReadLine();
                int x = int.Parse(xy.Substring(0, 1));
                int y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x >= this.gameField.Size) && (y < 0 || y >= this.gameField.Size))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    xy = Console.ReadLine();
                    x = int.Parse(xy.Substring(0, 1));
                    y = int.Parse(xy.Substring(2, 1));
                }

                //x += 2;
                //y = (2 * y) + 2;
                var position = new Position();

                position.X = x;
                position.Y = y;

                if (gameField.GetInteractableObjectAtPosition(position) == null)
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                }
                else
                {
                    DetonateMineAtPosition(position);
                }
                renderer.DrawGameField(gameField);
                if (EndGame(gameField))
                {
                    break;
                }
            }


            Console.WriteLine("Game over. Detonated mines: " + countPlayed);



            //int hitCoordinate = Convert.ToInt32(workField[x, y]);
            //switch (hitCoordinate)
            //{
            //    case 1: 
            //        HitOne(x, y, rows, cols, workField); 
            //        break;
            //    case 2:
            //        PrasniDvama(x, y, rows, cols, workField);
            //        break;
            //    case 3:
            //        HitThree(x, y, rows, cols, workField);
            //        break;
            //    case 4:
            //        HitFour(x, y, rows, cols, workField);
            //        break;
            //    case 5:
            //        HitFive(x, y, rows, cols, workField);
            //        break;
            //}



        }
        /*
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
        */
        private void DetonateMineAtPosition(IPosition position)
        {
            Mine mine = gameField.GetInteractableObjectAtPosition(position) as Mine;

            gameField.RemoveObjectFromInteractableObjects(position);
            gameField.RemoveObjectFromAllObjects(position);
            gameField.AddObjectToAllObjects(position, new DestroyedField(position));
            DestroyAllAroundMine(mine);
        }

        private IPosition[] DestroyAllAroundMine(Mine mine)
        {
            IPosition[] arrayOfFieldsToBeDestroyed;
            arrayOfFieldsToBeDestroyed = new IPosition[24];
            //strength 1
            arrayOfFieldsToBeDestroyed[0] = new Position(mine.Position.X - 1, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[1] = new Position(mine.Position.X - 1, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[2] = new Position(mine.Position.X + 1, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[3] = new Position(mine.Position.X + 1, mine.Position.Y - 1);
            //strength 2
            arrayOfFieldsToBeDestroyed[4] = new Position(mine.Position.X, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[5] = new Position(mine.Position.X, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[6] = new Position(mine.Position.X + 1, mine.Position.Y);
            arrayOfFieldsToBeDestroyed[7] = new Position(mine.Position.X - 1, mine.Position.Y);
            //strength 3
            arrayOfFieldsToBeDestroyed[8] = new Position(mine.Position.X - 2, mine.Position.Y);
            arrayOfFieldsToBeDestroyed[9] = new Position(mine.Position.X + 2, mine.Position.Y);
            arrayOfFieldsToBeDestroyed[10] = new Position(mine.Position.X, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[11] = new Position(mine.Position.X, mine.Position.Y + 2);
            //strength 4
            arrayOfFieldsToBeDestroyed[12] = new Position(mine.Position.X - 2, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[13] = new Position(mine.Position.X - 1, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[14] = new Position(mine.Position.X + 1, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[15] = new Position(mine.Position.X + 2, mine.Position.Y - 1);
            arrayOfFieldsToBeDestroyed[16] = new Position(mine.Position.X - 2, mine.Position.Y + 1);
            arrayOfFieldsToBeDestroyed[17] = new Position(mine.Position.X - 1, mine.Position.Y + 2);
            arrayOfFieldsToBeDestroyed[18] = new Position(mine.Position.X + 1, mine.Position.Y + 2);
            arrayOfFieldsToBeDestroyed[19] = new Position(mine.Position.X + 2, mine.Position.Y + 1);
            //strength 5
            arrayOfFieldsToBeDestroyed[20] = new Position(mine.Position.X - 2, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[21] = new Position(mine.Position.X + 2, mine.Position.Y - 2);
            arrayOfFieldsToBeDestroyed[22] = new Position(mine.Position.X - 2, mine.Position.Y + 2);
            arrayOfFieldsToBeDestroyed[23] = new Position(mine.Position.X + 2, mine.Position.Y + 2);

            switch (mine.GetStrength())
            {
                case 1:
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed[i]);
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed[i]);
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed[i]);
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed[i]);
                        }
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 24; i++)
                        {
                            DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed[i]);
                        }
                        break;
                    }

            }


            return arrayOfFieldsToBeDestroyed;
        }

        private void DestroyFieldsAroundDetonatedMine(IPosition position)
        {

            if (IsPositionInsideField(gameField, position))
            {
                gameField.RemoveObjectFromInteractableObjects(position);
                gameField.RemoveObjectFromAllObjects(position);
                gameField.AddObjectToAllObjects(position, new DestroyedField(position));
            }


        }

        private bool IsPositionInsideField(IGameField gameField, IPosition position)
        {
            if (position.X >=0 && position.Y >=0)
            {
                return true;
            }
            return false;
        }
    }
}