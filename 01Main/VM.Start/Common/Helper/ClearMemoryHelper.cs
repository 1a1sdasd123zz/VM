using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace VM.Start.Common.Helper
{
    public class ClearMemoryHelper
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(60000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    }
                }
            });
        }

    }
}
