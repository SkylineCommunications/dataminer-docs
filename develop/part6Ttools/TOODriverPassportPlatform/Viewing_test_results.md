---
uid: Viewing_test_results
---

# Viewing test results

Once a test has run its course, a test plan will automatically be created by the Skyline Driver Passport Platform, using the defined test name in the defined test project.

For each test plan build, test cases are inserted corresponding to each DMAPP used for this test.

You can view the results of a test via the TestLink instance at <https://slc-h57-g02.skyline.local/TestLink/login.php>.

To view test results, in the top menu bar, click the *Test Reports* icon, and then select the test plan for which you want to view a report.

The options* Test Report* or *Test Report on build* allows you to generate a summary of a test.

### Test case - execution steps

Below you can find an overview of all steps executed by the generated TestLink test plan.

| Execution Step           | Category | KPI                           |
|--------------------------|----------|-------------------------------|
| 1\. CPU Info             | Server   | Processor Load Average        |
| 2\. CPU Info (SL)        | DMA      | Processor Load Average        |
| 3\. Average Info         | DMA      | Process Average CPU Info      |
| 3\. Average Info         | DMA      | Process Average VM Size       |
| 3\. Average Info         | DMA      | Process Average Threads       |
| 3\. Average Info         | DMA      | Process Average Handles       |
| 3\. Average Info         | DMA      | Process Average IO Data Rate  |
| 3\. Average Info         | DMA      | Process Average IO Other Rate |
| 3\. Average Info         | DMA      | Process Average IO Read Rate  |
| 3\. Average Info         | DMA      | Process Average IO Write Rate |
| 4.Max Info               | DMA      | Process Max CPU Info          |
| 4.Max Info               | DMA      | Process Max VM Size           |
| 4.Max Info               | DMA      | Process Max Threads           |
| 4.Max Info               | DMA      | Process Max Handles           |
| 4.Max Info               | DMA      | Process Max IO Data Rate      |
| 4.Max Info               | DMA      | Process Max IO Other Rate     |
| 4.Max Info               | DMA      | Process Max IO Read Rate      |
| 4.Max Info               | DMA      | Process Max IO Write Rate     |
| 4.Max Info               | DMA      | Process Max IO Data Bytes     |
| 4.Max Info               | DMA      | Process Max IO Other Bytes    |
| 4.Max Info               | DMA      | Process Max IO read Bytes     |
| 4.Max Info               | DMA      | Process Max IO Write Bytes    |
| 5\. Processor Cores Info | Server   | Cores CPU                     |
| 6\. Disk Busy Time       | Server   | Disk Busy Time                |
| 6\. Disk Latency         | Server   | Disk Latency                  |
| 7\. Leak                 | Server   | Memory Leak                   |
| 7\. Leak                 | Server   | Handle Leak                   |
| 7\. Leak                 | Server   | Threads Leak                  |
| 7\. Leak                 | Server   | CPU Leak                      |

### Test case - execution notes

The following information is included in the execution notes:

- Test Name

- Test Start DateTime

- Test End DateTime

- Package Name

- Elements Count

- Server Name

- Server Model

- Operating System

- Operating System Architecture

- Passmark Rating

- CPU Mark Rating

- Disk Mark Rating

- CPU Type

- Amount of Cores

- Total Physical Memory

- Total Virtual Memory

- DataMiner Version

- Database Type
