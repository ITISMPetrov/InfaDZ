using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfaDZ
{
    public class WordSet : NewList
    {
        public WordSet() { }

        public WordSet(string[] arr)
        {
            Array.Sort(arr);
            foreach (var e in arr)
                AddLast(e);
        }

        public WordSet(WordSet wrd1, WordSet wrd2)
        {
            if (!wrd1.IsOrdered() || !wrd2.IsOrdered())
                throw new Exception("Список не упорядочен");

            var el1 = wrd1.First;
            var el2 = wrd2.First;
            var wrd = new WordSet();

            while (el1 != null && el2 != null)
            {
                if (el1.Info.CompareTo(el2.Info) < 0)
                {
                    wrd.AddLast(el1.Info);
                    el1 = el1.Next;
                }
                else
                {
                    wrd.AddLast(el2.Info);
                    el2 = el2.Next;
                }
            }
            if (el1 == null)
                while (el2 != null)
                {
                    wrd.AddLast(el2.Info);
                    el2 = el2.Next;
                }
            else
                while (el1 != null)
                {
                    wrd.AddLast(el1.Info);
                    el1 = el1.Next;
                }
            First = wrd.First;
        }

        public void Out(string name)
        {
            File.WriteAllText(name, ToString());
        }

        public void Insert(string word)
        {
            if (IsWordSetContainsWord(word))
                return;

            var el = First;
            while (el.Next != null)
            {
                if (el.Info.CompareTo(word) > 0)
                {
                    AddFirst(word);
                    return;
                }
                else if (el.Info.CompareTo(word) < 0 && el.Next.Info.CompareTo(word) > 0)
                {
                    var newEl = new Elem { Info = word, Next = el.Next };
                    el.Next = newEl;
                    return;
                }
                el = el.Next;
            }
            AddLast(word);
        }

        public void Delete(string word)
        {
            var el = First;
            Elem prevEl = null;

            while (el != null)
            {
                if (el.Info == word)
                {
                    if (prevEl == null)
                        First = el.Next;
                    else
                        prevEl.Next = el.Next;
                }
                else
                    prevEl = el;
                el = el.Next;
            }
        }

        public WordSet NewWordSetByWordLength(int l)
        {
            var wordList = new List<string>();
            var el = First;
            while (el != null)
            {
                if (el.Info.Length == l)
                    wordList.Add(el.Info);
                el = el.Next;
            }
            var fixedLengthWordSet = new WordSet(wordList.ToArray());
            return fixedLengthWordSet;
        }

        public WordSet[] VowelDivide()
        {
            var vovel = ("аеёиоуыэюяАЕЁИОУЫЭЮЯ").ToCharArray();

            var vWordSet = new WordSet();
            var cWordSet = new WordSet();

            var el = First;
            while (el != null)
            {
                for (int i = 0; i < vovel.Length; i++)
                    if (vovel[i] == el.Info[0])
                    {
                        vWordSet.AddLast(el.Info);
                        break;
                    }
                    else
                    {
                        cWordSet.AddLast(el.Info);
                        break;
                    }

                el = el.Next;
            }

            return new WordSet[] { cWordSet, vWordSet };
        }

        public void RemovePalindrome()
        {
            var el = First;
            while (el != null)
            {
                if (CheckForPalindrome(el.Info))
                    Delete(el.Info);
                el = el.Next;
            }
        }

        public static bool CheckForPalindrome(string myString)
        {
            string first = myString.Substring(0, myString.Length / 2);
            char[] arr = myString.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }

        public bool IsWordSetContainsWord(string word)
        {
            var el = First;
            while (el != null)
            {
                if (el.Info == word)
                    return true;
                el = el.Next;
            }
            return false;
        }
    }
}