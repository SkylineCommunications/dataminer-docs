---
uid: DataMiner_Health_Check_Usage
---

# Using the DataMiner Health Check Tool

## Health Check Manager element pages

## General data page

The *General* page of the *Health Check Manager* element provides an overview of information about the available tests.

Key metrics on this page are the **overall failure rate** of the **last run** and for a **longer duration**. The time range for this second metric can be adjusted with the *Longer Duration Time* parameter on the *Configuration* page.

![General Page](~/user-guide/images/Health_Check_General_Page.png)

### Test Configuration data page

This page allows you to manage the configuration of both **tests** and **subscriptions**, ensuring they align with your monitoring needs. For more information, see [Configuring the DataMiner Health Check Tool](xref:DataMiner_Health_Check_Tool_Configuration).

![Test Configuration Page](~/user-guide/images/Health_Check_Results.png)

### Results Data Page

The *Results* page displays a table listing all the tests that have been executed within a specified time span. This table contains essential details, including the execution time, test results, and the failure rate.

The *Success Count* and *Failure Count* metrics are calculated based on the DataMiner Agents within the DataMiner System. Below are the detailed calculation methods for each test type:

- Script-based tests:

  - *Evaluation Method*: Tests evaluate if DataMiner Agents meet the configured threshold for the test type.
  - *Success Count*: The number of DMAs that passed the threshold requirement.
  - *Failure Count*: The number of DMAs that failed to meet the threshold requirement.

- Subscription-based tests for standalone parameters:

  - *Evaluation Process*:
    - Tests evaluate the defined standalone parameter for each element within each DataMiner Agent.
    - A DMA passes only if all its elements meet the configured threshold for the standalone parameter.
    - A DMA fails if any single element fails to meet the threshold for the standalone parameter.
  - *Success Count*: The total number of DataMiner Agents where all elements passed.
  - *Failure Count*: The total number of DataMiner Agents where any element failed.

- Subscription-based tests for table columns:

  - *Evaluation Process*:
    - Tests evaluate all values within the specified table column for each element.
    - *Element Evaluation*:
      - Passes if all cells in the column meet the threshold.
      - Fails if any cell in the column fails to meet the threshold.
    - *DMA Evaluation*:
      - Passes if all elements pass.
      - Fails if any element fails.
  - *Success Count*: The total number of DataMiner Agents where all elements passed.
  - *Failure Count*: The total number of DataMiner Agents where any element failed.

The Failure Rate is calculated considering the Failure count and the total number of DMAs in the system.

Additionally, you can configure the time span using the **Auto Clear** parameter, allowing you to determine how many hours or days of test history to retain. For instance, you can choose to keep the results for **7 days**.

It is essential to set the **Auto Clear** parameter with a time span equal to or longer than the one configured in the **Long Duration Time** parameter. If the **Auto Clear** time span is shorter, there won't be enough historical data retained to accurately calculate the long-term failure rate.

![Results Page](~/user-guide/images/Health_Check_Result_table.png)

## Email Report Results

The Health Check solution offers daily email reports that summarize the results of executed tests.

These reports offer a clear overview of the latest test results, highlighting both **failed** and **successful tests**, along with detailed information about any failures.

Additionally, the report displays the **overall failure rate** of the most recent test run, as well as the **overall longer duration failure rate** for tests executed over a defined time interval.

> [!NOTE]
> The time span for the longer duration failure rate can be adjusted on the **Configuration** page within the Health Check Manager.

![Email Report](~/user-guide/images/Health_Check_Email_Report.png)
