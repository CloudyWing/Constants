using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CloudyWing.Constants {
    [Serializable]
    public sealed class Month : Constant<int> {
        private static readonly IList<Month> items;
        public static readonly Month January;
        public static readonly Month February;
        public static readonly Month March;
        public static readonly Month April;
        public static readonly Month May;
        public static readonly Month June;
        public static readonly Month July;
        public static readonly Month August;
        public static readonly Month September;
        public static readonly Month October;
        public static readonly Month November;
        public static readonly Month December;

        static Month() {
            January = new Month(1, "一月", nameof(January));
            February = new Month(2, "二月", nameof(February));
            March = new Month(3, "三月", nameof(March));
            April = new Month(4, "四月", nameof(April));
            May = new Month(5, "五月", nameof(May));
            June = new Month(6, "六月", nameof(June));
            July = new Month(7, "七月", nameof(July));
            August = new Month(8, "八月", nameof(August));
            September = new Month(9, "九月", nameof(September));
            October = new Month(10, "十月", nameof(October));
            November = new Month(11, "十一月", nameof(November));
            December = new Month(12, "十二月", nameof(December));

            items = new List<Month>() {
                January, February, March, April, May, June,
                July, August, September, October, November, December
            };
        }

        private Month(int value, string text, string name) : base(value, text) {
            Name = name;
        }

        public static explicit operator Month(int value) {
            return items.Where(x => x.Value == value).SingleOrDefault() ??
                throw new InvalidCastException();
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

        public string Name { get; }

        public string TextAbbreviation => Text.Substring(0, Text.Length - 1);

        public string NameAbbreviation => Name.Substring(0, 3);

        public static IReadOnlyList<Month> GetItems() => new ReadOnlyCollection<Month>(items);
    }
}
