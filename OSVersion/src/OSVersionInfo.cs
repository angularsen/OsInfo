using System;
using OSVersionUtils.Utils;

namespace OSVersionUtils
{
    internal sealed class OSVersionInfo : IComparable, ICloneable, IComparable<OSVersionInfo>, IEquatable<OSVersionInfo>
    {
        private readonly int _majorVersion;
        private readonly int _minorVersion;
        private readonly OperatingSystem _operatingSystem;
        private readonly PlatformID _platformId;
        private readonly OSProductType _osProductType;
        private readonly OSVersion _osVersion;

        public OSVersionInfo(
            OSVersion osVersion,
            PlatformID platformId,
            int majorVersion,
            int minorVersion,
            OSProductType osProductType = OSProductType.Invalid
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

        public OSProductType OsProductType
        {
            get { return _osProductType; }
        }

        public OSVersion OSVersion
        {
            get { return _osVersion; }
        }

        public object Clone()
        {
            return new OSVersionInfo(OSVersion, PlatformId, MajorVersion, MinorVersion, OsProductType);
        }

        public int CompareTo(object o)
        {
            return CompareTo(o as OSVersionInfo);
        }

        public int CompareTo(OSVersionInfo other)
        {
            return new Version(MajorVersion, MinorVersion).CompareTo(new Version(other.MajorVersion, other.MinorVersion));
        }

        public bool Equals(OSVersionInfo other)
        {
            return other.MajorVersion == MajorVersion && other.MinorVersion == MinorVersion &&
                   other.PlatformId == PlatformId && other.OsProductType == OsProductType;
        }

        public override bool Equals(object o)
        {
            var p = o as OSVersionInfo;
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

        public static bool operator ==(OSVersionInfo o, OSVersionInfo p)
        {
            return Equals(o, p);
        }

        public static bool operator !=(OSVersionInfo o, OSVersionInfo p)
        {
            return !Equals(o, p);
        }

        public static bool operator <(OSVersionInfo o, OSVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) < 0;
        }

        public static bool operator >(OSVersionInfo o, OSVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) > 0;
        }

        public static bool operator <=(OSVersionInfo o, OSVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) <= 0;
        }

        public static bool operator >=(OSVersionInfo o, OSVersionInfo p)
        {
            if (o == null)
            {
                return p == null;
            }

            return o.CompareTo(p) >= 0;
        }
    }
}