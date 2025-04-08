using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string processPath = "notepad.exe"; // Path to the process you want to run

        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Wait for the process to exit and display the exit code");
        Console.WriteLine("2. Forcefully terminate the process");
        string choice = Console.ReadLine();

        if (choice == "1" || choice == "2")
        {
            Process process = CreateAndStartProcess(processPath);
            HandleUserChoice(process, choice);
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting the program.");
        }
    }

    static Process CreateAndStartProcess(string processPath)
    {
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = processPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Starting the process...");
        Console.ResetColor();

        process.Start();
        return process;
    }

    static void HandleUserChoice(Process process, string choice)
    {
        try
        {
            switch (choice)
            {
                case "1":
                    WaitForProcessToExit(process);
                    break;

                case "2":
                    Console.WriteLine("Process will be terminated in 5 seconds...");
                    Thread.Sleep(5000); 
                    ForceTerminateProcess(process);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void WaitForProcessToExit(Process process)
    {
        process.WaitForExit();
        int exitCode = process.ExitCode;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Process exited. Exit code: {exitCode}");
        Console.ResetColor();
    }

    static void ForceTerminateProcess(Process process)
    {
        process.Kill();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Process forcibly terminated.");
        Console.ResetColor();
    }
}
