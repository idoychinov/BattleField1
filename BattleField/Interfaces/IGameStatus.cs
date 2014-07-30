namespace BattleField.Interfaces
{
    using System;

    public interface IGameStatus
    {
        int Score { get; }

        IPosition CurrentCursorPosition { get; set; }

        IGameField Field { get; }

        bool GetMemento();

        TimeSpan GetElapsedTime();

        void EndTurn(int scoreToAdd);
    }
}