using Builder.DriverManager;
using Entities;
using Entities.Pages.Redmart;
using Harness.ReadSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Automation
{
    public abstract class TestBase 
    {
        public PageNavigation Page;
        public string SuperUser;
        public string SuperPassword;
        public string TestName;

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
            DriverManager.Instance.NativeDriver.Quit();
            DriverManager.Reset();
        }

    }
}
