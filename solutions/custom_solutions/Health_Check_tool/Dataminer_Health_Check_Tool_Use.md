---
uid: DataMiner_Health_Check_Usage
---

# Using the DataMiner Health Check Tool

## Health Check Manager element pages

### General data page

The *General* page of the *Health Check Manager* element provides an overview of information about the available tests.

Key metrics on this page are the **overall failure rate** of the **last run** and for a **longer duration**. The time range for this second metric can be adjusted with the *Longer Duration Time* parameter on the *Configuration* page.

![General Page](~/solutions/images/Health_Check_General_Page.png)

### Test Configuration data page

This page allows you to manage the configuration of both **tests** and **subscriptions**, ensuring they align with your monitoring needs. For more information, see [Configuring the DataMiner Health Check Tool](xref:DataMiner_Health_Check_Tool_Configuration).

![Test Configuration Page](~/solutions/images/Health_Check_Results.png)

### Results Data Page

The *Results* page displays a table listing all the tests that have been executed within a specified time span. This table contains essential details, including the execution time, test results, and the failure rate.

![Results Page](~/solutions/images/Health_Check_Result_table.png)

#### Results metrics

The **Success Count** and **Failure Count** metrics are calculated based on the DataMiner Agents within the DataMiner System. Below are the detailed calculation methods for each test type:

- Script-based tests:

  - Evaluation method: Tests evaluate if DataMiner Agents meet the configured threshold for the test type.
  - *Success Count*: The number of DMAs that passed the threshold requirement.
  - *Failure Count*: The number of DMAs that failed to meet the threshold requirement.

- Subscription-based tests for standalone parameters:

  - Evaluation process:
    - Tests evaluate the defined standalone parameter for each element within each DataMiner Agent.
    - A DMA passes only if all its elements meet the configured threshold for the standalone parameter.
    - A DMA fails if any single element fails to meet the threshold for the standalone parameter.
  - *Success Count*: The total number of DataMiner Agents where all elements passed.
  - *Failure Count*: The total number of DataMiner Agents where any element failed.

- Subscription-based tests for table columns:

  - Evaluation Process:
    - Tests evaluate all values within the specified table column for each element.
    - Element evaluation:
      - Passes if all cells in the column meet the threshold.
      - Fails if any cell in the column fails to meet the threshold.
    - DMA evaluation:
      - Passes if all elements pass.
      - Fails if any element fails.
  - *Success Count*: The total number of DataMiner Agents where all elements passed.
  - *Failure Count*: The total number of DataMiner Agents where any element failed.

The **Failure Rate** is calculated based on the failure count and the total number of DMAs in the system.

#### Cleanup configuration

Also on the *Results* page, you can configure when results are automatically cleared from the table.

With the *Auto Delete* parameter, you can determine how many hours or days of test history should be retained. For instance, you can choose to keep the results for 7 days.

It is essential to set the *Auto Delete* parameter to a time span equal to or longer than the one configured with the *Long Duration Time* parameter [on the *Configuration* page](xref:DataMiner_Health_Check_Tool_Configuration#configuring-the-test-execution-schedule). If the *Auto Delete* time span is shorter, not enough historical data will be retained to accurately calculate the long-term failure rate.

## Email report results

The Health Check Tool can send daily email reports that summarize the results of executed tests.

These reports offer a clear overview of the latest test results, highlighting both **failed** and **successful tests**, along with detailed information about any failures.

The report also display the **overall failure rate** of the most recent test run, as well as the **overall longer duration failure rate** for tests executed over a defined time interval.

On the **Configuration** page of the Health Check Manager element, you can [configure who should receive the email reports](xref:DataMiner_Health_Check_Tool_Configuration#configuring-email-reports).

![Email Report](~/solutions/images/Health_Check_Email_Report.png)
