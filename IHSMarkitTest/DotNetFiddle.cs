using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace IHSMarkitTest
{
    /// <summary>
    ///     Page object class representing DotNetFiddle site
    /// </summary>
    public class DotNetFiddle
    {
        // The DotNetSeleniumExtras.PageObjects package provides nice helpers for finding elements
        // Can be coded more traditionally too, but this provides nice syntactic sugar
        // Initializing to null prevents some field related warnings from appearing
        [FindsBy(How = How.Id, Using = "output")]
        private readonly IWebElement consoleOutput = null;

        [FindsBy(How = How.Id, Using = "login-modal")]
        private readonly IWebElement loginModal = null;

        [FindsBy(How = How.Id, Using = "login-modal-label")]
        private readonly IWebElement loginModalTitle = null;

        [FindsBy(How = How.Id, Using = "run-button")]
        private readonly IWebElement runBtn = null;

        [FindsBy(How = How.Id, Using = "save-button")]
        private readonly IWebElement saveBtn = null;


        /// <summary>
        ///     Intializes elements of DotNetFiddle web page
        /// </summary>
        /// <param name="driver"></param>
        public DotNetFiddle(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string ConsoleText => consoleOutput.Text;

        public bool LoginModalDisplayed => loginModal.Displayed;

        public string LoginModalTitle => loginModalTitle.Text;

        public void ClickRunBtn()
        {
            // Probably isn't the most efficient way to do this,
            // but we do want to make sure the button can be interacted with
            // before clicking
            _ = ExpectedConditions.ElementToBeClickable(runBtn);
            runBtn.Click();
        }

        public void ClickSaveBtn()
        {
            // Probably isn't the most efficient way to do this,
            // but we do want to make sure the button can be interacted with
            // before clicking
            _ = ExpectedConditions.ElementToBeClickable(saveBtn);
            saveBtn.Click();
        }
    }
}
