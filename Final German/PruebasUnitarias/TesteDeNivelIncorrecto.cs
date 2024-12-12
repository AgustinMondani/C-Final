using Entidades;

namespace PruebasUnitarias
{
    [TestClass]
    public class TesteDeNivelIncorrecto
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestMethod1()
        {
            Personaje persoanje = new Hechicero(12,"pruebita", -10);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestMethod2()
        {
            Personaje persoanje = new Hechicero(12, "pruebita", 200);
        }
    }
}