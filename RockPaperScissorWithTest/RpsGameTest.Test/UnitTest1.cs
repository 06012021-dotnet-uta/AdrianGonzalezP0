using System;
using Xunit;
using rock_paper_scissors;

namespace RpsGameTest.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrnage
            int x = 5;
            int y = 6;

            // Act
            int z = x + y;

            // Assert
            Assert.Equal(11,z);
        }

        [Fact]
        public void WelcomeMessageTest() {
            // Arrange
            RpsGame game = new RpsGame();

            // Act
            string message = game.WelcomeMessage();

            // Assert
            Assert.Equal("\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choie.", message);


        }
    }
}
