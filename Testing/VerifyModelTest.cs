using System.Collections.Generic;
using EPAS.Models;
using EPAS.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class VerifyModelTest
    {
        List<Jobs> Datalist = new List<Jobs>();


        [TestMethod]
        public void VerifyModel_Returns_True()
        {

            Jobs job1 = new Jobs()
            {
                day = "April 1",
                task = "Testing Event",
                approval = "Approve all STP",
                responsibility = "sanketnaik.naik@cerner.com",
                target = "EOW",
                week = 1
            };
            Datalist.Add(job1);

            bool expected = true;
            VerifyModel _vf = new VerifyModel(Datalist);
            bool result=_vf.Show();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Verify_Model_Returns_False()
        {
            Datalist.Clear();
            bool expected = false;
            VerifyModel _vf = new VerifyModel(Datalist);
            bool result = _vf.Show();
            Assert.AreEqual(expected, result);
        }
        
    }
}
