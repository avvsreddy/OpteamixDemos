using System.Diagnostics;

namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Client 1
            ProcessManager processManager = new ProcessManager();
            //// show all running processes
            processManager.ShowProcessList(delegate (Process process)
            {
                return true; // No filtering, show all processes
            });


            processManager.ShowProcessList( process => 1==1);

            // Client 2 - get all processes starts with 'S'
            //ProcessManager processManager = new ProcessManager();

            // Anonymous delegate

            processManager.ShowProcessList(delegate (Process process)
            {
                return process.ProcessName.StartsWith("S"); // Filter processes that start with 'A'
            });

            processManager.ShowProcessList(process =>
             process.ProcessName.StartsWith("S") // Filter processes that start with 'A'
            );

            // Client 3 - get all processes based on memory size
            //ProcessManager processManager = new ProcessManager();
            //FilterDelegate filter = new FilterDelegate();
            //processManager.ShowProcessList(delegate (Process process)
            //{
            //    return process.WorkingSet64 > 500 * 1024 * 1024; // Filter processes using more than 100MB of memory

            //}); // Show processes using more than 100MB of memory


            // Lambda Expression : Light weight syntax for anonymous methods (delegates)

            // Using lambda statement for Client 3 filter logic
            processManager.ShowProcessList( (Process process) =>
            {
                return process.WorkingSet64 > 500 * 1024 * 1024; // Filter processes using more than 100MB of memory

            }); // Show processes using more than 100MB of memory

            // Using lambda expression for Client 3 filter logic

            // Lambda Expression:
            // Single expression
            // no language  keywords
            // no langauge specific syntax / symbols


            processManager.ShowProcessList((Process process) =>
            
                 process.WorkingSet64 > 500 * 1024 * 1024 // Filter processes using more than 100MB of memory

            ); // Show processes using more than 100MB of memory


            processManager.ShowProcessList(x => x.WorkingSet64 > 500 * 1024 * 1024);

        }

        // Client 1 filter logic (show all processes)
        //public static bool NoFilter(Process process)
        //{
        //    return true; // No filtering, show all processes
        //}

        // Client 2 filter logic
        //public static bool FilterByProcessName(Process process)
        //{
        //    return process.ProcessName.StartsWith("A", StringComparison.OrdinalIgnoreCase); // Filter processes that start with 'A'
        //}


        // Client 3 filter logic
        //public static bool FilterByMemorySize(Process process)
        //{
        //    return process.WorkingSet64 > 500 * 1024 * 1024; // Filter processes using more than 100MB of memory

        //}
    }



        // Back-end Developer
        public delegate bool FilterDelegate(Process process);
        public class ProcessManager
    {
        //public void ShowProcessList()
        //{
        //    foreach (Process process in Process.GetProcesses())
        //    {
        //        Console.WriteLine($"Process Name: {process.ProcessName}, ID: {process.Id}");
        //    }
        //}

        public void ShowProcessList(FilterDelegate filter)
        {
            foreach (Process process in Process.GetProcesses())
            {
                    //if(Program.FilterByMemorySize(process))
                    if (filter(process))
                    {
                        Console.WriteLine($"Process Name: {process.ProcessName}, ID: {process.Id}");
                    }
            }
        }
        //public void ShowProcessList(long size)
        //{
        //    foreach (Process process in Process.GetProcesses())
        //    {
        //        if (process.WorkingSet64 > size)
        //        {
        //            Console.WriteLine($"Process Name: {process.ProcessName}, ID: {process.Id}");
        //        }
        //    }
        //}
    }
}
