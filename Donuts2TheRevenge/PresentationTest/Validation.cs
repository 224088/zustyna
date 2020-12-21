using System;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel.AdditionalInterfaces;

namespace PresentationTest
{
    [TestClass]
    public class Validation
    {
        [TestMethod]
        public void ValidationIntager()
        {
            var expected = new ValidationResult(true, null);
            var value = 7;
            IntagerValidation val = new IntagerValidation();
            var actual = val.Validate(value, null);
            Assert.AreEqual(actual,expected);

        }
        [TestMethod]
        public void ValidationIntagerNot()
        {
            var expected = new ValidationResult(false, $"Input should be a number");
            var value = "lalalala";
            IntagerValidation val = new IntagerValidation();
            var actual = val.Validate(value, null);
            Assert.AreEqual(actual, expected);

        }


        [TestMethod]
        public void ValidationString()
        {
            var expected = new ValidationResult(true,null);
            var value = "lalalala";
            StringValidation val = new StringValidation();
            var actual = val.Validate(value, null);
            Assert.AreEqual(actual, expected);

        }



    }
}
