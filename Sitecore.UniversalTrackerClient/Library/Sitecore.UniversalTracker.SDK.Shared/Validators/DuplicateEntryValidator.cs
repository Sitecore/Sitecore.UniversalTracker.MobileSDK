﻿namespace Sitecore.UniversalTrackerClient.Validators
{
    using System;
    using System.Collections.Generic;

    public class DuplicateEntryValidator
    {
        private DuplicateEntryValidator()
        {
        }

        public static bool IsObjectInTheList(IEnumerable<Object> list, Object obj)
        {
            if (null == list)
            {
                return false;
            }

            foreach (Object singleElem in list)
            {
                if (singleElem.Equals(obj))
                {
                    return true;    
                }
            }

            return false;
        }

        public static bool IsDuplicatedFieldsInTheList(IEnumerable<string> fields)
        {
            if (null == fields)
            {
                return false;
            }

            var uniqueFields = new HashSet<string>();
            foreach (string singleField in fields)
            {
                bool isSingleFieldInvalid = String.IsNullOrWhiteSpace(singleField);
                if (isSingleFieldInvalid)
                {
                    return true;
                }

                string lowercaseSingleField = singleField.ToLowerInvariant();
                bool isDuplicateFound = uniqueFields.Contains(lowercaseSingleField);

                if (isDuplicateFound)
                {
                    return true;
                }

                uniqueFields.Add(lowercaseSingleField);
            }

            return false;
        }

        public static bool IsDuplicatedFieldsInTheListCaseInsensitive(IEnumerable<string> fields)
        {
            if (null == fields)
            {
                return false;
            }

            var uniqueFields = new HashSet<string>();
            foreach (string singleField in fields)
            {
                bool isSingleFieldInvalid = String.IsNullOrWhiteSpace(singleField);
                if (isSingleFieldInvalid)
                {
                    return true;
                }

                bool isDuplicateFound = uniqueFields.Contains(singleField);

                if (isDuplicateFound)
                {
                    return true;
                }

                uniqueFields.Add(singleField);
            }

            return false;
        }

        public static bool IsDuplicatedFieldsInTheDictionary(IDictionary<string, string> dictionary, string key)
        {
            if (null == key || null == dictionary)
            {
                return false;
            }

            if (dictionary.ContainsKey(key))
            {
                return true;
            }

            return false;
        }
    }
}

