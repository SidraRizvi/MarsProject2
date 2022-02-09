using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            // Click on Sign In tab
            GlobalDefinitions.wait(5);
            SignIntab.Click();

            // Enter Email
            Email.Clear();
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //Enter Password
            Password.Clear();
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click on Login Button
            LoginBtn.Click();

        }
    }
}