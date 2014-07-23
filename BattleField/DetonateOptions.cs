using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleField.Interfaces;

namespace BattleField
{
    class DetonateOptions
    {
        private readonly DetonateMineStrategy strategy;

    // Constructor 
        public DetonateOptions(DetonateMineStrategy strategy)
    {
      this.strategy = strategy;
    }

    public void Detonate(IGameField gameField, Mine mine)
    {
      strategy.DetonateMine(gameField, mine);
    }
    }
}
