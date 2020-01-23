using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudyWing.Constants.Examples {
    [Serializable]
    public sealed class Month : Constant<int> {
        private static readonly Lazy<Month> january = new Lazy<Month>(() => new Month(1, "一月", nameof(January)));
        private static readonly Lazy<Month> february = new Lazy<Month>(() => new Month(2, "二月", nameof(February)));
        private static readonly Lazy<Month> march = new Lazy<Month>(() => new Month(3, "三月", nameof(March)));
        private static readonly Lazy<Month> april = new Lazy<Month>(() => new Month(4, "四月", nameof(April)));
        private static readonly Lazy<Month> may = new Lazy<Month>(() => new Month(5, "五月", nameof(May)));
        private static readonly Lazy<Month> june = new Lazy<Month>(() => new Month(6, "六月", nameof(June)));
        private static readonly Lazy<Month> july = new Lazy<Month>(() => new Month(7, "七月", nameof(July)));
        private static readonly Lazy<Month> august = new Lazy<Month>(() => new Month(8, "八月", nameof(August)));
        private static readonly Lazy<Month> september = new Lazy<Month>(() => new Month(9, "九月", nameof(September)));
        private static readonly Lazy<Month> october = new Lazy<Month>(() => new Month(10, "十月", nameof(October)));
        private static readonly Lazy<Month> november = new Lazy<Month>(() => new Month(11, "十一月", nameof(November)));
        private static readonly Lazy<Month> december = new Lazy<Month>(() => new Month(12, "十二月", nameof(December)));

        private Month(int value, string text, string name) : base(value, text) {
            Name = name;
        }

        public static explicit operator Month(int value) {
            return GetItems().Where(x => x.Value == value).SingleOrDefault()
                ?? throw new InvalidCastException();
        }

        public static Month operator +(Month a, int b) {
            int remainder = ((a.Value + b - 1) % 12) + 1;
            return (Month)(remainder < 1 ? remainder + 12 : remainder);
        }

        public static Month operator -(Month a, int b) {
            return a + (0 - b);
        }

        public static Month operator ++(Month month) {
            return month + 1;
        }

        public static Month operator --(Month month) {
            return month - 1;
        }

        public static Month January => january.Value;

        public static Month February => february.Value;

        public static Month March => march.Value;

        public static Month April => april.Value;

        public static Month May => may.Value;

        public static Month June => june.Value;

        public static Month July => july.Value;

        public static Month August => august.Value;

        public static Month September => september.Value;

        public static Month October => october.Value;

        public static Month November => november.Value;

        public static Month December => december.Value;

        public string Name { get; }

        public string TextAbbreviation => Text.Substring(0, Text.Length - 1);

        public string NameAbbreviation => Name.Substring(0, 3);

        public static bool TryParse(int value, out Month result) {
            result = GetItems().Where(x => x.Value == value).SingleOrDefault();
            return result != null;
        }

        public static IEnumerable<Month> GetItems() {
            yield return January;
            yield return February;
            yield return March;
            yield return April;
            yield return May;
            yield return June;
            yield return July;
            yield return August;
            yield return September;
            yield return October;
            yield return November;
            yield return December;
        }
    }
}
