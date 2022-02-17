using System;
using NUnit;
using NUnit.Framework;

namespace Codewars_style_ranking_system
{
    // TODO: Replace examples and use TDD development by writing your own tests

    class TestUser : User
    {
        public TestUser() : base() { }
        public TestUser(int rank, int progress) : base(rank,progress) { }
    }

    public class Tests
    {

        #region [Helping methods]
        private void UserAssert(TestUser user, int expectedRank, int expectedProgress)
        {
            Assert.AreEqual(user.rank, expectedRank);
            Assert.AreEqual(user.progress, expectedProgress);
        }
        #endregion

        #region [UserConstructor tests]
        [Test]
        public void UserConstructor_DefaultInit()
        {
            var user = new TestUser();

            UserAssert(user, -8, 0);
        }
        #endregion

        #region [IncProgress tests]
        [Test]
        public void IncProgress_NotExistingRanking_ArgumentException()
        {
            var user = new TestUser();
            Assert.Throws<ArgumentException>(() => user.incProgress(-10));
        }

        [Test]
        public void IncProgress_2LevelsLower_NoProgress()
        {
            var user = new TestUser(-6, 0);

            user.incProgress(-8);

            UserAssert(user, -6, 0);
        }

        [Test]
        public void IncProgress_1LevelLower_1Progress()
        {
            var user = new TestUser(-7,0);

            user.incProgress(-8);

            UserAssert(user, -7, 1);
        }

        [Test]
        public void IncProgress_EqualLevels_3Progress()
        {
            var user = new TestUser(-8, 0);

            user.incProgress(-8);

            UserAssert(user, -8, 3);
        }

        //N states for negative, P - positive
        [Test]
        public void IncProgress_N8CompletesN4_RankUp60Progress()
        {
            var user = new TestUser(-8, 0);

            user.incProgress(-4);

            UserAssert(user, -7, 60);
        }

        [Test]
        public void IncProgress_N1CompletesP1_10Progress()
        {
            var user = new TestUser(-1, 0);

            user.incProgress(1);

            UserAssert(user, -1, 10);
        }

        [Test]
        public void IncProgress_95ProgressN1CompletesP1_RankUp5Progress()
        {
            var user = new TestUser(-1, 95);

            user.incProgress(1);

            UserAssert(user, 1, 5);
        }

        [Test]
        public void IncProgress_95ProgressP7CompletesP8_RankUp0Progress()
        {
            var user = new TestUser(7, 95);

            user.incProgress(8);

            UserAssert(user, 8, 0);
        }

        [Test]
        public void IncProgress_P8Completes100TasksP8_0Progress()
        {
            var user = new TestUser(8, 0);

            for (int i = 0; i < 100; i++) user.incProgress(8);

            UserAssert(user, 8, 0);
        }

        [Test]
        public void IncProgress_MultipleInc()
        {
            var user = new TestUser();

            for (int i = 0; i < 5; i++)
                user.incProgress(1);

            user.incProgress(2);
            user.incProgress(2);


            user.incProgress(-1);

            user.incProgress(3);

            for (int i = 0; i < 10; i++)
                user.incProgress(8);

            UserAssert(user, 8, 0);
        }
        #endregion
    }
}