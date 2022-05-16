using Exercise2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Main.Tests
{
    [TestClass]
    public class MainTest
    {
        Exercise2.MockUI mockUI = null!;

        [TestInitialize]
        public void Init()
        {
            Exercise2.Main.ui = new Exercise2.MockUI();
            mockUI = (Exercise2.MockUI)Exercise2.Main.ui;
        }

        [TestMethod]
        [DataRow("2", "2 2 2 2 2 2 2 2 2 2")]
        public void Multiply10(string strUserInput, string shouldReturn)
        {
            //Arrange
            mockUI.SetNextInput(strUserInput);

            //Act
            Exercise2.Main.Multiply10();
            string doesReturn = mockUI.GetLastOutput();

            //Assert
            Assert.AreEqual(doesReturn, shouldReturn);
        }

        [TestMethod]
        [DataRow(" jag   heter  Christian R�nnholm", "Christian")]
        public void GetThird(string strUserInput, string shouldReturn)
        {
            //Arrange
            mockUI.SetNextInput(strUserInput);

            //Act
            Exercise2.Main.GetThird();
            string doesReturn = mockUI.GetLastOutput();

            //Assert
            Assert.AreEqual(doesReturn, shouldReturn);
        }

        [TestMethod]
        [DataRow("3", "Enter visitors age:")]
        [DataRow("50", "Standardpris 120kr")]
        public void Lookup1Visitor(string strUserInput, string shouldReturn)
        {
            //Arrange
            mockUI.SetNextInput(strUserInput);

            //Act
            Exercise2.Main.Lookup1Visitor();
            string doesReturn = mockUI.GetLastOutput();

            //Assert
            Assert.AreEqual(doesReturn, shouldReturn);
        }

        /// <summary>
        /// invoking private static method addNewVisitorToTotal on Main class using reflection because we want that method to stay private yet be tested
        /// </summary>
        /// <param name="dStartValue"></param>
        /// <param name="strUserInput"></param> Age of Visitor
        /// <param name="shouldReturn"></param>
        [TestMethod]
        [DataRow(0, "50", 120)]
        [DataRow(120, "75", 210)]
        public void TestAddNewVisitorToTotal(double dStartValue, string strUserInput, double shouldReturn)
        {
            //Arrange
            mockUI.SetNextInput(strUserInput);
            Exercise2.Main objUnderTest = new Exercise2.Main();
            MethodInfo methodInfo = typeof(Exercise2.Main).GetMethod("addNewVisitorToTotal", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = { dStartValue };

            //Act
            double doesReturn = (double)(methodInfo.Invoke(objUnderTest, parameters));

            //Assert
            Assert.AreEqual(doesReturn, shouldReturn);
        }        

        [TestMethod]
        [DataRow(4, "Exercise2.ExceptionPrice")]
        [DataRow(50, "Standardpris 120kr")]
        [DataRow(16, "Ungdomspris 80kr")]
        [DataRow(101, "Exercise2.ExceptionPrice")]
        [DataRow(65, "Pension�rspris 90kr")]
        public void VisitorPrice_ToString(int iUserInput, string shouldReturn)
        {
            //Arrange
            Visitor v = new Visitor(iUserInput);

            //Act
            string doesReturn = v.Price.ToString();

            //Note: ExceptionPrice is not meant to be printed
            //Assert
            Assert.AreEqual(doesReturn, shouldReturn);
        }
    }
}