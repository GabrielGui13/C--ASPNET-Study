using System;

namespace Generics
{
    public class Utilities<T> where T : IComparable, new() { 
        public int Max(int a, int b) {
            return a > b ? a : b; 
        }

        public T Instantiate() {
            return new T();
        }

        public T Max(T a, T b) {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    public class DiscountCalculator<TProduct> where TProduct : Product {
        public float CalculateDiscount(TProduct product) {
            return product.Price;
        }
    }

    public class Nullable<T> where T : struct {
        private object _value;

        public Nullable() {}

        public Nullable(T value) {
            _value = value;
        }

        public bool HasValue {
            get { return _value != null; }
        }

        public T GetValueOrDefault() {
            if (HasValue) return (T) _value; //we boxed in constructor, now its unboxed

            return default(T); //default value for type T
        }
    }
}