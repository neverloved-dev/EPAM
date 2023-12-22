using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DictionaryReplacerNamespace
{
    public class DictionaryReplacer
    {
        public static string ReplaceVariables(string input, Dictionary<string, string> dict)
        {
            if (string.IsNullOrEmpty(input) || dict.Count == 0)
                return input;

            var regex = new Regex(@"\$\w+\$");

            return regex.Replace(input, match =>
            {
                string key = match.Value.Trim('$');
                return dict.ContainsKey(key) ? dict[key] : match.Value;
            });
        }
    }
}
