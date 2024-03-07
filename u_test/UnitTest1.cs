using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ConsoleApp1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ConsoleApp1Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Solve_WhenAtLeastOneItemFits_ReturnsAtLeastOneSelectedItem()
        {
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 5, 5), // Value: 5, Weight: 5
                new Przedmiot(2, 10, 10) // Value: 10, Weight: 10
            };
            int capacity = 6; // Just enough capacity for the first item

            // Act
            Problem problem = new Problem(2, 1);
            var result = problem.Solve(items, capacity);

            // Assert
            Assert.IsTrue(result.SelectedItems.Count > 0);
        }

        [TestMethod]
        public void Test_Solve_WhenNoItemFits_ReturnsEmptySelectedItems()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 10, 10), // Value: 10, Weight: 10
                new Przedmiot(2, 8, 8) // Value: 8, Weight: 8
            };
            int capacity = 5;

            // Act
            Problem problem = new Problem(2, 1);
            var result = problem.Solve(items, capacity);

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result.SelectedItems);
        }

        [TestMethod]
        public void Test_Solve_WhenOrderOfItemsChanges_ResultStaysSame()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 5, 2), // Value: 5, Weight: 2
                new Przedmiot(2, 10, 5), // Value: 10, Weight: 5
                new Przedmiot(3, 6, 3), // Value: 6, Weight: 3
                new Przedmiot(4, 10, 10) // Value: 10, Weight: 5
            };
            int capacity = 12; // Enough capacity for both items

            // Act
            Problem problem1 = new Problem(2, 1);
            Problem problem2 = new Problem(2, 1);
            var result1 = problem1.Solve(items, capacity);

            items.Reverse(); // Reverse the order of items
            var result2 = problem2.Solve(items, capacity);

            // Assert
            Assert.AreEqual(result1.TotalValue, result2.TotalValue);
            Assert.AreEqual(result1.TotalWeight, result2.TotalWeight);
        }

        [TestMethod]
        public void Test_Solve_WithSpecificInstance_ReturnsCorrectResult()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 3, 2),
                new Przedmiot(2, 5, 8),
                new Przedmiot(3, 7, 5),
                new Przedmiot(4, 4, 10),
                new Przedmiot(5, 2, 7),
                new Przedmiot(6, 1, 3),
                new Przedmiot(7, 4, 10),
                new Przedmiot(8, 7, 7),
                new Przedmiot(9, 3, 7),
                new Przedmiot(10, 8, 8)
            };
            int capacity = 20;
            var expectedResult = new Result(new List<int> { 1, 3, 8, 6 }, 18, 17); // Expected result

            // Act
            Problem p = new Problem(10, 1);
            var result = p.Solve(items, capacity);

            // Assert
            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

    }
}
