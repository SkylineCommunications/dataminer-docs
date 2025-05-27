---
uid: Configuring_the_Regression_Test_Management_Solution
---

# Configuring the Regression Test Management Solution

After deploying the solution, you can configure how and when tests are run, how reports are delivered, and how to organize and execute your regression test scripts.

## Step 1: Creating Groups and Tests

1. Open the **Regression Test Results** element in DataMiner Cube.
2. Navigate to the **Test Configuration** page.
3. In the **Groups** table:
   - Right-click and select **Add item...** to create a new test group.
   - Assign a name.
4. In the **Regression Tests** table:
   - Right-click and select **Add item...** to define a test.
   - Assign a name, select a group, select a test, and define an optional execution order.

![Test Configuration](~/solutions/images/Regression_Test_Configuration.png)

> [!NOTE]
> The execution order field is optional. If not defined, the test will be executed after all ordered tests.

## Step 2: Configuring the Settings Page

Go to the **Settings** page in the element to define how the tests should behave.

### Email Report Configuration

The **Settings** page of the *Regression Test Results* element contains all email-related configurations in one centralized panel.

![Email Settings Panel](~/solutions/images/Regression_Test_Settings.png)

- **Daily Email Report**: Enables or disables the automatic daily execution and email report.
- **Send Email on Single Test Run**: If enabled, email reports will also be sent when executing individual tests from the *Test Configuration* page.
- **Send Email on Group Run**: If enabled, email reports will also be sent when executing test groups.
- **Regression Test Runner Script**: Specifies the name of the Automation script that will be used to execute the tests and send the email report.
- **Report Recipients**: Comma-separated list of email addresses that should receive the report.
- **Start Time**: Time of day when the daily execution should occur.
- **Last Execution Time**: Timestamp of the most recent execution.
- **Email Report Execution Status**: Indicates the status of the last execution (e.g., *Succeeded*, *Failed*).

You can manually trigger the test run and email report by clicking the **Execute Tests** button at the bottom of the Settings page.

> [!TIP]
> By default, the solution uses the `RegressionTestRunner` script to execute and report tests. However, if you want to customize the report format or implement custom test handling logic, you can create your own Automation script and configure its name in the **Regression Test Runner Script** parameter.
