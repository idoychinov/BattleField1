namespace BattleField
{
    public interface IGameField : IDrawable
    {
        int Rows { get; set; }
        int Cols { get; set; }
        string[,] field {get;set;}
    }
}
