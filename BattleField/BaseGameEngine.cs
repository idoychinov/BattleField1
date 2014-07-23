﻿namespace BattleField
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

        public void StartNewGame()
        {
            this.renderer.PrintMessage("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            do
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    if (int.TryParse(input, out fieldSize) == false)
                    {
                        Console.WriteLine("Invalid input! Please enter a number");
                    }
                    else if (this.fieldSize < MinFieldSize || MaxFieldSize < this.fieldSize)
                    {
                        Console.WriteLine("Invalid input! Please enter a number between {0} and {1}", MinFieldSize, MaxFieldSize);
                        //throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number");
                    //throw new NullReferenceException();
                }

            } while (true);

            gameField = new BaseGameField(fieldSize);
            this.Run();
        }

        private void Run()
        {
            this.renderer.DrawGameField(gameField);
            this.MakeMove();
        }

        private void MakeMove()
        {
            int detonatedMinesCounter = 0;

            while (true)
            {
                detonatedMinesCounter++;

                IPosition position = ReadUserCoordinatesInput();
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
            Console.WriteLine("Congratulations! You win! Detonated mines: " + detonatedMinesCounter);
        }

        private void DetonateMineAtPosition(IPosition position)
        {
            //TODO make this work without the "as" operator
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
            if ((position.X >= 0 && position.X <= gameField.Size) && (position.Y >= 0 && position.Y <= gameField.Size))
            {
                return true;
            }
            return false;
        }

        private IPosition ReadUserCoordinatesInput()
        {
            Console.WriteLine("Please enter coordinates: ");
            string input = Console.ReadLine();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            int x = 0;
            int y = 0;

            if (input != null)
            {
                string[] inputData = input.Split(delimiterChars);
                if (inputData.Length != 2)
                {
                    Console.WriteLine("Invalid input! Please enter exactly two numbers");
                    //throw new ArgumentOutOfRangeException();
                }
                else
                {

                    if (int.TryParse(inputData[0], out x) == false)
                    {
                        Console.WriteLine("Invalid input!");
                        //throw new ArgumentOutOfRangeException();
                    }
                    if (int.TryParse(inputData[1], out y) == false)
                    {
                        Console.WriteLine("Invalid input!");
                        //throw new ArgumentOutOfRangeException();
                    }
                }
            }
            else
            {
                Console.WriteLine("Invallid input! Please enter a value");
                //throw new NullReferenceException();
            }
            IPosition position = new Position(x, y);
            if (!IsPositionInsideField(gameField, position))
            {
                Console.WriteLine("Invalid input!");
                //throw new ArgumentOutOfRangeException();
            }
            return position;
        }
    }
}