using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class VidaNegativa
    {
        [TestMethod]
        public void TestMethod1()
        {
            Personaje persoanje = new Hechicero(12, "pruebita");

            persoanje.RecibirAtaque(5000);

            Assert.IsTrue(persoanje.PuntosDeVida.Equals(0));
        }
    }
}
