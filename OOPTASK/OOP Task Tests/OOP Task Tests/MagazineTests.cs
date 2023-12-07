using OOP_Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OOP_Task_Tests
{
    public class MagazineTests
    {
        [Fact]
        public void Magazine_Search_ReturnValidResult()
        {
            //Arrange
            Magazine magazine = new Magazine("1");
            //Act
            Magazine magazine1 = magazine.Search("1");
            //Assert
            Assert.Equal(magazine,magazine1);
        }
        [Fact]
        public void Magazine_DisplayCorrectInfo()
        {
            //Arrange
            Magazine magazine = new Magazine("1");
            //Act
            magazine.DisplayInfo();
            //Assert
            Assert.NotNull(magazine.Title);
        }
        [Fact]
        public void Magazine_Search_ReturnNullResult()
        {
            //Arrange
            Magazine magazine = new Magazine("1");
            //Act
            Magazine foundMagazine = magazine.Search("2");
            //Assert
            Assert.Null(foundMagazine);
        }
    }
}
