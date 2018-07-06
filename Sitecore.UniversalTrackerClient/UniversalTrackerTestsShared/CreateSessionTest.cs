using System;
using NUnit.Framework;
using Sitecore.UniversalTrackerClient.Session.Config;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;

namespace UniversalTrackerTestsShared
{
    [TestFixture]
    public class CreateSessionTest
    {
        #region Explicit Construction
        [Test]
        public void TestSessionConfig()
        {
            var sessionSettings = new UTSessionConfig("localhost");

            Assert.IsNotNull(sessionSettings);

            Assert.AreEqual("localhost", sessionSettings.InstanceUrl);
        }
        #endregion Explicit Construction

        #region Builder Interface
        [Test]
        public void TestSessionShouldBeCreatedByTheBuilder()
        {
            var session = SitecoreUTSessionBuilder.SessionWithHost("localhost")
                                                  .TokenValue("blablalbal")
                                                  .BuildSession();

            Assert.IsNotNull(session);
        }

        #endregion Builder Interface

        #region Write Once


        [Test]
        public void TestTokenIsWriteOnce()
        {
            Assert.Throws<InvalidOperationException>(() =>
              SitecoreUTSessionBuilder.SessionWithHost("localhost")
                                      .TokenValue("blablalbal")
                                      .TokenValue("bugaga")
            );
        }

        #endregion Write Once

        #region Validate Null
        [Test]
        public void TestTokenValueCanBeNull()
        {
            var session = SitecoreUTSessionBuilder.SessionWithHost("localhost")
                                                  .TokenValue(null)
                                                  .BuildSession();

            Assert.IsNotNull(session);
        }

        [Test]
        public void TestHostCanNotBeNull()
        {Assert.Throws<ArgumentNullException>(() =>
              SitecoreUTSessionBuilder.SessionWithHost(null)

            );
        }
        #endregion Validate Null


    }
}
