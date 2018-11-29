namespace Sitecore.UniversalTrackerClient.Validators
{
    using System;

    public static class ItemIdValidator
    {
        private const string INVALID_ID_MESSAGE = "wrong item id";
        private const string EMPTY_ERROR_MESSAGE = "Item can not be empty";


        public static void ValidateItemId(string itemId, string source)
        {
#warning @igk clarify the item id pattern
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(itemId, source);

            bool correctIdLenght = (itemId.Length == 36 || itemId.Length == 38);
            if (!correctIdLenght)
            {
                throw new ArgumentException(source + " : " + INVALID_ID_MESSAGE);
            }
        }
    }
}

