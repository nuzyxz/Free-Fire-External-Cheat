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
using Microsoft.Win32;
using System.Reflection;
using System.Security.Principal;
namespace nuzy
{
    

internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName("AnyDesk").Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form2());
            }
        }

        public static void LastSavePid()
        {
            string hasy = @"Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\LastVisitedPidlMRU";
            RegistryKey local;
            local = Registry.CurrentUser.OpenSubKey(hasy);

            if (local == null)
            {

            }
            else if (local != null)
            {
                Registry.CurrentUser.DeleteSubKey(hasy);
                Registry.CurrentUser.CreateSubKey(hasy);
            }
        }

        public static void stror()
        {
            string hasy = @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store";
            string oi = Assembly.GetExecutingAssembly().Location.ToString();
            RegistryKey local;
            local = Registry.CurrentUser.OpenSubKey(hasy, true);
            if (local == null)
            {

            }
            else if (local != null)
            {
                if (Registry.CurrentUser.GetValue(oi) != null)
                {
                    Registry.CurrentUser.DeleteValue(oi);
                }
            }
        }

        public static void MuiCache1()
        {
            string hasy = @"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache";
            string oi = Assembly.GetExecutingAssembly().Location + ".FriendlyAppName";
            RegistryKey local;
            local = Registry.CurrentUser.OpenSubKey(hasy, true);
            if (local != null)
            {
                if (Registry.CurrentUser.GetValue(oi) != null)
                {
                    Registry.CurrentUser.DeleteValue(oi);
                }
            }
        }

        public static void UserSettings()
        {
            string hasy = @"SYSTEM\ControlSet001\Services\bam\UserSettings\" + WindowsIdentity.GetCurrent().User.Value;
            RegistryKey local;
            string oi = Assembly.GetExecutingAssembly().Location.ToString();
            local = Registry.LocalMachine.OpenSubKey(hasy, true);

            if (local == null)
            {

            }
            else if (local != null)
            {
                Registry.LocalMachine.DeleteSubKey(hasy);
                Registry.LocalMachine.CreateSubKey(hasy);
            }
        }

        public static void UserAssist()
        {
            string hasy = @"Software\Microsoft\Windows\CurrentVersion\Explorer\UserAssist\{CEBFF5CD-ACE2-4F4F-9178-9926F41749EA}\Count";
            RegistryKey local;
            local = Registry.CurrentUser.OpenSubKey(hasy);

            if (local == null)
            {

            }
            else if (local != null)
            {
                Registry.CurrentUser.DeleteSubKey(hasy);
                Registry.CurrentUser.CreateSubKey(hasy);
            }
        }

        public static void UserAssist2()
        {
            string hasy = @"Software\Microsoft\Windows\CurrentVersion\Explorer\UserAssist\{CEBFF5CD-ACE2-4F4F-9178-9926F41749EA}\Count";
            RegistryKey local;
            local = Registry.CurrentUser.OpenSubKey(hasy);

            if (local == null)
            {

            }
            else if (local != null)
            {
                Registry.CurrentUser.DeleteSubKey(hasy);
                Registry.CurrentUser.CreateSubKey(hasy);
            }
        }

        public static void Tracing()
        {
            string hasy = @"SOFTWARE\Microsoft\Tracing\";
            RegistryKey local;
            local = Registry.LocalMachine.OpenSubKey(hasy, true);

            if (local == null)
            {

            }
            else if (local != null)
            {
                Registry.LocalMachine.DeleteSubKeyTree(hasy, true);
            }
        }

        public static void MuiCache2()
        {
            string hasy = @"Software\Microsoft\Windows\ShellNoRoam\MUICache";
            string oi = Assembly.GetExecutingAssembly().Location.ToString();
            RegistryKey local;
            local = Registry.CurrentUser.OpenSubKey(hasy, true);
            if (local == null)
            {

            }
            else if (local != null)
            {
                if (Registry.CurrentUser.GetValue(oi) != null)
                {
                    Registry.CurrentUser.DeleteValue(oi);
                }
            }
        }

            
    }
}
