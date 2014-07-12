namespace BattleField
{
    using System;

    public class BaseGameField : IGameField
    {
        public BaseGameField(int n, int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;

            this.Field = new string[rows, cols];

            // the display logic should be moved to renderer but currently its also used as initialization
            this.Field[0, 0] = " ";
            this.Field[0, 1] = " ";
            this.Field[1, 0] = " ";
            this.Field[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            this.Field[0, col] = "0";
                        }
                        else
                        {
                            this.Field[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        this.Field[0, col] = " ";
                    }

                    if (col < cols - 1)
                    {
                        this.Field[1, col] = "-";
                    }

                    this.Field[row, 0] = Convert.ToString(row - 2);
                    this.Field[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        this.Field[row, col] = "-";
                    }
                    else
                    {
                        this.Field[row, col] = " ";
                    }
                }
            }

            // Ideal for Strategy or Bridge/Addapter - use object to determin the randomization principle ig. Easy Medium Hard game
            int count = 0;
            Random randomNumber = new Random();
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (n * n));
            int maxPercent = Convert.ToInt32(0.30 * (n * n));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                randomPlaceI = randomNumber.Next(0, n);
                randomPlaceJ = randomNumber.Next(0, n);
                randomPlaceI += 2;
                randomPlaceJ = (2 * randomPlaceJ) + 2;

                while (this.Field[randomPlaceI, randomPlaceJ] != " " && this.Field[randomPlaceI, randomPlaceJ] != "-")
                {
                    randomPlaceI = randomNumber.Next(0, n);
                    randomPlaceJ = randomNumber.Next(0, n);
                    randomPlaceI += 2;
                    randomPlaceJ = (2 * randomPlaceJ) + 2;
                }

                string randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                this.Field[randomPlaceI, randomPlaceJ] = randomDigit;
                this.Field[randomPlaceI, randomPlaceJ + 1] = " ";
                count++;
            }
        }

        // to remove later
        public int Rows { get; set; }

        // to remove later
        public int Cols { get; set; }

        // to make private
        public string[,] Field { get; set; }
    }
}