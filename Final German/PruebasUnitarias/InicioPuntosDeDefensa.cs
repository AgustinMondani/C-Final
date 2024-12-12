using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class InicioPuntosDeDefensa
    {
        [TestMethod]
        public void TestMethod1()
        {
            Personaje persoanje = new Hechicero(1, "pruebita1");

            Assert.IsTrue(persoanje.PuntosDeDefensa.Equals(100));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Personaje persoanje = new Guerrero(2, "pruebita2");

            Assert.IsTrue(persoanje.PuntosDeDefensa.Equals(110));
        }
    }
}