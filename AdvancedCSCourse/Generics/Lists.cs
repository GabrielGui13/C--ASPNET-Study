using System;

namespace Generics
{
    public class NumberList {
        public void Add (int number) {
            throw new NotImplementedException();
        }

        public int this[int index] {
            get { throw new NotImplementedException(); }
        }
    }

    public class BookList {
        public void Add (Book book) {
            throw new NotImplementedException();
        }

        public Book this[int index] {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericList<T> {
        public void Add (T value) {
            throw new NotImplementedException();
        }

        public Book this[int index] {
            get { throw new NotImplementedException(); }
        }
    }
}