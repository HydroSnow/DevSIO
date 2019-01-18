/************************************************************************************************************
 * 
 * Mme Le Ray
 * BTS SIO1 SI4
 * TP Fonction / Procédure
 * Test Unitaire
 * 
 * **********************************************************************************************************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFonction
{
    [TestClass]
    public class UnitTest1
    {
       


         [TestMethod]
        public void PhrasePrenomTest_Mathis()
        {
            string prenom = "Mathis";
            string resultat = Fonctions.PhrasePrenom(prenom);
            Assert.AreEqual("Je m'appelle Mathis", resultat);
        }

        [TestMethod]
        public void PhraseNomPrenomTest_Mathis_Dupont()
        {
            string prenom = "Mathis";
            string nom = "Dupont";
            string resultat = Fonctions.PhraseNomPrenom( nom, prenom);
            Assert.AreEqual("Je m'appelle Dupont Mathis", resultat);
        }

        [TestMethod]
        public void TableauPersonneTest_BUPONT_S_12()
        {
            string[] personnef = new string[3] { "BUPONT", "S", "12" };
            string[] personnet = Fonctions.Personne("BUPONT", "S", "12");
            Assert.AreEqual(personnef[0],personnet[0]);
            Assert.AreEqual(personnef[1], personnet[1]);
            Assert.AreEqual(personnef[2], personnet[2]);

        }

        [TestMethod]
        public void MultiplicationTest_a10_b2()
        {
            int a = 10;
            int b = 2;
            int result = Fonctions.Multiplication(a, b);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void AdditionTest_a3_b5()
        {
            int a = 10;
            int b = 2;
            int result = Fonctions.Addition(a, b);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void PuissanceTest_a4_b3()
        {
            int a = 4;
            int b = 3;
            int result = Fonctions.Puissance(a, b);
            Assert.AreEqual(64, result);
        }

        [TestMethod]
        public void FactorielleTest_a3()
        {
            int a = 3;
            
            int result = Fonctions.Factorielle(a);
            Assert.AreEqual(6, result);
        }
    }
}
