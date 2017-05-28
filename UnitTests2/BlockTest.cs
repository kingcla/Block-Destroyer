using BlockDestroyer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box2D.XNA;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for BlockTest and is intended
    ///to contain all BlockTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlockTest
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
        ///A test for Block Constructor
        ///</summary>
        [TestMethod()]
        public void StaticBlockMassTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Block target = new Block(world, null, 32, 32, 32, 32, 1, 'S');

            float f = target.GetBody().GetMass();

            bool b = f == 0.0f;

            Assert.IsTrue(b, "Nonzero mass, not a static block!");
        }


        [TestMethod()]
        public void StaticBlockMoveTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), true);

            Block target = new Block(world, null, 32, 32, 32, 32, 1, 'S');

            Vector2 tmp = target.GetBody().GetPosition();

            world.Step(1, 8, 3);

            Assert.IsTrue(tmp.Equals(target.GetBody().GetPosition()), "Block has moved, not a static block!");
        }
    }
}
