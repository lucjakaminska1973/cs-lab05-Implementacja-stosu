using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stos;
using System;

namespace UnitTestProjectStos
{
    [TestClass]
    public class UnitTestStosChar
    {
        private IStos<char> stos;
        private Random rnd = new Random();
        //zwraca znak ASCII o kodzie z zakresu 33..126
        private char RandomElement => (char)rnd.Next(33, 126);

        // s.create ==> s.IsEmpty==true
        [TestMethod]
        public void IsEmpty_PoUtworzeniuStosJestPusty()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);
        }

        // s.create.Push(e) ==> s.IsEmpty==false
        [TestMethod]
        public void IsEmpty_PoUtworzeniuIDodaniuElementuStosNieJestPusty()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            Assert.IsFalse(stos.IsEmpty);
        }

        // s.Pop( s.Push(e) ) == s
        [TestMethod]
        public void PushPop_StosSieNieZmienia()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            char[] tabPrzed = stos.ToArray();
            char e = RandomElement;
            stos.Push(e);
            stos.Pop();
            char[] tabPo = stos.ToArray();

            CollectionAssert.AreEqual(tabPrzed, tabPo);
        }

        // s.Peek( s.Push(e) ) == e
        [TestMethod]
        public void Peek_ZwracaOstatnioWstawionyElement()
        {
            stos = new StosWTablicy<char>();
            char e = RandomElement;

            stos.Push(e);

            Assert.AreEqual(stos.Peek, e);
        }

        // s.create.Peek ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PeekDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // s.create.Pop() ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PopDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        [TestMethod]
        public void TrimExceptionCzyZmieniarozmiarTablicy()
        {
            stos = new StosWTablicy<char>(2);
            char e = RandomElement;


            stos.Push(e);
            stos.Push(e);
            ((StosWTablicy<char>)stos).TrimExcess();
            stos.Push(e);

            ((StosWTablicy<char>)stos).TrimExcess();
            int temp = ((StosWTablicy<char>)stos).Capacity;
            Assert.IsTrue(temp == 4);

        }

        [TestMethod]
        public void StosIEnumeratorCzyEnumeruje()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            char[] tab = stos.ToArray();
            int i = 0;

            var enumerator = stos.ToArray().GetEnumerator();

            while (enumerator.MoveNext())
            {
                char s = (char)enumerator.Current;
                Assert.AreEqual(s, tab[i]);
                i++;
            }
        }

        [TestMethod]
        public void IndexerCzyZwracaOdpowiednielement()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            char[] tab = stos.ToArray();

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stos[i], tab[i]);
            }
        }

        // testy dla StosLink

        private StosLink<char> stos1;

        // s.create ==> s.IsEmpty==true
        [TestMethod]
        public void IsEmpty_PoUtworzeniuStosJestPustyLink()
        {
            stos1 = new StosLink<char>();
            Assert.IsTrue(stos1.IsEmpty);
        }

        // s.create.Push(e) ==> s.IsEmpty==false
        [TestMethod]
        public void IsEmpty_PoUtworzeniuIDodaniuElementustos1NieJestPustyLink()
        {
            stos1 = new StosLink<char>();
            stos1.Push(RandomElement);
            Assert.IsFalse(stos1.IsEmpty);
        }

        // s.Pop( s.Push(e) ) == s
        [TestMethod]
        public void PushPop_stos1SieNieZmieniaLink()
        {
            stos1 = new StosLink<char>();
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);

            char[] tabPrzed = stos1.ToArray();
            char e = RandomElement;
            stos1.Push(e);
            stos1.Pop();
            char[] tabPo = stos1.ToArray();

            CollectionAssert.AreEqual(tabPrzed, tabPo);
        }

        // s.Peek( s.Push(e) ) == e
        [TestMethod]
        public void Peek_ZwracaOstatnioWstawionyElementLink()
        {
            stos1 = new StosLink<char>();
            char e = RandomElement;

            stos1.Push(e);

            Assert.AreEqual(stos1.Peek, e);
        }

        // s.create.Peek ==> throw stos1EmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PeekDlaPustegostos1u_ZwracaWyjatek_stos1EmptyExceptionLink
            ()
        {
            stos1 = new StosLink<char>();
            Assert.IsTrue(stos1.IsEmpty);

            char c = stos1.Peek;
        }

        // s.create.Pop() ==> throw stos1EmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PopDlaPustegostos1u_ZwracaWyjatek_stos1EmptyExceptionLink()
        {
            stos1 = new StosLink<char>();
            Assert.IsTrue(stos1.IsEmpty);

            char c = stos1.Peek;
        }



        [TestMethod]
        public void stos1IEnumeratorCzyEnumerujeLink()
        {
            stos1 = new StosLink<char>();
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);

            char[] tab = stos1.ToArray();
            int i = 0;

            var enumerator = stos1.ToArray().GetEnumerator();

            while (enumerator.MoveNext())
            {
                char s = (char)enumerator.Current;
                Assert.AreEqual(s, tab[i]);
                i++;
            }
        }

        [TestMethod]
        public void IndexerCzyZwracaOdpowiednielementLink()
        {
            stos1 = new StosLink<char>();
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);
            stos1.Push(RandomElement);

            char[] tab = stos1.ToArray();

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stos1[i], tab[i]);
            }

        }

    }
}
