using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.abstraction.ValueObjects
{
    public struct MapPoint
    {
        public double NorthLatitude { get; init; }
        public double WesternLongitude { get; init; }

        public MapPoint(double northLatitude, double westernLongitude)
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
            builder.Append(NorthLatitude.ToString());
            builder.Append(", WesternLongitude = ");
            builder.Append(WesternLongitude.ToString());
            return true;
        }

        public override int GetHashCode()
        {
            return EqualityComparer<double>.Default.GetHashCode(NorthLatitude) * -1521134295 + EqualityComparer<double>.Default.GetHashCode(WesternLongitude);
        }
    }
}
