using JsonToCSV;
using Newtonsoft.Json;

namespace JsonToCSV
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Please enter the path to the JSON file (e.g., C:\\Users\\User\\Documents\\input.json):");

                string inputPath = Console.ReadLine()!;

                if (File.Exists(inputPath))
                {
                    string json = File.ReadAllText(inputPath);
                    var testCases = TestResultsProcessor.ParseJson(json);

                    Console.WriteLine("Please enter the path for the CSV output file (e.g., C:\\Users\\User\\Documents\\output.csv):");
                    string outputPath = Console.ReadLine()!;

                    // Export to CSV
                    TestResultsProcessor.WriteTestCasesToCsv(testCases, outputPath);

                    // Calculate test metrics
                    var metrics = new TestCaseMetrics();
                    metrics.CalculateMetrics(testCases);

                    // Display metrics
                    TestResultsProcessor.DisplayMetrics(metrics);
                }
                else
                {
                    Console.WriteLine("The specified input file does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON parsing error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
    }
}
