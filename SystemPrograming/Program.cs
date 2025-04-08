using System;
using System.Diagnostics;

class ParentProcess
{
    static void Main(string[] args)
    {
        try
        {
            // Ask for the file path
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();

            // Ask for the word to search
            Console.WriteLine("Enter the word to search:");
            string searchWord = Console.ReadLine();

            // Validate input
            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(searchWord))
            {
                Console.WriteLine("Invalid input. Please provide both file path and word.");
                return;
            }

            // Path to the child process executable
            string childProcessPath = "ChildProcess.exe"; // Ensure ChildProcess.exe is accessible

            // Prepare arguments
            string arguments = $"\"{filePath}\" \"{searchWord}\"";

            // Start the child process
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = childProcessPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };

            Console.WriteLine("Launching child process...");
            process.Start();

            // Read the output from the child process
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Display the result
            Console.WriteLine("Child process output:");
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}


/*
 * using System;
using System.IO;

class ChildProcess
{
    static void Main(string[] args)
    {
        try
        {
            // Validate arguments
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments. Please provide a file path and a word to search.");
                return;
            }

            string filePath = args[0];
            string searchWord = args[1];

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            // Read the file
            string fileContent = File.ReadAllText(filePath);

            // Count occurrences of the word
            int wordCount = CountOccurrences(fileContent, searchWord);

            // Display the result
            Console.WriteLine($"Word '{searchWord}' occurs {wordCount} time(s) in the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static int CountOccurrences(string text, string word)
    {
        int count = 0;
        int index = 0;

        while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count;
    }
}

*/