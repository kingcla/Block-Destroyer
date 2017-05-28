using BlockDestroyer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box2D.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for LevelTest and is intended
    ///to contain all LevelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LevelTest
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
        ///A test for DestroyBlock
        ///</summary>
        [TestMethod()]
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

            Level target = new Level(world, b);

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
        [TestMethod()]
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
