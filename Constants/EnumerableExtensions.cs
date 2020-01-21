using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudyWing.Constants {
    public static class EnumerableExtensions {
        public static bool Contains<T>(this IEnumerable<Constant<T>> constants, T value) where T : IConvertible {
            return constants.Any(x => x == value);
        }

        public static IEnumerable<T> OfType<T>(this IEnumerable<Constant<T>> constants) where T : IConvertible {
            return constants.Select(x => x.Value);
        }

        public static T[] ToValueArray<T>(this IEnumerable<Constant<T>> constants) where T : IConvertible {
            return constants.Select(x => x.Value).ToArray();
        }

        public static List<T> ToValueList<T>(this IEnumerable<Constant<T>> constants) where T : IConvertible {
            return constants.Select(x => x.Value).ToList();
        }
    }
}
