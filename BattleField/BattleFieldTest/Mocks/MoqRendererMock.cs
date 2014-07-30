namespace BattleFieldTest.Mocks
{
    using System;
    using System.Linq;
    using BattleField.Interfaces;
    using Moq;

    public class MoqRendererMock : RendererMock, IRendererMock
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
