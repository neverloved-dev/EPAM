using Game;
namespace TestGame
{
    public class TestGame
    {
        [Fact]
        public void TestGutterGame()
        {
            Game game = new Game();
            RollMany(game, 20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            Game game = new Game();
            RollMany(game, 20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            Game game = new Game();
            game.Roll(5);
            game.Roll(5); // Spare
            game.Roll(3);
            RollMany(game, 17, 0);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            Game game = new Game();
            game.Roll(10); // Strike
            game.Roll(3);
            game.Roll(4);
            RollMany(game, 16, 0);
            Assert.Equal(24, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            Game game = new Game();
            RollMany(game, 12, 10); // Twelve strikes
            Assert.Equal(300, game.GetScore());
        }


        [Fact]
        public void TestAllStrikesExceptLastFrame()
        {
            Game game = new Game();
            RollMany(game, 18, 10); // Nine strikes
            game.Roll(7);
            game.Roll(2); // Bonus rolls for the last frame
            Assert.Equal(259, game.GetScore());
        }

        [Fact]
        public void TestAllSpares()
        {
            Game game = new Game();
            RollMany(game, 21, 5); // Ten frames with all spares
            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void TestAlternateStrikesAndSpares()
        {
            Game game = new Game();
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    game.Roll(10); // Strike on even frames
                }
                else
                {
                    game.Roll(5);
                    game.Roll(5); // Spare on odd frames
                }
            }
            game.Roll(10); // Bonus roll for the last frame
            Assert.Equal(200, game.GetScore());
        }

        [Fact]
        public void TestRandomGame()
        {
            Game game = new Game();
            int[] rolls = { 7, 2, 10, 3, 6, 8, 1, 5, 4, 4, 2, 5, 10, 7, 3, 9, 1, 10, 10, 10 }; // Random rolls
            foreach (int pins in rolls)
            {
                game.Roll(pins);
            }
            Assert.Equal(170, game.GetScore());
        }


        private void RollMany(Game game, int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}