using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace UTStoreDemo.Helpers
{
    public static class ImageHelper
    {
        private static string flagPath = "https://raw.githubusercontent.com/hjnilsson/country-flags/master/png250px/";

        public static async Task<byte[]> LoadCountryFlagContent(string CountryCode, HttpClient httpClient)
        {
            string iconUrl = ImageHelper.flagPath + CountryCode + ".png";

            Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(iconUrl);

            var contents = await contentsTask;

            return contents;
        }
    }
}
