using System;
using System.Collections.Generic;

namespace CloudyWing.Constants {

    public abstract class Constant<T> : IConvertible where T : IConvertible {

        protected Constant(T value, string text) {
            Value = value;
            Text = text;
        }

        public static implicit operator T(Constant<T> item) {
            return item.Value;
        }

        public static bool operator ==(Constant<T> a, Constant<T> b) {
            if (a is null && b is null) {
                return true;
            }
            return a?.Equals(b) == true;
        }

        public static bool operator ==(Constant<T> a, T b) {
            return a?.Equals(b) == true;
        }

        public static bool operator ==(T a, Constant<T> b) {
            return b?.Equals(a) == true;
        }

        public static bool operator !=(Constant<T> a, Constant<T> b) {
            return !(a == b);
        }

        public static bool operator !=(Constant<T> a, T b) {
            return !(a == b);
        }

        public static bool operator !=(T a, Constant<T> b) {
            return !(a == b);
        }

        public T Value {
            get;
            private set;
        }

        public string Text {
            get;
            private set;
        }

         public override bool Equals(object obj) {
            if (obj is Constant<T>) {
                return Equals((Constant<T>)obj);
            } else if (typeof(T) == typeof(string) && obj is string) {
                return Value as string == obj as string;
            } else if (obj is IConvertible) { // 主要處理當T和obj為不同數值型別時的轉換
                try {
                    return Value.Equals(Convert.ChangeType(obj, typeof(T)));
                } catch {
                    return false;
                }
            }
            return false;
        }

        public bool Equals(Constant<T> item) {
            if (item is null || GetType() != item.GetType()) {
                return false;
            }
            return Value.Equals(item.Value);
        }

        public override int GetHashCode() {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        /// <summary>
        /// Returns Value to string.
        /// </summary>
        /// <returns>
        /// Value to string.
        /// </returns>
        public override string ToString() {
            return Value.ToString();
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider) {
            return Convert.ToBoolean(Value, provider);
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            return Convert.ToChar(Value, provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            return Convert.ToSByte(Value, provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            return Convert.ToByte(Value, provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            return Convert.ToInt16(Value, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16(Value, provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            return Convert.ToInt32(Value, provider);;
        }

        uint IConvertible.ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32(Value, provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            return Convert.ToInt64(Value, provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64(Value, provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            return Convert.ToSingle(Value, provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            return Convert.ToDouble(Value, provider);
        }

        Decimal IConvertible.ToDecimal(IFormatProvider provider) {
            return Convert.ToDecimal(Value, provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            return Convert.ToDateTime(Value, provider);
        }

        object IConvertible.ToType(Type type, IFormatProvider provider) {
            if (type == GetType()) {
                return this;
            }
            return Convert.ChangeType(this, type, provider);
        }

        string IConvertible.ToString(IFormatProvider provider) {
            return Convert.ToString(Value, provider);
        }
    }
}
