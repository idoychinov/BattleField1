namespace BattleField
{
    using System;

    public class BaseGameField : IGameField
    {
        public int Rows { get; set; }

        public int Cols { get; set; }

        //to make private
        public string[,] field;

        public BaseGameField(int rows, int cols)
        {
            this.Rows = rows ;
            this.Cols = cols;

            field = new string[rows, cols];

            field[0, 0] = " ";
            field[0, 1] = " ";
            field[1, 0] = " ";
            field[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            field[0, col] = "0";
                        }
                        else
                        {
                            field[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        field[0, col] = " ";
                    }

                    if (col < cols - 1)
                    {
                        field[1, col] = "-";
                    }

                    field[row, 0] = Convert.ToString(row - 2);
                    field[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        field[row, col] = "-";
                    }
                    else
                    {
                        field[row, col] = " ";
                    }
                }
            }
        }
    }
}
