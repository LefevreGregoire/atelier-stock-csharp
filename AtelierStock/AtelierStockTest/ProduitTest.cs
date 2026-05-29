namespace AtelierStock
{
    [TestClass]
    public class ProduitTest
    {
        [TestMethod]
        public void Initialiser_ProduitQuelconque()
        {
            var prixAchat = 100.0m;
            var marge = 0.18m;

            var p = new Produit("REF", "UnNom", prixAchat, marge);

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
            var p = new Produit("REF", "UnNom", 100, 0);

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

            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);

            p.Rentrer(5);
            Assert.AreEqual(5, p.Stocks);
            Assert.IsFalse(p.EstEnRupture);

            var sorti = p.Sortir(3);
            Assert.AreEqual(3, sorti);
            Assert.AreEqual(2, p.Stocks);

            sorti = p.Sortir(5);
            Assert.AreEqual(2, sorti);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

    }
}
