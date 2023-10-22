# Test Results Analyzer

This repository contains a comprehensive C# solution for analyzing test results, converting them to CSV format, and calculating various metrics based on the test results.

## Getting Started

To start using the Test Results Analyzer, follow these instructions to create an executable, execute the program, and run test cases.

### Prerequisites

Make sure you have the .NET SDK (Software Development Kit) installed. If you don't have it already, you can download and install it from [here](https://dotnet.microsoft.com/download/dotnet).

### Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/Estebanrrz/JsonToCsvAssesment.git


#### Option 1

Open the repository in Visual Studio.
Build the project.
Navigate to C:\..\JsonToCSV\MainProgram\bin\Release\net6.0.
Execute MainProgram.exe

#### Option 2
Select MainProgram project on Build/debug Toolbar
Click the "Run Project" button in Visual Studio.

#### Option 3
Run one of the test cases from the TestsTestCasesProcessor project and parameterize the JSON as needed. There are three example JSON files available for your use.

### Expected JSON Input Format
The input JSON should have the following format:

Each test case is represented as an object in the array.
The test case object should have a "Name" (string), "Status" (string, one of "Passed," "Failed," or "Not Executed"), "ExecutionTime" (double), and "Timestamp" (string in ISO 8601 format).
 
```json
[
  {
    "Name": "Test Case 1",
    "Status": "Passed",
    "ExecutionTime": 4.56,
    "Timestamp": "2023-10-19T10:30:00"
  },
  {
    "Name": "Test Case 2",
    "Status": "Failed",
    "ExecutionTime": 7.89,
    "Timestamp": "2023-10-19T11:15:00"
  },
  // Add more test cases as needed
]



