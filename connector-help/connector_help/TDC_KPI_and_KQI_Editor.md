---
uid: Connector_help_TDC_KPI_and_KQI_Editor
---

# TDC KPI and KQI Editor

The **TDC KPI and KQI Editor** is a virtual connector intended to provide an updated value of the **trending** of parameters from elements in the cluster. Those parameters can be a single parameter or indexes from a table column (all the indexes as one, all the indexes individually or just one of the indexes).

Ultimately the goal is to have an updated value of the **average, minimum or maximum** of the trending during a pre-defined period. The calculation can be made **daily, weekly or monthly** and it can be based on **real-time or average** (5-min or 1-hour) trending values. Note that when it is based on real-time trending values, the calculation can only be done daily. You can also set the calculation to be done continually or only over a fixed period of time.

## About

This connector is a virtual connector. Other than the configuration on the **General** page (see "General" section below), it does not require any additional settings.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.X          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays the **KPI & KQI** table, where the parameters to be measured are added.

It also includes the following page buttons:

- **Network Machine Credentials**: Allows you to set the remote credentials to copy files from the **Merged Files Destination Folder** to the **Remote Files Destination Folder**. To get access to the **CSV Files Folder**, **Generated Files Destination Folder** and the **Merged Files Destination Folder**, set the Network Machine Credentials.

- **Settings:**

  - **Reports Management:** A table with a list of KPI and KQI editors inside the cluster, as well as the last time CSV/XLSX files were generated.

  - **Import/Export**: Can be used to import/export a file to/from the KPI & KQI table. First define the folder where the export file should be located. There can be only be one file in this folder with a name starting with '*Export...*'.

  - **Topology Report**: Define the folder from where the topology files are read and where they are stored. You can also configure over how many files the results should be divided, by specifying the number of rows for each file. The **Remote Files Destination Folder** will be a remote folder that mirrors the **Merged Files Destination Folder**.

  - **Saturated Interfaces Report**: Allows you to configure reporting.

  - **Debug/Set:**

    - **Generate Log File**: Enables the creation of .txt files with information about the processing results.
    - **Log Store Time**: If log files were generated, the ones older than the Log Store Time will be zipped and deleted or simply deleted, depending on the **Action Log Files** setting.
    - **Action Log Files**: Allows you to choose beween zipping or just deleting the log files older than the Log Store Time. This is done automatically after the **Next Get Value** occurs. Click the **Execute Now** button to have the verification done immediately at the moment the button is clicked, and then automatically afterwards.
    - **Set Prev Period:** Allows you to set the previous **Next Get Value** in order to trigger previous period calculation.
    - **Average Trend Interval**: Set this value and then click the **Apply All** button in order to set the **Average Trend Interval Type** column for all the rows.

- **Add**: Used to add new entries to the table. If a table is used, a **Filter** can be applied to the retrieved keys.

- **Delete:** Used to delete several rows or all rows of the **KPI & KQI** table. Rows related to the same index in the **KPI & KQI Results** table will also be deleted.

In order to make the calculations, you should add a new row to the table using the **Add** page button. Then fill in the details of the parameter and the details about when the trending values will be read. By default, several of the parameters used to create the new entry will already have default values filled in, but you will always have to change at least the **DMA ID\Element ID\Parameter ID**. If **Use Default KPI\KQI Name** is set to *Yes*, the **KPI\KQI Name** will automatically be filled in with the description of the selected parameter.

After the necessary information has been provided, it will be validated. Validation can fail in the following cases:

- The **DMA ID\Element ID\Parameter ID** is invalid (parameter ID is not correct, parameter is not being trended or parameter is a table column).
- The parameter ID refers to a table, but you have not entered the **Column ID** and selected the **Table Indexes.**
- The **Recurrence Range Period** is set to *Yes,* but the **Recurrence Start** **and** **End Dates** are not filled in or the selected dates do not allow the calculation of the **Next Get Value** (time when the query to the database is done).
- The **Trending Type** is *Real Time*, but for that parameter only average trending is activated, or vice versa. Check the logging for more information.

> [!NOTE]
>
> - If you selected *All* for the **Table Indexes**, and **Process Indexes** is set to *All as One*, only one row is added to the **KPI & KQI Results** table. If *Individually* was selected, one row per index is added.
>
>   If you selected one of the indexes for **Table Indexes**, **Process Indexes** is automatically set to *Individually* and only one row is added in the **KPI & KQI Results** table.
>
> - By default, if **Trending Type** is *Real Time,* the **Average Trend Interval Type** will be set to *Auto*. If *Average* is selected, two options are available: *5min* or *1h*.
> - **Range Low** and **Range High** should be defined in order to set the range of valid values that are included in the calculation. This is intended to avoid exception values that are outside the normal range of the parameter.

If the validation does not fail, rows will be added to the tables. In case the **Recurrence Range Period** is set to *No,* the **Recurrence Start Date** and the **Recurrence End Date** will be set with default values, which are the first and last day of the month.

> [!NOTE]
> There is a difference between the hours on the **Next Get Value** and on the **Daily Recurrence Time** when the selected **Trending Type** is *Average*. This is necessary in order to get the trend record taken at the time of the **Daily Recurrence Time**. For the *Real Time* **Trending Type**, trending records must be taken at the exact time, because *Real Time* trending values only last for a day.

Changing settings on the row will set the **Status** to *Not Active,* except if that setting is the **KPI\KQI Name** or if the setting does not relate to the current setup, i.e.:

- If the **Recurrence Frequency** is set to *Monthly,* the **Weekly Recurrence Day** can be changed. If it is set to *Weekly,* the **Monthly Recurrence Day** can be changed.
- If the **Recurrence Range Period** is set to *No,* the **Recurrence Start and End Date** can be changed.

Every time you change the **Status** to *Active*, a new **Next Get Value** date to retrieve the trending values is calculated. If the **Status** does not become *Active,* this is because one of the settings is not correct. If you set the **Status** to *Not Active,* no future calculation takes place.
