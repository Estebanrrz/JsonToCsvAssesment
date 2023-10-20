using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;

namespace JsonToCSV
{
    public static class TestResultsProcessor
    {
        public static List<TestCase> ParseJson(string json)
        {

            return JsonConvert.DeserializeObject<List<TestCase>>(json);
        }

        public static void WriteTestCasesToCsv(List<TestCase> testCases, string csvPath)
        {
            using (var writer = new StreamWriter(csvPath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(testCases);
            }
        }

        public static void DisplayMetrics(TestCaseMetrics metrics)
        {
            Console.WriteLine("Test Metrics:");
            Console.WriteLine($"Total Test Cases: {metrics.TotalTestCases}");
            Console.WriteLine($"Passed Test Cases: {metrics.PassedTestCases}");
            Console.WriteLine($"Failed Test Cases: {metrics.FailedTestCases}");
            Console.WriteLine($"Not Executed Test Cases: {metrics.NotExecutedTestCases}");
            Console.WriteLine($"Average Execution Time: {metrics.AverageExecutionTime} seconds");
            Console.WriteLine($"Minimum Execution Time: {metrics.MinExecutionTime} seconds");
            Console.WriteLine($"Maximum Execution Time: {metrics.MaxExecutionTime} seconds");
        }

    }
}
