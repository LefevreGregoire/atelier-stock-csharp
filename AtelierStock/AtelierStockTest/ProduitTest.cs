namespace AtelierStock
{
    [TestClass]
    public class ProduitTest
    {
        [TestMethod]
        public void Initialiser_ProduitQuelconque()
        {
            // Arrange
            var prixAchat = 100.0m;
            var marge = 0.18m;

            // Act
            var p = new Produit("REF", "UnNom", prixAchat, marge);

            // Assert
            Assert.AreEqual("REF"  , p.Reference);
            Assert.AreEqual("UnNom", p.Libelle);
            Assert.AreEqual(100.0m , p.PrixAchat);
            Assert.AreEqual(118.0m , p.PrixVente);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }
        [TestMethod]
        public void Initialiser_ProduitMarge0()
        {
            // Arrange
            // Act
            var p = new Produit("REF", "UnNom", 100, 0);

            // Assert
            Assert.AreEqual("REF", p.Reference);
            Assert.AreEqual("UnNom", p.Libelle);
            Assert.AreEqual(100.0m, p.PrixAchat);
            Assert.AreEqual(100.0m, p.PrixVente);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Initialiser_ProduitReferenceVide_LeveArgumentException()
        {
            Action act = () => new Produit("", "UnNom", 100, 0);

            Assert.Throws<ArgumentException>(act);
        }

        [TestMethod]
        public void Gérer_EntréeEtSortie_DeStock()
        {
            var p = new Produit("REF", "Nom", 10, 0);

            // initial
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);

            // rentrer du stock
            p.Rentrer(5);
            Assert.AreEqual(5, p.Stocks);
            Assert.IsFalse(p.EstEnRupture);

            // sortir moins que le stock
            var sorti = p.Sortir(3);
            Assert.AreEqual(3, sorti);
            Assert.AreEqual(2, p.Stocks);

            // sortir plus que le stock -> rupture partielle
            sorti = p.Sortir(5);
            Assert.AreEqual(2, sorti);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }


    }
}