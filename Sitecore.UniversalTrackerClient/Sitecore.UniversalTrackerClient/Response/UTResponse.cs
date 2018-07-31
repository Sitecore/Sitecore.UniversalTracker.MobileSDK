using System.Collections.ObjectModel;

namespace Sitecore.UniversalTrackerClient.Response
{
    public class UTResponse 
    {
        
#warning not implemented!!!

        public UTResponse(int responseCode, string description, Collection<string> errors)
        {
            this.StatusCode = responseCode;
            this.Description = description;
        }

        public string Description
        {
            get;
            private set;
        }

        public bool Successful
        {
            get
            {
                //FIXME: @igk shold we use concrete codes!???
                if (this.StatusCode >= 200 && this.StatusCode < 300)
                {
                    return true;
                }

                return false;
            }
        }

        public int StatusCode
        {
            get;
            private set;
        }

        public Collection<string> Errors
        {
            get;
            private set;
        }
      
    }
}