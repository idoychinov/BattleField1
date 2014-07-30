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

        public void AddObjectToAllObjects(IGameObject objToBeAdded)
        {
            this.AllObjects.Add(objToBeAdded.Position, objToBeAdded);
        }

        public void RemoveObjectFromAllObjects(IPosition position)
        {
            this.AllObjects.Remove(position);
        }

        public void AddObjectToInteractableObjects(IInteractableObject objToBeAdded)
        {
            this.InteractableObjects.Add(objToBeAdded.Position, objToBeAdded);
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