using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ConResultado
    {
        [TestMethod]
        public void TestMethod1()
        {
            Usuario persoanje = new Usuario("sdsds", "sasdas", 1, "pruebita1");

            Assert.IsTrue(persoanje.dni.Equals(100));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Usuario persoanje = new Usuario("wwe", "wqwq", 2, "pruebita2");

            Assert.IsTrue(persoanje.dni.Equals(110));
        }
    }
}
