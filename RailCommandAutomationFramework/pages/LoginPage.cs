
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;



namespace RailCommandAutomationFramework.pages
{
    public class LoginPage
    {
        
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
           
        }

        IWebElement usernameBox=> driver.FindElement(By.Id("1-email"));
        IWebElement passwordBox => driver.FindElement(By.Name("password"));

        IWebElement loginButton => driver.FindElement(By.Name("submit"));

        IWebElement users => driver.FindElement(By.Id("client-switcher"));
       

        IWebElement rsiTestClient => driver.FindElement(By.XPath("//*[@id='client-switcher-menu']/div[@class='VirtualList_virtual-list-wrapper__5TmIq']/ul/li[@id='client-switcher-item-59']"));




        public void Login(string username,string password) {
            usernameBox.SendKeys(username);
            passwordBox.SendKeys(password);
            loginButton.Submit();
          
        
        }

        public void selectRsiTestClientUser() {
            users.Click();


            Actions actions = new Actions(driver);


            for (int i = 21; i <= 59; i+=2)
            {
                actions.ScrollToElement(driver.FindElement(By.XPath("//*[@id='client-switcher-menu']/div[@class='VirtualList_virtual-list-wrapper__5TmIq']/ul/li[@id='client-switcher-item-"+i+"']"))).Build().Perform();
            }
            rsiTestClient.Click();





        }

















    }
}
