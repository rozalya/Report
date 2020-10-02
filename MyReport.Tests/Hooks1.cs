using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

using TechTalk.SpecFlow;

namespace MyReport.Tests
{
    [Binding]
    public sealed class Hooks1
    {
        private static Process _iisExpressProcess;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            StartIISExpress();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            StopIISExpress();
        }

        private static void StartIISExpress()
        {
            var arguments = string.Format(
                CultureInfo.InvariantCulture,
                "/path:\"{0}\" /port:{1}", "https://localhost:44310/", 44310);

            var startInfo = new ProcessStartInfo(@"C:\Users\rosal\source\repos\MyReport\MyReport")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = arguments
            };

            _iisExpressProcess = Process.Start(startInfo);
        }

        private static void StopIISExpress()
        {
            if (_iisExpressProcess.HasExited == false)
            {
                _iisExpressProcess.Kill();
                _iisExpressProcess.Dispose();
                _iisExpressProcess = null;
            }
        }
    }
}
