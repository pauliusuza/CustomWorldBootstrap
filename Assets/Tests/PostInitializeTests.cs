﻿using NUnit.Framework;
using CustomWorldBoostrapInternal;

namespace Tests
{
    public class PostInitializeTests : MyTestFixture
    {
        protected override void Setup()
        {
            m_FakeCWB = new FakeCustomWorldBootstrap();
        }

        [Test]
        public void PostInitialize_Runs()
        {
            new Initialiser(m_FakeCWB).Initialise(m_DefaultSystems);
            Assert.IsTrue(m_FakeCWB.PostInitializeRan);
        }

        [Test]
        public void Alterations_In_PostInitialize_Are_Returned()
        {
            m_FakeCWB.Alterations.Add(typeof(Test1));
            var results = new Initialiser(m_FakeCWB).Initialise(m_DefaultSystems);
            Assert.IsTrue(results.Contains(typeof(Test1)));
        }
    }
}