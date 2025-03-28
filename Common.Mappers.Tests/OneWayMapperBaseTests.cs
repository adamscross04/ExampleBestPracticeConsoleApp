using FluentAssertions;

namespace Common.Mappers.Tests;

/// <summary>
/// Unit tests for the <see cref="OneWayMapperBase{TSource, TDestination}"/> implementation.
/// </summary>
public class OneWayMapperBaseTests
{
    /// <summary>
    /// A test implementation of the <see cref="OneWayMapperBase{TSource, TDestination}"/> class.
    /// </summary>
    private class TestMapper : OneWayMapperBase<int, string>
    {
        /// <summary>
        /// Maps an integer to a string.
        /// </summary>
        /// <param name="obj">The integer to map.</param>
        /// <returns>The string representation of the integer.</returns>
        public override string Map(int obj) => obj.ToString();
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

    /// <summary>
    /// Tests that the MapCollection method returns the correct string representations when the inputs are valid integers.
    /// </summary>
    [Fact]
    public void MapCollection_ReturnsStringRepresentations_WhenInputsAreValid()
    {
        TestMapper mapper = new();
        IEnumerable<string> result = mapper.Map(new List<int> { 1, 2, 3 });
        result.Should().BeEquivalentTo(new List<string> { "1", "2", "3" });
    }

    /// <summary>
    /// Tests that the MapCollection method returns an empty collection when the input collection is empty.
    /// </summary>
    [Fact]
    public void MapCollection_ReturnsEmptyCollection_WhenInputIsEmpty()
    {
        TestMapper mapper = new();
        IEnumerable<string> result = mapper.Map(new List<int>());
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Tests that the MapCollection method returns the correct string representations when the inputs are negative integers.
    /// </summary>
    [Fact]
    public void MapCollection_ReturnsNegativeStringRepresentations_WhenInputsAreNegative()
    {
        TestMapper mapper = new();
        IEnumerable<string> result = mapper.Map(new List<int> { -1, -2, -3 });
        result.Should().BeEquivalentTo(new List<string> { "-1", "-2", "-3" });
    }
}