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
            }
                return $"Hello, {names[0]} and {names[1]}.";
            

        }
    }
}
