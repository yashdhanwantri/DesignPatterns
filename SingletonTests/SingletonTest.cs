using NUnit.Framework;
using Singleton;

namespace SingletonTests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db1 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db1));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }
    }
}