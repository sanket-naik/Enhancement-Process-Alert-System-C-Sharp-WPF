using System;
using System.Collections.Generic;
using EPAS.Models;
using EPAS.ViewModel;
using EPAS.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class VerifyViewModelTest
    {
        List<Jobs> Datalist = new List<Jobs>();

        Jobs job1 = new Jobs()
        {
            day = "April 1",
            task = "Testing Event",
            approval = "Approve all STP",
            responsibility = "sanketnaik.naik@cerner.com",
            target = "EOW",
            week = 1
        };

        [TestMethod]
        public void VerifyViewModel_CanExecute_True()
        {
            VerifyViewModel Validate = new VerifyViewModel(Datalist);
            bool Expected = true;
            bool Result = Validate.SubmitCommand.CanExecute(true);
            Assert.AreEqual(Result, Expected);
        }

        [TestMethod]
        public void VerifyViewModel_Execute_True()
        {
            VerifyViewModel Validate = new VerifyViewModel(Datalist);
            Validate.SubmitCommand.Execute(null);
        }

        [TestMethod]
        public void VerifyViewModel_True()
        {
            VerifyViewModel Validate = new VerifyViewModel(Datalist);
            Validate.SubmitCommand.Execute(null);
        }

        [TestMethod]
        public void UploadView()
        {
            try
            { UploadView upload = new UploadView();}
            catch { }
        }
    }
}
