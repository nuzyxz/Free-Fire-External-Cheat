using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Guna.UI2.WinForms;

namespace nuzy
{
    public partial class aim : UserControl
    {
        public aim()
        {
            InitializeComponent();
        }

        private void aim_Load(object sender, EventArgs e)
        {

        }

        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        public static string PID;

        public async void Apply_Changes_InMemory(string SEARCH, string REPLACE)
        {
            bool shh = Process.GetProcessesByName("HD-Player").Length == 0 && Process.GetProcessesByName("LdVBoxHeadless").Length == 0 && Process.GetProcessesByName("AndroidProcess").Length == 0 && Process.GetProcessesByName("ProjectTitan").Length == 0 && Process.GetProcessesByName("Nox").Length == 0 && Process.GetProcessesByName("aow_exe").Length == 0 && Process.GetProcessesByName("MEmuHeadless").Length == 0;
            if (shh)
            {
                All.ShowNotification("Falha ao conectar");
                return;
            }
            else if (Process.GetProcessesByName("HD-Player").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("HD-Player") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));
                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(SEARCH, writable: true);
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");

                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", REPLACE, "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!"); ;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("LdVBoxHeadless").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("LdVBoxHeadless") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));

                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!");
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }

            else if (Process.GetProcessesByName("AndroidProcess").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("AndroidProcess") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));

                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!");
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("ProjectTitan").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("ProjectTitan") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));

                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!");
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("MEmuHeadless").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("MEmuHeadless") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));

                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!");
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("Nox").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("Nox") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));

                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!");
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("aow_exe").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("aow_exe") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID));

                    int i2 = 22000000;
                    IEnumerable<long> dreex = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + dreex.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (dreex.Count() != 0)
                    {
                        for (int i = 0; i < dreex.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(dreex.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        All.ShowNotification("Aplicado!");
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        All.ShowNotification("Erro ao aplicar!");
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
        }
        public Mem MemLib = new Mem();
        private static string string_0;

        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("62 00 6F 00 6E 00 65 00 5F 00 48 00 69 00 70 00 73 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 62 ?? 79 ?? 74 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ??", "62 00 6F 00 6E 00 65 00 5F 00 4E 00 65 00 63 00 6B");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64", "62 00 6F 00 6E 00 65 00 5F 00 48 00 69 00 70 00 73");
            }
        }

        private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.guna2CustomCheckBox2.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("62 00 6F 00 6E 00 65 00 5F 00 48 00 69 00 70 00 73 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 09 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 0C 00 00 00 62 00 79 00 74 00 65 00 73 00 55 00 6E 00 6B 00 6E 00 6F 00 77 00 6E 00 00 00 ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? 00 00 ??", "62 00 6F 00 6E 00 65 00 5F 00 4E 00 65 00 63 00 6B");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("62 00 6F 00 6E 00 65 00 5F 00 4E 00 65 00 63 00 6B 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 09 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 0C 00 00 00 62 00 79 00 74 00 65 00 73 00 55 00 6E 00 6B 00 6E 00 6F 00 77 00 6E 00 00 00 ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? 00 00 ??", "62 00 6F 00 6E 00 65 00 5F 00 48 00 69 00 70 00 73");
            }
        }

        private void guna2CustomCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41", "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 00");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 00", "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41");
            }
        }

        private void guna2CustomCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox4.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("A0 42 00 00 C0 3F 33 33 13 40 00 00 C0 3F 00 00 80 3F", "A0 42 00 00 C0 3F E0 B1 FF FF 00 00 C0 3F 00 00 80 3F");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("A0 42 00 00 C0 3F E0 B1 FF FF 00 00 C0 3F 00 00 80 3F", "A0 42 00 00 C0 3F 33 33 13 40 00 00 C0 3F 00 00 80 3F");
            }
        }

        private void guna2CustomCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox8.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41", "00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45", "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41");
            }
        }

        private void guna2CustomCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox7.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("AE 47 01 3F", "80 7B E1 FF FF FF FF FF");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("80 7B E1 FF FF FF FF FF", "AE 47 01 3F");
            }
        }

        private void guna2CustomCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox6.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED", "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 00 00 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 00 00 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED", "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED");
            }
        }

        private void guna2CustomCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox5.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("DB 0F 49 40 DB 0F 49 40", "00 00 A0 40 00 00 A0 40");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 A0 40 00 00 A0 40", "DB 0F 49 40 DB 0F 49 40");
            }
        }
    }
}
