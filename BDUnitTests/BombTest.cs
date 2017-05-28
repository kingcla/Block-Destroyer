using BlockDestroyer;
using Box2D.XNA;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTests2
{
    /// <summary>
    ///This is a test class for BombTest and is intended
    ///to contain all BombTest Unit Tests
    ///</summary>
    [TestFixture]
    public class BombTest
    {

        /// <summary>
        ///A test for Update
        ///</summary>
        [Test]
        public void BombRemovalTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false); 
            Rectangle rect = new Rectangle(1,1,32,32);
            Bomb target = new Bomb(world, null, rect, null, 1000, 4); 

            target.TriggerBomb(0);
            
            target.Update(2000.0f);

            Assert.IsTrue(target.HaveExploded());
        }

        [Test]
        public void BombBlockCheckTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false); 
            Rectangle rect = new Rectangle(1, 1, 32, 32); 
            Block b = new Block(world, null, new Rectangle(1, 2, 32, 32), 1, 'D');
            Bomb target = new Bomb(world, null, rect, null, 0, 4); 

            target.TriggerBomb(0);

            target.Update(2.0f);
            
            List<Body> listOfBodies = target.GetExplosionResult();
                
            Assert.IsTrue(b.GetBody() == listOfBodies[0]);
        }
    }
}
