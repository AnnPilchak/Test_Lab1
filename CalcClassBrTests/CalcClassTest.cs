using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcClassBr;
using System.Data.SqlTypes;

namespace CalcClassBr.Tests
{
    [TestClass]
    public class CalcClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "test.xml",
                    "Operation", DataAccessMethod.Sequential)]

        public void DivTest()
        {
            //Arrange
            long expression_1 = Convert.ToInt64(TestContext.DataRow["expression_1"]);
            long expression_2 = Convert.ToInt64(TestContext.DataRow["expression_2"]);
            string expected = Convert.ToString(TestContext.DataRow["expected"]);

            //Act
            string result;
            try
            {
                result = Convert.ToString(CalcClass.Div(expression_1, expression_2));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                result = ex.ParamName;
            }
            catch (DivideByZeroException e)
            {
                result = e.Message;
            }

            Assert.AreEqual(expected, result);
        }
    }
}