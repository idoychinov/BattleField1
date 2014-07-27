namespace BattleField.Interfaces
{
    using System;

    public interface IGameStatus
    {
        TimeSpan GetElapsedTime();

        void EndTurn(int scoreToAdd);
        
        int Score {get;}
       
        IPosition CurrentCursorPosition {get;set;}

        bool GetMemento();
        
        IGameField Field {get;}
        
    }
}