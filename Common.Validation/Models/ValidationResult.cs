namespace Common.Validation.Models
{
    /// <summary>
    /// Represents the result of a validation operation.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Gets the collection of validation error messages.
        /// </summary>
        public IEnumerable<string> Errors { get; init; } = [];

        /// <summary>
        /// Gets a value indicating whether the validation result is valid.
        /// </summary>
        public bool IsValid => !Errors.Any();
    }
}