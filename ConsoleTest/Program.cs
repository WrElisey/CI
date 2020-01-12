
using NUnitLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using static GitHubAutomation.Services.TestDataReader;

namespace GitHubAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmdArgs = args
                .Select(s => new Regex(@"/(?<name>.+?)=(?<val>.+)")
                .Match(s))
                .Where(m => m.Success)
                .ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value);

                Settings.Env = cmdArgs["env"] ?? "dev";
                Settings.Browser = cmdArgs["browser"] ?? "chrome";


            var testRunner = new AutoRun(Assembly.GetExecutingAssembly());
            var tests = new string[] { $"--testlist:{Directory.GetCurrentDirectory()}\\..\\..\\..\\tests.txt" };
            int a = testRunner.Execute(tests);
            if(a == 1)
            {
                throw new System.Exception("FAIL");
            }
        }
    }
}