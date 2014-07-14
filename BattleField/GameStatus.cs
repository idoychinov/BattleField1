namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    class GameStatus : IGameStatus
    {
        private IGameField field;
        private IList<IGameField> gameFieldMemento;
        private int turn;
        private int score;
        private int time;
        private Position currentCursorPosition;
    }
}
