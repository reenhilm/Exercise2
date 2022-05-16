using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests
{
    [TestClass]
    internal class UtilTest
    {
        [TestMethod]
        [DataRow(" jag   heter  Christian Rönnholm", "jag heter Christian Rönnholm")]
        public void DuplicateSpacesIntoSingleSpaces(string strUserInput, string shouldReturn)
        {
            //Act
            string doesReturn = Exercise2.Util.DuplicateSpacesIntoSingleSpaces(strUserInput);

            //Assert
            Assert.AreEqual(doesReturn, shouldReturn);
        }
    }
}
