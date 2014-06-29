namespace BattleField
{
    public interface IGameField 
    {
        int Rows { get; set; }
        int Cols { get; set; }
        string[,] field {get;set;}
    }
}
