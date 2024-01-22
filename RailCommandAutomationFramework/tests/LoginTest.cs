using RailCommandAutomationFramework.pages;
using RailCommandAutomationFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailCommandAutomationFramework.tests
{
    internal class LoginTest:Base
    {
            
        [Test]
        public void testLogin()
        {
            LoginPage lp = new LoginPage(driver.Value);
            lp.Login("nkaya@rsilogistics.commm", "Vanderrohe2!");

            lp.selectRsiTestClientUser();
        }
    }
}
    

