using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Greeting
{
    public class Greeting 
    {
        public string Greet(params string[] names)
        {
            if (names == null)
            {
                return "Hello, my friend.";
            }
            else if (names.Length == 1)
            {
                return names[0] == names[0].ToUpper()
                    ? $"HELLO, {names[0]}!"
                    : $"Hello, {names[0]}.";
            }else 
            {
                bool isComma = names.Any(name => name.Contains(","));
                bool isApice = names.Any(name => name.Contains("\""));
                List<string> word = new List<string>();
                foreach (string name in names)
                {
                    word.AddRange(isComma && !isApice ? name.Split(',').ToList() : new List<string> { name });
                }
                if (!isComma && names.Length == 2)
                {
                    return $"Hello, {names[0]} and {names[1]}.";
                }
                string[] namesWord = word.ToArray();
                namesWord = namesWord.Select(name =>
                {
                    return (name.Contains("\"")) ? Regex.Replace(name, "\"", "") : Regex.Replace(name, @"\s", "");
                }
                ).ToArray();

                bool hasUpper = word.Any(name =>name==name.ToUpper());
                if (!hasUpper)
                {
                    string lastSeparator = (namesWord.Length > 1) ? (isApice ? " " : ", ") : "";
                    string greeting = $"Hello, {string.Join(", ", namesWord[0..^1])}{lastSeparator}and {namesWord[^1]}.";
                    return greeting;
                }
                else
                {
                    string[] namesUpper = namesWord.Where(name => name == name.ToUpper()).ToArray();
                    string[] namesLower = namesWord.Where(name => name != name.ToUpper()).ToArray();
                    StringBuilder greet = new StringBuilder();
                    greet.Append("Hello, ");
                    for (int i = 0; i < namesLower.Length; i++)
                    {
                        greet.Append((i == namesLower.Length - 1)
                            ? "and " + namesLower[i] + "."
                            : namesLower[i] + ((namesLower.Length > 2) ? ", " : " ")
                            );
                    }
                    greet.Append(" AND HELLO ");
                    if (namesUpper.Length > 0)
                    {
                        greet.Append(string.Join(", ", namesUpper.Take(namesUpper.Length - 1)));
                        greet.Append(namesUpper.Length > 1 ? " AND " : "");
                        greet.Append(namesUpper.Last());
                    }
                    greet.Append("!");
                    return greet.ToString();
                }
            }
        }
    }
}