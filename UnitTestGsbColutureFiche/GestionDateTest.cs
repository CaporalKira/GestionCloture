using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GsbClotureFiche;

namespace UnitTestGsbColutureFiche
{
    [TestClass]
    public class GestionDateTest
    {
        [TestMethod]
        public void TestMoisPrecedent()
        {
            //arrange 
            DateTime date = new DateTime(2018, 02, 19);
            //act
            string resultat = GestionDate.getMoisPrecedent(date);
            //assert
            Assert.AreEqual("01", resultat);

        }

        [TestMethod]
        public void TestMoisSuivant()
        {
            //arrange 
            DateTime date = new DateTime(2018, 02, 19);
            //act 
            string resultat = GestionDate.getMoisSuivant(date);
            //assert
            Assert.AreEqual("03", resultat);
        }

        [TestMethod]
        public void TestEntre()
        {
            //Arrange
            int min = 7;
            int max = 29;
            DateTime date = new DateTime(2018, 02, 19);
            //Act
            bool resultat = GestionDate.entre(min, max, date);
            //Assert
            Assert.IsTrue(resultat);
        }

    }
}
