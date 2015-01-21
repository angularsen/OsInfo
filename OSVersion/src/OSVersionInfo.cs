using System;
using OsInfo.Utils;

namespace OsInfo
{
    internal sealed class OsVersionInfo : IComparable, ICloneable, IComparable<OsVersionInfo>, IEquatable<OsVersionInfo>
    {
        private readonly int _majorVersion;
        private readonly int _minorVersion;
        private readonly OperatingSystem _operatingSystem;
        private readonly PlatformID _platformId;
        private readonly OsProductType _osProductType;
        private readonly OsVersion _osVersion;

        public OsVersionInfo(
            OsVersion osVersion,
            PlatformID platformId,
            int majorVersion,
            int minorVersion,
            OsProductType osProductType = OsProductType.Invalid
            )
        {
            _osVersion = osVersion;
            _platformId = platformId;
            _operatingSystem = new OperatingSystem(platformId, new Version(majorVersion, minorVersion));
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _osProductType = osProductType;
        }

        public PlatformID PlatformId
        {
            get { return _platformId; }
        }

        public OperatingSystem OperatingSystem
        {
            get { return _operatingSystem; }
        }

        public int MajorVersion
        {
            get { return _majorVersion; }
        }

        public int MinorVersion
        {
            get { return _minorVersion; }
        }

        public OsProductType OsProductType
        {
            get { return _osProductType; }
        }

        public OsVersion OSVersion
        {
            get { return _osVersion; }
        }

        public object Clone()
        {
            return new OsVersionInfo(OSVersion, PlatformId, MajorVersion, MinorVersion, OsProductType);
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
            return other.MajorVersion == MajorVersion && other.MinorVersion == MinorVersion &&
                   other.PlatformId == PlatformId && other.OsProductType == OsProductType;
        }

        public override bool Equals(object o)
        {
            var p = o as OsVersionInfo;
            if (p == null)
                return false;

            return Equals(p);
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.HashAll(PlatformId, MajorVersion, MinorVersion, OsProductType, OperatingSystem);
        }

        public override string ToString()
        {
            return OperatingSystem.ToString();
        }

        public static bool operator ==(OsVersionInfo o, OsVersionInfo p)
        {
            return Equals(o, p);
        }

        public static bool operator !=(OsVersionInfo o, OsVersionInfo p)
        {
            return !Equals(o, p);
        }

        public static bool operator <(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) < 0;
        }

        public static bool operator >(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) > 0;
        }

        public static bool operator <=(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) <= 0;
        }

        public static bool operator >=(OsVersionInfo o, OsVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) >= 0;
        }
    }
}