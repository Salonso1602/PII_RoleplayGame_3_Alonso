using NUnit.Framework;
using Program;

namespace Test.Library
{
    [TestFixture]
    public class TestEncounters
    {
        [Test]
        public void TestGoblinspawner()
        {
            int expectedgoblins = 5;
            Encounter.Arena.AddGoblins(5);

            Assert.AreEqual(expectedgoblins, Encounter.Arena.Goblins.Count);
        }

        [Test]
        public void TestEncuentroMasGoblinLoss()
        {
            Enano alonsoChar = new Enano("Torbjorn");
            Espada arma = new Espada("Mjollnir",150);
            alonsoChar.AddItem(arma);

            Encounter.Arena.AddHero(alonsoChar);
            Encounter.Arena.AddGoblins(10);

            Encounter.Arena.doEncounter();

            int expectedsurvivors = 0;
            Assert.AreEqual(expectedsurvivors, Encounter.Arena.Goblins.Count);
        }

        [Test]
        public void TestEncuentroMasGoblinWin()
        {
            Enano alonsoChar = new Enano("Torbjorn");
            Espada arma = new Espada("Mjollnir",150);
            alonsoChar.AddItem(arma);

            Encounter.Arena.AddHero(alonsoChar);
            Encounter.Arena.AddGoblins(100); //si atacan primero hacen suficiente daño para matarlo

            Encounter.Arena.doEncounter();

            int expectedsurvivors = 0;
            Assert.AreEqual(expectedsurvivors, Encounter.Arena.Heroes.Count);
        }
        
        public void TestEncuentroMasGoblinCasualties()
        {
            Enano alonsoChar = new Enano("Torbjorn");
            Espada arma = new Espada("Mjollnir",150);
            alonsoChar.AddItem(arma);

            Encounter.Arena.AddHero(alonsoChar);
            Encounter.Arena.AddGoblins(10);
            Goblin superGoblin = new Goblin();
            superGoblin.AddItem(new Escudo("Escudo", 90, 55));
            Encounter.Arena.AddGoblins(superGoblin);
            //deberian ganar los goblins con solo el supergoblin vivo

            Encounter.Arena.doEncounter();

            int expectedsurvivors = 1;
            Assert.AreEqual(expectedsurvivors, Encounter.Arena.Goblins.Count);
        }

        public void TestMuchosHeroesJuntos()
        //igual que el anterior pero con ayuda los heroes ganan
        {
            Enano alonsoChar = new Enano("Torbjorn");
            Espada arma = new Espada("Mjollnir",150);
            alonsoChar.AddItem(arma);
            Elfo maxiChar = new Elfo("Legolas");
            Espada arco = new Espada("Arco élfico",50);
            maxiChar.AddItem(arco);

            Encounter.Arena.AddHero(alonsoChar);
            Encounter.Arena.AddHero(maxiChar);
            
            Encounter.Arena.AddGoblins(10);
            Goblin superGoblin = new Goblin();
            superGoblin.AddItem(new Escudo("Escudo", 90, 55));
            Encounter.Arena.AddGoblins(superGoblin);
            //deberian ganar los goblins con solo el supergoblin vivo

            Encounter.Arena.doEncounter();

            int expectedsurvivors = 2;
            Assert.AreEqual(expectedsurvivors, Encounter.Arena.Heroes.Count);
        }
    }
}
