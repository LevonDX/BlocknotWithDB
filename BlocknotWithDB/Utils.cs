using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    static class Utils
    {
        public static void DisplayMenu()
        {
            foreach (MenuItems item in Enum.GetValues<MenuItems>())
            {
                Console.WriteLine($"{item.ToString().AddSpaceBetweenRoots()} - {(int)item}");
            }
        }
    }
}
