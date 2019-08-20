using WebApplication1;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.Tests
{
    //Note: CalcNumber Class may be too complex for simple Unit Tests
    //         Plus InputString uses a MaskedEditExtender as well as checked for length in CodBehind
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void SetNumbersTest_7Digits()
        {
            CalcNumbers.SetNumbers("1010139");
        }

        [TestMethod()]
        public void SetNumbersTest_10Digits()
        {
            CalcNumbers.SetNumbers("2011010139");
        }

        [TestMethod()]
        public void SetNumbersTest_ToFail()
        {
            CalcNumbers.SetNumbers("");
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNumbersTest_ToFail2()
        {
            CalcNumbers.SetNumbers("ABCDEFG");
            Assert.Fail();
        }
    }
    
}
