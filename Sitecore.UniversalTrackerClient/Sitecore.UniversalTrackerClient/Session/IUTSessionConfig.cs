﻿namespace Sitecore.UniversalTrackerClient.Session
{
    public interface IUTSessionConfig
    {
        IUTSessionConfig SessionConfigShallowCopy();

        /// <summary>
        /// Specifies URL to the Sitecore instance, must starts with "http://" or "https://" prefix.
        /// 
        /// The value is case insensitive.
        /// </summary>
        string InstanceUrl
        {
            get;
        }
    }
}