using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfaDZ
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new string[] {"абмьаылдм", "ябмьаылдм", "вбмьаылдм", "кбмьаылдм", "лбмьаылдм"};

            var wrd = new WordSet(arr);

            wrd.Out("new");
        }
    }
}
