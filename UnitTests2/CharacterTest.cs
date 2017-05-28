using BlockDestroyer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box2D.XNA;
using Microsoft.Xna.Framework;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for CharacterTest and is intended
    ///to contain all CharacterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CharacterTest
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

        [TestMethod()]
        public void CharMoveRightTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Character chara = new Character(world, null, 32, 0, 32, 32);


            Vector2 tmp = chara.GetBody().GetPosition();
            chara.GetBody().ApplyLinearImpulse(new Vector2(10.0f, 0.0f), new Vector2(0, 0));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsTrue(chara.GetBody().GetPosition().X > tmp.X, "Character doesn't move right!");
        }

        [TestMethod()]
        public void CharMoveLeftTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Character chara = new Character(world, null, 32, 0, 32, 32);


            Vector2 tmp = chara.GetBody().GetPosition();
            chara.GetBody().ApplyLinearImpulse(new Vector2(-10.0f, 0.0f), new Vector2(0, 0));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsTrue(chara.GetBody().GetPosition().X < tmp.X, "Character doesn't move left!");
        }

        [TestMethod()]
        public void CharJumpTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Character chara = new Character(world, null, 32, 0, 32, 32);

            Vector2 tmp = chara.GetBody().GetPosition();
            chara.GetBody().ApplyLinearImpulse(new Vector2(0, -300.0f), new Vector2(0, 0));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsTrue(chara.GetBody().GetPosition().Y < tmp.Y, "Character doesn't jump!");
        }

        [TestMethod()]
        public void CharFallTest()
        {
            World world = new World(new Vector2(0.0f, 10.0f), true);

            Character chara = new Character(world, null, 32, 0, 32, 32);


            Vector2 tmp = chara.GetBody().GetPosition();

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsTrue(chara.GetBody().GetPosition().Y > tmp.Y, "Character doesn't fall!");
        }

        [TestMethod()]
        public void CharCollisionFallingTest()
        {
            World world = new World(new Vector2(0.0f, 10.0f), true);

            Character chara = new Character(world, null, 0, 0, 32, 32);
            Block b = new Block(world, null, new Rectangle(0, 32, 32, 32), 1, 'S');

            Vector2 tmp = chara.GetBody().GetPosition();

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsTrue(chara.GetBody().GetPosition().Y < tmp.Y, "Character is falling and not colliding!");
        }

        [TestMethod()]
        public void CharCollisionMovementTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Character chara = new Character(world, null, 0, 0, 32, 32);
            Block b = new Block(world, null, new Rectangle(20, 0, 32, 32), 1, 'S');

            Vector2 tmp = chara.GetBody().GetPosition();

            chara.GetBody().ApplyLinearImpulse(new Vector2(10.0f, 0.0f), new Vector2(0, 0));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1, 8, 3);
            }

            Assert.IsTrue(chara.GetBody().GetPosition().X < tmp.X, "Character is moving left through the block and not colliding!");
        }

        /// <summary>
        ///A test for Jump
        ///</summary>
        [TestMethod()]
        public void CharJumpTest2()
        {
            World world = new World(new Vector2(0, 0), true);
            int x = 0;
            int y = 0;
            int w = 32;
            int h = 32;
            Character target = new Character(world, null, x, y, w, h);
            target.Jump();
            Body bd = target.GetBody();

            Assert.IsNotNull(bd, "The body attribute of the character must not be null");

            Assert.AreNotEqual(new Microsoft.Xna.Framework.Vector2(0.0f, 0.0f), bd.GetLinearVelocity(), "After jump liner velocity must not be 0");

        }

        /// <summary>
        ///A test for Land
        ///</summary>
        [TestMethod()]
        public void CharLandTest()
        {
            World world = new World(new Vector2(0, 0), true);
            int x = 0;
            int y = 0;
            int w = 32;
            int h = 32;
            Character target = new Character(world, null, x, y, w, h);
            target.Jump();
            target.Land();

            Body bd = target.GetBody();
            Fixture fl = bd.GetFixtureList();
            while (fl != null)
            {
                Assert.AreEqual(0.3f, fl.GetFriction(), "All friction must be set to 0.3, but fixture has " + fl.GetFriction() + " friction");
                fl = fl.GetNext();
            }
        }
    }
}
