using Application;
using Application.Enums;
using AutoFixture;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Fare;
using Moq;
using Services;

namespace Tests.Application
{
    public class ApplicationServiceRobotTests
    {
        [Fact]
        public void Valid_RotateHead()
        {
            // Arrange
            var createRobot = new Fixture().Create<Robot>();

            var robotRepositoryMock = new Mock<IRobotRepository>();

            var robotService = new RobotService(robotRepositoryMock.Object);

            // Act
            Task<bool> result = robotService.Rotate(createRobot);


            // Assert
            Assert.True(result.Result);

            robotRepositoryMock.Verify(r => r.Rotate(It.IsAny<Robot>()), Times.Once);
        }


        [Fact]
        public void Invalid_IsHeadRotate()
        {
            // Arrange
            var robotService = new ApplicationValidations();

            // Act
            var teste = Enum.IsDefined(typeof(RotateHeadEnum), 1);

            bool result = robotService.IsHeadRotate((int)RotateHeadEnum.RotateMinus90, typeof(RotateHeadEnum));

            // Assert
            Assert.True(result);

        }


        [Fact]
        public void ValidRobot_InclinateHead()
        {
            // Arrange
            var createRobot = new Fixture().Create<Robot>();

            var robotRepositoryMock = new Mock<IRobotRepository>();

            var robotService = new RobotService(robotRepositoryMock.Object);

            // Act
            createRobot.HeadInclination = (int)InclinateEnum.ToUp;
            Task<bool> result = robotService.Inclinate(createRobot);


            // Assert
            Assert.True(result.Result);

            robotRepositoryMock.Verify(r => r.Inclinate(It.IsAny<Robot>()), Times.Once);
        }

        [Fact]
        public void ValidRobot_Contract()
        {
            // Arrange
            var createRobot = new Fixture().Create<Robot>();

            var robotRepositoryMock = new Mock<IRobotRepository>();

            var robotService = new RobotService(robotRepositoryMock.Object);

            // Act
            createRobot.LeftElbow = (int)ContractLevelEnum.StrongContracted;
            Task<bool> result = robotService.Contract(createRobot);


            // Assert
            Assert.True(result.Result);

            robotRepositoryMock.Verify(r => r.Contract(It.IsAny<Robot>()), Times.Once);
        }
    }
}
