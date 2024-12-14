using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    static class Extensions
    {
        public static string AddSpaceBetweenRoots(this string str)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]) && i != 0)
                {
                    result.Append(' ');
                }
                result.Append(str[i]);
            }
            return result.ToString();
        }
    }
}
