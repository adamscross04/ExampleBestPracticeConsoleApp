using FluentAssertions;

namespace Common.Mappers.Tests;

/// <summary>
/// Unit tests for the <see cref="TwoWayMapperBase{TSource, TDestination}"/> implementation.
/// </summary>
public class TwoWayMapperBaseTests
{
    /// <summary>
    /// A test implementation of the <see cref="TwoWayMapperBase{TSource, TDestination}"/> class.
    /// </summary>
    private class TestMapper : TwoWayMapperBase<int, string>
    {
        /// <summary>
        /// Maps a string to an integer.
        /// </summary>
        /// <param name="obj">The string to map.</param>
        /// <returns>The integer representation of the string.</returns>
        public override int Map(string obj) => int.Parse(obj);

        /// <summary>
        /// Maps an integer to a string.
        /// </summary>
        /// <param name="obj">The integer to map.</param>
        /// <returns>The string representation of the integer.</returns>
        public override string Map(int obj) => obj.ToString();
    }

    /// <summary>
    /// Tests that the Map method returns the correct integer representation when the input is a valid string.
    /// </summary>
    [Fact]
    public void Map_ReturnsIntRepresentation_WhenInputIsValidString()
    {
        TestMapper mapper = new();
        int result = mapper.Map("123");
        result.Should().Be(123);
    }

    /// <summary>
    /// Tests that the Map method throws a FormatException when the input is an invalid string.
    /// </summary>
    [Fact]
    public void Map_ThrowsFormatException_WhenInputIsInvalidString()
    {
        TestMapper mapper = new();
        Action act = () => mapper.Map("abc");
        act.Should().Throw<FormatException>();
    }

    /// <summary>
    /// Tests that the Map method returns the correct string representation when the input is a valid integer.
    /// </summary>
    [Fact]
    public void Map_ReturnsStringRepresentation_WhenInputIsValidInt()
    {
        TestMapper mapper = new();
        string result = mapper.Map(123);
        result.Should().Be("123");
    }

    /// <summary>
    /// Tests that the MapCollection method returns the correct integer representations when the inputs are valid strings.
    /// </summary>
    [Fact]
    public void MapCollection_ReturnsIntRepresentations_WhenInputsAreValidStrings()
    {
        TestMapper mapper = new();
        IEnumerable<int> result = mapper.Map(new List<string> { "1", "2", "3" });
        result.Should().BeEquivalentTo(new List<int> { 1, 2, 3 });
    }

    /// <summary>
    /// Tests that the MapCollection method returns the correct string representations when the inputs are valid integers.
    /// </summary>
    [Fact]
    public void MapCollection_ReturnsStringRepresentations_WhenInputsAreValidInts()
    {
        TestMapper mapper = new();
        IEnumerable<string> result = mapper.Map(new List<int> { 1, 2, 3 });
        result.Should().BeEquivalentTo(new List<string> { "1", "2", "3" });
    }
}