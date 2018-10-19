using System;
using System.Threading.Tasks;
using Sitecore.MobileSDK.API.Items;
using Sitecore.MobileSDK.API.Session;
using SSCExtensions;
using Sitecore.MobileSDK.API;

namespace UTStoreDemo.Helpers
{
    public static class NetworkHelper
    {
        public static async Task<ScItemsResponse> GetAllCities()
        {
            string query = "/sitecore/content/Home//*[@@templatename='City Item']";

            ScItemsResponse response = await NetworkHelper.GetItemsByQyery(query);

            return response;
        }

        public static async Task<ScItemsResponse> GetAllCountries()
        {
            string query = "/sitecore/content/Home//*[@@templatename='Country Item']";

            ScItemsResponse response = await NetworkHelper.GetItemsByQyery(query);

            return response;
        }

        public static async Task<ScItemsResponse> GetAllRegions()
        {
            string query = "/sitecore/content/Home//*[@@templatename='Region Item']";

            ScItemsResponse response = await NetworkHelper.GetItemsByQyery(query);

            return response;
        }



        public static async Task<ISitecoreItem> GetRegionNamed(string gerionTitle)
        {
            string query = "/sitecore/content/Home//*[@@templatename='Region Item' and contains(@Title, '" + gerionTitle + "')]";

            ScItemsResponse response = await NetworkHelper.GetItemsByQyery(query);

            if (response == null || response.ResultCount == 0)
            {
                return null;
            }

            return response[0];
        }

        public static async Task<ISitecoreItem> GetCountryNamed(string countryTitle)
        {
            string query = "/sitecore/content/Home//*[@@templatename='Country Item' and contains(@Title, '" + countryTitle + "')]";

            ScItemsResponse response = await NetworkHelper.GetItemsByQyery(query);

            if (response == null || response.ResultCount == 0)
            {
                return null;
            }

            return response[0];
        }

        public static async Task<ISitecoreItem> GetCityNamed(string cityTitle)
        {
            string query = "/sitecore/content/Home//*[@@templatename='City Item' and contains(@Title, '" + cityTitle + "')]";

            ScItemsResponse response = await NetworkHelper.GetItemsByQyery(query);

            if (response == null || response.ResultCount == 0)
            {
                return null;
            }

            return response[0];
        }

        public static async Task<ScItemsResponse> GetCountriesForRegion(string regionTitle)
        {
            ISitecoreItem region = await NetworkHelper.GetRegionNamed(regionTitle);

            if (region == null)
            {
                return null;
            }

            ScItemsResponse response = await NetworkHelper.GetCountriesForRegion(region);

            return response;
        }

        public static async Task<ScItemsResponse> GetCountriesForRegion(ISitecoreItem region)
        {
            ScItemsResponse response = await NetworkHelper.GetItemChildren(region);

            return response;
        }

        public static async Task<ScItemsResponse> GetCitiesForCountry(string countryTitle)
        {
            ISitecoreItem country = await NetworkHelper.GetCountryNamed(countryTitle);

            if (country == null)
            {
                return null;
            }

            ScItemsResponse response = await NetworkHelper.GetCitiesForCountry(country);

            return response;
        }

        public static async Task<ScItemsResponse> GetCitiesForCountry(ISitecoreItem country)
        {

            ScItemsResponse response = await NetworkHelper.GetItemChildren(country);

            return response;
        }

        private static async Task<ScItemsResponse> GetItemsByQyery(string query)
        {
            using (var credentials = ScNetworkSettings.Credentials())
            {

                using (var session = ScNetworkSettings.Session(credentials))
                {
                    var ext = ExtendedSessionBuilder.ExtendedSessionWith(session)
                                                    .PathForTemporaryItems("/sitecore/content/Home")
                                                    .Build();

                    var request = ExtendedSSCRequestBuilder.SitecoreQueryRequest(query)
                                                           .PageNumber(0)
                                                           .ItemsPerPage(500)//max
                                                           .Build();

                    var response = await ext.SearchBySitecoreQueryAsync(request);

                    return response;
                }
            }
        }

        private static async Task<ScItemsResponse> GetItemChildren(ISitecoreItem parentItem)
        {
            using (var credentials = ScNetworkSettings.Credentials())
            {

                using (var session = ScNetworkSettings.Session(credentials))
                {

                    var request = ItemSSCRequestBuilder.ReadChildrenRequestWithId(parentItem.Id)
                        .Build();

                    var response = await session.ReadChildrenAsync(request);

                    return response;
                }
            }
        }
    }
}
