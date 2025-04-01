// ReSharper disable MemberCanBePrivate.Global

using System.Text.RegularExpressions;
using Common.Validation.Models;

namespace Common.Validation.Implementations
{
    /// <summary>
    /// Base class for validation services.
    /// </summary>
    /// <typeparam name="T">The type of the object to be validated.</typeparam>
    public abstract class ValidationServiceBase<T>
    {
        /// <summary>
        /// Overrideable validation logic for the specified object.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>An enumerable of validation error messages.</returns>
        protected abstract IEnumerable<string> DoValidate(T obj);

        /// <summary>
        /// Validates the specified object and returns a validation result.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> containing the validation errors.</returns>
        public ValidationResult Validate(T obj)
        {
            // Force enumeration via ToArray so that all yield return code executes.
            string[] errors = DoValidate(obj).ToArray();
            return new ValidationResult { Errors = errors };
        }

        // String helpers

        protected bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        protected bool IsNotEmpty(string value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// Checks if the specified string value matches the provided regular expression pattern.
        /// </summary>
        protected bool MatchesRegex(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// Checks if the specified email is in a valid format.
        /// </summary>
        protected bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the specified URL is valid.
        /// </summary>
        protected bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

        // Guid helpers

        protected bool IsEmpty(Guid value)
        {
            return value == Guid.Empty;
        }

        protected bool IsNotEmpty(Guid value)
        {
            return !IsEmpty(value);
        }

        // Decimal helpers

        protected bool IsZero(decimal value)
        {
            return value == 0;
        }

        protected bool IsNotZero(decimal value)
        {
            return value != 0;
        }

        protected bool IsZeroOrNegative(decimal value)
        {
            return value <= 0;
        }

        protected bool IsNegative(decimal value)
        {
            return value < 0;
        }

        protected bool IsPositive(decimal value)
        {
            return value > 0;
        }

        /// <summary>
        /// Checks if the decimal value is between the specified minimum and maximum (inclusive).
        /// </summary>
        protected bool IsBetween(decimal value, decimal min, decimal max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Checks if the decimal value is greater than the specified minimum.
        /// </summary>
        protected bool IsGreaterThan(decimal value, decimal min)
        {
            return value > min;
        }

        /// <summary>
        /// Checks if the decimal value is less than the specified maximum.
        /// </summary>
        protected bool IsLessThan(decimal value, decimal max)
        {
            return value < max;
        }

        // DateTime helpers

        /// <summary>
        /// Checks if the given date is in the past.
        /// </summary>
        protected bool IsInPast(DateTime date)
        {
            return date < DateTime.Now;
        }

        /// <summary>
        /// Checks if the given date is in the future.
        /// </summary>
        protected bool IsInFuture(DateTime date)
        {
            return date > DateTime.Now;
        }

        // Collection helpers

        /// <summary>
        /// Checks if the collection is null or empty.
        /// </summary>
        protected bool IsEmpty<TItem>(IEnumerable<TItem> collection)
        {
            return collection == null || !collection.Any();
        }

        /// <summary>
        /// Checks if the collection is not null and contains at least one element.
        /// </summary>
        protected bool IsNotEmpty<TItem>(IEnumerable<TItem> collection)
        {
            return collection != null && collection.Any();
        }

        // String length helpers

        protected bool IsShorterThan(string value, int length)
        {
            return value.Length < length;
        }

        protected bool IsLongerThan(string value, int length)
        {
            return value.Length > length;
        }

        protected bool IsShorterThanOrEqual(string value, int length)
        {
            return value.Length <= length;
        }

        protected bool IsLongerThanOrEqual(string value, int length)
        {
            return value.Length >= length;
        }

        // Generic null-check helpers

        /// <summary>
        /// Checks if the given object is null.
        /// </summary>
        protected bool IsNull(object obj)
        {
            return obj is null;
        }

        /// <summary>
        /// Checks if the given object is not null.
        /// </summary>
        protected bool IsNotNull(object obj)
        {
            return obj != null;
        }

        // Enum helper

        /// <summary>
        /// Checks if the specified enum value is defined.
        /// </summary>
        protected bool IsValidEnumValue<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}