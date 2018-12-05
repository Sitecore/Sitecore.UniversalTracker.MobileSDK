using System;
using NUnit.Framework;
using Sitecore.UniversalTrackerClient;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
using Sitecore.UniversalTrackerClient.Session.Config;
using Sitecore.UniversalTrackerClient.UserRequest;

namespace UniversalTrackerTestsShared
{
    [TestFixture]
    public class UrlBuilderTest
    {
        private UTSessionConfig sessionConfig;

        private TrackInteractionUrlBuilder<ITrackInteractionRequest> interactionUrlBuilder;
        private TrackEventUrlBuilder<ITrackEventRequest> eventUrlBuilder;
        private UTEvent testEvent = new UTEvent(null, null, null, null, null, null, null, null, null);
        private UTInteraction testInteraction = new UTInteraction(null, null, null, null, null, null, null);


        [SetUp]
        public void Setup()
        {
            this.sessionConfig = new UTSessionConfig(TestEndpointsConfig.InstanceUrl);
            this.interactionUrlBuilder = new TrackInteractionUrlBuilder<ITrackInteractionRequest>(UTGrammar.UTV1Grammar());
            this.eventUrlBuilder = new TrackEventUrlBuilder<ITrackEventRequest>(UTGrammar.UTV1Grammar());
        }

        [TearDown]
        public void TearDown()
        {
            this.sessionConfig = null;

            this.interactionUrlBuilder = null;
            this.eventUrlBuilder = null;
        }

        [Test]
        public void TestNullEventRequest()
        {
            TestDelegate action = () => this.eventUrlBuilder.GetUrlForRequest(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void TestNullInteractionRequest()
        {
            TestDelegate action = () => this.interactionUrlBuilder.GetUrlForRequest(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void TestEventNullSessionConfigParams()
        {
            TestDelegate action = () =>
            {
                var parameters = new TrackEventParameters(null, testEvent);

                this.eventUrlBuilder.GetUrlForRequest(parameters);
            };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void TestInteractionNullSessionConfigParams()
        {
            TestDelegate action = () =>
            {
                var parameters = new TrackInteractionParameters(null, testInteraction);

                this.interactionUrlBuilder.GetUrlForRequest(parameters);
            };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void TestEventNullParams()
        {
            TestDelegate action = () =>
            {
                var parameters = new TrackEventParameters(this.sessionConfig, null);

                this.eventUrlBuilder.GetUrlForRequest(parameters);
            };

            Assert.Throws<ArgumentNullException>(action);
        } 

        [Test]
        public void TestInteractionNullParams()
        {
            TestDelegate action = () =>
            {
                var parameters = new TrackInteractionParameters(this.sessionConfig, null);

                this.interactionUrlBuilder.GetUrlForRequest(parameters);
            };

            Assert.Throws<ArgumentNullException>(action);
        }


        [Test]
        public void TestEventCorrectRequest()
        {
            var parameters = new TrackEventParameters(this.sessionConfig, this.testEvent);

            var url = this.eventUrlBuilder.GetUrlForRequest(parameters);

            Assert.AreEqual("https://localhost/event", url);
        }

        [Test]
        public void TestInteractionCorrectRequest()
        {
            var parameters = new TrackInteractionParameters(this.sessionConfig, this.testInteraction);

            var url = this.interactionUrlBuilder.GetUrlForRequest(parameters);

            Assert.AreEqual("https://localhost/interaction", url);
        }
    }
}
