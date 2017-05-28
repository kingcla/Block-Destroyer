using BlockDestroyer;
using Box2D.XNA;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace UnitTests2
{
    /// <summary>
    ///This is a test class for BlockTest and is intended
    ///to contain all BlockTest Unit Tests
    ///</summary>
    [TestFixture]
    public class BlockTest
    {
        /// <summary>
        ///A test for Block Constructor
        ///</summary>
        [Test]
        public void StaticBlockMassTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Block target = new Block(world, null, new Rectangle(32, 32, 32, 32), 1, 'S');

            float f = target.GetMass();

            bool b = f == 0.0f;

            Assert.IsTrue(b, "Nonzero mass, not a static block!");
        }


        [Test]
        public void StaticBlockMoveTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Block target = new Block(world, null, 32, 32, 32, 32, 1, 'S');

            Vector2 tmp = target.GetUnitPos();

            world.Step(1, 8, 3);

            Assert.IsTrue(tmp.Equals(target.GetUnitPos()), "Block has moved, not a static block!");
        }
    }
}
