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
        [Test]
        public void UserConstructor_DefaultInit()
        {
            var user = new TestUser();
            Assert.AreEqual(user.rank, -8);
            Assert.AreEqual(user.progress, 0);
        }
    }
}