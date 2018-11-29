using System;
using System.Threading;
using NUnit.Framework;
using Sitecore.UniversalTrackerClient.Response;

namespace UniversalTrackerTestsShared
{
    [TestFixture]
    public class ResponseParserTest
    {

        [Test]
        public void TestParseNullData()
        {
            TestDelegate action = () => UTResponseParser.Parse(null, CancellationToken.None);

            Assert.Throws<ArgumentNullException>(action, "cannot parse null response");
        }

        //
    }
}
