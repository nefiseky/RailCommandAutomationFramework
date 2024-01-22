using RailCommandAutomationFramework.pages;
using RailCommandAutomationFramework.utilities;
using System.Reflection.Metadata;

namespace RailCommandAutomationFramework.tests
{
    internal class ShipmentTest : Base
    {
        [Test, TestCaseSource(nameof(AddTestDataConfig),Category="Regression")]
        // one class file can take multiple tests with [Test] annotation
        //  [TestCase("", "")]


        [Parallelizable(ParallelScope.All)]

        public void testShipment(string expectedWeightBoxValue, string expectedBolValue, string federalTaxIdNumber)
        {
            LoginPage lp = new LoginPage(driver.Value);
            lp.Login("nkaya@rsilogistics.com", "Vanderrohe2!");


            lp.selectRsiTestClientUser();

            ShipmentPage shipment = new ShipmentPage(driver.Value);

            string expectedSCACValue;
            string expectedShippedDate;

            shipment.shipmentDropdown.Click();
            shipment.shipmentOption.Click();
            shipment.createTab.Click();
            shipment.originStation.Click();
            shipment.atlantaOption.Click();
            shipment.destinationStation.Click();
            shipment.chicagoSLOption.Click();
            shipment.patternBox.Click();
            shipment.patternOption.Click();
            shipment.extendedReferenceTextBox.SendKeys(expectedBolValue);
            shipment.equipmentBox.Click();

            shipment.equipmentSelection.Click();
            string expectedEquipmentBoxValue = shipment.equipmentBox.GetAttribute("value");



            shipment.weightBox.SendKeys(expectedWeightBoxValue);


            expectedShippedDate = shipment.shippedDateBox.GetAttribute("value");


            string expectedShippedTime = shipment.shippedTimeBox.GetAttribute("value");

            string expectedShipmentDate = expectedShippedDate + " " + expectedShippedTime;
            Console.WriteLine(expectedShipmentDate);

            shipment.detailsTab.Click();
            expectedSCACValue = shipment.lineHaul.GetAttribute("value");
            shipment.federalTaxIdNumber.Click();
            shipment.federalTaxIdNumber.SendKeys(federalTaxIdNumber);



            shipment.reviewBOL.Submit();

            Thread.Sleep(100);

            shipment.createShipmentTab.Submit();

            Thread.Sleep(2000);


            string actualBolValue = shipment.bolBoxShipments.Text;


            string actualEquipmentBoxValue = shipment.equipmentBoxShipments.Text;

            string actualShipmentDate = shipment.shippedDateBoxShipments.Text;

            string actualSCACValue = shipment.scacBoxShipments.Text;


            // Parse the input string to DateTime object
            DateTime dateTime = DateTime.Parse(actualShipmentDate);

            // Format the DateTime object as required
            string formattedActualShipmentDateTime = dateTime.ToString("MM/dd/yyyy h:mm tt");

            Console.WriteLine("Formatted Actual Date and Time: " + formattedActualShipmentDateTime);

            DateTime dt = DateTime.Parse(expectedShipmentDate);

            // Format the DateTime object as required
            string formattedExpectedShipmentDateTime = dt.ToString("MM/dd/yyyy h:mm tt");

            Console.WriteLine("Formatted Expected Date and Time: " + formattedExpectedShipmentDateTime);



            Assert.That(actualBolValue, Is.EqualTo(expectedBolValue));

            Assert.That(actualEquipmentBoxValue, Is.EqualTo(expectedEquipmentBoxValue), $"Expected: {expectedEquipmentBoxValue}, Actual: {actualEquipmentBoxValue}");

            Assert.That(actualBolValue, Is.EqualTo(expectedBolValue), $"Expected: {expectedBolValue}, Actual: {actualBolValue}");

            Assert.That(formattedActualShipmentDateTime, Is.EqualTo(formattedExpectedShipmentDateTime), $"Expected: {formattedExpectedShipmentDateTime}, Actual: {formattedActualShipmentDateTime}");

            Assert.That(actualSCACValue, Is.EqualTo(expectedSCACValue), $"Expected: {expectedSCACValue}, Actual: {actualSCACValue}");

        }

        public static IEnumerable<TestCaseData> AddTestDataConfig() {


            yield return new TestCaseData(getDataParser().extractData("expectedWeightBoxValue1"), getDataParser().extractData("expectedBolValue1"), getDataParser().extractData("federalTaxIdNumber1"));
            yield return new TestCaseData(getDataParser().extractData("expectedWeightBoxValue2"), getDataParser().extractData("expectedBolValue2"), getDataParser().extractData("federalTaxIdNumber2"));


        }

}

    /*Notes: 
    Parallel Testing
        1. Run all data sets of Test method in parallel [Parallelizable(ParallelScope.All)]
        2.Run all test methods in one class parallel [Parallelizable(ParallelScope.Children)
        3.Run all test files in project [Parallelizable(ParallelScope.Self)  put tthis annotation on top of class name method for each class 
    you want to run all together at the same time
    
     Running tests from Terminal
    All tests:
    dotnet test RailCommandAutoamtionFramework.csproj
    To filter tests:
    dotnet test RailCommandAutomationFramework.csproj --filter TestCategory="Regression"

    dotnet test RailCommandAutomationFramework.csproj --filter TestRunParameters.Parameter(name="browserName", value="Chrome")
     
     */


}