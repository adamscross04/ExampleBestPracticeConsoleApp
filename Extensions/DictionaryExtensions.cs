using System;
using System.Collections.Generic;

namespace ExampleConsoleApplication.Extensions
{
    public static class DictionaryExtensions
    {
        public static void EnsureFieldPresent(this IDictionary<string, object> dictionary, string fieldName,
            out string returnValue)
        {
            if (!dictionary.ContainsKey(fieldName))
                throw new MissingFieldException($"property '{fieldName}' must be provided");

            returnValue = dictionary[fieldName].ToString();
        }

        public static void EnsureFieldPresent(this IDictionary<string, object> dictionary, string fieldName,
            out double returnValue)
        {
            dictionary.EnsureFieldPresent(fieldName, out string stringValue);
            returnValue = double.Parse(stringValue);
        }

        public static void EnsureFieldPresent(this IDictionary<string, object> dictionary, string fieldName,
            out DateTime returnValue)
        {
            dictionary.EnsureFieldPresent(fieldName, out string stringValue);
            returnValue = DateTime.Parse(stringValue);
        }

        public static void EnsureFieldPresent(this IDictionary<string, object> dictionary, string fieldName,
            out bool returnValue)
        {
            dictionary.EnsureFieldPresent(fieldName, out string stringValue);
            returnValue = bool.Parse(stringValue);
        }

        public static void EnsureFieldPresent(this IDictionary<string, object> dictionary, string fieldName,
            out int returnValue)
        {
            dictionary.EnsureFieldPresent(fieldName, out string stringValue);
            returnValue = int.Parse(stringValue);
        }
    }
}