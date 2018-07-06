namespace Sitecore.UniversalTrackerClient.Response
{
    public class UTEventResponse 
    {
        
#warning not implemented!!!

        public UTEventResponse(int responseCode)
        {
            this.StatusCode = responseCode;
        }

        public bool isSuccessful
        {
            get;
            private set;
        }

        public int StatusCode
        {
            get;
            private set;
        }
      
    }
}