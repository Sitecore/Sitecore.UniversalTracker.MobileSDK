using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
using Sitecore.UniversalTrackerClient.Response;
using Sitecore.UniversalTrackerClient.Session;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;

namespace UniversalTrackerTestsShared
{
    [TestFixture]
    public class CancelOperationsTest
    {
        private ISitecoreUTSession session;
        private Int32 standardDelay = 10;


        [SetUp]
        public void Setup()
        {
            this.session = SitecoreUTSessionBuilder.SessionWithHost(TestEndpointsConfig.InstanceUrl)
                                                   .BuildSession();
        }

        [TearDown]
        public void TearDown()
        {
            this.session.Dispose();
            this.session = null;
        }

        [Test]
        public void TestCancelInteraction()
        {
            var request = UTRequestBuilder.Interaction(UTEvent.GetEmptyEvent())
                                          .Build();


            var cancelToken = CreateCancelTokenWithDelay(standardDelay);
            UTEventResponse response = null;

            // do not use Task.WaitAll() since it may cause deadlocks
            TestDelegate testCode = async () =>
            {
                var task = this.session.TrackInteractionAsync(request, cancelToken);
                response = await task;
            };

            var exception = Assert.Catch<OperationCanceledException>(testCode);
            Debug.WriteLine("Expected token : " + cancelToken);
            Debug.WriteLine("Received token : " + exception.CancellationToken);


            Assert.IsNull(response);
            //      Desktop (Windows) : "A task was canceled."
            //      iOS               : "The Task was canceled"
            Assert.IsTrue(exception.Message.ToLowerInvariant().Contains("task was canceled"));

            // CancellationToken class comparison or scheduling works differently on iOS
            // Assert.AreEqual(cancelToken, exception.CancellationToken);
        }

        [Test]
        public void TestCancelEvent()
        {
            var request = UTRequestBuilder.EventWithDefenitionId(TestEndpointsConfig.HomeItemID)
                                          //  .AddCustomValues("1", "1")
                                          .Build();


            var cancelToken = CreateCancelTokenWithDelay(standardDelay);
            UTEventResponse response = null;

            // do not use Task.WaitAll() since it may cause deadlocks
            TestDelegate testCode = async () =>
            {
                var task = this.session.TrackEventAsync(request, cancelToken);
                response = await task;
            };

            var exception = Assert.Catch<OperationCanceledException>(testCode);
            Debug.WriteLine("Expected token : " + cancelToken);
            Debug.WriteLine("Received token : " + exception.CancellationToken);


            Assert.IsNull(response);
            //      Desktop (Windows) : "A task was canceled."
            //      iOS               : "The Task was canceled"
            Assert.IsTrue(exception.Message.ToLowerInvariant().Contains("task was canceled"));

            // CancellationToken class comparison or scheduling works differently on iOS
            // Assert.AreEqual(cancelToken, exception.CancellationToken);
        }

        [Test]
        public void TestCancelLocationEvent()
        {
            double lat = 37.342454;
            double lon = -122.342454;
            var request = UTRequestBuilder.LocationEvent(lat, lon)
                                          .Build();


            var cancelToken = CreateCancelTokenWithDelay(standardDelay);
            UTEventResponse response = null;

            // do not use Task.WaitAll() since it may cause deadlocks
            TestDelegate testCode = async () =>
            {
                var task = this.session.TrackLocationEventAsync(request, cancelToken);
                response = await task;
            };

            var exception = Assert.Catch<OperationCanceledException>(testCode);
            Debug.WriteLine("Expected token : " + cancelToken);
            Debug.WriteLine("Received token : " + exception.CancellationToken);


            Assert.IsNull(response);
            //      Desktop (Windows) : "A task was canceled."
            //      iOS               : "The Task was canceled"
            Assert.IsTrue(exception.Message.ToLowerInvariant().Contains("task was canceled"));

            // CancellationToken class comparison or scheduling works differently on iOS
            // Assert.AreEqual(cancelToken, exception.CancellationToken);
        }

        [Test]
        public void TestCancelErrorEvent()
        {
            var request = UTRequestBuilder.ErrorEvent("some error", "some error description")
                                          .Build();


            var cancelToken = CreateCancelTokenWithDelay(standardDelay);
            UTEventResponse response = null;

            // do not use Task.WaitAll() since it may cause deadlocks
            TestDelegate testCode = async () =>
            {
                var task = this.session.TrackErrorEventAsync(request, cancelToken);
                response = await task;
            };

            var exception = Assert.Catch<OperationCanceledException>(testCode);
            Debug.WriteLine("Expected token : " + cancelToken);
            Debug.WriteLine("Received token : " + exception.CancellationToken);


            Assert.IsNull(response);
            //      Desktop (Windows) : "A task was canceled."
            //      iOS               : "The Task was canceled"
            Assert.IsTrue(exception.Message.ToLowerInvariant().Contains("task was canceled"));

            // CancellationToken class comparison or scheduling works differently on iOS
            // Assert.AreEqual(cancelToken, exception.CancellationToken);
        }

        [Test]
        public void TestCancelAppLaunchedEvent()
        {
            var request = UTRequestBuilder.AppLaunchedEvent()
                                          .Build();


            var cancelToken = CreateCancelTokenWithDelay(standardDelay);
            UTEventResponse response = null;

            // do not use Task.WaitAll() since it may cause deadlocks
            TestDelegate testCode = async () =>
            {
                var task = this.session.TrackEventAsync(request, cancelToken);
                response = await task;
            };

            var exception = Assert.Catch<OperationCanceledException>(testCode);
            Debug.WriteLine("Expected token : " + cancelToken);
            Debug.WriteLine("Received token : " + exception.CancellationToken);


            Assert.IsNull(response);
            //      Desktop (Windows) : "A task was canceled."
            //      iOS               : "The Task was canceled"
            Assert.IsTrue(exception.Message.ToLowerInvariant().Contains("task was canceled"));

            // CancellationToken class comparison or scheduling works differently on iOS
            // Assert.AreEqual(cancelToken, exception.CancellationToken);
        }

        [Test]
        public void TestCancelAppFinishedEvent()
        {
            var request = UTRequestBuilder.AppFinishedEvent()
                                          .Build();


            var cancelToken = CreateCancelTokenWithDelay(standardDelay);
            UTEventResponse response = null;

            // do not use Task.WaitAll() since it may cause deadlocks
            TestDelegate testCode = async () =>
            {
                var task = this.session.TrackEventAsync(request, cancelToken);
                response = await task;
            };

            var exception = Assert.Catch<OperationCanceledException>(testCode);
            Debug.WriteLine("Expected token : " + cancelToken);
            Debug.WriteLine("Received token : " + exception.CancellationToken);


            Assert.IsNull(response);
            //      Desktop (Windows) : "A task was canceled."
            //      iOS               : "The Task was canceled"
            Assert.IsTrue(exception.Message.ToLowerInvariant().Contains("task was canceled"));

            // CancellationToken class comparison or scheduling works differently on iOS
            // Assert.AreEqual(cancelToken, exception.CancellationToken);
        }

        private static CancellationToken CreateCancelTokenWithDelay(Int32 delay)
        {
            var cancelTokenSource = new CancellationTokenSource();
            cancelTokenSource.CancelAfter(delay);
            var cancelToken = cancelTokenSource.Token;

            return cancelToken;
        }

    }
}
