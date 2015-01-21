using System;
using System.Linq;
using OSVersionUtils.Utils;

namespace OSVersionUtils.Extensions
{
    public static class OperatingSystemExtensions
    {
        private static readonly OSVersionInfo[] Versions;

        static OperatingSystemExtensions()
        {
            Versions = new[]
            {
                new OSVersionInfo(OSVersion.Win32S, PlatformID.Win32S, 0, 0),
                new OSVersionInfo(OSVersion.Win95, PlatformID.Win32Windows, 4, 0),
                new OSVersionInfo(OSVersion.Win98, PlatformID.Win32Windows, 4, 10),
                new OSVersionInfo(OSVersion.WinME, PlatformID.Win32Windows, 4, 90),
                new OSVersionInfo(OSVersion.WinNT351, PlatformID.Win32NT, 3, 51),
                new OSVersionInfo(OSVersion.WinNT4, PlatformID.Win32NT, 4, 0),
                new OSVersionInfo(OSVersion.Win2000, PlatformID.Win32NT, 5, 0),
                new OSVersionInfo(OSVersion.WinXP, PlatformID.Win32NT, 5, 1),
                new OSVersionInfo(OSVersion.Win2003, PlatformID.Win32NT, 5, 2, OSProductType.Server),
                new OSVersionInfo(OSVersion.WinXPx64, PlatformID.Win32NT, 5, 2, OSProductType.Workstation),
                //new OSVersionInfo(OSVersion.WinCE, PlatformID.WinCE ), // TODO: WinCE version
                new OSVersionInfo(OSVersion.Vista, PlatformID.Win32NT, 6, 0, OSProductType.Workstation),
                new OSVersionInfo(OSVersion.WinServer2008, PlatformID.Win32NT, 6, 0, OSProductType.Server),
                new OSVersionInfo(OSVersion.WinServer2008R2, PlatformID.Win32NT, 6, 1, OSProductType.Server),
                new OSVersionInfo(OSVersion.Win7, PlatformID.Win32NT, 6, 1, OSProductType.Workstation),
                new OSVersionInfo(OSVersion.WinServer2012, PlatformID.Win32NT, 6, 2, OSProductType.Server),
                new OSVersionInfo(OSVersion.Win8, PlatformID.Win32NT, 6, 2, OSProductType.Workstation),
                new OSVersionInfo(OSVersion.WinServer2012R2, PlatformID.Win32NT, 6, 3, OSProductType.Server),
                new OSVersionInfo(OSVersion.Win8Update1, PlatformID.Win32NT, 6, 3, OSProductType.Workstation)
            };
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.Equals(OSVersion.Win7)</example>
        public static bool Equals(this OperatingSystem os, OSVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) == GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.GetServicePackVersion()</example>
        public static int? GetServicePackVersion(this OperatingSystem os)
        {
            int result;
            var numericString =
                os.ServicePack
                    .Replace("Service Pack ", string.Empty)
                    .Replace("SP", string.Empty)
                    .Trim();

            if (int.TryParse(numericString,
                out result))
                return result;

            return null;
        }

        /// <summary>
        ///     Returns true if the CURRENT operating system is 64-bit. <paramref name="os" /> parameter is only
        ///     used to get the extension syntax in the example.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.Is64Bit()</example>
        /// <param name="os">IGNORED, expected to use <see cref="Environment.OSVersion" />.</param>
        public static bool Is64Bit(this OperatingSystem os)
        {
            return OperatingSystemBitChecker.Is64BitOperatingSystem();
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsGreaterThan(OSVersion.Win7)</example>
        public static bool IsGreaterThan(this OperatingSystem os, OSVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) > GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsGreaterThanOrEqualTo(OSVersion.Win7)</example>
        public static bool IsGreaterThanOrEqualTo(this OperatingSystem os, OSVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) >= GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsLessThan(OSVersion.Win7)</example>
        public static bool IsLessThan(this OperatingSystem os, OSVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) < GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsLessThanOrEqualTo(OSVersion.Win7)</example>
        public static bool IsLessThanOrEqualTo(this OperatingSystem os, OSVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) <= GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        private static Version GetMajorMinorVersion(Version v)
        {
            return new Version(v.Major, v.Minor);
        }

        private static OSVersionInfo GetOsVersionInfo(OSVersion osVersion)
        {
            var osVersionInfo = Versions.FirstOrDefault(v => v.OSVersion == osVersion);
            if (osVersionInfo == null)
                throw new NotImplementedException("OSVersion:" + osVersion);
            return osVersionInfo;
        }
    }
}