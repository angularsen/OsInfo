using System;
using OsInfo.Extensions;

namespace OsInfo.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var currentOs = Environment.OSVersion;
            Console.WriteLine("Current OS: " + currentOs);
            Console.WriteLine("Service pack: " + (currentOs.GetServicePackVersion() ?? (object) "(null)"));

            // In .NET 4.5+ you can use Environment.Is64BitOperatingSystem instead
            Console.WriteLine("Is 64-bit: " + currentOs.Is64Bit());

            Console.WriteLine("NOTE!");
            Console.WriteLine(@"
Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2).
To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your application for Windows:
https://msdn.microsoft.com/en-us/library/windows/desktop/dn481241(v=vs.85).aspx

");

            Console.WriteLine();
            Console.WriteLine("Greater than or equal to XP     : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.WinXP));
            Console.WriteLine("Greater than or equal to Vista  : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Vista));
            Console.WriteLine("Greater than or equal to Win7   : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Win7));
            Console.WriteLine("Greater than or equal to Win8   : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Win8));
            Console.WriteLine("Greater than or equal to Win8.1 : " +
                              currentOs.IsGreaterThanOrEqualTo(OsVersion.Win8Update1));
            Console.WriteLine("Greater than or equal to Win10  : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Win10));
            Console.WriteLine();
            Console.WriteLine("Equal to Win10                   : " + currentOs.IsEqualTo(OsVersion.Win10));
            Console.WriteLine("Equal to Win8                   : " + currentOs.IsEqualTo(OsVersion.Win8));
            Console.WriteLine("Equal to Win7                   : " + currentOs.IsEqualTo(OsVersion.Win7));
            Console.WriteLine();
            Console.WriteLine("Less than or equal to Win10      : " + currentOs.IsLessThanOrEqualTo(OsVersion.Win10));
            Console.WriteLine("Less than or equal to Win8      : " + currentOs.IsLessThanOrEqualTo(OsVersion.Win8));
            Console.WriteLine("Less than or equal to Win7      : " + currentOs.IsLessThanOrEqualTo(OsVersion.Win7));
            Console.WriteLine();
            Console.WriteLine("Less than Win10                  : " + currentOs.IsLessThan(OsVersion.Win10));
            Console.WriteLine("Less than Win8                  : " + currentOs.IsLessThan(OsVersion.Win8));
            Console.WriteLine("Less than Win7                  : " + currentOs.IsLessThan(OsVersion.Win7));
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}