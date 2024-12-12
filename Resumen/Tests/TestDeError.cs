using Entidades;

namespace Tests
{
    [TestClass]
    public class TestDeError
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestMethod1()
        {
            Usuario persoanje = new Usuario("pedro", "pruebita", 200, "dsdsdss");
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestMethod2()
        {
            Usuario persoanje = new Usuario("pedro", "pruebita", 200, "dsdsdss");
        }
    }
}