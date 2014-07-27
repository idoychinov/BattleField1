using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField.Interfaces
{
    public interface IMinePositioner
    {
        void PlaceMines(IGameField field);
    }
}
