using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace nuzy
{
    internal class All
    {
        public static void ShowNotification(string Mensagem)
        {
            Form3 form = new Form3();
            form.showAlert(Mensagem);
        }
    }
}
