using System;

namespace Tongs
{
    public class Option<T>
    {
        private readonly T value;
        private readonly bool hasValue;

        public static readonly Option<T> None = new Option<T>();

        private Option() { }

        private Option(T value)
        {
            this.value = value;
            hasValue = true;
        }

        public bool IsNone => !hasValue;
        public bool IsSome => hasValue;

        public T Value
        {
            get
            {
                if (IsNone) throw new InvalidOperationException("Cannot get value from Option.None");
                return value;
            }
        }

        public static Option<T> Some(T value) => new Option<T>(value);

        public Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> f)
        {
            return IsSome ? f(value) : Option.None<TResult>();
        }
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value) => Option<T>.Some(value);
        public static Option<T> None<T>() => Option<T>.None;
    }
}
