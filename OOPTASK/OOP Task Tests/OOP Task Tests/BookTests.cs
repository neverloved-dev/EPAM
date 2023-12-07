using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OOP_Task;

namespace OOP_Task_Tests
{
    public class BookTests
    {
        [Fact]
        public void Book_Search_ReturnValidResult()
        {
            //Arrange
            Book book = new Book("1999");
            //Act
            Book foundBook = book.Search("1999");
            //Assert
            Assert.True(foundBook.Equals(book));
        }
        [Fact]
        public void Book_DisplayCorrectInfo()
        {
            //Arrange
            Book book = new Book("1999");
            //Act
            Book foundBook = book.Search("1999");
            foundBook.DisplayInfo();
            //Assert
            Assert.NotNull(foundBook.ISBN);
        }
        [Fact]
        public void Book_Search_ReturnNullResult()
        {
            //Arrange
            Book book = new Book("1999");
            //Act
            Book foundBook = book.Search("1998");
            //Assert
            Assert.Null(foundBook);
        }
    }
}
