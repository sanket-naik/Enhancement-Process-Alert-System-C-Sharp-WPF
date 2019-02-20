using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAS.ViewModel.LoginViewModel;
using EPAS.Views;
using DynamicLocalization;

namespace Testing
{
    [TestClass]
    public class LoginTest
    {

        [TestMethod]
        public void CanExecute_True_Test1()
        {
            LoginViewModel Validate = new LoginViewModel();
            bool Expected = true;
            Validate.Username = "DemoUser";
            Validate.Password = "DemoPass";
            bool Result = Validate.SubmitCommand.CanExecute(null);
            Assert.AreEqual(Result, Expected);

        }

        [TestMethod]
        public void CanExecute_False_Test2()
        {
            LoginViewModel Validate = new LoginViewModel();
            bool Expected = false;
            Validate.Username = "";
            Validate.Password = "";
            bool Result = Validate.SubmitCommand.CanExecute(null);
            Assert.AreEqual(Result, Expected);

        }

        [TestMethod]
        public void CanExecute_False_Test3()
        {
            LoginViewModel Validate = new LoginViewModel();
            bool Expected = false;
            Validate.Username = "DemoUser";
            Validate.Password = "";
            bool Result = Validate.SubmitCommand.CanExecute(null);
            Assert.AreEqual(Result, Expected);

        }

        [TestMethod]
        public void Execute_Method_Test1()
        {
            LoginViewModel Validate = new LoginViewModel();
            Validate.Username = "DemoUser";
            Validate.Password = "DemoPass";
            Validate.SubmitCommand.Execute(null);
        }

        [TestMethod]
        public void Execute_Method_Test2()
        {
            LoginViewModel Validate = new LoginViewModel();
            Validate.Username = "";
            Validate.Password = "";
            Validate.SubmitCommand.Execute(null);
        }

        [TestMethod]
        public void Login_View_Test()
        {
            LoginView Validate = new LoginView();
        }

        [TestMethod]
        public void LocUtil_View_Test()
        {
            LoginView login = new LoginView();
            LocUtil.SwitchLanguage(login, "en-US");
        }
    }
}
