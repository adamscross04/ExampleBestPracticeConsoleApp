using FluentAssertions;

namespace Common.Validation.Tests
{
    public class ValidationServiceBaseTests
    {
        private readonly TestValidationService _service = new();

        [Fact]
        public void IsEmptyString_ShouldReturnTrue_ForNullOrWhitespace()
        {
            _service.TestIsEmptyString(null!).Should().BeTrue();
            _service.TestIsEmptyString("").Should().BeTrue();
            _service.TestIsEmptyString("   ").Should().BeTrue();
        }

        [Fact]
        public void IsNotEmptyString_ShouldReturnTrue_ForNonEmptyString()
        {
            _service.TestIsNotEmptyString("hello").Should().BeTrue();
        }

        [Fact]
        public void MatchesRegex_ShouldReturnTrue_WhenInputMatchesPattern()
        {
            _service.TestMatchesRegex("123-45-6789", @"^\d{3}-\d{2}-\d{4}$").Should().BeTrue();
            _service.TestMatchesRegex("abc", @"\d+").Should().BeFalse();
        }

        [Fact]
        public void IsValidEmail_ShouldValidateEmailAddresses()
        {
            _service.TestIsValidEmail("test@example.com").Should().BeTrue();
            _service.TestIsValidEmail("invalid-email").Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void IsValidEmail_ShouldReturnFalse_WhenEmailIsNullOrWhitespace(string? email)
        {
            // Act
            bool result = _service.TestIsValidEmail(email);

            // Assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void IsValidUrl_ShouldValidateUrls()
        {
            _service.TestIsValidUrl("https://example.com").Should().BeTrue();
            _service.TestIsValidUrl("not-a-url").Should().BeFalse();
        }

        [Fact]
        public void IsEmptyGuid_ShouldReturnTrue_ForEmptyGuid()
        {
            _service.TestIsEmptyGuid(Guid.Empty).Should().BeTrue();
        }

        [Fact]
        public void IsNotEmptyGuid_ShouldReturnTrue_ForNonEmptyGuid()
        {
            _service.TestIsNotEmptyGuid(Guid.NewGuid()).Should().BeTrue();
        }

        [Fact]
        public void IsZeroDecimal_ShouldReturnTrue_WhenValueIsZero()
        {
            _service.TestIsZeroDecimal(0m).Should().BeTrue();
        }

        [Fact]
        public void IsNotZeroDecimal_ShouldReturnTrue_WhenValueIsNonZero()
        {
            _service.TestIsNotZeroDecimal(10m).Should().BeTrue();
        }

        [Fact]
        public void IsNegativeDecimal_ShouldReturnTrue_WhenValueIsNegative()
        {
            _service.TestIsNegativeDecimal(-5m).Should().BeTrue();
        }

        [Fact]
        public void IsPositiveDecimal_ShouldReturnTrue_WhenValueIsPositive()
        {
            _service.TestIsPositiveDecimal(5m).Should().BeTrue();
        }

        [Fact]
        public void IsBetweenDecimal_ShouldReturnTrue_WhenValueIsWithinRange()
        {
            _service.TestIsBetweenDecimal(5m, 1m, 10m).Should().BeTrue();
            _service.TestIsBetweenDecimal(0m, 1m, 10m).Should().BeFalse();
        }

        [Fact]
        public void IsGreaterThan_ShouldReturnTrue_WhenValueExceedsMinimum()
        {
            _service.TestIsGreaterThan(5m, 3m).Should().BeTrue();
            _service.TestIsGreaterThan(2m, 3m).Should().BeFalse();
        }

        [Fact]
        public void IsLessThan_ShouldReturnTrue_WhenValueIsBelowMaximum()
        {
            _service.TestIsLessThan(5m, 10m).Should().BeTrue();
            _service.TestIsLessThan(15m, 10m).Should().BeFalse();
        }

        [Fact]
        public void IsInPast_ShouldReturnTrue_WhenDateIsInPast()
        {
            _service.TestIsInPast(DateTime.Now.AddDays(-1)).Should().BeTrue();
            _service.TestIsInPast(DateTime.Now.AddDays(1)).Should().BeFalse();
        }

        [Fact]
        public void IsInFuture_ShouldReturnTrue_WhenDateIsInFuture()
        {
            _service.TestIsInFuture(DateTime.Now.AddDays(1)).Should().BeTrue();
            _service.TestIsInFuture(DateTime.Now.AddDays(-1)).Should().BeFalse();
        }

        [Fact]
        public void IsEmptyCollection_ShouldReturnTrue_ForNullOrEmptyCollection()
        {
            _service.TestIsEmptyCollection(new List<int>()).Should().BeTrue();
            _service.TestIsEmptyCollection<int>(null!).Should().BeTrue();
        }

        [Fact]
        public void IsNotEmptyCollection_ShouldReturnTrue_WhenCollectionHasItems()
        {
            _service.TestIsNotEmptyCollection([1, 2, 3]).Should().BeTrue();
        }

        [Fact]
        public void IsShorterThan_ShouldReturnTrue_WhenStringIsShorterThanSpecifiedLength()
        {
            _service.TestIsShorterThan("abc", 5).Should().BeTrue();
            _service.TestIsShorterThan("abcdef", 5).Should().BeFalse();
        }

        [Fact]
        public void IsLongerThan_ShouldReturnTrue_WhenStringIsLongerThanSpecifiedLength()
        {
            _service.TestIsLongerThan("abcdef", 5).Should().BeTrue();
            _service.TestIsLongerThan("abc", 5).Should().BeFalse();
        }

        [Fact]
        public void IsShorterThanOrEqual_ShouldReturnTrue_WhenStringIsShorterThanOrEqualToSpecifiedLength()
        {
            _service.TestIsShorterThanOrEqual("abc", 3).Should().BeTrue();
            _service.TestIsShorterThanOrEqual("abcdef", 3).Should().BeFalse();
        }

        [Fact]
        public void IsLongerThanOrEqual_ShouldReturnTrue_WhenStringIsLongerThanOrEqualToSpecifiedLength()
        {
            _service.TestIsLongerThanOrEqual("abcdef", 6).Should().BeTrue();
            _service.TestIsLongerThanOrEqual("abc", 6).Should().BeFalse();
        }

        [Fact]
        public void IsNull_ShouldReturnTrue_WhenObjectIsNull()
        {
            _service.TestIsNull(null!).Should().BeTrue();
        }

        [Fact]
        public void IsNotNull_ShouldReturnTrue_WhenObjectIsNotNull()
        {
            _service.TestIsNotNull(new object()).Should().BeTrue();
        }

        [Fact]
        public void IsValidEnumValue_ShouldReturnTrue_ForDefinedEnumValues()
        {
            _service.TestIsValidEnumValue(DummyEnum.Value1).Should().BeTrue();
            _service.TestIsValidEnumValue((DummyEnum)999).Should().BeFalse();
        }
    }
}