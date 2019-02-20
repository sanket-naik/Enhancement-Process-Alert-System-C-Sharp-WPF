using System;
using System.IO;
using System.Windows;
using EPAS.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class AssigneeModelTest
    {
        AssigneeModel _ens = new AssigneeModel();

        [TestMethod]
        public void Assignee_Returns_True()
        {
            bool expected = true;
            string path= Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+@"\Documents\testAssignee.docx";
            bool result = _ens.Read(path);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Assignee_Returns_False()
        {
            bool expected = false;
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEmpty.docx";
            bool result = _ens.Read(path);
            Assert.AreEqual(expected, result);
        }
    }
}
