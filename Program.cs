using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swimming_Pool_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Form());

          /* Login_Form loginForm = new Login_Form();

            if(loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Dashboard());
                
            }
            else
            {
                Application.Exit();
            }
           */ 
        }
    }
}
