using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTest.Mocks
{
    using BattleField.Interfaces;
    interface IRendererMock
    {
        IRenderer Renderer { get; }
    }
}
