using BlockDestroyer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box2D.XNA;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for DynamicBlockTest and is intended
    ///to contain all DynamicBlockTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DynamicBlockTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void DynBlockMoveTest()
        {
            World world = new World(new Vector2(0.0f, -10.0f), false);
           List<Texture2D> sprite = null; 
            Rectangle rect = new Rectangle(32,32,32,32); 
            DynamicBlock target = new DynamicBlock(world, sprite, rect, 'D');

            Vector2 tmp = target.GetBody().GetPosition();

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsFalse(tmp.Equals(target.GetBody().GetPosition()), "Block has not moved, not a dynamic block!");
        }

        [TestMethod()]
        public void DynBlockImpulseTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false);
           List<Texture2D> sprite = null;
            Rectangle rect = new Rectangle(32, 32, 32, 32);
            DynamicBlock target = new DynamicBlock(world, sprite, rect, 'D');

            Vector2 tmp = target.GetBody().GetPosition();
            target.GetBody().ApplyLinearImpulse(new Vector2(-10.0f, 0.0f), new Vector2(0, 0));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsFalse(tmp.Equals(target.GetBody().GetPosition()), "Block has not moved by impulse, not a dynamic block!");
        }

        [TestMethod()]
        public void DynObjRotationTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false);
           List<Texture2D> sprite = null;
            Rectangle rect = new Rectangle(32, 32, 32, 32);
            DynamicBlock target = new DynamicBlock(world, sprite, rect, 'D');


            target.GetBody().ApplyLinearImpulse(new Vector2(5, 0), new Vector2(0, 0));
            world.Step(2, 8, 3);
            float angle1 = target.GetBody().GetAngle();
            world.Step(3, 8, 3);
            float angle2 = target.GetBody().GetAngle();

            Assert.IsFalse(angle1.Equals(angle2), "the block still has the same angle 1: " + angle1 + " 2: " + angle2);
        }
    }
}
