namespace HarryPotter
{
    public class HarryPotterTests
    {
        [Fact]
        public void TestCalculateTotalPrice()
        {
            HarryPotterPricing pricing = new HarryPotterPricing();

            // Test case: 2 of each book (max discount)
            var basket1 = new List<int> { 1, 1, 2, 2, 3, 3, 4, 5 };
            Assert.Equal(51.60m, pricing.CalculateTotalPrice(basket1));

            // Test case: Single book
            var basket2 = new List<int> { 1 };
            Assert.Equal(8.0m, pricing.CalculateTotalPrice(basket2));

            // Test case: 2 different books (5% discount)
            var basket3 = new List<int> { 1, 2 };
            Assert.Equal(15.2m, pricing.CalculateTotalPrice(basket3));

            // Test case: 3 different books (10% discount)
            var basket4 = new List<int> { 1, 2, 3 };
            Assert.Equal(21.6m, pricing.CalculateTotalPrice(basket4));

            // Test case: 4 different books (20% discount)
            var basket5 = new List<int> { 1, 2, 3, 4 };
            Assert.Equal(25.6m, pricing.CalculateTotalPrice(basket5));

            // Test case: 5 different books (25% discount)
            var basket6 = new List<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(30.0m, pricing.CalculateTotalPrice(basket6));

            // Test case: Edge case - empty basket
            var basket7 = new List<int>();
            Assert.Equal(0.0m, pricing.CalculateTotalPrice(basket7));
        }
    }
}