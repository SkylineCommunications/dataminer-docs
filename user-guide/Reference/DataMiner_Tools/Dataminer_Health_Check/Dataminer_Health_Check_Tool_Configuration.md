---
uid: DataMiner_Health_Check_Tool_Configuration
---

# Configurating the DataMiner Health Check Tool

To begin receiving results from the DataMiner Health Check Tool, the tool needs to first be configured. Configuration consists of two main categories:

1. Test case configuration
2. General report settings

## Configuring Test Cases

The test cases to be configured consist of two main types: Script Based and Subscription Based tests, each providing a different mechanism for querying data to allow for greater flexibility depending on the kind of data being tested.

### Script Based Tests

Script Based Tests utilize custom automation scripts to execute and retrieve data. These tests can retrieve data from various sources, including DataMiner elements (via SLNet calls), DataMiner Agents (DMS calls), or other external systems the DMS communicates with. Once the data is retrieved, it is evaluated against predefined thresholds to determine if the test passes or fails.

The system offers several default tests related to the state of the Dataminer system, but you can also integrate new ones using automation scripts.

For the Health Check tool to recognize the new tests, the automation scripts must be placed in the Dataminer Automation Scripts module under the following path: **Automation Scripts > Health Check > Health Check Tests**.

![Automation Scripts Path](~/user-guide/images/Health_Check_Automation_Path.png)

#### Test Creation

Create a new test with the following steps:

1. Navigate to the Test Configuration table
   - Open the **Health Check Manager** element and go to the **Test Configuration** page
   - Here, you will see a list of pre-configured tests related to your DataMiner system's health. These include tests for checking the status of DMAs in the cluster, monitoring active timeouts, and more

2. Access the Add Test option
   - To create a new test, right-click on the **Test Configuration Table** to open the context menu and select **Add Test** from the menu

![Add Test Option](~/user-guide/images/Health_Check_Add_Test.png)

3. Configure the Test
   In the new test window, fill out the required fields:

   - **Test Type**: Select *Script* from the dropdown menu
   - **Name**: Select an available script-based test
   - **Operator and Threshold**: Define the conditions for the test to determine whether it passes or fails
   - **Display Title**: Optionally, enter a custom name for the test to make it easily identifiable. If provided, this title will be used to identify the test in the email report; otherwise, the default test name will be displayed
   - **Element/DMA Filter**: Use this field to apply the test to a specific element. Enter the Element/DMA you wish to target
   - **Display Key Filter**: Apply this filter if you want the test to consider only certain entries for the test
   - **Status Checkbox**: Check this box if you wish to enable the test upon creation

![Test Configuration](~/user-guide/images/Health_Check_Configure_Test.png)

#### Test Editing

To edit an existing test, follow the steps below:

1. Navigate to the Test Configuration table
   - Open the **Health Check Manager** element and go to the **Test Configuration page**
   - Here, you will see a list of the tests that are currently available

2. Access the Edit Test option
   - Right-click on the test you would like to edit to open the context menu
   - From the menu, choose **Edit Test**

![Test Edit](~/user-guide/images/Health_Check_Edit_Test.png)

3. Modify the Test Configuration
   - A window will appear displaying the current configuration of the selected test
   - You can modify any of the available fields as needed
   - Once you've made the necessary modifications, click **OK** to apply the changes
   - The updated test configuration will now be reflected in the **Test Configuration Table**

> [!NOTE]
> These fields are the same to those configured when creating the test. Refer to the test creation section for detailed information on each field.

### Parameter Subscription Based Tests

Subscription based tests allow you to select a specific standalone parameter or table column from any connector in the Dataminer System and subscribe to it. Once subscribed, you can link it to a test that retrieves the parameter's value and evaluates it against defined thresholds. This process helps assess the data's current state and detect any deviations from expected conditions.

#### Subscription Creation

To create a new subscription, follow these steps:

1. Access the Parameter Subscription Table
   - Navigate to the **Parameter Subscription Table** available on the **Test Configuration page** of the **Health Check Manager**

2. Add a New Subscription
   - Right-click on the **Parameter Subscription Table** to open the context menu
   - Select the option **Add Subscription**

![Add Subscription](~/user-guide/images/Health_Check_Add_Subscription.png)

3. Configure the Subscription
   A window will appear where you can set up the subscription. Fill in the following fields:

   - **Protocol**: Choose the protocol associated with the parameter you wish to subscribe to. Only protocols with active elements will be displayed in the dropdown menu
   - **Protocol Version**: Select the version of the chosen protocol
   - **Parameter Type**: Indicate whether you want to subscribe to a Standalone Parameter or a Table Parameter
     - If you select Standalone Parameter, in the **Parameter** field, select the name of the parameter you want to subscribe to from the dropdown menu
     - If you select Table Parameter, you will need to specify the table name and the column name in the respective **Table** and **Parameter** fields

![Add Subscription](~/user-guide/images/Health_Check_Configure_Subscription.png)

##### Subscription Editing

To modify an existing subscription, follow these steps:

1. Navigate to the Parameter Subscriptions Table
   - Open the **Health Check Manager** element and go to the **Test Configuration** page
   - In this section, locate the **Parameter Subscriptions Table**, which lists all current subscriptions

2. Access the Edit Subscription Option
   - Right-click on the subscription you want to edit to open the context menu
   - From the menu, select **Edit Subscription**

   ![Edit Subscription](~/user-guide/images/Health_Check_Edit_Subscription.png)

3. Modify the Subscription Configuration
   - A window will appear with the current configuration of the selected subscription
   - Make any necessary adjustments to the fields
   - Once the changes are complete, click **OK** to save them
   - The updated subscription will now be reflected in the **Parameter Subscriptions Table**

> [!NOTE]
> The fields available for editing are the same as those used when creating the subscription. Refer to the subscription creation section for more details on each field.

##### Linking a subscription to a test

After a Subscription is created it is necessary to link it to a test. Follow these steps:

1. Access the Test Configuration Table
   - Go to the **Test Configuration Table** in the Health check Manager element
   - Right-click on the table, and from the context menu, select **Add Test**

2. Configure the Test
   A new window will open where you need to fill in the following fields in order to configure the test:

   - **Test Type:** Set this field to **Subscription**
   - **Name:** From the dropdown, select the name of the subscription you created earlier
   - **Operator and Threshold:** Define the conditions to determine whether the test passes or fails
   - **Display Title:** Optionally, enter a custom name for the test to make it easily identifiable
   - **Element/DMA Filter:** Use this field to apply the test to a specific element
   - **Display Key Filter:** Use this field if the test should only consider specific entries
   - **Status Checkbox:** Check this box to enable the test upon creation

![Link Subscription to Test](~/user-guide/images/Health_Check_Link_Subscription.png)

### General Solution Settings

#### Email Report Configuration

The **Health Check solution** can provide daily email reports summarizing the result of the tests that have been executed.

To set up the recipients for the email reports, follow these steps:

1. Access the Configuration Page
   - Navigate to the **Configuration** page of the **Health Check Manager** element and go to the **Email Configuration** section

2. Enable Email State
   - Ensure the **Email State** is enabled to activate email reporting

3. Add Recipient Email Addresses
   - In the **Email Address** field, enter the list of email addresses you want to receive the reports
   - Make sure each email address is **separated by a comma ( , )**

#### Test Execution Configuration

You have the flexibility to schedule when and how frequently tests will run to ensure they align with your operational needs. Follow the steps below to configure the test execution schedule:

1. Access the Test Settings Section
   - Open the **Health Check Manager** element and navigate to the **Configuration** page
   - In this page, locate the **Test Settings** section

2. Open the Edit Window
   - Click the **Edit** button
   - A new window will appear, allowing you to configure the test schedule

3. Configure the Execution Time and Recurrence
   - First specify the exact time you want the tests to run (e.g., 22:00)
   - After you can choose how often the tests should execute (e.g., Daily, Weekly, Every X number of days etc.)
   - Once you've configured the schedule, click **OK**
   - The updated settings will be reflected in the **Test Settings** section

In this section, you'll also find the **Long Duration Time** parameter, which lets you set the time span for including test results in the **Long Duration Overall Failure Rate** calculations. For example, if set to 7 days, only test results from the last 7 days will be considered in the failure rate.

![Test Recurrance](~/user-guide/images/Health_Check_Recurrance.png)