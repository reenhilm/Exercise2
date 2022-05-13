using Exercise2;
using Xunit;

namespace TestProjectExercise2
{
    public class UnitTest1
    {
        [Fact]
        public void TestToStringOfDifferentVisitors()
        {
            //Arrange
            Visitor v = new Visitor(4);
            Visitor v2 = new Visitor(50);
            Visitor v3 = new Visitor(16);
            Visitor v4 = new Visitor(101);
            Visitor v5 = new Visitor(65);

            //Act
            string price = v.Price.ToString();
            string price2 = v2.Price.ToString();
            string price3 = v3.Price.ToString();
            string price4 = v4.Price.ToString();
            string price5 = v5.Price.ToString();

            //Note: ExceptionPrice is not meant to be printed
            //Assert
            Assert.Equal(price, "Exercise2.ExceptionPrice");
            Assert.Equal(price2, "Standardpris 120kr");
            Assert.Equal(price3, "Ungdomspris 80kr");
            Assert.Equal(price4, "Exercise2.ExceptionPrice");
            Assert.Equal(price5, "Pensionärspris 90kr");
        }

        [Fact]
        public void TestMultiply10()
        {
            //Arrange
            Exercise2.Program.ui = new Exercise2.MockUI();
            Exercise2.MockUI mockUI = (Exercise2.MockUI)Exercise2.Program.ui;
            mockUI.SetNextInput("2");

            //Act
            Exercise2.Program.Multiply10();
            string s = mockUI.GetLastOutput();

            //Assert
            Assert.Equal(s, "2 2 2 2 2 2 2 2 2 2");
        }
    }
}