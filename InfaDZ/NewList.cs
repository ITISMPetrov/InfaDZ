using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfaDZ
{
    public class Elem
    {
        public string Info { get; set; }
        public Elem Next { get; set; }
    }

    public class NewList
    {
        public Elem First { get; set; }

        public int Length
        {
            get
            {
                int k = 0;
                var el = First;
                while (el != null)
                {
                    k++;
                    el = el.Next;
                }
                return k;
            }
        }

        public void AddFirst(string x)
        {
            var el = new Elem() { Info = x, Next = First };
            First = el;
        }

        public void AddLast(string x)
        {
            var el = First;
            if (el == null)
            {
                AddFirst(x);
                return;
            }
            while (el.Next != null)
                el = el.Next;
            el.Next = new Elem() { Info = x };
        }

        public bool IsOrdered()
        {
            var el = First;
            if (el == null || el.Next == null)
                return true;
            while (el.Next != null)
            {
                if (string.CompareOrdinal(el.Info, el.Next.Info) > 0)
                    return false;
                el = el.Next;
            }
            return true;
        }

        public override string ToString()
        {
            if (First == null)
                throw new Exception("First is null");
            StringBuilder sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($"{el.Info} ");
                el = el.Next;
            }
            return sb.ToString();
        }
    }
}
