namespace Sitecore.UniversalTrackerClient.API.Exceptions
{
  using System;

  /// <summary>
  /// Base exception that represents errors that occur during working with Sitecore Mobile SDK.
  /// </summary>
  public class SitecoreUTSdkException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SitecoreUTSdkException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public SitecoreUTSdkException(string message, Exception inner = null)
      : base(message, inner)
    {
    }
  }
}

