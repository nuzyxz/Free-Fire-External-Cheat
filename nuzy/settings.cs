using Guna.UI2.WinForms;
using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuzy
{
    public partial class settings : UserControl
    {
        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
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

        private void buttonDestruct_Click(object sender, EventArgs e)
        {
            string jump = @"C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Recent\CustomDestinations";
            string jump2 = @"C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Recent\AutomaticDestinations";
            command(@"del /s /f /q C:\Users\%username%\AppData\Local\CrashDumps\ *.dmp*");
            command(@"deltree /y c:\windows\tempor~1");
            command(@"deltree /y c:\windows\temp");
            command(@"deltree /y c:\windows\tmp");
            command(@"deltree /y c:\windows\ff*.tmp");
            command(@"deltree /y c:\windows\history");
            command(@"deltree /y c:\windows\cookies");
            command(@"sc stop Dusmsvc");
            command(@"sc stop sysmain");
            command(@"sc stop bam");
            command("del /s /q " + jump2);
            command("rd /s /q " + jump2);
            command("del /s /q " + jump);
            command("rd /s /q " + jump);
            Thread.Sleep(400);
            Program.stror();
            Thread.Sleep(400);
            Thread.Sleep(400);
            Program.LastSavePid();
            Thread.Sleep(400);
            Program.UserAssist();
            Thread.Sleep(400);
            Program.UserAssist2();
            Thread.Sleep(400); ;
            Program.MuiCache1();
            Thread.Sleep(400);
            Program.MuiCache2();
            Thread.Sleep(400);
            Thread.Sleep(400);
            Program.Tracing();
            Thread.Sleep(400);
            Program.UserSettings();
            command(@"sc start sysmain");
            command(@"sc start bam");
            DELETE_Program();
        }

        public static void command(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Verb = "runas";
            process.Start();
            process.StandardInput.WriteLine(command);
            process.Close();
        }

        void DELETE_Program()
        {
            string location = Assembly.GetExecutingAssembly().Location;
            if (location == "" || location == null)
            {
                location = Assembly.GetEntryAssembly().Location;
            }
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C ping 1.1.1.1 -n 1 -w 4000 > Nul & Del \"" + location + "\"",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });
            Environment.Exit(0);
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("0A 00 A0 E3 ?? ?? ?? EB 00 50 A0 E1 90 00 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00", "00 F0 20 E3");
            }
        }

        private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox2.Checked)
            {
                All.ShowNotification("Aguarde As Duas Aplicações");
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("F6 0D 09 EA 04 00 90 E5 00 10 A0 E3 00 00 90 E5 F2 ?? 09 EA 04 00 90 E5 00 10 A0 E3 00 00 90 E5", "00 F0 20 E3");
                All.ShowNotification("Conectando...");
                Apply_Changes_InMemory("F0 48 2D E9 10 B0 8D E2 20 D0 4D E2 01 50 A0 E1 00 40 A0 E1 EB 03 07 E3", "00 F0 20 E3");
            }
        }

        private void guna2CustomCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            string jump = @"C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Recent\CustomDestinations";
            string jump2 = @"C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Recent\AutomaticDestinations";
            command(@"del /s /f /q C:\Users\%username%\AppData\Local\CrashDumps\ *.dmp*");
            command(@"deltree /y c:\windows\tempor~1");
            command(@"deltree /y c:\windows\temp");
            command(@"deltree /y c:\windows\tmp");
            command(@"deltree /y c:\windows\ff*.tmp");
            command(@"deltree /y c:\windows\history");
            command(@"deltree /y c:\windows\cookies");
            command(@"sc stop Dusmsvc");
            command(@"sc stop sysmain");
            command(@"sc stop bam");
            command("del /s /q " + jump2);
            command("rd /s /q " + jump2);
            command("del /s /q " + jump);
            command("rd /s /q " + jump);
            Thread.Sleep(400);
            Program.stror();
            Thread.Sleep(400);
            Thread.Sleep(400);
            Program.LastSavePid();
            Thread.Sleep(400);
            Program.UserAssist();
            Thread.Sleep(400);
            Program.UserAssist2();
            Thread.Sleep(400); ;
            Program.MuiCache1();
            Thread.Sleep(400);
            Program.MuiCache2();
            Thread.Sleep(400);
            Thread.Sleep(400);
            Program.Tracing();
            Thread.Sleep(400);
            Program.UserSettings();
            command(@"sc start sysmain");
            command(@"sc start bam");
        }
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        private void casdasdasdasdas(bool state)
        {
            foreach (object obj in Application.OpenForms)
            {
                Form form = obj as Form;
                if (state)
                {
                    SetWindowDisplayAffinity(form.Handle, 0x00000011);
                }
                else
                {
                    SetWindowDisplayAffinity(form.Handle, 0);
                }
            }
        }
        private void guna2CustomCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (guna2CustomCheckBox4.Checked)
                {
                    casdasdasdasdas(true);
                }
                else
                {
                    casdasdasdasdas(false);
                }
            }
        }
    }
}