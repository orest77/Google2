using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using TheBestProject.Data.Application;

namespace TheBestProject.Tools
{
    [TestFixture]
    public abstract class TestRunner
    {
        //public readonly Logger Log = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get(ApplicationSourceRepository.Get().ChromeMaximizedWithUi());
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            Application.Get().BaseUrlAction();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Application.Get().SaveCurrentState();
                //Log.Error("Test Failed");
            }
            // Logout
            Application.Remove();
        }
    }
}
