using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clipsyncService.Models;

namespace clipsyncService
{
    public class UserProcess
    {
        private List<string> _gameList; 

        public List<IApp> GetActiveProcesses()
        {
            List<IApp> userProcesses = new List<IApp>();
            foreach (string item in _gameList)
            {
                Process[] currentProcess = Process.GetProcessesByName(item);
                if (!(currentProcess.FirstOrDefault() is null))
                {
                    if (!userProcesses.Contains(new App(currentProcess.FirstOrDefault()?.ProcessName))) // this is probably gonna cause a bug if the two objects aren't the exact same
                    {
                        userProcesses = userProcesses.Append(new App(currentProcess.FirstOrDefault()?.ProcessName)).ToList();
                    }
                }
            }

            return userProcesses;
        }

        public void SetGameList (List<string> gameList)
        {
            _gameList = gameList;
        }

    }
}
