using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudyWing.Constants.Examples {
    [Serializable]
    public sealed class WeekDay : Constant<int> {
        private static readonly Lazy<WeekDay> sunday = new Lazy<WeekDay>(() => new WeekDay(0, "星期日", nameof(Sunday)));
        private static readonly Lazy<WeekDay> monday = new Lazy<WeekDay>(() => new WeekDay(1, "星期一", nameof(Monday)));
        private static readonly Lazy<WeekDay> tuesday = new Lazy<WeekDay>(() => new WeekDay(2, "星期二", nameof(Tuesday)));
        private static readonly Lazy<WeekDay> wednesday = new Lazy<WeekDay>(() => new WeekDay(3, "星期三", nameof(Wednesday)));
        private static readonly Lazy<WeekDay> thursday = new Lazy<WeekDay>(() => new WeekDay(4, "星期四", nameof(Thursday)));
        private static readonly Lazy<WeekDay> friday = new Lazy<WeekDay>(() => new WeekDay(5, "星期五", nameof(Friday)));
        private static readonly Lazy<WeekDay> saturday = new Lazy<WeekDay>(() => new WeekDay(6, "星期六", nameof(Saturday)));

        private WeekDay(int value, string text, string name) : base(value, text) {
            Name = name;
        }

        public static explicit operator WeekDay(int value) {
            return GetItems().Where(x => x.Value == value).SingleOrDefault() ??
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

        public static WeekDay Sunday => sunday.Value;

        public static WeekDay Monday => monday.Value;

        public static WeekDay Tuesday => tuesday.Value;

        public static WeekDay Wednesday => wednesday.Value;

        public static WeekDay Thursday => thursday.Value;

        public static WeekDay Friday => friday.Value;

        public static WeekDay Saturday => saturday.Value;

        public string Name { get; }

        public string TextAbbreviation => Text.Substring(2);

        public string TextAbbreviationWithBracket => $"({TextAbbreviation})";

        public string NameAbbreviation => Name.Substring(0, 3);

        public static bool TryParse(int value, out WeekDay result) {
            result = GetItems().Where(x => x.Value == value).SingleOrDefault();
            return result != null;
        }

        public static IEnumerable<WeekDay> GetItems() {
            yield return Sunday;
            yield return Monday;
            yield return Tuesday;
            yield return Wednesday;
            yield return Thursday;
            yield return Friday;
            yield return Saturday;
        }
    }
}
