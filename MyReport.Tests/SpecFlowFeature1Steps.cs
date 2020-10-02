using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MyReport.Tests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            Thread.Sleep(1000);
        }
        
        
    }
}
