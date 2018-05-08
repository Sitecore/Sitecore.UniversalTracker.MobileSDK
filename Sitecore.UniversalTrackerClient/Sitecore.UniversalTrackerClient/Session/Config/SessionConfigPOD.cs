
namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Session.Config;

	public class SessionConfigPOD : IUTSessionConfig
    {
        private SessionConfigPOD SessionConfigPODCopy()
        {
            SessionConfigPOD result = new SessionConfigPOD();
            result.InstanceUrl = this.InstanceUrl;

            return result;
        }

		public virtual IUTSessionConfig SessionConfigShallowCopy()
        {
            return this.SessionConfigPODCopy();
        }
        
        public string InstanceUrl { get; set; }
      
        #region Comparator
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            SessionConfigPOD other = (SessionConfigPOD)obj;
            if (null == other)
            {
                return false;
            }


            bool isUrlEqual = object.Equals(this.InstanceUrl, other.InstanceUrl);

            return isUrlEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.InstanceUrl.GetHashCode();
        }
        #endregion Comparator
    }
}