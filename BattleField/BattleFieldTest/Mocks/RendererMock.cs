namespace BattleFieldTest.Mocks
{
    using System;
    using System.Linq;
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
