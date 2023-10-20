using JsonToCSV;

namespace JsonToCSV
{
    public class Program
    {
        static void Main()
        {


            try
            {
                Console.WriteLine("Enter the JSON Path:");

                string inputPath = Console.ReadLine();
                string json = File.ReadAllText(inputPath);
                // Parse JSON into a list of test cases
                var testCases = TestResultsProcessor.ParseJson(json);

                // Export to CSV
                Console.WriteLine("Enter the output Path:");
                string outputPath = Console.ReadLine();
                TestResultsProcessor.WriteTestCasesToCsv(testCases, outputPath);
                // Calculate test metrics
                var metrics = new TestCaseMetrics();
                metrics.CalculateMetrics(testCases);

                // Display metrics
                TestResultsProcessor.DisplayMetrics(metrics);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
//

//    if (File.Exists(configFile))
//    {
//        try
//        {
//            string configJson = File.ReadAllText(configFile);
//            var config = JsonSerializer.Deserialize<AppConfig>(configJson);

//            // Use config.JsonFilePath and config.CsvFilePath for your program
//            ProcessTestResults(config.JsonFilePath, config.CsvFilePath);
//        }
//        catch (JsonException ex)
//        {
//            Console.WriteLine($"Error parsing the JSON configuration: {ex.Message}");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Configuration file not found. Please create a 'config.json' file.");
//    }
//}


