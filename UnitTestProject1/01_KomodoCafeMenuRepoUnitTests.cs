using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenuConsole
{
    [TestClass]
    public class KomodoCafeMenuRepoUnitTests
    {
        [TestMethod]
        public void AddNumber_ShouldGetCorrectNumberBack()
        {
            //Arrange
            MenuItem meal = new MenuItem();

            meal.Number = 4;

            //Act
            int expected = 4;
            int actual = meal.Number;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToRepo_ShouldGetTrueBack()
        {
            // Arrange
            MenuItem item = new MenuItem();
            KomodoCafeMenuRepo repo = new KomodoCafeMenuRepo();
            // Act
            bool addResult = repo.AddItemToMenuList(item);
            // Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirecty_ShouldReturnCorrectCollection()
        {
            // Arrange
            MenuItem item = new MenuItem();
            KomodoCafeRepo repo = new KomodoCafeRepo();

            repo.AddItemsToMenuList(item);
            // Act
            List<MenuItem> MenuItems = repo.GetMenuItems();

            bool directoryHasContent = MenuItems.Contains(item);

            // Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoCafeRepo();
            _content = new MenuItem(1, "Human Food Name", "Some normal Human food. Mmm, tasty...", "Normal Vegtable, Normal Fruit, Some normal protien, mmmm...", 4.20m);
            _repo.AddItemToMenuList(_content);
        }

        [TestMethod]
        public void DeleteExistingMenuItem_ShouldReturnTrue()
        {
            // Arrange
            MenuItem item = _repo.GetContentByNumber(1);

            // Act
            bool removeResult = _repo.DeleteExistingMenuItem(item);

            // Assert
            Assert.IsTrue(removeResult);
        }
    }
}
