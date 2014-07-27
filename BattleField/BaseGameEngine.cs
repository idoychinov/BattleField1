namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public sealed class BaseGameEngine : IEngine
    {
        private const int MinFieldSize = 1;
        private const int MaxFieldSize = 10;
        private const int NumberOfDimensions = 2;

        private readonly IRenderer renderer;
        private readonly IUserInterface userInterface;
        private IGameStatus gameStatus;

        public BaseGameEngine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
        }

        public void StartNewGame()
        {
            int fieldSize;
            this.renderer.PrintMessage("Welcome to \"Battle Field game.\" Enter battle field size: n = ");

            do
            {
                fieldSize = this.userInterface.ReadInteger();

                if (fieldSize < MinFieldSize || MaxFieldSize < fieldSize)
                {
                    Console.WriteLine("Invalid input! Please enter a number between {0} and {1}", MinFieldSize, MaxFieldSize);
                }
                else
                {
                    break;
                }
            }
            while (true);

            this.gameStatus = GameStatus.GetInstance(fieldSize);
            this.Run();
        }

        private void Run()
        {
            this.renderer.DrawGameField(this.gameStatus.Field);
            this.MakeMove();
        }

        private void MakeMove()
        {

            while (true)
            {
                int scoreToAdd = 0;
                IPosition position = this.ReadUserCoordinatesInput();
                var gameObjectAtPosition = this.gameStatus.Field.GetInteractableObjectAtPosition(position);

                if (gameObjectAtPosition == null)
                {
                    this.renderer.PrintMessage("Invalid move !");
                    this.renderer.PrintMessage("Please enter coordinates: ");
                }
                else
                {
                    var area = gameObjectAtPosition.InteractionAffectedArea();
                    foreach (var itemPosition in area)
                    {
                        if (IsPositionInsideField(itemPosition))
                        {
                            var destroyedField = new DestroyedField(itemPosition);
                            scoreToAdd++;
                            if (this.gameStatus.Field.GetObjectAtPosition(itemPosition) == null)
                            {
                                this.gameStatus.Field.AddObjectToAllObjects(itemPosition, destroyedField);
                            }
                            else
                            {
                                if (this.gameStatus.Field.GetInteractableObjectAtPosition(itemPosition) != null)
                                {
                                    this.gameStatus.Field.RemoveObjectFromInteractableObjects(itemPosition);
                                }
                                this.gameStatus.Field.RemoveObjectFromAllObjects(itemPosition);
                                this.gameStatus.Field.AddObjectToAllObjects(itemPosition, destroyedField);
                            }
                        }
                    }
                }

                this.gameStatus.EndTurn(scoreToAdd);
                this.renderer.DrawGameField(this.gameStatus.Field);

                if (this.EndGame())
                {
                    if(this.gameStatus.Field.GetObjectsCount() == (this.gameStatus.Field.Size*this.gameStatus.Field.Size))
                    {
                        this.renderer.PrintMessage("Congratulations! You win! Your score is: " + this.gameStatus.Score);
                    } 
                    else 
                    {
                        this.renderer.PrintMessage("Sorry you lose. You didn't manage to detonate all mines. Your score is: " + this.gameStatus.Score);
                    }
                    break;
                }
            }
        }

        private bool EndGame()
        {
            if (this.gameStatus.Field.GetInteractableObjectsCount() != 0)
            {
                return false;
            }

            return true;
        }
        
        private bool IsPositionInsideField(IPosition position)
        {
            if ((position.X >= 0 && position.X <= this.gameStatus.Field.Size) && (position.Y >= 0 && position.Y <= this.gameStatus.Field.Size))
            {
                return true;
            }

            return false;
        }

        private IPosition ReadUserCoordinatesInput()
        {
            this.renderer.PrintMessage("Please enter coordinates: ");
            IEnumerable<int> enteredCoordinates = this.userInterface.ReadMultipleIntegers(NumberOfDimensions);
            IEnumerator<int> i = enteredCoordinates.GetEnumerator();
            i.MoveNext();
            int x = i.Current;
            i.MoveNext();
            int y = i.Current;
            IPosition position = new Position(x, y);

            // if (!IsPositionInsideField(position))
            // {
            //    throw new ArgumentException("The entered position is outside the game field");
            // }
            return position;
        }
    }
}