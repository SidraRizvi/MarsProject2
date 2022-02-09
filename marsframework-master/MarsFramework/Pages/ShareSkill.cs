using MarsFramework.Global;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System.Threading;
using static NUnit.Core.NUnitFramework;
using OpenQA.Selenium.Interactions;
using System.IO;
using AutoIt;
using System.Diagnostics;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

               
        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Select Skill Exchange on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[1]/div/input")]
        private IWebElement SkillTradeOptionExchange { get; set; }

        //Select Credit on Skill Trade option 
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[2]/div/input")]
        private IWebElement SkillTradeOptionCredit { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        public IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        


        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }


        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Successful Message
        [FindsBy(How = How.XPath, Using = "/ html / body / div[1] / div")]
        private IWebElement Message { get; set; }

        //Error Message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]")]
        private IWebElement MessageError { get; set; }

        //Cancel button
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div.ui.vertically.padded.right.aligned.grid > div > input:nth-child(2)")]
        private IWebElement CancelButton { get; set; }

        //Click on Work Sample
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }

        // Title field Empty Warning Message
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div")]
        private IWebElement TitleWarningMessage { get; set; }

        // Description field Empty Warning Message
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/form/div[2]/div/div[2]/div[2]/div")]
        private IWebElement DescriptionWarningMessage { get; set; }

        // Category field Empty Warning Message
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/form/div[3]/div[2]/div[2]")]
        private IWebElement CategoryWarningMessage { get; set; }

        // Tags field Empty Warning Message
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/form/div[4]/div[2]/div[2]")]
        private IWebElement TagsWarningMessage { get; set; }

        // Skill Exchange Tag field Empty Warning Message
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[4]/div[2]")]
        private IWebElement SkillExchangeTagWarningMessage { get; set; }

        //Add Share Skill
        private void AddShareSkillSteps(int rowNo)
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Enter Title
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("title"), 5);
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Title"));

            //Enter Description
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Description"));

            // Enter Category
            SelectElement Category = new SelectElement(CategoryDropDown);
            Category.SelectByText(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Category"));

            //Enter Sub Category
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(rowNo, "SubCategory"));

          
            Thread.Sleep(3000);

            //Enter New Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Select Service Type
            string serviceTypeValue = GlobalDefinitions.ExcelLib.ReadData(rowNo, "ServiceType");
            IWebElement serviceType = ServiceTypeOptions.FindElement(By.XPath("//div[@class = 'ui radio checkbox']/input[following-sibling::label[text()='" + serviceTypeValue + "']]"));
            serviceType.Click();

            //Select Location Type
            string locationTypeValue = GlobalDefinitions.ExcelLib.ReadData(rowNo, "LocationType");
            IWebElement locationType = LocationTypeOption.FindElement(By.XPath("//div[@class = 'ui radio checkbox']/input[following-sibling::label[text()='" + locationTypeValue + "']]"));
            locationType.Click();

            Thread.Sleep(3000);
            Actions actions1 = new Actions(GlobalDefinitions.driver);                 
                     


            //Enter Start Date
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Startdate"));
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Enddate"));

            //Select Day
            string selectDayOption = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Selectday");
            IWebElement selectDay = Days.FindElement(By.XPath("//div[@class = 'ui checkbox']/input[following-sibling::label[text()='" + selectDayOption + "']]"));
            selectDay.Click();

            //Enter Start time
            IWebElement StartTime = StartTimeDropDown.FindElement(By.XPath(@"//div[@class = 'four wide field']/input[@name='StartTime' and @index='" + selectDay.GetAttribute("index") + "']"));
            string selectStartTime = DateTime.Parse(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Starttime")).ToShortTimeString().Remove(4, 1);
            StartTime.SendKeys(selectStartTime);


            //Enter End time
            IWebElement EndTime = EndTimeDropDown.FindElement(By.XPath(@"//div[@class = 'four wide field']/input[@name = 'EndTime'and @index='" + selectDay.GetAttribute("index") + "']"));
            string selectEndTime = DateTime.Parse(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Endtime")).ToShortTimeString().Remove(4, 1);
            EndTime.SendKeys(selectEndTime);

                       

            Thread.Sleep(3000);
            // Select Skill trade option
            string selectSkillTradeOption = GlobalDefinitions.ExcelLib.ReadData(rowNo, "SkillTrade");
            IWebElement selectSkillTrade = SkillTradeOption.FindElement(By.XPath("//div[@class = 'ui radio checkbox']/input[following-sibling::label[text()='" + selectSkillTradeOption + "']]"));
            selectSkillTrade.Click();

            //Enter Skill Trade value
            if (SkillTradeOptionExchange.Selected)
            {
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Credit"));
            }

            //Upload new text file in  Work Sample
            WorkSample.Click();
            Thread.Sleep(2000);
            Process.Start(@"C:\Users\Owner\Desktop\AutoIT\Worksample.exe");
           

           // Process.Start(@"E:\Industryconnect Repo\marsframework-master\marsframework-master\MarsFramework\Test\Worksample.exe");


            // Select Active/Hidden option
            string activeHiddenOption = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Active");
            IWebElement activeHidden = ActiveOption.FindElement(By.XPath("//div[@class = 'ui radio checkbox']/input[following-sibling::label[text()='" + activeHiddenOption + "']]"));
            activeHidden.Click();

            //Click on Save
            Save.Click();



        }
        internal void EnterShareSkill()
        {

            //Click on share skill button
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, By.LinkText("Share Skill"), 5);
            ShareSkillButton.Click();
            AddShareSkillSteps(2);
            Thread.Sleep(500);

        }
        internal void EnterEmptyFieldShareSkill()
        {

            //Click on share skill button
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, By.LinkText("Share Skill"), 5);

            ShareSkillButton.Click();

            AddShareSkillSteps(2);

        }

        internal void VerifyWarningMessage()
        {
            //Verify Error message if Mandatory fields are empty

            Assert.AreEqual(MessageError.Text, "Please complete the form correctly.");
            Base.test.Log(LogStatus.Pass, "Please complete the form correctly.");

            //Verify for Title Warning message
            if (Title.GetAttribute("value") == " ")
            {
                string titleActualMessage = TitleWarningMessage.Text;
                Assert.AreEqual(titleActualMessage, "Title is required");
                Base.test.Log(LogStatus.Pass, titleActualMessage);
            }

            //Verify for Description Warning message

            if (Description.GetAttribute("value") == "")
            {
                string descriptionActualMessage = DescriptionWarningMessage.Text;
                Assert.AreEqual(descriptionActualMessage, "Description is required");
                Base.test.Log(LogStatus.Pass, descriptionActualMessage);
            }

            //Verify for Category Warning message

            if (int.Parse(CategoryDropDown.GetAttribute("value")) == 0 || int.Parse(CategoryDropDown.GetAttribute("value")) >= 9)
            {
                string categoryActualMessage = CategoryWarningMessage.Text;
                Assert.AreEqual(categoryActualMessage, "Category is required");
                Base.test.Log(LogStatus.Pass, categoryActualMessage);
            }

            //Verify for Tags Warning message

            if (Tags.FindElement(By.XPath("..//..")).Text == "")
            {
                string tagsActualMessage = TagsWarningMessage.Text;
                Assert.AreEqual(tagsActualMessage, "Tag is required");
                Base.test.Log(LogStatus.Pass, tagsActualMessage);
            }

            //Verify for Skill exchange Tag Warning message
            if (SkillTradeOptionExchange.FindElement(By.XPath("..//..")).Text == "")
            {
                string skillExchangeActualMessage = SkillExchangeTagWarningMessage.Text;
                Assert.AreEqual(skillExchangeActualMessage, "Tag is required");
                Base.test.Log(LogStatus.Pass, skillExchangeActualMessage);
            }
            CancelButton.Click();

        }



        internal void EditShareSkill()
        {
            AddShareSkillSteps(3);

        }


        internal void VerifyListingAdded()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("/html/body/div[1]/div"), 5);
            string ExpectedMsg = "Service Listing added successfully";
            string ActualMsg = Message.Text;
            Assert.AreEqual(ExpectedMsg, ActualMsg);

        }
        internal void VerifyListingEdited()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("/html/body/div[1]/div"), 5);
            string ExpectedMsg = "Service Listing updated successfully";
            string ActualMsg = Message.Text;
            Assert.AreEqual(ExpectedMsg, ActualMsg);
        }
    }


}

