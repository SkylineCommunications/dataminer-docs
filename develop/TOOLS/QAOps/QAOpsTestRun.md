---
uid: QAOps_Test_Run
---

# QAOps test run

> [!IMPORTANT]
> This page applies only to Skyline employees.

A QAOps test run stores all [test results](xref:QAOps_Test_Result) produced when you execute a [test suite](xref:QAOps_Test_Suite) on a [test configuration](xref:QAOps_Configuration).

During its lifecycle, a test run can move through the following statuses:

1. **Initializing... (0)**

   During initialization, QAOps downloads all required test packages from the catalog or temporary storage and retrieves any provided ".dmupgrade" files.

1. **Initialization completed (1)**

   QAOps has finished downloading all required items.

1. **Upgrading DataMiner... (2)**

   If a ".dmupgrade" file was provided, QAOps applies it to DataMiner.

1. **Upgrade DataMiner completed (3)**

   If a ".dmupgrade" file was provided, the upgrade has completed.

1. **Installing dependencies... (4)**

   QAOps installs all test packages in the same way as a [DataMiner Package (.dmapp)](xref:DataMiner_packages) file.

1. **Install dependencies completed (5)**

   QAOps has finished installing all packages.

1. **In progress... (6)**

   QAOps runs the PowerShell scripts for all provided test packages and executes the tests on the prepared system.

1. **Completed (7)**

   All testing has completed, and no failures were reported.

1. **Completed with failures (8)**

   All testing has completed, but one or more failures were reported.

1. **Cancelling... (9)**

   The test run is being canceled.

1. **Cancelled (10)**

   The cancellation has been applied.

1. **Failed (99)**

   The test run failed as a whole.

   Common scenarios include:

   - Dependency installation of a ".dmapp" file failed. This usually indicates a problem with the ".dmtest" package or SLNet.

   - Installation of a provided ".dmupgrade" file failed. This usually indicates a problem with that ".dmupgrade" file.

For the Platform Development Team, this issue is most often caused by mismatched assemblies when you test new code. Rebase on the latest RC and run the test again. If the problem persists, check "C:\Skyline DataMiner\Logging\SLAppPackageInstaller.txt" for additional details.

For other teams, this issue is most often caused by problems in the test package itself. For additional details, check "C:\Skyline DataMiner\Logging\SLAppPackageInstaller.txt". You can also rename the ".dmtest" file to ".dmapp" and install it manually to gather more information.

## Maximum test runs to keep

A [QAOps configuration](xref:QAOps_Configuration) can keep only a limited amount of data in memory. You configure this by defining how many test suites and test runs the configuration retains.

It is important to understand that QAOps is currently built to block releases when regressions are detected and to support regression testing of changes. Long-term data storage is not yet available, though it is planned for 2026. Do not use the system as long-term storage by setting an excessively high value for "Maximum test runs to keep".
