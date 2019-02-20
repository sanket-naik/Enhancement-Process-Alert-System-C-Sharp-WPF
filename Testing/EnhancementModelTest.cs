using System;
using System.IO;
using EPAS.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class EnhancementModelTest
    {
        EnhancementModel _ens = new EnhancementModel();

        [TestMethod]
        public void Enhancement_Returns_True()
        {
            bool expected = true;
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEnhancement.docx";
            bool result = _ens.Read(path);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Enhancement_Returns_False()
        {
            bool expected = false;
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEmpty.docx";
            bool result = _ens.Read(path);
            Assert.AreEqual(expected, result);
        }

    }
}
