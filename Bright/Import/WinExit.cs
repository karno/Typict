using System;
using System.Runtime.InteropServices;

namespace K.Snippets
{
    static class Windows
    {
        internal abstract class WinExit
        {
            [DllImport("kernel32")]
            private static extern IntPtr GetCurrentProcess();

            private const uint TOKEN_ADJUST_PRIVILEGES = 0x20;
            private const uint TOKEN_QUERY = 0x8;

            [DllImport("advapi32")]
            private static extern int OpenProcessToken(IntPtr processHandle, uint desiredAccess, ref IntPtr tokenHandle);

            private const uint SE_PRIVILEGE_ENABLED = 0x2;

            private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

            [DllImport("advapi32", EntryPoint = "LookupPrivilegeValueA")]
            private static extern int LookupPrivilegeValue(string systemName, string name, ref long luid);

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct LUID_AND_ATTRIBUTES
            {
                public long Luid;
                public uint Attributes;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct TOKEN_PRIVILEGES
            {
                public uint PrivilegeCount;
                public LUID_AND_ATTRIBUTES Privilege;
            }

            [DllImport("advapi32")]
            private static extern int AdjustTokenPrivileges(IntPtr tokenHandle, bool disableAllPrivilege, ref TOKEN_PRIVILEGES newState, uint bufferLength, IntPtr previousState, IntPtr returnLength);

            [Flags]
            public enum ExitWindowExFlags : uint
            {
                EWX_LOGOFF = 0,
                EWX_SHUTDOWN = 1,
                EWX_REBOOT = 2,
                EWX_FORCE = 4,
                EWX_POWEROFF = 8
            }

            [DllImport("user32")]
            private static extern int ExitWindowsEx(ExitWindowExFlags flags, uint reserved);

            public enum ExitOption { Shutdown, Logoff, Reboot }
            public static void Exit(ExitOption option)
            {
                int ret;

                //
                IntPtr tokenHandle = IntPtr.Zero;
                ret = OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref tokenHandle);

                //
                long luid = 0;
                ret = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref luid);

                //
                TOKEN_PRIVILEGES tp;
                tp.PrivilegeCount = 1;
                tp.Privilege.Luid = luid;
                tp.Privilege.Attributes = SE_PRIVILEGE_ENABLED;
                ret = AdjustTokenPrivileges(tokenHandle, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);

                //
                ExitWindowExFlags flag;
                switch (option)
                {
                    case ExitOption.Logoff:
                        flag = ExitWindowExFlags.EWX_LOGOFF;
                        break;
                    case ExitOption.Reboot:
                        flag = ExitWindowExFlags.EWX_REBOOT;
                        break;
                    default:
                        flag = ExitWindowExFlags.EWX_POWEROFF;
                        break;
                }
                ret = ExitWindowsEx(flag | ExitWindowExFlags.EWX_FORCE, 0);
            }
        }
    }
}