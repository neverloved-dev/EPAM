using MineFieldNamespace;
namespace MineFields
{
    public class MineFieldsTest
    {
        [Fact]
        public void GenerateHintField_SampleMineField_ReturnsCorrectHintField()
        {
            // Arrange
            int[,] mineFieldArray = {
                { 1, 0, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
            MineField mineField = new MineField(mineFieldArray);

            // Act
            string actualHintField = mineField.GenerateHintField();

            // Assert
            string expectedHintField = "*100\n2210\n1110\n0000";
            Assert.Equal(expectedHintField, actualHintField);
        }

        [Fact]
        public void GenerateHintField_AllZeros_ReturnsAllZeroHintField()
        {
            // Arrange
            int[,] mineFieldArray = {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            MineField mineField = new MineField(mineFieldArray);

            // Act
            string actualHintField = mineField.GenerateHintField();

            // Assert
            string expectedHintField = "000\n000\n000";
            Assert.Equal(expectedHintField, actualHintField);
        }

        [Fact]
        public void GenerateHintField_AllOnes_ReturnsAllStarsHintField()
        {
            // Arrange
            int[,] mineFieldArray = {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            MineField mineField = new MineField(mineFieldArray);

            // Act
            string actualHintField = mineField.GenerateHintField();

            // Assert
            string expectedHintField = "***\n***\n***";
            Assert.Equal(expectedHintField, actualHintField);
        }
    }
}
}