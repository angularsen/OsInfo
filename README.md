# OsInfo - Operating System Info
Compare operating system versions, check if OS is 32/64-bit and what service pack is installed.
Supports .NET 3.5 Client and later.

## NuGet
To install, type ```Install-package OsInfo``` into Package Manager Console in Visual Studio or [visit the nuget page](http://www.nuget.org/packages/osinfo).

## Examples
```csharp
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
```

Yields:
```
Current OS: Microsoft Windows NT 6.2.9200.0
Service pack: (null)

Greater than or equal to XP     : True
Greater than or equal to Vista  : True
Greater than or equal to Win7   : True
Greater than or equal to Win8   : True
Greater than or equal to Win8.1 : False

Equal to Win8                   : True
Equal to Win7                   : False

Less than or equal to Win8      : True
Less than or equal to Win7      : False

Less than Win8                  : False
Less than Win7                  : False
```

## Notes
Windows 8.1 will report as Windows 8 (6.2.9200) for applications that do not explicitly specify compatibility with Windows 8.1 in their app manifest. [Read more](http://stackoverflow.com/a/17406963/134761).
