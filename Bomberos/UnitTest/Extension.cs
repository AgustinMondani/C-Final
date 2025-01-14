using Entidades.Metodos_de_Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void CalcularDiferenciaEnSegundos_DeberiaRetornarLaDiferenciaEnSegundos()
        {
            // Arrange
            DateTime inicio = new DateTime(2021, 11, 16, 12, 00, 00);
            DateTime fin = new DateTime(2021, 11, 16, 12, 01, 30);
            double valorEsperado = 90;

            // Act
            double resultado = inicio.DiferenciaEnSegundos(fin);

            // Assert
            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}