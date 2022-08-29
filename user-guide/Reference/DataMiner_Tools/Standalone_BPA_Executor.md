---
uid: Standalone_BPA_Executor
---

# Standalone BPA Executor

The *Standalone BPA Executor* can be used to run BPA (i.e. Best Practices Analysis) tests outside of DataMiner Cube. These tests can be used to verify that a specific part of a DataMiner setup conforms with Skyline recommendations. For example, a BPA test can be used to verify that all DMAs in a cluster are configured to use the same time server.

This tool is available on every DMA using DataMiner 10.0.10 or higher, in the folder `C:\Skyline DataMiner\Tools\StandaloneBpaExecutor`. However, it can execute BPA tests on any DMA, even a DMA using an older DataMiner version.

> [!NOTE]
> For information on the available BPA tests and on how to run these tests within DataMiner Cube instead of using this standalone tool, see [Running BPA tests](xref:Running_BPA_tests).

## Running BPA tests

To execute a BPA test using the *Standalone BPA Executor* tool:

1. On a DMA using DataMiner 10.0.10 or higher, go to the folder `C:\Skyline DataMiner\Tools\StandaloneBpaExecutor` and double-click *StandaloneBpaExecutor.exe*. If a message appears asking if you want to allow the app to make changes to your device, click *Yes*.

   - If you wish to run a BPA test on a DMA with a lower DataMiner version, you can do so by copying the tool from a DMA where it is available and running it on the DMA with the lower DataMiner version.

   - Running a BPA test on the offline DMA of a Failover pair is only supported from DataMiner 10.1.0 \[CU11]/10.2.2 onwards.

1. If you want to run the BPA test using different credentials than those you are currently using to log into Windows, go to the *Settings* tab, select *Custom credentials* and specify the username and password.

1. Some BPA tests can be configured to run corrective actions when they discover an issue. If you want corrective actions to be run, in the *Settings* tab, select *Execute corrective actions*.

1. You can now execute a BPA test in two different ways:

   - In the *Run From File* tab, you can browse to a specific BPA test and execute it. To do so:

     1. Click the *Browse for BPA* button, browse to the BPA file and click *Open*.

     1. Click the *Execute* button.

     1. Once the test has run, the *BPA Test Results* window will be displayed. To save the results of the test, you can copy them to the clipboard or export them to a file using the buttons at the bottom of the window.

   - In the *Run from DMA* tab, you can run one or more BPA tests that were previously installed on the DMA. This will only work on a DMA using DataMiner version 10.0.10 or higher.

     1. Select the BPA test(s) you want to run. If a test is not listed yet, you can upload it using the *Upload* button at the bottom of the window, or by right-clicking the list and selecting *Upload* (depending on the version of the tool).

     1. Some BPA tests can be run repeatedly based on a schedule. If you want to modify the default schedule for a BPA test, right-click it in the list and select *Change Schedule*. Then specify the interval at which the test should be run. If you specify "0", the test will only run once. If an interval is specified, the test will run in the background each time the interval has passed.

     1. Click the *Run Locally* button to run the test via the tool, or the *Run on DMA* button to run it via the DataMiner Agent.

     1. When a test has run, the list will be updated with the test result. For more detailed information, right-click the test and select *View Result Details*. This will open a pop-up window where you can copy the test results to the clipboard or export them to a file using the buttons at the bottom of the window.

> [!NOTE]
>
> - For specific actions, such as uploading a BPA test to a DMA or running a BPA test on a DMA, you need to have the necessary security permissions. You can find these in the *Users/Groups* module in DataMiner Cube under *Modules > System configuration > Tools > Best practices analyzer*.
> - BPA tests that are uploaded to a DMA are automatically synchronized to the other DMAs in the cluster.
> - You can remove a BPA test from a DMA in the *Run from DMA* tab by selecting the test and clicking the *Delete* button. Note that in earlier versions of this tool, this option is available via the right-click menu instead.
> - When the result of a BPA test has been exported to a file, you can load the result in the *Load Results* tab of the tool (from DataMiner 9.6.0 \[CU19], 10.0.0 \[CU7] and 10.0.12 onwards). To do so, first browse for the result file, then click the *Load Result File* button.
> - The *Save Test Results* button will save the results of all tests that are currently selected.
> - The *Get Last Results* button on the *Run From DMA* tab allows you to fetch the most recent results for the selected tests, if these are run on a schedule (from DataMiner 9.6.0 \[CU21], 10.0.0 \[CU9] and 10.1.1 onwards).

## Running BPA tests via command line

From DataMiner 9.6.0 \[CU19], 10.0.0 \[CU7], and 10.0.12 onwards, the Standalone BPA Executor tool also allows you to run BPA tests using a command line, instead of via the UI of the tool.

This is the general syntax to run one or more tests:

```txt
StandaloneBpaExecutor.exe -<options> --<paths to tests>
```

> [!NOTE]
> When you specify a path to a test, place this between double quotation marks.

The following options are supported:

- `-f` or `-file`: Saves the results to a specified file, which must have the .json extension (see example below).

    Supported from DataMiner 10.0.0 \[CU19], 10.1.0 \[CU8], and 10.1.11 onwards.

- `-h` or `-help`: Displays the help.

- `-p` or `-password`: The password used to run the test.

- `-u` or `-username`: The username used to run the test.

Examples:

```txt
StandaloneBpaExecutor.exe -u Administrator -p Swordfish123 --"C:\BPA tests\AnalyzeStartupLogs\AnalyzeStartupLogsBpa.dll" "C:\BPA tests\StandaloneBpaExecutor\ReportActiveRTE\ReportActiveRTE.dll"

StandaloneBpaExecutor.exe -u Administrator -p Swordfish123 -f "C:\Skyline DataMiner\Tools\StandaloneBpaExecutor\test.json" --"C:\Skyline DataMiner\Tools\StandaloneBpaExecutor\Check System Health.dll"
```
