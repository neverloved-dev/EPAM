using OOP_Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OOP_Task_Tests
{
    public class LocalizedBookTests
    {
        [Fact]
        public void LocalizedBook_Search_ReturnValidResult()
        {
            //Arrange
            LocalizedBook localizedBook = new LocalizedBook("2");
            //Act
            LocalizedBook foundBook = localizedBook.Search("1");
            //Assert
            Assert.True(localizedBook.Equals(foundBook));
        }
        [Fact]
        public void LocalizedBook_DisplayCorrectInfo()
        {
            //Arrange
            LocalizedBook localizedBook = new LocalizedBook("1");
            //Act
            localizedBook.DisplayInfo();
            //Assert
            Assert.NotNull(localizedBook.ISBN);
        }
        [Fact]
        public void LocalizedBook_Search_ReturnNullResult()
        {
            //Arrange
            LocalizedBook localizedBook = new LocalizedBook("1");
            //Act
            LocalizedBook foundBook = localizedBook.Search("2");
            //Assert
            Assert.Null(foundBook);
        }
    }
}
