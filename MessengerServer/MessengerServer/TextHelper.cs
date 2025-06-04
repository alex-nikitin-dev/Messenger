namespace TextOperations
{
    public static class TextHelper
    {
        /// <summary>
        /// Returns true if the input string is not null, not empty, and contains at least one non-space character.
        /// </summary>
        public static bool ContainsNotSpaces(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}