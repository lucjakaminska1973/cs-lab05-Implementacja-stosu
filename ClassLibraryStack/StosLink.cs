using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stos
{
    public class StosLink<T> : IStos<T>, IEnumerable
    {
        public class Wezel 
        {
            private T element { get; }
            private Wezel nastepnik { get; }

            public Wezel (T e)
            {
                this.element = e;
                nastepnik = null;
            }

            public Wezel(T e, Wezel nast)
            {
                this.element = e;
                this.nastepnik = nast;
            }

            public T Element => element;
            public Wezel Nastepnik => nastepnik; 
            
        }
        // private Wezel t
        public Wezel szczyt;
        private int counter;

        public StosLink() { szczyt = null; counter = 0; }
        public int Count => counter;
        public void Clear() { szczyt = null; counter = 0; }
        public bool IsEmpty => counter == 0;

        public T Peek => IsEmpty? throw new StosEmptyException() : szczyt.Nastepnik.Element;
       

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Exception("operacja niedozwolona, Stos jest pusty");
            }
            else
            {
                szczyt = szczyt.Nastepnik;
                counter--;
            }
            return szczyt.Element;
        }

        public void Push(T value)
        {
            var tmp = new Wezel(value, szczyt);
                szczyt = tmp;
                counter++;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public T[] ToArray()
        {
            if (IsEmpty) throw new Exception("Stos jest pusty");
            T[] temp = new T[Count];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = this[i];
            return temp;
        }


        public T this[int index] => this[counter = index];
    }
}
