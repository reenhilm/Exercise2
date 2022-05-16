using Exercise2;
using Xunit;

namespace TestProjectExercise2
{
    public class UnitTest1
    {
        [Fact]
        public void TestToStringOfDifferentVisitors()
        {

        }

        [Fact]
        public void TestMultiply10()
        {
            //Arrange
            Exercise2.Main.ui = new Exercise2.MockUI();
            Exercise2.MockUI mockUI = (Exercise2.MockUI)Exercise2.Main.ui;
            mockUI.SetNextInput("2");

            //Act
            Exercise2.Main.Multiply10();
            string s = mockUI.GetLastOutput();

            //Assert
            Assert.Equal(s, "2 2 2 2 2 2 2 2 2 2");
        }
    }
}