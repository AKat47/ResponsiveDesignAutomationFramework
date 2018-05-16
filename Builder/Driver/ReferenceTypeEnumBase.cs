namespace Builder.Driver
{
    public class ReferenceTypeEnumBase<T>
    {
        public T Value { get; private set; }

        protected ReferenceTypeEnumBase(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(ReferenceTypeEnumBase<T> a, ReferenceTypeEnumBase<T> b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Value.Equals(b.Value);
        }

        public static bool operator !=(ReferenceTypeEnumBase<T> a, ReferenceTypeEnumBase<T> b)
        {
            return !(a == b);
        }

        public static implicit operator string(ReferenceTypeEnumBase<T> type)
        {
            return type != null ? type.ToString() : null;
        }

        public static implicit operator ReferenceTypeEnumBase<T>(T value)
        {
            return new ReferenceTypeEnumBase<T>(value);
        }

        public override bool Equals(object obj)
        {
            var refEnumMember = obj as ReferenceTypeEnumBase<T>;

            if (refEnumMember != null)
            {
                return refEnumMember.Value.Equals(Value);
            }

            return false;
        }

    }
}