using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Calc
    {
        public void Counter() 
        {
            int counter = 0;
            Dictionary<char, int> letters = new Dictionary<char, int>();
            string str = "ababaa";
            //HashSet<char> set = new HashSet<char>();
            //foreach (var item in str)
            //{
            //    set.Add(item);
            //}


            foreach (var item in str)
            {
                if (letters.ContainsKey(item) == false)
                {
                    counter = 0;
                    letters.Add(item, counter);
                }
                else
                {
                    counter += 1;
                    letters[item] = counter ;
                }
            }

            var r = 5;
        }

    }
}
