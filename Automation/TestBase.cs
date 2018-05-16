using Builder.Driver;
using Entities;
using Entities.Pages.Redmart;
using Harness;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Automation
{
    public abstract class TestBase 
    {
        public PageNavigation Page;
        public string SuperUser;
        public string SuperPassword;
        public string TestName;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ReadSettings.ReadConfig();
            TestName = DriverManager.Instance.TestName;                      
            InititializeConfig();
        }

        public void InititializeConfig()
        {
            SuperUser = Configurations.userName;
            SuperPassword = Configurations.passWord;
            Page = UIAutomation.Page;
        }

        [TestCleanup]
        public void cleanup()
        {
            if ((TestContext.CurrentTestOutcome != UnitTestOutcome.Passed))
            {
                DriverManager.Instance.TakeFailureScreenshot();
            }

            DriverManager.Instance.NativeDriver.Quit();
            DriverManager.Reset();
        }

    }
}
