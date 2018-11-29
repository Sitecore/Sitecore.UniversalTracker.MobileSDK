﻿
using Sitecore.MobileSDK.API;
using Sitecore.MobileSDK.API.Session;
using Sitecore.MobileSDK.PasswordProvider;
using Sitecore.MobileSDK.PasswordProvider.Interface;
using System.Net;

namespace UTStoreDemo.Helpers
{
    public static class ScNetworkSettings
    {
        private static string defaultDatabase = "web";
        public static string instanceUrl = "https://tst90170928.test24dk1.dk.sitecore.net/";

        public static IScCredentials Credentials()
        {
            return new ScUnsecuredCredentialsProvider("admin", "b", "sitecore");
        }

        public static ISitecoreSSCSession Session(IScCredentials credentials)
        {
            //return SitecoreSSCSessionBuilder.AnonymousSessionWithHost(instanceUrl)
            //                                .DefaultDatabase(defaultDatabase)
            //                                .BuildSession();

            

            var session = SitecoreSSCSessionBuilder.AuthenticatedSessionWithHost(instanceUrl)
                                                              .Credentials(credentials)
                                                              .DefaultDatabase(defaultDatabase)
                                                              .BuildSession();

            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            return session;
        }

    }
}