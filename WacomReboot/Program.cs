using System;
using System.Diagnostics;


namespace RestartService
{
    class Program
    {
        static void Main(string[] args) {
            RestartService("WTabletServicePro");
        }
        public static void RestartService(string serviceName)
        {
            var psi = new ProcessStartInfo("net.exe", "stop " + serviceName);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = true;
            psi.WorkingDirectory = Environment.SystemDirectory;
            var st = Process.Start(psi);
            st.WaitForExit();

            psi = new ProcessStartInfo("net.exe", "start " + serviceName);
            psi.UseShellExecute = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.WorkingDirectory = Environment.SystemDirectory;
            st = Process.Start(psi);
            st.WaitForExit();
        }

    }
}