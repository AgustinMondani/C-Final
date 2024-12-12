using Entidades.Exceptions;
using Entidades.Files;
using Entidades.Models;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void FileManagerException()
        {
            // Arrage
            Ahorcado<Pais> juego = new Ahorcado<Pais>();

            //Act
            Assert.AreEqual(0, juego.CantidadDeAciertos);
        }
    }
}