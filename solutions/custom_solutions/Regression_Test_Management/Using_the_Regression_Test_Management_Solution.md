---
uid: Using_the_Regression_Test_Management_Solution
---

# Using the Regression Test Management Solution

Once you’ve configured your test groups and report settings, you can execute tests manually or automatically, track their results, and access detailed reports.

## Execution Methods

There are multiple ways to execute regression tests:

### 1. **From the Settings Page**

Click the **Execute Tests** button to run all configured tests immediately. This simulates the daily automated execution and sends an email report if enabled.

### 2. **From the Test Configuration Page**

- To run a **single test**, click the **Execute** button on the corresponding row in the *Regression Tests* table.
- To run an entire **group**, click the **Execute** button next to a group in the *Groups* table. All associated tests will execute in the specified order.

### 3. **From the Visual Overview (Visio)**

Click the **EXECUTE...** button on the visual overview of the *Regression Test Results* element. A pop-up will appear allowing you to select specific tests or folders to run.

![Visual Overview](~/solutions/images/Regression_Test_Visual.png)

### 4. **From the DataMiner Scheduler**

1. Open the **Scheduler** module in DataMiner Cube.
2. Create a new **Task**.
3. Set the **Recurrence** (e.g., daily at 2:00 AM).
4. Under **Actions**, select the `RegressionTestRunner` script.
5. Provide the configuration in the **ScriptConfiguration** field using a JSON structure like this:

   ```json
   {
     "Folders": ["Regression Testing"],
     "Scripts": ["RT_TestName"],
     "SearchSubDirectories": True,
     "ScriptsToSkip": ["RT_SKIP_THIS"],
     "FoldersToSkip": ["Regression Testing/FolderToSkip"],
     "Recipients": ["someone@example.com"]
   }
   ```

## Viewing Test Results

Navigate to the **General** page in the *Regression Test Results* element to view the summary of test executions.

- **Summary** shows the total amount of tests and overall success rate.
- **Overview** displays the list of executed tests with their result, reason, and timestamp.

## Email Reports

If enabled in the **Settings** page, the system sends out a formatted email report after execution, summarizing:

- Success rate
- Test names
- Result (OK/Fail)
- Reason for failure or success
- Timestamp

![Email Settings Panel](~/solutions/images/Regression_Test_Email.png)

These reports help quickly identify failures and track regression test health over time.

> [!NOTE]
> You can adjust email recipients or disable email entirely via the *Settings* page of the element.
