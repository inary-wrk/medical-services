using System;
using System.Collections.Generic;
using System.Text;

namespace businesslogic.abstraction.TinyTypes
{
    public struct Id : IEquatable<Id>
    {
        public static implicit operator long(Id d) => d.Value;
        public static explicit operator Id(long b) => new(b);

        public long Value { get; set; }

        public Id(long Id)
        {
            this.Value = Id;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("IdType");
            stringBuilder.Append(" { ");
            if (PrintMembers(stringBuilder))
            {
                stringBuilder.Append(' ');
            }
            stringBuilder.Append('}');
            return stringBuilder.ToString();
        }

        private bool PrintMembers(StringBuilder builder)
        {
            builder.Append("Id = ");
            builder.Append(Value);
            return true;
        }

        public static bool operator !=(Id left, Id right)
        {
            return !(left == right);
        }

        public static bool operator ==(Id left, Id right)
{
            return left.Equals(right);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<long>.Default.GetHashCode(Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Id idType)
            {
                return Equals(idType);
            }
            return false;
        }

        public bool Equals(Id other)
        {
            return EqualityComparer<long>.Default.Equals(Value, other.Value);
        }

        public void Deconstruct(out long Id)
        {
            Id = this.Value;
        }
    }
}
