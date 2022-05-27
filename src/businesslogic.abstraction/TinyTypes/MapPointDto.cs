using System.Collections.Generic;
using System.Text;

namespace businesslogic.abstraction.ValueObjects
{
    public struct MapPointDto
    {
        public double NorthLatitude { get; init; }
        public double WesternLongitude { get; init; }

        public MapPointDto(double northLatitude, double westernLongitude)
        {
            NorthLatitude = northLatitude;
            WesternLongitude = westernLongitude;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("MapPoint");
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
            builder.Append("NorthLatitude = ");
            builder.Append(NorthLatitude);
            builder.Append(", WesternLongitude = ");
            builder.Append(WesternLongitude);
            return true;
        }

        public override int GetHashCode()
        {
            return (EqualityComparer<double>.Default.GetHashCode(NorthLatitude) * -1521134295)
                + EqualityComparer<double>.Default.GetHashCode(WesternLongitude);
        }
    }
}
