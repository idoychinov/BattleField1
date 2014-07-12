namespace BattleField
{
    using System;

    public class BaseGameField : IGameField
    {
        private int fieldSize;
        private GameObject[,] field;

        public BaseGameField(int fieldSize)
        {
            this.Size = fieldSize;
            this.field = new GameObject[this.Size,this.Size];

            // Ideal for Strategy or Bridge/Addapter - use object to determin the randomization principle ig. Easy Medium Hard game
            int count = 0;
            Random randomNumber = new Random();
            int minPercent = Convert.ToInt32(0.15 * (this.Size * this.Size));
            int maxPercent = Convert.ToInt32(0.30 * (this.Size * this.Size));
            int countMines = randomNumber.Next(minPercent, maxPercent);
            while (count <= countMines)
            {
                int x = randomNumber.Next(0, this.Size);
                int y = randomNumber.Next(0, this.Size);
                if(this.field[x,y] == null){
                    this.field[x, y] = new Mine(randomNumber.Next(1, 6));
                    count++;
                }
            }
            for (int i = 0; i < this.Size; i++)
            {
                for(int j=0; j < this.Size; j++)
                {
                    if (this.field[i, j] == null)
                    {
                        this.field[i, j] = new EmptyField();
                    }
            
                }
            }

           

            
        }

        public GameObject GetObjectAtPosition(Position position)
        {
            return this.field[position.X, position.Y];
        }

        public int Size
        {
            get
            {
                return this.fieldSize;
            }
            private set
            {
                this.fieldSize = value;
            }
        }
        
    }
}