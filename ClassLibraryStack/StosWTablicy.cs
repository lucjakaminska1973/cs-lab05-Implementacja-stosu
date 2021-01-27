using System;
using System.Collections;
using System.Collections.Generic;

namespace Stos
{
    public class StosWTablicy<T> : IStos<T>, IEnumerable<T>
    {
        private T[] tab;
        private int szczyt = -1;

        public int Capacity => tab.Length;

        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[szczyt];

        public int Count => szczyt + 1;

        public bool IsEmpty => szczyt == -1;

        public void Clear() => szczyt = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            szczyt--;
            return tab[szczyt + 1];
        }

        public void Push(T value)
        {

            if (szczyt == tab.Length - 1)
            {
                Array.Resize(ref tab, tab.Length * 2);
            }

            szczyt++;
            tab[szczyt] = value;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 || index < this.Count)
                {
                    return tab[index];
                }
                else throw new Exception("index poza zakresem");
            }
        }


        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            if (IsEmpty) throw new Exception("Stos jest pusty");
            T[] temp = new T[szczyt + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }

        public void TrimExcess()
        {
            if (IsEmpty) throw new StosEmptyException();
            else if (szczyt >= (tab.Length-1) * 0.9)
            {
                int temp = (int)(Math.Ceiling(tab.Length * 1.1));
                Array.Resize(ref tab, temp );
            }

        }

        #region implementacja IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            return new StosIEnumerator(this);
        }

        ////Getenumerator z yeild;
        //public IEnumerator<T> GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return this[i];
        //}

        internal class StosIEnumerator : IEnumerator<T>
        {
            private StosWTablicy<T> _stos;
            private T current = default(T);
            private int actCursorValue = -1;

            public StosIEnumerator(StosWTablicy<T> stos)
            {
                this._stos = stos;
            }
            public T Current
            {
                get
                {
                    if (this._stos.tab == null)
                        throw new InvalidOperationException
                        ("Use MoveNext before calling Current");
                    current = _stos.tab[actCursorValue];
                    return this.current;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
               if(actCursorValue < _stos.szczyt)
                {
                    actCursorValue++;
                    return true;
                }
                return false;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public void Reset() => actCursorValue = -1;
            
        }

        // dotyczy niegeneryków, odwołujemy się do funkcji generycznej
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        public IEnumerable<T> StosOdKonca
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    yield return this[i];
                }
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<T> ToArrayReadOnly()
        {
            return Array.AsReadOnly(tab);
        }

    }
}
