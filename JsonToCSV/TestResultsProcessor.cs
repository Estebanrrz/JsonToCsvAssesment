using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;

namespace JsonToCSV
{
    /// <summary>
    /// Class designed to process test results.
    /// </summary>
    public static class TestResultsProcessor
    {
        /// <summary>
        /// Parses a JSON string into a list of test cases.
        /// </summary>
        /// <param name="json">JSON to parse</param>
        /// <returns>A list of test cases</returns>
        public static List<TestCase> ParseJson(string json)
        {
            return JsonConvert.DeserializeObject<List<TestCase>>(json);
        }

        /// <summary>
        /// Writes a list of test cases to a CSV file.
        /// </summary>
        /// <param name="testCases">List of test cases to write</param>
        /// <param name="csvPath">Path where to create the CSV file</param>
        public static void WriteTestCasesToCsv(List<TestCase> testCases, string csvPath)
        {
            using (var writer = new StreamWriter(csvPath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(testCases);
            }

        }

        /// <summary>
        /// Display test metrics.
        /// </summary>
        /// <param name="metrics">Metrics to display</param>
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