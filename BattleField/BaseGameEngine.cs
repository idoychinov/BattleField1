namespace BattleField
{
    using System;
    using BattleField.Interfaces;

    public class BaseGameEngine : IEngine
    {
        private const int MinFieldSize = 1;
        private const int MaxFieldSize = 10;

        private IGameField gameField;

        private readonly IRenderer renderer;

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
                if (xy != null)
                {
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

                    var position = new Position { X = x, Y = y };

                    if (gameField.GetInteractableObjectAtPosition(position) == null)
                    {
                        Console.WriteLine("Invalid move !");
                        Console.WriteLine("Please enter coordinates: ");
                    }
                    else
                    {
                        DetonateMineAtPosition(position);
                    }
                }
                renderer.DrawGameField(gameField);
                if (EndGame(gameField))
                {
                    break;
                }
            }
            Console.WriteLine("Game over. Detonated mines: " + countPlayed);
        }
        private void DetonateMineAtPosition(IPosition position)
        {
            Mine mine = gameField.GetInteractableObjectAtPosition(position) as Mine;
            gameField.RemoveObjectFromInteractableObjects(position);
            gameField.RemoveObjectFromAllObjects(position);
            gameField.AddObjectToAllObjects(position, new DestroyedField(position));
            DestroyAllFieldsAroundMine(mine);
        }

        private void DestroyAllFieldsAroundMine(Mine mine)
        {
            IPosition[] arrayOfFieldsToBeDestroyed = new IPosition[24];
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
                        DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed, 0, 4);
                        break;
                    }
                case 2:
                    {
                        DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed, 0, 8);
                        break;
                    }
                case 3:
                    {
                        DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed, 0, 12);
                        break;
                    }
                case 4:
                    {
                        DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed, 0, 20);
                        break;
                    }
                case 5:
                    {
                        DestroyFieldsAroundDetonatedMine(arrayOfFieldsToBeDestroyed, 0, 24);
                        break;
                    }
            }
        }

        private void DestroyFieldsAroundDetonatedMine(IPosition[] positions, int startIndex, int numberOfFieldsToBeDestroyed)
        {
            for (int i = startIndex; i < startIndex + numberOfFieldsToBeDestroyed; i++)
            {
                if (IsPositionInsideField(gameField, positions[i]))
                {
                    gameField.RemoveObjectFromInteractableObjects(positions[i]);
                    gameField.RemoveObjectFromAllObjects(positions[i]);
                    gameField.AddObjectToAllObjects(positions[i], new DestroyedField(positions[i]));
                }
            }
        }

        private bool IsPositionInsideField(IGameField gameField, IPosition position)
        {
            if ((position.X >= 0 && position.X<=gameField.Size)&&(position.Y >= 0 && position.Y<=gameField.Size))
            {
                return true;
            }
            return false;
        }
    }
}