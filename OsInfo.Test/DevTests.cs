using System;
using NUnit.Framework;
using OsInfo.Extensions;

namespace OsInfo.Test
{
    [TestFixture, Ignore("For development and testing")]
    public class DevTests
    {
        [Test]
        public void PrintCurrentOs()
        {
            OperatingSystem currentOs = Environment.OSVersion;
            Console.WriteLine("Current OS: " + currentOs);
            Console.WriteLine("Service pack: " + (currentOs.GetServicePackVersion() ?? (object)"(null)"));

            // In .NET 4.5+ you can use Environment.Is64BitOperatingSystem instead
            Console.WriteLine("Is 64-bit: " + currentOs.Is64Bit()); 

            Console.WriteLine();
            Console.WriteLine("Greater than or equal to XP     : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.WinXP));
            Console.WriteLine("Greater than or equal to Vista  : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Vista));
            Console.WriteLine("Greater than or equal to Win7   : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Win7));
            Console.WriteLine("Greater than or equal to Win8   : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Win8));
            Console.WriteLine("Greater than or equal to Win8.1 : " + currentOs.IsGreaterThanOrEqualTo(OsVersion.Win8Update1));
            Console.WriteLine();
            Console.WriteLine("Equal to Win8                   : " + currentOs.IsEqualTo(OsVersion.Win8));
            Console.WriteLine("Equal to Win7                   : " + currentOs.IsEqualTo(OsVersion.Win7));
            Console.WriteLine();
            Console.WriteLine("Less than or equal to Win8      : " + currentOs.IsLessThanOrEqualTo(OsVersion.Win8));
            Console.WriteLine("Less than or equal to Win7      : " + currentOs.IsLessThanOrEqualTo(OsVersion.Win7));
            Console.WriteLine();
            Console.WriteLine("Less than Win8                  : " + currentOs.IsLessThan(OsVersion.Win8));
            Console.WriteLine("Less than Win7                  : " + currentOs.IsLessThan(OsVersion.Win7));
        }
    }
}