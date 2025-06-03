---
uid: Configuring_the_Regression_Test_Management_Solution
---

# Configuring the Regression Test Management Solution

After deploying the solution, you can configure how and when tests are run, how reports are delivered, and how to organize and execute your regression test scripts.

## Creating groups and tests

1. In DataMiner Cube, open the *Regression Test Results* element.

1. Go to the *Test Configuration* page.

1. In the *Groups* table:

   1. Right-click, and select *Add item* to create a new test group.
   1. Assign a name.

1. In the *Regression Tests* table:

   1. Right-click, and select *Add item* to define a test.
   1. Assign a name, select a group, select a test, and define an optional execution order.

![Test Configuration](~/solutions/images/Regression_Test_Configuration.png)

> [!NOTE]
> The execution order field is optional. If it is not defined, the test will be executed after all ordered tests.

## Configuring the solution settings

Go to the *Settings* page of the element to define how the tests should behave.

### Email report configuration

The *Settings* page of the *Regression Test Results* element contains all email-related configurations in one centralized panel.

![Email Settings Panel](~/solutions/images/Regression_Test_Settings.png)

- **Daily Email Report**: Enables or disables the automatic daily execution and email report.
- **Send Email on Single Test Run**: If enabled, email reports will also be sent when individual tests are executed from the *Test Configuration* page.
- **Send Email on Group Run**: If enabled, email reports will also be sent when test groups are executed.
- **Regression Test Runner Script**: The name of the Automation script that will be used to execute the tests and send the email report.
- **Report Recipients**: Comma-separated list of email addresses that should receive the report.
- **Start Time**: Time of day when the daily execution should occur.
- **Last Execution Time**: Timestamp of the most recent execution.
- **Email Report Execution Status**: The status of the last execution (e.g. *Succeeded*, *Failed*).

You can manually trigger the test run and email report by clicking the *Execute Tests* button at the bottom of the *Settings* page.

> [!NOTE]
> By default, the solution uses the *RegressionTestRunner* script to execute and report tests. However, if you want to customize the report format or implement custom test handling logic, you can create your own Automation script and configure its name in the **Regression Test Runner Script** parameter.
