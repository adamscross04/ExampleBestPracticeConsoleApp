// A dummy implementation that exposes the protected helpers for testing.

using Common.Validation.Implementations;

public class TestValidationService : ValidationServiceBase<object>
{
    // We don't need any validation logic for our tests here.
    protected override IEnumerable<string> DoValidate(object obj)
    {
        return Enumerable.Empty<string>();
    }

    // Expose string helpers
    public bool TestIsEmptyString(string value) => IsEmpty(value);
    public bool TestIsNotEmptyString(string value) => IsNotEmpty(value);
    public bool TestMatchesRegex(string input, string pattern) => MatchesRegex(input, pattern);
    public bool TestIsValidEmail(string email) => IsValidEmail(email);
    public bool TestIsValidUrl(string url) => IsValidUrl(url);

    // Expose Guid helpers
    public bool TestIsEmptyGuid(Guid value) => IsEmpty(value);
    public bool TestIsNotEmptyGuid(Guid value) => IsNotEmpty(value);

    // Expose decimal helpers
    public bool TestIsZeroDecimal(decimal value) => IsZero(value);
    public bool TestIsNotZeroDecimal(decimal value) => IsNotZero(value);
    public bool TestIsNegativeDecimal(decimal value) => IsNegative(value);
    public bool TestIsPositiveDecimal(decimal value) => IsPositive(value);
    public bool TestIsBetweenDecimal(decimal value, decimal min, decimal max) => IsBetween(value, min, max);
    public bool TestIsGreaterThan(decimal value, decimal min) => IsGreaterThan(value, min);
    public bool TestIsLessThan(decimal value, decimal max) => IsLessThan(value, max);

    // Expose DateTime helpers
    public bool TestIsInPast(DateTime date) => IsInPast(date);
    public bool TestIsInFuture(DateTime date) => IsInFuture(date);

    // Expose collection helpers
    public bool TestIsEmptyCollection<T>(IEnumerable<T> collection) => IsEmpty(collection);
    public bool TestIsNotEmptyCollection<T>(IEnumerable<T> collection) => IsNotEmpty(collection);

    // Expose string length helpers
    public bool TestIsShorterThan(string value, int length) => IsShorterThan(value, length);
    public bool TestIsLongerThan(string value, int length) => IsLongerThan(value, length);
    public bool TestIsShorterThanOrEqual(string value, int length) => IsShorterThanOrEqual(value, length);
    public bool TestIsLongerThanOrEqual(string value, int length) => IsLongerThanOrEqual(value, length);

    // Expose generic null-check helpers
    public bool TestIsNull(object obj) => IsNull(obj);
    public bool TestIsNotNull(object obj) => IsNotNull(obj);

    // Expose enum helper
    public bool TestIsValidEnumValue<TEnum>(TEnum value) where TEnum : struct, Enum => IsValidEnumValue(value);
}
