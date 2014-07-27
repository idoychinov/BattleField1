using BattleField.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class BaseMinePlacer : IMinePositioner
    {
        private const double DefaultMinPercent = 0.15;
        private const double DefaultMaxPercent = 0.30;

        private double minChance;
        private double maxChance;

        public BaseMinePlacer() 
            : this(DefaultMinPercent, DefaultMaxPercent)
        {

        }

        public BaseMinePlacer(double minChance, double maxChance)
        {
            this.MinChance = minChance;
            this.MaxChance = maxChance;
        }

        public double MinChance
        {
            get
            {
                return this.minChance;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("The MinChance must be between 0 and 1");
                }

                this.minChance = value;
            }
        }

        public double MaxChance
        {
            get
            {
                return this.maxChance;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("The MaxChance must be between 0 and 1");
                }

                this.maxChance = value;
            }
        }

        public void PlaceMines(IGameField field, int minPercent, int maxPercent)
        {
            int count = 0;
            Random randomNumber = new Random();
            minPercent = Convert.ToInt32(0.15 * (field.Size * field.Size));
            maxPercent = Convert.ToInt32(0.30 * (field.Size * field.Size));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                int x = randomNumber.Next(0, field.Size);
                int y = randomNumber.Next(0, field.Size);
                IPosition position = new Position(x, y);

                if (!field.AllObjects.ContainsKey(position))
                {
                    MineFactory factory = new MineFactory();

                    IInteractableObject mine = factory.CreateMine(position, randomNumber.Next(1, 6));
                    field.AllObjects[position] = mine;
                    field.InteractableObjects[position] = mine;
                    count++;
                }
            }
        }

        public void PlaceMines(IGameField field)
        {
            int count = 0;
            Random randomNumber = new Random();
            int minPercent = Convert.ToInt32(this.MinChance * (field.Size * field.Size));
            int maxPercent = Convert.ToInt32(this.MaxChance * (field.Size * field.Size));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                int x = randomNumber.Next(0, field.Size);
                int y = randomNumber.Next(0, field.Size);
                IPosition position = new Position(x, y);

                if (!field.AllObjects.ContainsKey(position))
                {
                    MineFactory factory = new MineFactory();

                    IInteractableObject mine = factory.CreateMine(position, randomNumber.Next(1, 6));
                    field.AllObjects[position] = mine;
                    field.InteractableObjects[position] = mine;
                    count++;
                }
            }
        }
    }
}
