using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string processPath = "notepad.exe";// Path to the process you want to run

            // Запускаємо процес
            Process process = new Process();
            process.StartInfo.FileName = processPath;
            process.StartInfo.UseShellExecute = false; // For work without shell(window)
            process.StartInfo.RedirectStandardOutput = true; // for output
            process.StartInfo.RedirectStandardError = true;

            Console.WriteLine("Start process after");
            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("1");
            Thread.Sleep(1000);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Start process");
            process.Start();
            Console.ResetColor();
            
            process.WaitForExit();

            // Get code for exit
            int exitCode = process.ExitCode;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Process ended. Exiting code: {exitCode}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Exception: {ex.Message}");
            Console.ResetColor();
        }
    }
}