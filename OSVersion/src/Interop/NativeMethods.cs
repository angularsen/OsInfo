using System.Runtime.InteropServices;

namespace OSVersionUtils.Interop
{
    internal class NativeMethods
    {
        private NativeMethods()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetVersionEx
            (
            [In, Out] OSVERSIONINFO osVersionInfo
            );

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetVersionEx
            (
            [In, Out] OSVERSIONINFOEX osVersionInfoEx
            );

        //			[ DllImport( "kernel32.dll", SetLastError = true ) ]
        //			public static extern bool VerifyVersionInfo
        //				(
        //					[ In ] OSVERSIONINFOEX VersionInfo,
        //					UInt32 TypeMask,
        //					UInt64 ConditionMask
        //				);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);
    }
}