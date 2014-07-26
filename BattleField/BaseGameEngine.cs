namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public sealed class BaseGameEngine : IEngine
    {
        private const int MinFieldSize = 1;
        private const int MaxFieldSize = 10;

        private readonly IRenderer renderer;
        private readonly IUserInterface userInterface;

        private IGameField gameField;

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

            this.gameField = new BaseGameField(fieldSize);
            this.Run();
        }

        private void Run()
        {
            this.renderer.DrawGameField(this.gameField);
            this.MakeMove();
        }

        private void MakeMove()
        {
            int detonatedMinesCounter = 0;

            while (true)
            {
                detonatedMinesCounter++;
                IPosition position = this.ReadUserCoordinatesInput();

                if (this.gameField.GetInteractableObjectAtPosition(position) == null)
                {
                    this.renderer.PrintMessage("Invalid move !");
                    this.renderer.PrintMessage("Please enter coordinates: ");
                }
                else
                {
                    this.DetonateMineAtPosition(position);
                }

                this.renderer.DrawGameField(this.gameField);

                if (this.EndGame())
                {
                    break;
                }
            }

            this.renderer.PrintMessage("Congratulations! You win! Detonated mines: " + detonatedMinesCounter);
        }

        private bool EndGame()
        {
            bool endGame = true;

            if (this.gameField.GetInteractableObjectsCount() != 0)
            {
                endGame = false;
            }

            return endGame;
        }

        private void DetonateMineAtPosition(IPosition position)
        {
            // TODO make this work without the "as" operator
            Mine mine = this.gameField.GetInteractableObjectAtPosition(position) as Mine;
            this.gameField.RemoveObjectFromInteractableObjects(position);
            this.gameField.RemoveObjectFromAllObjects(position);
            this.gameField.AddObjectToAllObjects(position, new DestroyedField(position));
            this.DestroyAllFieldsAroundMine(mine);
        }

        private void DestroyAllFieldsAroundMine(Mine mine)
        {
            DetonateOptions detonate = null;

            switch (mine.GetStrength())
            {
                case 1:
                    {
                        detonate = new DetonateOptions(new DetonateStrength1Mine());
                        break;
                    }

                case 2:
                    {
                        detonate = new DetonateOptions(new DetonateStrength2Mine());
                        break;
                    }

                case 3:
                    {
                        detonate = new DetonateOptions(new DetonateStrength3Mine());
                        break;
                    }

                case 4:
                    {
                        detonate = new DetonateOptions(new DetonateStrength4Mine());
                        break;
                    }

                case 5:
                    {
                        detonate = new DetonateOptions(new DetonateStrength5Mine());
                        break;
                    }
            }

            detonate.Detonate(this.gameField, mine);
        }

        private void DestroyFields(IPosition[] positions, int startIndex, int numberOfFieldsToBeDestroyed)
        {
            for (int i = startIndex; i < startIndex + numberOfFieldsToBeDestroyed; i++)
            {
                if (this.IsPositionInsideField(positions[i]))
                {
                    this.gameField.RemoveObjectFromInteractableObjects(positions[i]);
                    this.gameField.RemoveObjectFromAllObjects(positions[i]);
                    this.gameField.AddObjectToAllObjects(positions[i], new DestroyedField(positions[i]));
                }
            }
        }

        private bool IsPositionInsideField(IPosition position)
        {
            if ((position.X >= 0 && position.X <= this.gameField.Size) && (position.Y >= 0 && position.Y <= this.gameField.Size))
            {
                return true;
            }

            return false;
        }

        private IPosition ReadUserCoordinatesInput()
        {
            Console.WriteLine("Please enter coordinates: ");
            IEnumerable<int> enteredCoordinates = this.userInterface.ReadMultipleIntegers(2);
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