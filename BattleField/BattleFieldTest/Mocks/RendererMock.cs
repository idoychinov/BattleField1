using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTest.Mocks
{
    using BattleField.Interfaces;
    public abstract class RendererMock : IRendererMock
    {
        public RendererMock()
        {
            this.GenerateRendererMock();
        }

        public IRenderer Renderer { get; protected set; }

        protected abstract void GenerateRendererMock();
    }
}
