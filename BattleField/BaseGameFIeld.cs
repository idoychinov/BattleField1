namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class BaseGameField : IGameField
    {
        public BaseGameField(int fieldSize, IMinePositioner positioner)
        {
            this.Size = fieldSize;
            this.AllObjects = new Dictionary<IPosition, IGameObject>();
            this.InteractableObjects = new Dictionary<IPosition, IInteractableObject>();

            positioner.PlaceMines(this);

            // Ideal for Strategy or Bridge/Addapter - use object to determin the randomization principle ig. Easy Medium Hard game
            // int count = 0;
            // Random randomNumber = new Random();
            // int minPercent = Convert.ToInt32(0.15 * (this.Size * this.Size));
            // int maxPercent = Convert.ToInt32(0.30 * (this.Size * this.Size));
            // int countMines = randomNumber.Next(minPercent, maxPercent);
            // 
            // while (count <= countMines)
            // {
            //     int x = randomNumber.Next(0, this.Size);
            //     int y = randomNumber.Next(0, this.Size);
            //     IPosition position = new Position(x, y);
            // 
            //     if (!this.AllObjects.ContainsKey(position))
            //     {
            //         MineFactory factory = new MineFactory();
            // 
            //         IInteractableObject mine = factory.CreateMine(position, randomNumber.Next(1, 6));
            //         this.AllObjects[position] = mine;
            //         this.InteractableObjects[position] = mine;
            //         count++;
            //     }
            // }
        }

        public IDictionary<IPosition, IGameObject> AllObjects { get; private set; }

        public IDictionary<IPosition, IInteractableObject> InteractableObjects { get; private set; }

        public int Size { get; private set; }

        public IGameObject GetObjectAtPosition(IPosition position)
        {
            IGameObject result;

            if (this.AllObjects.TryGetValue(position, out result))
            {
                return result;
            }

            return null;
        }

        public IInteractableObject GetInteractableObjectAtPosition(IPosition position)
        {
            IInteractableObject result;

            if (this.InteractableObjects.TryGetValue(position, out result))
            {
                return result;
            }

            return null;
        }

        public void AddObjectToAllObjects(IPosition position, IGameObject objToBeAdded)
        {
            this.AllObjects.Add(position, objToBeAdded);
        }

        public void RemoveObjectFromAllObjects(IPosition position)
        {
            this.AllObjects.Remove(position);
        }

        public void AddObjectToInteractableObjects(IPosition position, IInteractableObject objToBeAdded)
        {
            this.InteractableObjects.Add(position, objToBeAdded);
        }

        public void RemoveObjectFromInteractableObjects(IPosition position)
        {
            this.InteractableObjects.Remove(position);
        }

        public int GetInteractableObjectsCount()
        {
            return this.InteractableObjects.Count;
        }

        public int GetObjectsCount()
        {
            return this.AllObjects.Count;
        }
    }
}