using JsonToCSV;

namespace TestsTestCasesProcessor
{
    [TestClass]
    public class TestCasesProcessorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string inputPath = @"Jsons\20records.json";
            string outputPath = @"C:\Users\User\Documents\JSONTOCSVResults";

            string json = File.ReadAllText(inputPath);
            // Process json
            var testCases = TestResultsProcessor.ParseJson(json);

            // Export to CSV
            TestResultsProcessor.WriteTestCasesToCsv(testCases, outputPath);
            TestCaseMetrics metrics = new TestCaseMetrics();
            metrics.CalculateMetrics(testCases); // Assuming testCases is your list of test cases
            TestResultsProcessor.DisplayMetrics(metrics);

        }
    }
}