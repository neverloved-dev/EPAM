namespace EquiTests;
using EquiNamespace;
public class EquiTests
{
     [Theory]
        [InlineData(new[] { -1, 3, -4, 5, 1, -6, 2, 1 }, new[] { 1, 3, 7 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { -1 })]
        [InlineData(new[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new[] { 0, 1, 2, 3, 4, 5, 6, 7 })]
        public void Solution_ValidInput_ReturnsEquilibriumIndices(int[] input, int[] expected)
        {
            // Act
            var result = Equi.Solution(input);

            // Assert
            Assert.True(expected.Contains(result));
        }
}