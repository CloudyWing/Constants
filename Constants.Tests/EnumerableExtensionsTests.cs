using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CloudyWing.Constants.Tests {
    [TestFixture()]
    public class EnumerableExtensionsTests {
        [Test()]
        public void Contains_IsTrue() {
            bool actual = WeekDay.GetItems().Contains(WeekDay.Sunday);
            Assert.That(actual);
        }

        [Test()]
        public void OfType_IsSame() {
            IEnumerable<int> actual = WeekDay.GetItems().OfType();
            IEnumerable<int> expected = WeekDay.GetItems().Select(x => x.Value);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void ToValueArray_IsSame() {
            int[] actual = WeekDay.GetItems().ToValueArray();
            int[] expected = WeekDay.GetItems().Select(x => x.Value).ToArray();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test()]
        public void ToValueList_IsSame() {
            List<int> actual = WeekDay.GetItems().ToValueList();
            List<int> expected = WeekDay.GetItems().Select(x => x.Value).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}