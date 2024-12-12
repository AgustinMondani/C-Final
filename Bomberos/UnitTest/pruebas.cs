using Entidades.Modelos;
namespace UnitTest
{
    [TestClass]
    public class BomberoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Bombero bombero = new Bombero("Prueba");

            // Act
            bombero.Guardar(bombero);

            // Assert
            Bombero bomberoDeserializado = bombero.Leer();
            Assert.AreEqual(bombero.nombre, bomberoDeserializado.nombre);
        }
    }
}