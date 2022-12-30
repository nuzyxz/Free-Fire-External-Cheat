using Guna.UI2.WinForms;
using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuzy
{
    public partial class visual : UserControl
    {
        public visual()
        {
            InitializeComponent();
        }

        private void visual_Load(object sender, EventArgs e)
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
                Apply_Changes_InMemory("00 00 80 3F CF F7 AD 34", "33 33 34 43 CF F7 AD 34");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("33 33 34 43 CF F7 AD 34", "00 00 80 3F CF F7 AD 34");
            }
        }

        private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox2.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 80 3F 21 13 17 BE DE A0 76 BF", "EC 11 8C 43 21 13 17 BE DE A0 76 BF");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("EC 11 8C 43 21 13 17 BE DE A0 76 BF", "00 00 80 3F 21 13 17 BE DE A0 76 BF");
            }
        }

        private void guna2CustomCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("96 00 00 00 00 00 B0 40 00 00 80 3F 00 00 40 3F", "96 00 00 00 00 00 B8 40 00 00 00 00 00 00 00 00");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("96 00 00 00 00 00 B8 40 00 00 00 00 00 00 00 00", "96 00 00 00 00 00 B0 40 00 00 80 3F 00 00 40 3F");
            }
        }

        private void guna2CustomCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox6.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("DB 0F 49 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE 00 10 00 E3 41 3A 30 EE 80 1F 4B E3 01 0A 30 EE 2C 10 80 E5 50 00 C0 F2", "00 00 A0 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 A0 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE", "DB 0F 49 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE 00 10 00 E3 41 3A 30 EE 80 1F 4B E3 01 0A 30 EE 2C 10 80 E5 50 00 C0 F2");
            }
        }

        private void guna2CustomCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox5.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("0A D7 23 3C BD 37 86 35 00", "0A D7 23 3C 00 00 80 BF 00 20 A0 E3");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("0A D7 23 3C 00 00 80 BF 00 20 A0 E3", "0A D7 23 3C BD 37 86 35 00");
            }
        }

        private void guna2CustomCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox4.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("9A 99 99 3E 00 00 00 3F 00 00 34 42 CD CC CC", "00 C7 0A 5F 00 00 80 3F 00 00 40 3F 00 00 80 3F");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 C7 0A 5F 00 00 80 3F 00 00 40 3F 00 00 80 3F", "9A 99 99 3E 00 00 00 3F 00 00 34 42 CD CC CC");
            }
        }

        private void guna2CustomCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox8.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 B0 40 00 00 80 3F 00 00 40 3F 00 00 80 3F", "00 C7 0A 5F 00 00 80 3F 00 00 40 3F 00 00 80 3F");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 C7 0A 5F 00 00 80 3F 00 00 40 3F 00 00 80 3F", "00 00 B0 40 00 00 80 3F 00 00 40 3F 00 00 80 3F");
            }
        }

        private void guna2CustomCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox7.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("33 33 B3 3F AB AA AA 3E 8F C2 F5 3C", "00 00 80 3F AB AA AA 3E 8F C2 F5 3C");
            }
            else
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("00 00 80 3F AB AA AA 3E 8F C2 F5 3C", "33 33 B3 3F AB AA AA 3E 8F C2 F5 3C");
            }
        }
    }
}
