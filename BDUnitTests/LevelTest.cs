using BlockDestroyer;
using Box2D.XNA;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace UnitTests2
{
    /// <summary>
    ///This is a test class for LevelTest and is intended
    ///to contain all LevelTest Unit Tests
    ///</summary>
    [TestFixture]
    public class LevelTest
    {
        /// <summary>
        ///A test for DestroyBlock
        ///</summary>
        [Test]
        public void DestroyBodyCountDecrease()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);
            bool[,] b = new bool[5, 5];

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    b[i, j] = false;
                }
            }

            b[1, 1] = true;

            Level target = new Level(world, b, null);

            int k = world.BodyCount;
            Vector2 pos = new Vector2(32, 32);
            target.DestroyBlock(pos,100);

            if (k > world.BodyCount)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }
        }
        //TestMethod for destroying the right block
        [Test]
        public void DestroyCorrectBlock()
        {

            World world = new World(new Vector2(0.0f, 0.0f), true);

            bool[,] b = new bool[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    b[i, j] = false;
                }
            }

            b[1, 1] = true;
            
            Level target = new Level(world, b);
            Vector2 pos = new Vector2(32, 32);
            bool destroyed = target.CheckBlock(pos);
           
            target.DestroyBlock(pos, 100);

            Assert.IsTrue(target.CheckBlock(pos) != destroyed);
        }
    }
}
