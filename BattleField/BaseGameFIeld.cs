namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class BaseGameField : IGameField
    {
        private int fieldSize;
        private IDictionary<IPosition, IGameObject> allObjects;
        private IDictionary<IPosition, IInteractableObject> interactableObjects;
        public IDictionary<IPosition, IInteractableObject> InteractableObjects
        {
            get { return interactableObjects; }
        }
        public IDictionary<IPosition, IGameObject> AllObjects
        {
            get { return allObjects; }
        }

        public void AddObjectToAllObjects(IPosition position, IGameObject objToBeAdded)
        {
            this.allObjects.Add(position, objToBeAdded);
        }
        public void RemoveObjectFromAllObjects(IPosition position)
        {
            this.allObjects.Remove(position);
        }

        public void AddObjectToInteractableObjects(IPosition position, IInteractableObject objToBeAdded)
        {
            this.interactableObjects.Add(position, objToBeAdded);
        }
        public void RemoveObjectFromInteractableObjects(IPosition position)
        {
            this.interactableObjects.Remove(position);
        }
        public int GetInteractableObjectsCount()
        {
            return this.interactableObjects.Count;
        }
        public BaseGameField(int fieldSize)
        {
            this.Size = fieldSize;
            this.allObjects = new Dictionary<IPosition, IGameObject>();
            this.interactableObjects = new Dictionary<IPosition, IInteractableObject>();

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
                IPosition position = new Position(x, y);
                if (!this.allObjects.ContainsKey(position))
                {
                    IInteractableObject mine = new Mine(position, randomNumber.Next(1, 6));
                    this.allObjects[position] = mine;
                    this.interactableObjects[position] = mine;
                    count++;
                }
            }
        }

        public IGameObject GetObjectAtPosition(IPosition position)
        {
            IGameObject result;
            if (this.allObjects.TryGetValue(position, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public IInteractableObject GetInteractableObjectAtPosition(IPosition position)
        {
            IInteractableObject result;
            if (this.interactableObjects.TryGetValue(position, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
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