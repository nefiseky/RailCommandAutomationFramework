using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailCommandAutomationFramework.pages
{
    internal class ShipmentPage
    {
        private readonly IWebDriver driver;

        public ShipmentPage(IWebDriver driver)
        {
            this.driver = driver;

        }

      

       public IWebElement shipmentDropdown => driver.FindElement(By.XPath("//button[@data-testid='Shipments-nav-group']"));
       public  IWebElement shipmentOption => driver.FindElement(By.LinkText("Shipments"));

        public IWebElement createTab => driver.FindElement(By.LinkText("Create"));
        public IWebElement originStation => driver.FindElement(By.Id("patternOrigin"));
        public IWebElement destinationStation => driver.FindElement(By.Id("patternDestination"));
        public IWebElement atlantaOption => driver.FindElement(By.Id("patternOrigin-item-0"));
        public IWebElement chicagoSLOption => driver.FindElement(By.CssSelector("#patternDestination-item-0 > .Item_content-wrapper__ex3z7"));
        public IWebElement patternBox => driver.FindElement(By.Id("patternId"));
        public IWebElement patternOption => driver.FindElement(By.Id("patternId-item-0"));
        public IWebElement extendedReferenceTextBox => driver.FindElement(By.Id("shipmentExtendedReferences[0].referenceText"));
        public IWebElement equipmentBox => driver.FindElement(By.Id("shipmentEquipments[0].equipmentCode"));

        public IWebElement equipmentSelection => driver.FindElement(By.Id("shipmentEquipments[0].equipmentCode-item-0"));
        public IWebElement weightBox => driver.FindElement(By.Id("shipmentEquipments[0].weight"));
        public IWebElement comodityBox => driver.FindElement(By.Id("shipmentCommodities[0].commodityId-item-0"));
        public IWebElement reviewBOL => driver.FindElement(By.Name("submitButton"));

        public IWebElement createShipmentTab => driver.FindElement(By.Name("submitButton"));

        public IWebElement shippedDateBoxShipments => driver.FindElement(By.XPath("//div[@row-index='0']/div[@col-id='shipped']"));

        public IWebElement bolBoxShipments => driver.FindElement(By.XPath("//div[@row-index='0']/div[@col-id='bol']"));

        public IWebElement  equipmentBoxShipments => driver.FindElement(By.XPath("//div[@row-index='0']/div[@col-id='equipmentCode']"));

        public IWebElement weightBoxShipments => driver.FindElement(By.XPath("//div[@row-index='0']/div[@col-id='weight']"));

        public IWebElement scacBoxShipments => driver.FindElement(By.XPath("//div[@row-index='0']/div[@col-id='scac']"));

        public IWebElement shippedDateBox => driver.FindElement(By.Id("shipped-date"));
        public IWebElement shippedTimeBox => driver.FindElement(By.Id("shipped-time"));
        public IWebElement detailsTab => driver.FindElement(By.Id("additional-info-nav-item"));

        public IWebElement federalTaxIdNumber => driver.FindElement(By.Id("shipmentParties[2].federalTaxpayerId"));


        public IWebElement lineHaul => driver.FindElement(By.Id("route-line-haul"));

    }
}
