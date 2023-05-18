using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }else if (names.Length == 2)
            {
                return $"Hello, {names[0]} and {names[1]}.";
            }
            else
            {
                StringBuilder greet =new StringBuilder();
                greet.Append("Hello, ");

                for (int i  = 0; i < names.Length; i++)
                {
                    
                    if (i==names.Length-1)
                    {
                        greet.Append("and ");
                        greet.Append(names[i]);
                        greet.Append(".");
                    }
                    else
                    {
                        greet.Append(names[i]);
                        greet.Append(", ");
                    }
                   
                }
                return greet.ToString();
            }



        }
    }
}
