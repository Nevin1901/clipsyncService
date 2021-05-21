using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clipsyncService
{
    public class UserProcess
    {
        public static List<string> GetActiveProcesses(List<string> gameProcesses)
        {
            List<string> userProcesses = new List<string>();
            foreach (string item in gameProcesses)
            {
                Process[] currentProcess = Process.GetProcessesByName(item);
                if (!(currentProcess.FirstOrDefault() is null))
                {
                    if (!userProcesses.Contains(currentProcess.FirstOrDefault()?.ProcessName))
                    {
                        userProcesses = userProcesses.Append(currentProcess.FirstOrDefault()?.ProcessName).ToList();
                    }
                }
            }

            return userProcesses;
        }
    }
}
