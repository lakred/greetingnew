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
                    StringBuilder greet = new StringBuilder();
                    greet.Append("Hello, ");

                    for (int i = 0; i < namesWord.Length; i++)
                    {

                        if (i == namesWord.Length - 1)
                        {
                            greet.Append("and ");
                            greet.Append(namesWord[i]);
                            greet.Append(".");
                        }
                        else if (i == namesWord.Length - 2)
                        {
                            greet.Append(namesWord[i]);
                            greet.Append(isApice ? " " : ", ");
                        }
                        else
                        {
                            greet.Append(namesWord[i]);
                            greet.Append(", ");
                        }
                    }
                    return greet.ToString();
                }
                else
                {
                    int CountUpper = namesWord.Count(name => name == name.ToUpper());
                    string[] namesUpper = new string[CountUpper];
                    int m = 0;

                    for (int i=0; i < namesWord.Length; i++)
                    {
                        if (namesWord[i] == namesWord[i].ToUpper())
                        {
                            namesUpper[m] = namesWord[i];
                            m++;
                        }
                    }
                    string[] namesLower = new string[namesWord.Length- CountUpper];
                    int n = 0;
                    for (int i = 0; i < namesWord.Length; i++)
                    {
                        if (names[i] != namesWord[i].ToUpper())
                        {
                           
                            namesLower[n] = namesWord[i];
                            n++;
                        }
                    }
                    StringBuilder greet = new StringBuilder();
                    greet.Append("Hello, ");
                    for (int i = 0; i < namesLower.Length; i++)
                    {

                        if (i == namesLower.Length - 1)
                        {
                            greet.Append("and ");
                            greet.Append(namesLower[i]);
                            greet.Append(".");
                        }
                        else
                        {
                            greet.Append(namesLower[i]);
                            greet.Append((namesLower.Length > 2)? ", ": " ");
                         }
                    }
                    greet.Append(" AND HELLO ");
                    for (int i = 0; i < namesUpper.Length; i++)
                    {
                        if (i == namesUpper.Length-1&&i>=1)
                        {
                            greet.Append("AND ");
                            greet.Append(namesUpper[i]);
                        }
                        else if (i == namesUpper.Length - 1 && i < 1)
                        {
                            greet.Append(namesUpper[i]);
                        }
                        else
                        {
                            greet.Append(namesUpper[i]);
                            greet.Append(", ");
                        }
                    }
                    greet.Append("!");
                    return greet.ToString();
                }
            }
        }
    }
}
