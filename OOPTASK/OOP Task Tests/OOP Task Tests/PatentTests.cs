using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OOP_Task;

namespace OOP_Task_Tests
{
    public class PatentTests
    {
        [Fact]
        public void Patent_Search_ReturnValidResult()
        {
            //Arrange
            Patent patent = new Patent("1");
            //Act
            Patent foundPatent = patent.Search(patent.Id);
            //Assert
            Assert.True(foundPatent.Equals(patent));
        }
        [Fact]
        public void Patent_DisplayCorrectInfo()
        {
            //Arrange
            Patent patent = new Patent("1");
            //Act
            patent.DisplayInfo();
            //Assert
            Assert.NotNull(patent.Id);
        }
        [Fact]
        public void Patent_Search_ReturnNullResult()
        {
            //Arrange
            Patent patent = new Patent("1");
            //Act
            Patent foundPatent = patent.Search("2");
            //Assert
            Assert.Null(foundPatent);
        }
    }
}
