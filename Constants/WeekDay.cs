using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CloudyWing.Constants {
    [Serializable]
    public sealed class WeekDay : Constant<int> {
        private static IList<WeekDay> items;
        public static readonly WeekDay Sunday;
        public static readonly WeekDay Monday;
        public static readonly WeekDay Tuesday;
        public static readonly WeekDay Wednesday;
        public static readonly WeekDay Thursday;
        public static readonly WeekDay Friday;
        public static readonly WeekDay Saturday;

        static WeekDay() {
            Sunday = new WeekDay(0, "星期日", nameof(Sunday));
            Monday = new WeekDay(1, "星期一", nameof(Monday));
            Tuesday = new WeekDay(2, "星期二", nameof(Tuesday));
            Wednesday = new WeekDay(3, "星期三", nameof(Wednesday));
            Thursday = new WeekDay(4, "星期四", nameof(Thursday));
            Friday = new WeekDay(5, "星期五", nameof(Friday));
            Saturday = new WeekDay(6, "星期六", nameof(Saturday));

            items = new List<WeekDay>() {
                Sunday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
                Saturday
            };
        }

        private WeekDay(int value, string text, string name) : base(value, text) {
            Name = name;
        }

        public static explicit operator WeekDay(int value) {
            return items.Where(x => x.Value == value).SingleOrDefault() ??
                throw new InvalidCastException();
        }

        public static implicit operator DayOfWeek(WeekDay item) {
            return (DayOfWeek)item.Value;
        }

        public static implicit operator WeekDay(DayOfWeek item) {
            return (WeekDay)((int)item);
        }

        public static WeekDay operator +(WeekDay a, int b) {
            int remainder = (a.Value + b) % 7;
            return (WeekDay)(remainder < 0 ? remainder + 7 : remainder);
        }

        public static WeekDay operator -(WeekDay a, int b) {
            return a + (0 - b);
        }

        public static WeekDay operator ++(WeekDay weekDay) {
            return weekDay + 1;
        }

        public static WeekDay operator --(WeekDay weekDay) {
            return weekDay - 1;
        }

        public string Name { get; }

        public string TextAbbreviation => Text.Substring(2);

        public string TextAbbreviationWithBracket => $"({TextAbbreviation})";

        public string NameAbbreviation => Name.Substring(0, 3);

        public static IReadOnlyList<WeekDay> GetItems() => new ReadOnlyCollection<WeekDay>(items);
    }
}
