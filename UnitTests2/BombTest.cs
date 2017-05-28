using BlockDestroyer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box2D.XNA;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for BombTest and is intended
    ///to contain all BombTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BombTest
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
        public void BombRemovalTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false); 
            Rectangle rect = new Rectangle(1,1,32,32);
            Bomb target = new Bomb(world, null, rect, null, 1000, 4); 
            double time1 = 2F; 
            target.TriggerBomb(0);
            
            target.Update(time1);

            Assert.IsTrue(target.HaveExploded());
        }

        [TestMethod()]
        public void BombBlockCheckTest()
        {
            World world = new World(new Vector2(0.0f, 0.0f), false); 
            Rectangle rect = new Rectangle(1, 1, 32, 32); 
            Block b = new Block(world, null, new Rectangle(1, 2, 32, 32), 1, 'D');
            Bomb target = new Bomb(world, null, rect, null, 1000, 4); 
            double time1 = 2F; 
            target.TriggerBomb(0);

            target.Update(time1);
            List<Body> listOfBodies = target.GetExplosionResult();
            Assert.IsTrue(b.GetBody() == listOfBodies[0]);
        }
        
    }
}
