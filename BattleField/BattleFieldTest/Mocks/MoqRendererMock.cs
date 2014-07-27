using BattleField.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTest.Mocks
{
    class MoqRendererMock : RendererMock, IRendererMock
    {
        protected override void GenerateRendererMock()
        {
            var rendererMock = new Mock<IRenderer>();
            rendererMock.Setup(r => r.DrawGameField(It.IsAny<IGameField>())).Verifiable();
            rendererMock.Setup(r => r.PrintMessage(It.IsAny<string>())).Verifiable();
            this.Renderer = rendererMock.Object;
        }
    }
}
