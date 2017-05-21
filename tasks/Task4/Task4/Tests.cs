using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Create_GI_Konto_KNZuKurz()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Girokonto(1234567));
        }

        [Test]
        public void Create_GI_Konto_KNZuLang()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Girokonto(123456789));
        }

        [Test]
        public void Create_WP_Konto_KNZuKurz()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Wertpapierdepot(123456,"TestVorname","TestNachname",0));
        }

        [Test]
        public void Create_WP_Konto_KNZuLang()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Wertpapierdepot(123456, "TestVorname", "TestNachname", 0));
        }

        [Test]
        public void Create_WP_WrongNoame()
        {
            Assert.Throws<ArgumentException>(() => new Wertpapierdepot(1234567, "", "", 0));
            Assert.Throws<ArgumentException>(() => new Wertpapierdepot(1234567, "TestVorname", "", 0));
            Assert.Throws<ArgumentException>(() => new Wertpapierdepot(1234567, "", "TestNachname", 0));
        }

        [Test]
        public void TestRisikoklasse()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Wertpapierdepot(1234567, "Test", "Test", -6));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Wertpapierdepot(1234568, "Test", "Test", 6));
        }

        [Test]
        public void ChangeSaloGI()
        {
            Girokonto gi = new Girokonto(12345678);
            var KontostandGI = gi.Saldo;
            gi.Saldo = 123;
            Assert.IsTrue(KontostandGI < gi.Saldo);
            gi.Saldo = -234;
            Assert.IsTrue(KontostandGI > gi.Saldo);
        }

        [Test]
        public void ChangeSaloWP()
        {
            Wertpapierdepot wp = new Wertpapierdepot(1234567, "Test", "Test", 0);
            var KontostandWP = wp.Saldo;
            wp.Saldo = 123;
            Assert.IsTrue(KontostandWP < wp.Saldo);
            wp.Saldo = -234;
            Assert.IsTrue(KontostandWP > wp.Saldo);
        }

    }
}
