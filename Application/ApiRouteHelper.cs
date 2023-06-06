using System.Text.RegularExpressions;

namespace Application
{
    public static class ApiRouteHelper
    {
        public static string ReplaceId(string input, string value)
        {
            string pattern = "{id}";
            input = Regex.Replace(input, pattern, value);

            return input;
        }

        public static string ReplaceTags(string input, Dictionary<string, string> replacements)
        {
            foreach (var replacement in replacements)
            {
                string pattern = "{" + replacement.Key + "}";
                input = Regex.Replace(input, pattern, replacement.Value);
            }

            return input;
        }
    }
}
