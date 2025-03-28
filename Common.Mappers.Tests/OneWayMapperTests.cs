using Common.Mappers.Abstractions;
using FluentAssertions;

namespace Common.Mappers.Tests;

/// <summary>
/// Unit tests for the <see cref="IOneWayMapper{TSource, TDestination}"/> implementation.
/// </summary>
public class OneWayMapperTests
{
    /// <summary>
    /// A test implementation of the <see cref="IOneWayMapper{TSource, TDestination}"/> interface.
    /// </summary>
    private class TestMapper : IOneWayMapper<int, string>
    {
        /// <summary>
        /// Maps an integer to a string.
        /// </summary>
        /// <param name="obj">The integer to map.</param>
        /// <returns>The string representation of the integer.</returns>
        public string Map(int obj) => obj.ToString();
    }

    /// <summary>
    /// Tests that the Map method returns the correct string representation when the input is a valid integer.
    /// </summary>
    [Fact]
    public void Map_ReturnsStringRepresentation_WhenInputIsValid()
    {
        TestMapper mapper = new();
        string result = mapper.Map(123);
        result.Should().Be("123");
    }

    /// <summary>
    /// Tests that the Map method returns the correct string representation when the input is zero.
    /// </summary>
    [Fact]
    public void Map_ReturnsEmptyString_WhenInputIsZero()
    {
        TestMapper mapper = new();
        string result = mapper.Map(0);
        result.Should().Be("0");
    }

    /// <summary>
    /// Tests that the Map method returns the correct string representation when the input is a negative integer.
    /// </summary>
    [Fact]
    public void Map_ReturnsNegativeStringRepresentation_WhenInputIsNegative()
    {
        TestMapper mapper = new();
        string result = mapper.Map(-123);
        result.Should().Be("-123");
    }
}