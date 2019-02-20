using System;
using System.IO;
using EPAS.Services;
using EPAS.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Testing
{
    [TestClass]
    public class FindMatchTest
    {
        

        EnhancementModel _enhancement = new EnhancementModel();
        AssigneeModel _assignee = new AssigneeModel();
       
        [TestMethod]
        public void FindMatch_Returns_True()
        {
            string enhancement = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEnhancement.docx";
            string assignee = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testAssignee.docx";

            bool expected = true;
            _enhancement.Read(enhancement);
            _assignee.Read(assignee);
            FindMatch _fm = new FindMatch(_assignee, _enhancement);
            bool result=_fm.Get();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMatch_Returns_Fasle_Test1()
        {
            string enhancement = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEnhancement.docx";
            string assignee = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testAsine.docx";

            bool expected = false;
            _enhancement.Read(enhancement);
            _assignee.Read(assignee);
            FindMatch _fm = new FindMatch(_assignee, _enhancement);
            bool result = _fm.Get();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMatch_Returns_False_Test2()
        {
            string enhancement = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEmpty.docx";
            string assignee = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEmpty.docx";

            bool expected = false;
            _enhancement.Read(enhancement);
            _assignee.Read(assignee);
            FindMatch _fm = new FindMatch(_assignee, _enhancement);
            bool result = _fm.Get();
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void About_Returns_True()
        {
            AboutWindow about = new AboutWindow();
        }
    }
}
