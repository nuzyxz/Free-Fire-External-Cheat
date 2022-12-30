using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAuth;
using System.Windows.Forms;
using System.Security.Principal;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace nuzy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
            casdasdasdasdas(true);
        }

        public static api KeyAuthApp = new api(
        name: "nuzy",
        ownerid: "KcdJMs4Ts1",
        secret: "7487131b74522579c1250f9d99787caf70884b09d4f01c6c12be43f63c73c865",
        version: "1.0"
        );

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(user.Text, pass.Text);
            if (KeyAuthApp.response.success)
            {
                KeyAuthApp.log("LOGOU! USER: ||" + user.Text + "|| PASS: ||" + pass.Text + "|| HWID: ||" + WindowsIdentity.GetCurrent().User.Value + "||");
                All.ShowNotification("Welcome!");
                Console.Beep(500, 300);
                Form1 form = new Form1();
                form.Show();
                base.Hide();
            }
            else
            {
                All.ShowNotification("Username or Password is Invalid!");
                Console.Beep(500, 900);
                KeyAuthApp.log("```Errou o login! USER:``` ||" + user.Text + "|| PASS: ||" + pass.Text + "|| HWID: ||" + WindowsIdentity.GetCurrent().User.Value + "||");

            }
        }

        internal static bool IsKeyDown(Keys f2)
        {
            throw new NotImplementedException();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
