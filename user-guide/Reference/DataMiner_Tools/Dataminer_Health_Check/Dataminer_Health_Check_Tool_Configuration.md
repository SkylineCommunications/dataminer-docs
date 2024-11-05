---
uid: DataMiner_Health_Check_Tool_Configuration
---

# Configuring the DataMiner Health Check Tool

To begin receiving results from the DataMiner Health Check Tool, you will first need to [configure the test cases](#configuring-test-cases) and [configure the general report settings](#configuring-email-reports).

## Configuring test cases

There are two main types of test cases that can be configured, [script-based tests](#script-based-tests) and [subscription-based tests](#parameter-subscription-based-tests), each providing a different mechanism for querying data to allow for greater flexibility depending on the kind of data being tested.

### Script-based tests

Script-based tests use custom Automation scripts to execute and retrieve data. These tests can retrieve data from various sources, including DataMiner elements (via SLNet calls), DataMiner Agents (via DMS calls), or other external systems the DMS communicates with. Once the data is retrieved, it is evaluated against predefined thresholds to determine if the test passes or fails.

Several default tests are available related to the state of the DataMiner System, but you can also **integrate new tests using Automation scripts**. For the Health Check tool to recognize the new tests, the Automation scripts must be placed in the following folder in the Automation module: *Automation Scripts* > *Health Check* > *Health Check Tests*.

![Health Check tests in the Automation module](~/user-guide/images/Health_Check_Automation_Path.png)

#### Adding a script-based test

1. Make sure the script for the test you want to add is available in the Automation module in the folder *Automation Scripts* > *Health Check* > *Health Check Tests*.

1. In DataMiner Cube, open the *Health Check Manager* element and go to the *Test Configuration* page.

   This page shows a list pre-configured tests related to your DataMiner System's health. These include tests for checking the status of DMAs in the cluster, monitoring active timeouts, and more.

1. Right-click the *Test Configuration* table and select *Add Test* in the context menu.

   ![Add Test option](~/user-guide/images/Health_Check_Add_Test.png)

1. In the pop-up window, fill in the required fields:

   - *Test Type*: Make sure *Script* is selected.
   - *Name*: Select an available script-based test.
   - *Operator* and *Threshold*: Define the conditions for the test to determine whether it passes or fails.
   - *Display Title*: Optionally, enter a custom name for the test to make it easily identifiable. If provided, this title will be used to identify the test in the email report; otherwise, the default test name will be displayed.
   - *Element/DMA Filter*: Use this field to apply the test to a specific element. Enter the element/DMA you wish to target.
   - *Display Key Filter*: Apply this filter if you want the test to consider only certain entries for the test.
   - *Status Checkbox*: Select this box if you want the text to be enabled as soon as it is created.

1. Click *OK* to create the test.

![Test configuration](~/user-guide/images/Health_Check_Configure_Test.png)

#### Editing a script-based test

1. In DataMiner Cube, open the *Health Check Manager* element and go to the *Test Configuration* page.

1. Right-click the test you want to edit and select *Edit Test* in the context menu.

   ![Edit Test option](~/user-guide/images/Health_Check_Edit_Test.png)

   A pop-up window will show the current configuration of the selected test.

1. Modify any of the fields in the window as needed.

   These are the same fields as when you [add a test](#adding-a-script-based-test).

1. Click *OK* to apply the changes.

   The updated test configuration will be reflected in the *Test Configuration* table.

### Parameter subscription-based tests

Subscription-based tests allow you to select a specific standalone parameter or table column from any connector in the DataMiner System and subscribe to it. Once you have [created a subscription](#creating-a-subscription), you can [link it to a test](#linking-a-subscription-to-a-test) that retrieves the parameter's value and evaluates it against defined thresholds. This process helps assess the data's current state and detect any deviations from expected conditions.

#### Creating a subscription

1. In DataMiner Cube, open the *Health Check Manager* element, go to the *Test Configuration* page.

1. Right-click the *Parameter Subscription Table* and select *Add Subscription* in the context menu.

   ![Add Subscription option](~/user-guide/images/Health_Check_Add_Subscription.png)

1. In the pop-up window, configure the fields to set up the subscription:

   - *Protocol*: Select the protocol associated with the parameter you want to subscribe to. Only protocols with active elements will be displayed in the dropdown menu.
   - *Protocol Version*: Select the version of the selected protocol you want to use.
   - *Parameter Type*: Indicate whether you want to subscribe to a standalone parameter or a table parameter
     - If you select *Standalone Parameter*, in the *Parameter* field, select the name of the parameter you want to subscribe to.
     - If you select *Table Parameter*, specify the table name in the *Table* field and the column name in the *Parameter* field.

   ![Add Subscription window](~/user-guide/images/Health_Check_Configure_Subscription.png)

1. Click *OK* to add the subscription.

#### Editing a subscription

1. In DataMiner Cube, open the *Health Check Manager* element, go to the *Test Configuration* page.

1. Right-click the *Parameter Subscription Table* and select *Edit Subscription* in the context menu.

   ![Edit Subscription](~/user-guide/images/Health_Check_Edit_Subscription.png)

   A pop-up window will show the current configuration of the selected subscription.

1. Modify any of the fields in the window as needed.

   These are the same fields as when you [create a subscription](#creating-a-subscription).

1. Click *OK* to apply the changes.

   The updated subscription will now be reflected in the *Parameter Subscriptions* table.

#### Linking a subscription to a test

After you have created a subscription, you will still need to link it to a test:

1. In DataMiner Cube, open the *Health Check Manager* element and go to the *Test Configuration* page.

1. Right-click the *Test Configuration* table and select *Add Test* in the context menu.

1. In the pop-up window, fill in the required fields:

   - *Test Type*: Set this field to **Subscription**.
   - *Name*: Select the name of the subscription you want to link to a test.
   - *Operator and Threshold*: Define the conditions to determine whether the test passes or fails.
   - *Display Title*: Optionally, enter a custom name for the test to make it easily identifiable.
   - *Element/DMA Filter*: Use this field to apply the test to a specific element.
   - *Display Key Filter*: Use this field if the test should only consider specific entries.
   - *Status Checkbox*: Select this box if you want the text to be enabled as soon as it is created.

   ![Link Subscription to Test](~/user-guide/images/Health_Check_Link_Subscription.png)

## Configuring email reports

The **Health Check solution** can provide daily email reports summarizing the result of the tests that have been executed.

To set up the recipients for the email reports, follow these steps:

1. Access the Configuration Page
   - Navigate to the **Configuration** page of the **Health Check Manager** element and go to the **Email Configuration** section

1. Enable Email State
   - Ensure the **Email State** is enabled to activate email reporting

1. Add Recipient Email Addresses
   - In the **Email Address** field, enter the list of email addresses you want to receive the reports
   - Make sure each email address is **separated by a comma ( , )**

## Configuring test execution

You have the flexibility to schedule when and how frequently tests will run to ensure they align with your operational needs. Follow the steps below to configure the test execution schedule:

1. Access the Test Settings Section
   - Open the **Health Check Manager** element and navigate to the **Configuration** page
   - In this page, locate the **Test Settings** section

1. Open the Edit Window
   - Click the **Edit** button
   - A new window will appear, allowing you to configure the test schedule

1. Configure the Execution Time and Recurrence
   - First specify the exact time you want the tests to run (e.g., 22:00)
   - After you can choose how often the tests should execute (e.g., Daily, Weekly, Every X number of days etc.)
   - Once you've configured the schedule, click **OK**
   - The updated settings will be reflected in the **Test Settings** section

In this section, you'll also find the **Long Duration Time** parameter, which lets you set the time span for including test results in the **Long Duration Overall Failure Rate** calculations. For example, if set to 7 days, only test results from the last 7 days will be considered in the failure rate.

![Test recurrence](~/user-guide/images/Health_Check_Recurrance.png)
