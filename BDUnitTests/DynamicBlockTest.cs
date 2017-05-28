using BlockDestroyer;
using Box2D.XNA;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for DynamicBlockTest and is intended
    ///to contain all DynamicBlockTest Unit Tests
    ///</summary>
    [TestFixture]
    public class DynamicBlockTest
    {
        /// <summary>
        ///A test for Update
        ///</summary>
        [Test]
        public void DynBlockMoveTest()
        {
            World world = new World(new Vector2(0.0f, -10.0f), false);
            Rectangle rect = new Rectangle(32,32,32,32); 
            DynamicBlock target = new DynamicBlock(world, null, rect, 'D');

            Vector2 tmp = target.GetBody().GetPosition();

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsFalse(tmp.Equals(target.GetBody().GetPosition()), "Block has not moved, not a dynamic block!");
        }

        [Test]
        public void DynBlockImpulseTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false);
            Rectangle rect = new Rectangle(32, 32, 32, 32);
            DynamicBlock target = new DynamicBlock(world, null, rect, 'D');

            Vector2 tmp = target.GetBody().GetPosition();
            target.GetBody().ApplyLinearImpulse(new Vector2(-10.0f, 0.0f), new Vector2(0, 0));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsFalse(tmp.Equals(target.GetBody().GetPosition()), "Block has not moved by impulse, not a dynamic block!");
        }

        [Test]
        public void DynObjRotationTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false);
            Rectangle rect = new Rectangle(32, 32, 32, 32);
            DynamicBlock target = new DynamicBlock(world, null, rect, 'D');


            target.GetBody().ApplyLinearImpulse(new Vector2(5, 0), new Vector2(0, 0));
            world.Step(2, 8, 3);
            float angle1 = target.GetBody().GetAngle();
            world.Step(3, 8, 3);
            float angle2 = target.GetBody().GetAngle();

            Assert.IsFalse(angle1.Equals(angle2), "the block still has the same angle 1: " + angle1 + " 2: " + angle2);
        }
    }
}
