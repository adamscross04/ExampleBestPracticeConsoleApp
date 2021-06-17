using System;

namespace ExampleConsoleApplication.Extensions
{
    public static class StringArrayExtensions
    {
        public static void EnsureFieldPresent(this string[] data, int index, out string returnValue)
        {
            returnValue = data[index].Trim();
        }

        public static void EnsureFieldPresent(this string[] data, int index, out double returnValue)
        {
            data.EnsureFieldPresent(index, out string stringValue);
            returnValue = double.Parse(stringValue);
        }

        public static void EnsureFieldPresent(this string[] data, int index, out DateTime returnValue)
        {
            data.EnsureFieldPresent(index, out string stringValue);
            returnValue = DateTime.Parse(stringValue);
        }

        public static void EnsureFieldPresent(this string[] data, int index, out bool returnValue)
        {
            data.EnsureFieldPresent(index, out string stringValue);
            returnValue = bool.Parse(stringValue);
        }

        public static void EnsureFieldPresent(this string[] data, int index, out int returnValue)
        {
            data.EnsureFieldPresent(index, out string stringValue);
            returnValue = int.Parse(stringValue);
        }
    }
}