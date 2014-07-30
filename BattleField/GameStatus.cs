namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class GameStatus : IGameStatus
    {
        private static GameStatus instance;
        private readonly Stack<IGameField> gameFieldMemento;
        private readonly DateTime startTime;
        private IGameField field;
        private int turn;
        private int score;
        private IPosition currentCursorPosition;

        private GameStatus(int fieldSize)
        {
            this.field = new BaseGameField(fieldSize, new BaseMinePlacer());
            this.gameFieldMemento = new Stack<IGameField>();
            this.gameFieldMemento.Push(this.field);
            this.turn = 0;
            this.score = 0;
            this.startTime = DateTime.Now;
            this.currentCursorPosition = new Position(0, 0);
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score must be positive");
                }

                this.score = value;
            }
        }

        public IGameField Field
        {
            get
            {
                return this.field;
            }
        }

        public IPosition CurrentCursorPosition
        {
            get
            {
                return this.currentCursorPosition;
            }

            set
            {
                this.currentCursorPosition = value;
            }
        }

        public static GameStatus GetInstance(int fieldSize)
        {
            if (instance == null)
            {
                instance = new GameStatus(fieldSize);
            }

            return instance;
        }

        public TimeSpan GetElapsedTime()
        {
            return DateTime.Now - this.startTime;
        }

        public void EndTurn(int scoreToAdd)
        {
            this.turn++;
            this.Score = this.Score + scoreToAdd;
            this.gameFieldMemento.Push(this.field);
        }

        public bool GetMemento()
        {
            if (this.gameFieldMemento.Count > 0)
            {
                this.field = this.gameFieldMemento.Pop();
                return true;
            }

            return false;
        }
    }
}