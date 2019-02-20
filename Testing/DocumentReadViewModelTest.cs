using System;
using System.IO;
using EPAS.ViewModel;
using EPAS.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class DocumentReadViewModelTest
    {
        [TestMethod]
        public void CanExecute_True_Test1()
        {
            DocumentReadViewModel documentVM = new DocumentReadViewModel();
            bool Expected = false;
            documentVM.EnhancementPath = "";
            documentVM.AssigneePath = "";
            bool Result = documentVM.SubmitCommand.CanExecute(null);
            Assert.AreEqual(Result, Expected);

        }

        [TestMethod]
        public void CanExecute_False_Test2()
        {
            DocumentReadViewModel documentVM = new DocumentReadViewModel();
            documentVM.EnhancementPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEnhancement.docx";
            documentVM.AssigneePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testAssignee.docx";
            documentVM.SubmitCommand.Execute(null);
        }



        [TestMethod]
        public void Execute_False_Test4()
        {
            DocumentReadViewModel documentVM = new DocumentReadViewModel();
            documentVM.EnhancementPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEnhancement.docx";
            documentVM.AssigneePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEmpty.docx";
            documentVM.ThreadProc();

        }

        [TestMethod]
        public void Execute_False_Test5()
        {
            DocumentReadViewModel documentVM = new DocumentReadViewModel();
            documentVM.EnhancementPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testEnhancement_error.docx";
            documentVM.AssigneePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Documents\testAssignee.docx";
            documentVM.ThreadProc();
        }

        [TestMethod]
        public void Enhancement_True_Test4()
        {
            DocumentReadViewModel documentVM = new DocumentReadViewModel();
            documentVM.EnhancementCommand.Execute(null);

        }

        [TestMethod]
        public void Assignee_True_Test5()
        {
            DocumentReadViewModel documentVM = new DocumentReadViewModel();
            documentVM.AssigneeCommand.Execute(null);

        }
        
    }
}
