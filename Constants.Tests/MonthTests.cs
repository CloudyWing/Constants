using System;
using System.Collections.Generic;
using CloudyWing.Constants.Examples;
using NUnit.Framework;

namespace CloudyWing.Constants.Tests {
    [TestFixture]
    public class MonthTests {
        private IList<Month> months;

        [SetUp]
        public void Setup() {
            months = new List<Month> {
                Month.January, Month.February, Month.March, Month.April, Month.May, Month.June,
                Month.July, Month.August, Month.September, Month.October, Month.November, Month.December
            };
        }

        private Month GetMonth(int integer) {
            int remainder = integer % 12;
            int index = (remainder == 0 ? 12 : remainder) - 1;
            return months[index];
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Equals_WithMonth_IsTrue(int integer) {
            Month month = GetMonth(integer);

            bool actual = month.Equals(month);

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Equals_WithNextMonth_IsFalse(int integer) {
            Month month = GetMonth(integer);
            Month nextMonth = GetMonth(integer + 1);

            bool actual = month.Equals(nextMonth);

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Equals_WithInteger_IsTrue(int integer) {
            Month month = GetMonth(integer);

            bool actual = month.Equals(integer);

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Equals_WithNextInteger_IsFalse(int integer) {
            Month month = GetMonth(integer);
            int nextInt = integer + 1;

            bool actual = month.Equals(nextInt);

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Equals_WithDecimal_IsTrue(decimal dec) {
            Month month = GetMonth((int)dec);

            bool actual = month.Equals(dec);

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Equals_WithNextDecimal_IsFalse(decimal dec) {
            Month month = GetMonth((int)dec);
            decimal nextDec = dec + 1;

            bool actual = month.Equals(nextDec);

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorConvert_ToInteger_AreEqual(int integer) {
            Month month = GetMonth(integer);

            int actual = month;

            Assert.AreEqual(integer, actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorConvert_ToMonth_AreEqual(int integer) {
            Month expected = GetMonth(integer);

            Month actual = (Month)integer;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OperatorConvert_ToMonth_ThrowsInvalidCast() {
            Assert.Throws<InvalidCastException>(() => {
                Month month = (Month)13;
            });
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorEqual_MonthWithMonth_IsTrue(int integer) {
            Month month = GetMonth(integer);
            Month month2 = GetMonth(integer);

            bool actual = month == month2;

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorEqual_MonthWithNextMonth_IsFalse(int integer) {
            Month month = GetMonth(integer);
            Month nextMonth = GetMonth(integer + 1);

            bool actual = month == nextMonth;

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorEqual_MonthWithInteger_IsTrue(int integer) {
            Month month = GetMonth(integer);

            bool actual = month == integer;

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorEqual_MonthWithNextInteger_IsFalse(int integer) {
            Month month = GetMonth(integer);
            int nextInt = integer + 1;

            bool actual = month == nextInt;

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorEqual_IntegerWithMonth_IsTrue(int integer) {
            Month month = GetMonth(integer);

            bool actual = integer == month;

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorEqual_IntegerWithNextMonth_IsFalse(int integer) {
            Month nextMonth = GetMonth(integer + 1);

            bool actual = integer == nextMonth;

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorNonEqual_MonthWithMonth_IsFalse(int integer) {
            Month month = GetMonth(integer);
            Month month2 = GetMonth(integer);

            bool actual = month != month2;

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorNonEqual_MonthWithNextMonth_IsTrue(int integer) {
            Month month = GetMonth(integer);
            Month nextMonth = GetMonth(integer + 1);

            bool actual = month != nextMonth;

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorNonEqual_MonthWithInteger_IsFalse(int integer) {
            Month month = GetMonth(integer);

            bool actual = month != integer;

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorNonEqual_MonthWithNextInteger_IsTrue(int integer) {
            Month month = GetMonth(integer);
            int nextInt = integer + 1;

            bool actual = month != nextInt;

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorNonEqual_IntegerWithMonth_IsFalse(int integer) {
            Month month = GetMonth(integer);

            bool actual = integer != month;

            Assert.IsFalse(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorNonEqual_IntegerWithNextMonth_IsTrue(int integer) {
            Month nextMonth = GetMonth(integer + 1);

            bool actual = integer != nextMonth;

            Assert.IsTrue(actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorAdd_AddOne_AreEqual(int integer) {
            Month month = GetMonth(integer);
            Month expected = GetMonth(integer + 1);

            Month actual = month + 1;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorReduce_ReduceOne_AreEqual(int integer) {
            Month month = GetMonth(integer);
            Month expected = GetMonth(integer - 1);

            Month actual = month - 1;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorAdd_AddDouble_AreEqual(int integer) {
            Month month = GetMonth(integer);
            Month expected = GetMonth(integer + 1);

            month++;

            Assert.AreEqual(expected, month);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void OperatorReduce_ReduceDouble_AreEqual(int integer) {
            Month month = GetMonth(integer);
            Month expected = GetMonth(integer - 1);

            month--;

            Assert.AreEqual(expected, month);
        }

        [TestCase(1), TestCase(2), TestCase(3), TestCase(4), TestCase(5), TestCase(6)]
        [TestCase(7), TestCase(8), TestCase(9), TestCase(10), TestCase(11), TestCase(12)]
        public void Value_Get_AreEqual(int integer) {
            Month month = GetMonth(integer);
            int expected = integer;

            int actual = month.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "一月"), TestCase(2, "二月"), TestCase(3, "三月")]
        [TestCase(4, "四月"), TestCase(5, "五月"), TestCase(6, "六月")]
        [TestCase(7, "七月"), TestCase(8, "八月"), TestCase(9, "九月")]
        [TestCase(10, "十月"), TestCase(11, "十一月"), TestCase(12, "十二月")]
        public void Text_Get_AreEqual(int integer, string expected) {
            Month month = GetMonth(integer);

            string actual = month.Text;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "一"), TestCase(2, "二"), TestCase(3, "三")]
        [TestCase(4, "四"), TestCase(5, "五"), TestCase(6, "六")]
        [TestCase(7, "七"), TestCase(8, "八"), TestCase(9, "九")]
        [TestCase(10, "十"), TestCase(11, "十一"), TestCase(12, "十二")]
        public void TextAbbreviation_Get_AreEqual(int integer, string expected) {
            Month month = GetMonth(integer);

            string actual = month.TextAbbreviation;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, nameof(Month.January)), TestCase(2, nameof(Month.February)), TestCase(3, nameof(Month.March))]
        [TestCase(4, nameof(Month.April)), TestCase(5, nameof(Month.May)), TestCase(6, nameof(Month.June))]
        [TestCase(7, nameof(Month.July)), TestCase(8, nameof(Month.August)), TestCase(9, nameof(Month.September))]
        [TestCase(10, nameof(Month.October)), TestCase(11, nameof(Month.November)), TestCase(12, nameof(Month.December))]
        public void Name_Get_AreEqual(int integer, string expected) {
            Month month = GetMonth(integer);

            string actual = month.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "Jan"), TestCase(2, "Feb"), TestCase(3, "Mar")]
        [TestCase(4, "Apr"), TestCase(5, nameof(Month.May)), TestCase(6, "Jun")]
        [TestCase(7, "Jul"), TestCase(8, "Aug"), TestCase(9, "Sep")]
        [TestCase(10, "Oct"), TestCase(11, "Nov"), TestCase(12, "Dec")]
        public void NameAbbreviation_Get_AreEqual(int integer, string expected) {
            Month month = GetMonth(integer);

            string actual = month.NameAbbreviation;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetItems_Returns_AreEuqal() {
            IEnumerable<Month> expected = months;
            IEnumerable<Month> actual = Month.GetItems();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}