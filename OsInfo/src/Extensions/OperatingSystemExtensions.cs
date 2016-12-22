using System;
using System.Linq;
using OsInfo.Utils;

namespace OsInfo.Extensions
{
    public static class OperatingSystemExtensions
    {
        /// <summary>
        ///     List of operating system versions based on:
        ///     https://msdn.microsoft.com/en-us/library/windows/desktop/ms724832(v=vs.85).aspx
        /// </summary>
        /// <remarks>
        ///     For applications that have been manifested for Windows 8.1 or Windows 10. Applications not manifested for
        ///     Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2). To manifest your applications for
        ///     Windows 8.1 or Windows 10, refer to Targeting your application for Windows:
        ///     https://msdn.microsoft.com/en-us/library/windows/desktop/dn481241(v=vs.85).aspx
        /// </remarks>
        private static readonly OsVersionInfo[] Versions;

        static OperatingSystemExtensions()
        {
            Versions = new[]
            {
                new OsVersionInfo(OsVersion.Win32S, PlatformID.Win32S, 0, 0),
                new OsVersionInfo(OsVersion.Win95, PlatformID.Win32Windows, 4, 0),
                new OsVersionInfo(OsVersion.Win98, PlatformID.Win32Windows, 4, 10),
                new OsVersionInfo(OsVersion.WinME, PlatformID.Win32Windows, 4, 90),
                new OsVersionInfo(OsVersion.WinNT351, PlatformID.Win32NT, 3, 51),
                new OsVersionInfo(OsVersion.WinNT4, PlatformID.Win32NT, 4, 0),
                new OsVersionInfo(OsVersion.Win2000, PlatformID.Win32NT, 5, 0),
                new OsVersionInfo(OsVersion.WinXP, PlatformID.Win32NT, 5, 1),
                new OsVersionInfo(OsVersion.Win2003, PlatformID.Win32NT, 5, 2, OsProductType.Server),
                new OsVersionInfo(OsVersion.WinXPx64, PlatformID.Win32NT, 5, 2, OsProductType.Workstation),
                new OsVersionInfo(OsVersion.Vista, PlatformID.Win32NT, 6, 0, OsProductType.Workstation),
                new OsVersionInfo(OsVersion.WinServer2008, PlatformID.Win32NT, 6, 0, OsProductType.Server),
                new OsVersionInfo(OsVersion.WinServer2008R2, PlatformID.Win32NT, 6, 1, OsProductType.Server),
                new OsVersionInfo(OsVersion.Win7, PlatformID.Win32NT, 6, 1, OsProductType.Workstation),
                new OsVersionInfo(OsVersion.WinServer2012, PlatformID.Win32NT, 6, 2, OsProductType.Server),
                new OsVersionInfo(OsVersion.Win8, PlatformID.Win32NT, 6, 2, OsProductType.Workstation),
                new OsVersionInfo(OsVersion.WinServer2012R2, PlatformID.Win32NT, 6, 3, OsProductType.Server),
                new OsVersionInfo(OsVersion.Win8Update1, PlatformID.Win32NT, 6, 3, OsProductType.Workstation),
                new OsVersionInfo(OsVersion.Win10, PlatformID.Win32NT, 10, 0, OsProductType.Workstation),
                new OsVersionInfo(OsVersion.WinServer2016, PlatformID.Win32NT, 10, 0, OsProductType.Server),
            };
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.Equals(OSVersion.Win7)</example>
        public static bool IsEqualTo(this OperatingSystem os, OsVersion osVersion)
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
        public static bool IsGreaterThan(this OperatingSystem os, OsVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) > GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsGreaterThanOrEqualTo(OSVersion.Win7)</example>
        public static bool IsGreaterThanOrEqualTo(this OperatingSystem os, OsVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) >= GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsLessThan(OSVersion.Win7)</example>
        public static bool IsLessThan(this OperatingSystem os, OsVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) < GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        /// <summary>
        ///     Compares the major/minor version of <paramref name="os" /> and <paramref name="osVersion" />.
        /// </summary>
        /// <example><see cref="System.Environment.OSVersion" />.IsLessThanOrEqualTo(OSVersion.Win7)</example>
        public static bool IsLessThanOrEqualTo(this OperatingSystem os, OsVersion osVersion)
        {
            var osVersionInfo = GetOsVersionInfo(osVersion);
            return GetMajorMinorVersion(os.Version) <= GetMajorMinorVersion(osVersionInfo.OperatingSystem.Version);
        }

        private static Version GetMajorMinorVersion(Version v)
        {
            return new Version(v.Major, v.Minor);
        }

        private static OsVersionInfo GetOsVersionInfo(OsVersion osVersion)
        {
            var osVersionInfo = Versions.FirstOrDefault(v => v.OSVersion == osVersion);
            if (osVersionInfo == null)
                throw new NotImplementedException("OSVersion:" + osVersion);
            return osVersionInfo;
        }
    }
}