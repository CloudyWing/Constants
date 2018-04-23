using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CloudyWing.Constants.Tests {

    [TestFixture]
    public class WeekDayTests {

        private IList<WeekDay> weekDays;

        [SetUp]
        public void Setup() {
            weekDays = new List<WeekDay> {
                WeekDay.Sunday, WeekDay.Monday, WeekDay.Tuesday, WeekDay.Wednesday,
                WeekDay.Thursday, WeekDay.Friday, WeekDay.Saturday
            };
        }

        private WeekDay GetWeekDay(int integer) {
            int remainder = integer % 7;
            int index = remainder < 0 ? remainder + 7 : remainder;
            return weekDays[index]; 
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Equals_WithWeekDay_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);

            bool actual = weekDay.Equals(weekDay); 

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Equals_WithNextWeekDay_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay nextWeekDay = GetWeekDay(integer +　1);

            bool actual = weekDay.Equals(nextWeekDay);

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Equals_WithInteger_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);

            bool actual = weekDay.Equals(integer);

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Equals_WithNextInteger_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            int nextInt = integer + 1;

            bool actual = weekDay.Equals(nextInt);

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Equals_WithDecimal_IsTrue(decimal dec) {
            WeekDay weekDay = GetWeekDay((int)dec);

            bool actual = weekDay.Equals(dec);

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Equals_WithNextDecimal_IsFalse(decimal dec) {
            WeekDay weekDay = GetWeekDay((int)dec);
            decimal nextDec = dec + 1;

            bool actual = weekDay.Equals(nextDec);

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorConvert_ToInteger_AreEqual(int integer) {
            WeekDay weekDay = GetWeekDay(integer);

            int actual = weekDay;

            Assert.AreEqual(integer, actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorConvert_ToWeekDay_AreEqual(int integer) {
            WeekDay expected = GetWeekDay(integer);

            WeekDay actual = (WeekDay)integer;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OperatorConvert_ToWeekDay_ThrowsInvalidCast() {
            Assert.Throws<InvalidCastException>(() => {
                WeekDay weekDay = (WeekDay)7;
            });
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorEqual_WeekDayWithWeekDay_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay weekDay2 = GetWeekDay(integer);

            bool actual = weekDay == weekDay2;

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorEqual_WeekDayWithNextWeekDay_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay nextWeekDay = GetWeekDay(integer + 1);

            bool actual = weekDay == nextWeekDay;

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorEqual_WeekDayWithInteger_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);

            bool actual = weekDay == integer;

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorEqual_WeekDayWithNextInteger_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            int nextInt = integer + 1;

            bool actual = weekDay == nextInt;

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorEqual_IntegerWithWeekDay_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);

            bool actual = integer ==  weekDay;

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorEqual_IntegerWithNextWeekDay_IsFalse(int integer) {
            WeekDay nextWeekDay = GetWeekDay(integer + 1);

            bool actual = integer == nextWeekDay;

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorNonEqual_WeekDayWithWeekDay_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay weekDay2 = GetWeekDay(integer);

            bool actual = weekDay != weekDay2;

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorNonEqual_WeekDayWithNextWeekDay_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay nextWeekDay = GetWeekDay(integer + 1);

            bool actual = weekDay != nextWeekDay;

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorNonEqual_WeekDayWithInteger_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            
            bool actual = weekDay != integer;

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorNonEqual_WeekDayWithNextInteger_IsTrue(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            int nextInt = integer + 1;

            bool actual = weekDay != nextInt;

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorNonEqual_IntegerWithWeekDay_IsFalse(int integer) {
            WeekDay weekDay = GetWeekDay(integer);

            bool actual = integer != weekDay;

            Assert.IsFalse(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorNonEqual_IntegerWithNextWeekDay_IsTrue(int integer) {
            WeekDay nextWeekDay = GetWeekDay(integer + 1);
            
            bool actual = integer != nextWeekDay;

            Assert.IsTrue(actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorAdd_AddOne_AreEqual(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay expected = GetWeekDay(integer + 1);

            WeekDay actual = weekDay + 1;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorReduce_ReduceOne_AreEqual(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay expected = GetWeekDay(integer - 1);

            WeekDay actual = weekDay - 1;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorAdd_AddDouble_AreEqual(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay expected = GetWeekDay(integer + 1);

            weekDay++;

            Assert.AreEqual(expected, weekDay);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void OperatorReduce_ReduceDouble_AreEqual(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            WeekDay expected = GetWeekDay(integer - 1);

            weekDay--;

            Assert.AreEqual(expected, weekDay);
        }

        [TestCase(0),TestCase(1),TestCase(2),TestCase(3),TestCase(4),TestCase(5),TestCase(6)]
        public void Value_Get_AreEqual(int integer) {
            WeekDay weekDay = GetWeekDay(integer);
            int expected = integer;

            int actual = weekDay.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "星期日"),TestCase(1, "星期一"),TestCase(2, "星期二"),TestCase(3, "星期三")]
        [TestCase(4, "星期四"),TestCase(5, "星期五"),TestCase(6, "星期六")]
        public void Text_Get_AreEqual(int integer, string expected) {
            WeekDay weekDay = GetWeekDay(integer);

            string actual = weekDay.Text;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "日"),TestCase(1, "一"),TestCase(2, "二"),TestCase(3, "三")]
        [TestCase(4, "四"),TestCase(5, "五"),TestCase(6, "六")]
        public void TextAbbreviation_Get_AreEqual(int integer, string expected) {
            WeekDay weekDay = GetWeekDay(integer);

            string actual = weekDay.TextAbbreviation;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "(日)"),TestCase(1, "(一)"),TestCase(2, "(二)"),TestCase(3, "(三)")]
        [TestCase(4, "(四)"),TestCase(5, "(五)"),TestCase(6, "(六)")]
        public void TextAbbreviationWithBracket_Get_AreEqual(int integer, string expected) {
            WeekDay weekDay = GetWeekDay(integer);

            string actual = weekDay.TextAbbreviationWithBracket;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, nameof(WeekDay.Sunday)),TestCase(1, nameof(WeekDay.Monday)),TestCase(2, nameof(WeekDay.Tuesday))]
        [TestCase(3, nameof(WeekDay.Wednesday)),TestCase(4, nameof(WeekDay.Thursday)),TestCase(5, nameof(WeekDay.Friday))]
        [TestCase(6, nameof(WeekDay.Saturday))]
        public void Name_Get_AreEqual(int integer, string expected) {
            WeekDay weekDay = GetWeekDay(integer);

            string actual = weekDay.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "Sun"),TestCase(1, "Mon"),TestCase(2, "Tue"),TestCase(3, "Wed")]
        [TestCase(4, "Thu"),TestCase(5, "Fri"),TestCase(6, "Sat")]
        public void NameAbbreviation_Get_AreEqual(int integer, string expected) {
            WeekDay weekDay = GetWeekDay(integer);

            string actual = weekDay.NameAbbreviation;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetItems_Returns_AreEuqal() {
            IEnumerable<WeekDay> expected = weekDays;
            IEnumerable<WeekDay> actual = WeekDay.GetItems();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}