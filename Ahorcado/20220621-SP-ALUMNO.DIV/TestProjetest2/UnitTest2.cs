using Entidades.Exceptions;
using Entidades.Files;
namespace TestProyect2
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [ExpectedException(typeof(FileManagerException))]
        public void FileManagerException()
        {
            // Arrage
            string prueba = "dffsgdfgdf";

            //Act
            FileManager.Guardar(prueba, "prueba.xml");
        }
    }
}