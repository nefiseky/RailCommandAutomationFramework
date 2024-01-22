using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailCommandAutomationFramework.utilities
{
    internal class JsonReader
    {

   

        public string extractData(string tokenName) {

        var  myJsonString =  File.ReadAllText("utilities/testData.json");

           var jsonObject= JToken.Parse(myJsonString);
          return  jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string[] extractDataArray(string tokenName)
        {

            var myJsonString = File.ReadAllText("utilities/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
          
            List<string> arrayList=jsonObject.SelectTokens(tokenName).Values<string>().ToList();

           return arrayList.ToArray();

            //This is only for string arrays. If I want to return integers, I need to create another method for extractDataIntArray  and pass "int" into values and
            //method signituare.
        }
    }
}
