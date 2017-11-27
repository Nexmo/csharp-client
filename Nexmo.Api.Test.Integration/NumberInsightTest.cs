﻿using NUnit.Framework;

namespace Nexmo.Api.Test.Integration
{
    [TestFixture]
    public class NumberInsightTest
    {
        [Test]
        public void should_send_basic_ni_request()
        {
            var result = NumberInsight.RequestBasic(new NumberInsight.NumberInsightRequest
            {
                number = Configuration.Instance.Settings["test_number"]
            });
            Assert.AreEqual("0", result.status);
            Assert.AreEqual(Configuration.Instance.Settings["test_number"], result.international_format_number);
            Assert.AreEqual("(555) 555-1212", result.national_format_number);
            
        }

        [Test]
        public void should_send_standard_ni_request()
        {
            var result = NumberInsight.RequestStandard(new NumberInsight.NumberInsightRequest
            {
                number = Configuration.Instance.Settings["test_number"]
            });
            Assert.AreEqual("0", result.status);
            Assert.AreEqual(Configuration.Instance.Settings["test_number"], result.international_format_number);
            Assert.AreEqual("(555) 555-1212", result.national_format_number);
            Assert.AreEqual("Verizon Wireless", result.current_carrier.name);
        }
    }
}