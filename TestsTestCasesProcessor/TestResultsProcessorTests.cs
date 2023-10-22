using JsonToCSV;

namespace TestsTestCasesProcessor
{
    [TestClass]
    public class TestResultsProcessorTests
    {
        [DataTestMethod]
        [DataRow(@"Jsons\20records.json", @"C:\Users\User\Documents\JSONTOCSVResults\resultstest.csv")]
        public void VerifyProcessJsonAndAssertMetrics(string inputPath, string outputPath)
        {
            // Arrange
            double deltaOneDec = 0.1;
            double deltaTwoDec = 0.01;

            // Act
            string json = File.ReadAllText(inputPath);
            var testCases = TestResultsProcessor.ParseJson(json);
            TestResultsProcessor.WriteTestCasesToCsv(testCases, outputPath);
            TestCaseMetrics metrics = new TestCaseMetrics();
            metrics.CalculateMetrics(testCases);

            string[] lines = File.ReadAllLines(outputPath);
            int actualLineCount = lines.Length;

            // Assert
            Assert.AreEqual(actualLineCount, 21, "Number of lines in the file is not as expected");
            Assert.AreEqual(20, metrics.TotalTestCases, "Total test cases are not as expected");
            Assert.AreEqual(11, metrics.PassedTestCases, "Passed test cases are not as expected");
            Assert.AreEqual(5, metrics.FailedTestCases, "Failed test cases are not as expected");
            Assert.AreEqual(4, metrics.NotExecutedTestCases, "Not Executed test cases are not as expected");
            Assert.AreEqual(5.13, metrics.AverageExecutionTime, deltaOneDec, "Average is not as expected");
            Assert.AreEqual(2.34, metrics.MinExecutionTime, deltaTwoDec, "Min time of execution is not as expected");
            Assert.AreEqual(9.87, metrics.MaxExecutionTime, deltaTwoDec, "Max time of execution is not as expected");
        }

        [DataTestMethod]
        [DataRow(@"Jsons\Empty.json", @"C:\Users\User\Documents\JSONTOCSVResults\resultstestEmpty.csv")]
        public void VerifyProcessJsonAndAssertMetricsEmptyJson(string inputPath, string outputPath)
        {
            // Arrange
            const int EXPECTED_NUMBER = 0;
            // Act
            string json = File.ReadAllText(inputPath);
            var testCases = TestResultsProcessor.ParseJson(json);
            TestResultsProcessor.WriteTestCasesToCsv(testCases, outputPath);
            TestCaseMetrics metrics = new TestCaseMetrics();
            metrics.CalculateMetrics(testCases);
            string[] lines = File.ReadAllLines(outputPath);
            int actualLineCount = lines.Length;

            // Assert
            Assert.AreEqual(actualLineCount, 1, "Number of lines in the file is not as expected");

            // Assert
            Assert.AreEqual(EXPECTED_NUMBER, metrics.TotalTestCases, "Total test cases are not as expected");
            Assert.AreEqual(EXPECTED_NUMBER, metrics.PassedTestCases, "Passed test cases are not as expected");
            Assert.AreEqual(EXPECTED_NUMBER, metrics.FailedTestCases, "Failed test cases are not as expected");
            Assert.AreEqual(EXPECTED_NUMBER, metrics.NotExecutedTestCases, "Not Executed test cases are not as expected");
            Assert.AreEqual(EXPECTED_NUMBER, metrics.AverageExecutionTime, "Average is not as expected");
            Assert.AreEqual(EXPECTED_NUMBER, metrics.MinExecutionTime, "Min time of execution is not as expected");
            Assert.AreEqual(EXPECTED_NUMBER, metrics.MaxExecutionTime, "Max time of execution is not as expected");
        }
    }
}