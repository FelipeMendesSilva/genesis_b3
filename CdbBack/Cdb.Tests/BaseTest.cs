using Cdb.App.Interfaces;
using Cdb.Domain.Interfaces;
using Moq;

namespace Cdb.Tests
{
    public class BaseTest
    {
        protected readonly Mock<ICdbHandler> _cdbHandlerMock;
        protected readonly Mock<ICdbCalculatorService> _cdbCalculatorService;

        public BaseTest()
        {
            //Application
            _cdbHandlerMock = new Mock<ICdbHandler>();

            //Domain
            _cdbCalculatorService = new Mock<ICdbCalculatorService>();            
        }
    }
}
