using System;
using OsInfo.Utils;

namespace OsInfo
{
    internal sealed class OsVersionInfo : IComparable, ICloneable, IComparable<OsVersionInfo>, IEquatable<OsVersionInfo>
    {
        public OsVersionInfo(
            OsVersion osVersion,
            PlatformID platformId,
            int majorVersion,
            int minorVersion,
            OsProductType osProductType = OsProductType.Invalid
        )
        {
            OsVersion = osVersion;
            PlatformId = platformId;
            OperatingSystem = new OperatingSystem(platformId, new Version(majorVersion, minorVersion));
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            OsProductType = osProductType;
        }

        private int MajorVersion { get; }

        private int MinorVersion { get; }

        public OperatingSystem OperatingSystem { get; }

        private OsProductType OsProductType { get; }

        public OsVersion OsVersion { get; }

        private PlatformID PlatformId { get; }

        public object Clone()
        {
            return new OsVersionInfo(OsVersion, PlatformId, MajorVersion, MinorVersion, OsProductType);
        }

        public int CompareTo(object o)
        {
            return CompareTo(o as OsVersionInfo);
        }

        public int CompareTo(OsVersionInfo other)
        {
            return new Version(MajorVersion, MinorVersion).CompareTo(new Version(other.MajorVersion, other.MinorVersion));
        }

        public bool Equals(OsVersionInfo other)
        {
            return (other != null) && (other.MajorVersion == MajorVersion) && (other.MinorVersion == MinorVersion) &&
                   (other.PlatformId == PlatformId) && (other.OsProductType == OsProductType);
        }

        public override bool Equals(object o)
        {
            OsVersionInfo p = o as OsVersionInfo;
            return p != null && Equals(p);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.HashAll(PlatformId, MajorVersion, MinorVersion, OsProductType, OperatingSystem);
        }

        public static bool operator ==(OsVersionInfo o, OsVersionInfo p)
        {
            return Equals(o, p);
        }

        public static bool operator >(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
                return p == null;

            return o.CompareTo(p) > 0;
        }

        public static bool operator >=(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
                return p == null;

            return o.CompareTo(p) >= 0;
        }

        public static bool operator !=(OsVersionInfo o, OsVersionInfo p)
        {
            return !Equals(o, p);
        }

        public static bool operator <(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
                return p == null;

            return o.CompareTo(p) < 0;
        }

        public static bool operator <=(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
                return p == null;

            return o.CompareTo(p) <= 0;
        }

        public override string ToString()
        {
            return OperatingSystem.ToString();
        }
    }
}