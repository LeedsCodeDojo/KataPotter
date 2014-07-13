using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

using NUnit.Framework;

namespace KataPotter.UnitTests
{
    [TestFixture]
    public class PriceCalculatorFixture
    {
        private PriceCalculator _priceCalculator;
        private Book _book1;
        private Book _book2;
        private Book _book3;
        private Book _book4;
        private Book _book5;

        [SetUp]
        public void SetUp()
        {
            _book1 = new Book { Id = 5 };
            _book2 = new Book { Id = 6 };
            _book3 = new Book { Id = 7 };
            _book4 = new Book { Id = 8 };
            _book5 = new Book { Id = 9 };

            _priceCalculator = new PriceCalculator();
        }

        [Test]
        public void Scan_OneBook_ReturnsSingleBookPrice()
        {
            // Arrange
            var expected = PriceCalculator.BookPrice;
            var book = new Book();

            // Act
            var actual = _priceCalculator.Scan(book);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoSameBooks_ReturnsTotalBookPrice()
        {
            // Arrange
            var expected = PriceCalculator.BookPrice * 2;
            var book = _book1;

            // Act
            var actual = _priceCalculator.Scan(book, book);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
            };
            double totalPrice = PriceCalculator.BookPrice * list.Count;
            double expected = totalPrice - (totalPrice*5/100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_ThreeDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
                _book3,
            };
            double totalPrice = PriceCalculator.BookPrice * list.Count;
            double expected = totalPrice - (totalPrice * 10 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_FourDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
                _book3,
                _book4,
            };
            double totalPrice = PriceCalculator.BookPrice * list.Count;
            double expected = totalPrice - (totalPrice * 20 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }
        
        [Test]
        public void Scan_FiveDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
                _book3,
                _book4,
                _book5,
            };
            double totalPrice = PriceCalculator.BookPrice * list.Count;
            double expected = totalPrice - (totalPrice * 25 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoSameBooksOneDifferent_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book1,
                _book2,
            };
            double totalPrice = PriceCalculator.BookPrice * list.Count;
            double expected = totalPrice - ((PriceCalculator.BookPrice*list.Distinct().Count())*5/100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

    }
}