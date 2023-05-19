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
                bool IsComma = false;
                bool IsApice = false;
                List<string> word=new List<string>();
                foreach (string name in names)
                {
                    if (name.Contains(",")&&!name.Contains("\""))
                    {
                        IsComma = true;
                        List<string> words =name.Split(",").ToList();
                        word.AddRange(words);

                    }else if (name.Contains("\""))
                    {
                        IsComma = true;
                        IsApice = true;
                        word.Add(name);
                    }
                    else
                    {
                       
                        word.Add(name);
                    }
                }
                if (!IsComma&&names.Length == 2)
                {
                    return $"Hello, {names[0]} and {names[1]}.";
                }
                else
                {
                }

                string apice = "\"";
                string[] namesWord = word.ToArray();
                for(int i=0; i < namesWord.Length; i++)
                {
                    if (namesWord[i].Contains(apice))
                    {
                        namesWord[i] = Regex.Replace(namesWord[i], apice, "");
                    }
                    else
                    {
                        namesWord[i] = Regex.Replace(namesWord[i], @"\s", "");
                    }
                     
                    
                }





                bool allLower = true ;
                foreach (string name in word)
                {
                    if (name == name.ToUpper())
                    {
                        allLower= false;
                    }

                }
                if (allLower)
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
                            if (IsApice)
                            {
                                greet.Append(" ");
                            }
                            else
                            {
                                greet.Append(", ");
                            }
                           

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
                    int UppesCount=0 ;
                    foreach (string name in namesWord)
                    {
                        if (name == name.ToUpper())
                        {
                            UppesCount++;
                        }

                    }

                    string[] namesUpper = new string[UppesCount];
                    int m = 0;

                    for (int i=0; i < namesWord.Length; i++)
                    {
                        if (namesWord[i] == namesWord[i].ToUpper())
                        {
                            namesUpper[m] = namesWord[i];
                            m++;
                        }
                    }
                    string[] namesLower = new string[namesWord.Length-UppesCount];
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
                            if (namesLower.Length > 2)
                            {
                                greet.Append(", ");
                            }
                            else
                            {
                                greet.Append(" ");
                            }
                                
                        }
                    }
                    greet.Append(" AND ");
                    greet.Append("HELLO ");
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
