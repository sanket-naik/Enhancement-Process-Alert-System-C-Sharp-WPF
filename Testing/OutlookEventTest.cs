using System.Collections.Generic;
using EPAS.Models;
using EPAS.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class OutlookEventTest
    {
        List<Jobs> Datalist1 = new List<Jobs>();
        List<Jobs> Datalist2 = new List<Jobs>();

        Jobs job1 = new Jobs()
        {
            day = "April 1",
            task = "Testing Event",
            approval = "Approve all STP",
            responsibility = "sanketnaik.naik@cerner.com",
            target = "EOW",
            week = 1
        };

        Jobs job2 = new Jobs()
        {
            day = "April 1",
            task = "Testing Event",
            approval = "Approve all STP",
            responsibility = "Invalid",
            target = "EOW",
            week = 1
        };


        [TestMethod]
        public void OutlookEvent_Return_true()
        {
            Datalist1.Add(job1);
            OutlookEventModel _oe = new OutlookEventModel(Datalist1);
            bool result=_oe.Event();
        }

        [TestMethod]
        public void OutlookEvent_Return_False()
        {
            bool expected = false;
            Datalist2.Add(job2);
            OutlookEventModel _oe = new OutlookEventModel(Datalist2);
            bool result = _oe.Event();
            Assert.AreEqual(expected, result);
        }

    }
}
