using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Payroll.API.Controllers;
using Payroll.Application.Commands.Payments;
using System.Threading.Tasks;
using Payroll.DomainCore.AggregatesModel.TaxAggregate;
using Payroll.Tests.Mocks;

namespace Payroll.Tests.Api
{
    [TestClass]
    public class PaymentControllerTests : PayrollMocks
    {

        [TestMethod]
        public async Task Payment_for_JohnDoe_withAnualSalary_60050_super_9()
        {

            //Assemble 
            var _mediatorMock = new Mock<IMediator>();
            var _taxRepositoryMock = new Mock<ITaxRepository>();
            var FirstName = "JOHN";
            var LastName = "DOE";
            var AnualSalary = 60050;
            var PaymentPeriod = "1March-31March";
            var Super = "9";
            var year = 2018;
            var mockedTaxData = MockTaxDataRepo(year);

            //expected results
            var ExpectedIncomeTax = 922;
            var ExpectedSuper = 450;
            var ExpectedGrossIncome = 5004;
            var ExpectedNetIncome = 4082;

            //Arrange
            var mockPayCmd = new GeneratePaymentCmd(FirstName, LastName, AnualSalary, PaymentPeriod,Super);
            _taxRepositoryMock
                .Setup(s => s.GetTaxData(It.IsAny<int>()))
                .Returns(await MockTaxDataRepo(year));
            var handler = new GeneratePaymentCmdHandler(_taxRepositoryMock.Object);
            var cltToken = new System.Threading.CancellationToken();

            //Act
            var result = await handler.Handle(mockPayCmd, cltToken);

            //Assert 
            Assert.AreEqual(result.GrossIncome, ExpectedGrossIncome);
            Assert.AreEqual(result.IncomeTax, ExpectedIncomeTax);
            Assert.AreEqual(result.NetIncome, ExpectedNetIncome);
            Assert.AreEqual(result.IncomeTax, ExpectedIncomeTax);
            Assert.AreEqual(result.Super, ExpectedSuper);

        }

        [TestMethod]
        public async Task Mediatr_test_success()
        {
            //Assemble 
            var _mediatorMock = new Mock<IMediator>();
            var _mockCmd = new Mock<GeneratePaymentCmd>();
            var FirstName = "JOHN";
            var LastName = "DOE";
            var AnualSalary = 60050;
            var PaymentPeriod = "1March-31March";
            var Super = "9";
            var ExpectedIncomeTax = 922;

            //Arrange
            var fakeResult = new PaymentDTO() { IncomeTax = ExpectedIncomeTax };
            var mockCmd = new GeneratePaymentCmd(FirstName, LastName, AnualSalary, PaymentPeriod,Super);

            _mediatorMock.Setup(x => x.Send(It.IsAny<GeneratePaymentCmd>(), default(System.Threading.CancellationToken)))
            .Returns(Task.FromResult(fakeResult));

            //Act
            var payController = new PaymentController(_mediatorMock.Object);
            var actionResult = await payController.GeneratePaymentAsync(mockCmd);

            //Assert
            Assert.AreEqual(actionResult.Value.IncomeTax, ExpectedIncomeTax); 

        }

          
        private async Task<Tax> MockTaxDataRepo(int year)
        {
            return await Task.Run(() =>
            {
                switch (year)
                {
                    case 2017: return Tax2017;
                    case 2018: return Tax2018;
                    case 2019: return Tax2019;
                    default:
                        return Tax2019;
                }
            });
        }

        
    }
}
 
