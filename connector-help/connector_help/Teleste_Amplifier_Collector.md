---
uid: Connector_help_Teleste_Amplifier_Collector
---

# Teleste Amplifier Collector

With this connector, you can poll a set of Teleste amplifiers (that all support the same MIBs) and collect all the data in one connector.

## About

The connector can be provisioned via the import of CSV files with IP addresses and names. The connector then makes sure that all single SNMP parameters and SNMP tables of every amplifier are polled once every 15 minutes, by using multiple threads.

### Version Info

| **Range**     | **Description**                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                  | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Updated spectrum analyzer tables | No                  | Yes                     |

### Product Info

The connector was tested with three different types of Teleste amplifiers, listed in the table below, and can also be used with other types of Teleste amplifiers that support the same MIBs.

| **Range** | **Device Firmware Version**                                                                               |
|------------------|-----------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Teleste AC3010 Teleste AC3210 Teleste ACE3 (Other types of Teleste amplifiers that support the same MIBs) |
| 1.0.1.x          | Teleste AC3010 Teleste AC3210 Teleste ACE3 (Other types of Teleste amplifiers that support the same MIBs) |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: DataMiner requires that this field is filled in. However, it does not matter which IP address you specify. The IP addresses that will be polled are the addresses imported via the CSV files, not the one specified in this field.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Configuration of the amplifiers to poll

You need to configure the set of amplifiers to make the connector work. This can be done via the **Configure Provisioning** page. Please refer to the section "Configure Provisioning" below for further details.

### Offload configuration

The following parameters can be set via **multiple set** in order to configure the offload mechanism to all related elements:

- **Offload State**: Enables or disables the offload mechanism. Default value: *Disabled.*

- **Cleanup State**: Enables or disables the file cleanup mechanism.
  - If enabled, all files in the **Offload Directory** that are older than the age defined in the **File Age Threshold** parameter will be deleted.
  - This parameter is automatically enabled when the **Offload State** is also enabled.
  - Default value: *Disabled.*

- **Offload Directory**: The root directory where the offload files will be stored.

- The directory can be a shared folder, where the credentials can be set using the **Offload** **Shared Folder Username** and **Offload Shared Folder Password** parameters.
  - A folder will be created per OLT with its name - the **OLT Name.**
  - Default value: *\\80.62.121.234\c\$\Skyline_Data\AMP Offload\\*

- **File Age Threshold:** Determines for how long files are stored in the Offload Directory before they are deleted to free up space.

- Range between *8 hours* and *1 year*, with 8-hour increments.
  - Default value: *2 weeks*

- **Force Offload / Offload To Disk:** Set this button to manually execute the offload of the files, regardless of the **Offload State** value.

- **Debug Log Times:** Enables or disables extra logging related to the offload.

- If enabled, upon a successful offload, the time and number of rows will be written in the element's log file.

- **Config String \[table name\]**: All the column parameters that should be offloaded for the table with the specified name.

- Multiple columns are allowed, using a comma (",") as separator.
  - The primary key will always be offloaded as the first column.
  - Information template column names are not allowed.

## Usage

### Main Poll Table Page

This page contains a parameter indicating the **Number of Polled Amplifiers**, as well as several tables.

#### Main Table

The **Main Table** is the table on which the polling via the multithreaded timer is based. It consists of several groups of columns:

- **Amplifier Name and IP Address (2):** These are the 2 columns that were provisioned via the CSV files. For more information, refer to the section "Configure Provisioning" below.

- **Communication Statistics (5):** These 5 columns contain information regarding the timing and status of the polling of the relevant amplifier, with the parameters **Last Polled on**, **Communication Status**, **Last Updated On, Last TimeOut Cleared Since** and **Last TimeOut Reason.**

- **Single SNMP Params (30):** These 30 columns contain the values retrieved by polling 30 single SNMP parameters. If a cell stays empty, this means that the amplifier in question does not have that SNMP parameter.

- **SNMP Table Instances (12):** These 12 columns contain the instances of the rows that are in the corresponding table and belong to the relevant amplifier. For more information, refer to the section "SNMP Table Pages" below.

- **Imported from CSV/DB Params** **(13):** These 13 columns contain additional information that was imported from the CSV file, in addition to the IP address and unique Amplifier Name that are in the first columns of this table.

This table also contains the following columns:

- **TV Service Unavailable Time**
- **TV Service \#Subscribers**
- **TV Service Availability**
- **NQI**
- **Modem Input Level**
- **Spectrum Analyzer Status \[72\]**
- **Spectrum Analyzer Status \[76\]**

#### Spectrum Analyzer Table

The page also contains the **Spectrum Analyzer Table**. For each amplifier, this table lists all the spectrum frequencies and the associated levels.

In the table, for each Amplifier/Frequency pair, you can set the **Expected Value** and a **Margin**, which are used to compute the **TV Service Unavailable Time** and the **TV Service Availability** in the **Main Table**.

Via the **Import Expected Values** page button, you can import a CSV file containing the **Expected Value** and the **Margin** per Amplifier/Frequency pair:

- The CSV file needs to adhere to the following naming convention: *\<DMA_ID\>\_\<Element_ID\>\_ExpectedValues.csv* (eg. *192_9322_ExpectedValues.csv*).
- The rows of the file must have the following format: *\<Name\>,\<Frequency\>(MHz),\<Expected Value\>(dB),\<Margin\>(dB)* (e.g. "*id=70307,450,11,2"*).

#### Reductions Table

The **Reductions Table** is used to define thresholds used for the reduction computation. To add a new parameter to monitor, select a value in the **New Threshold on Parameter** drop-down list and click the **Add Row** button. The parameter will be added to the table only if no previous entry for this parameter is present in the table. You can remove the thresholds line by line by pressing the **Delete** buttons.

#### Excluded Incident Windows table

In the **Excluded Incident Windows** table, you can define time windows during which the computed reduction is not taken into account in the **NQI** computation for a particular amplifier.

You can add a window with the **Add Row** button or remove windows row by row by pressing the **Delete** button.

It is also possible to remove all the old windows at the same time by pressing the **Remove Old Rows** button.

#### Amplifier Reductions table

The **Amplified Reductions** table makes use of the information specified in the previous two tables:

- The thresholds from the **Reductions Table** are used to compute the total **Reduction** and the **NQI** per amplifier within the current month.
- The reduction computed during the time windows in the **Excluded Incident Windows** table is added to the **Excluded Reduction** column.

### SNMP Table Pages

The connector can poll 12 different SNMP tables. For every amplifier, the SNMP table can contain multiple rows. As a real collector connector, this connector collects all rows of a certain SNMP table in one table, regardless of which amplifier it refers to.

Before the columns of the SNMP table itself, you will find four columns that are always the same:

- **Index \[IDX\]:** This is the index of the row. It is a concatenation of the amplifier name and raw row instance.
- **Amplifier Name:** The name of the amplifier this row refers to.
- **Row Instance:** The raw row instance of the row.
- **Validity:** Whether or not the data is "Valid". If the amplifier goes into timeout, the rows corresponding with that amplifier are considered "Old". With this mechanism, a manager connector using this information can know that this data is no longer 100 percent reliable.

The 12 different SNMP tables, which all have a separate page, are:

- **Ingress Switch Table**
- **Level Control Table**
- **Level Detector Table**
- **ALSC Target Level Table**
- **ALSC Level Control Table**
- **Voltages Table**
- **Interfaces Table**
- **DocsIf Downstream Channel Table**
- **DocsIf Upstream Channel Table**
- **DocsIf Signal Quality Table**
- **DocsIf CM Status Table**
- **DocsIf CM Service Table**

From version **1.0.0.26 onwards**, each table has an additional parameter that toggles the **auto clear** functionality. This functionality will **clear** the **old entries** instead of still showing them in the corresponding tables. By default, the button is set to *disabled*.

### Configure Polling Page

In the **Polling Configuration Table**, you can specify which SNMP tables should be polled. However, note that the more SNMP tables are polled, the more time it will take to poll one amplifier.

From version **1.0.0.22 onwards**, it is possible to **force poll** an amplifier collector. Note that this will only poll the SNMP parameters, but will not have an influence on the KQIs. Only 1 amplifier can be force polled at a time, but it is possible to add more amplifiers to a queue waiting to be force polled. The max size of the queue can be configured with the **Max Force Poll Queue Size** parameter (default: *10*).

### Configure Provisioning via CSV Page

This page contains all the parameters needed to configure the provisioning via CSV of amplifiers for the polling of the collector.

- The left side of the page displays the **Import via CSV section**.

> In this section, the **Directory Path Name** should contain the directory where the CSV file(s) you want to import are located. For example, if your files are in the Downloads folder of your local C:\\ drive, specify *C:\Downloads*. If the directory containing the files is accessed remotely (e.g. if you specify '*\\80.62.121.234'*), you also need to specify a **Network Share User Name** (can contain a domain name, but not always needed) and a **Network Share Password**.
>
> With this provisioning tool, the connector can immediately synchronize with the amplifier configuration that the Huawei iManager U2000 dumped in the specified directory. The **Expected File Name** and **Expected File Format** indicate the kind of files the connector expects. This way, the connector is adapted to the way the Huawei iManager U2000 dumps the information that this connector needs. It can synchronize the configuration daily, if you enable this via the toggle button **Automatic Refresh of the Amplifier CSV Provisioning**. You can also force a refresh by clicking the button **Force Refresh** or by setting this parameter (with ID 3101) via an Automation script.
>
> All imported data will be used to populate the **Main Poll Table**: The first two columns will be imported in the first two columns of the Main Table (**Amplifier Name** and **IP Address**) and are the most important for polling. The other 11 columns contain additional information (such as the hardware or software version of the amplifier), which is added to the table after the Table Instances. The IP addresses are the addresses that DataMiner will use to communicate with the amplifiers.

- The right side of the page displays the **Import Response section**. In this section, the **CSV Import State** parameter indicates whether the import succeeded. In addition, the **CSV Response Message** provides more details on how the imported files were found and parsed.

Note:

- **Not all files** that pass the **Expected File Name** check will be **imported**. In the files that pass the first check and are considered valid, the algorithm searches for the **most recent timestamp**. It will then only import the files that contain this most recent timestamp and ignore the other, older files. This way, when the Huawei iManager U2000 dumps a new CSV file with a more recent timestamp, that file will be prioritized and updates of the IP addresses will be detected correctly. You can see which files have been imported and what their timestamp was in the CSV Response Message.
- The **Amplifier Name** is the **unique key** used. The connector will therefore not allow the import of two amplifiers with the same Amplifier Name. Note that when the iManager U2000 element detects that an amplifier has changed IP addresses, it can dump a new CSV file in the directory with the same Amplifier Name and another IP address. The connector will then detect this and adjust the IP address. As a consequence, this collector connector will dynamically adapt to the new IP address.
- The validity of every row of the CSV file is checked before it is processed, e.g. a check if the IP address is a valid IPv4 address.
- Each primary key will be unique, but the IP address does not have to be unique. Two amplifiers with another primary key can have the same IP address at the same time.

### Configure Provisioning via DB Page (from version 1.0.0.2 onwards)

This page contains all the parameters to configure the provisioning via DB of amplifiers for the polling of the collector.

In the upper left corner of the page, the **Collector Device ID** is displayed, which is needed to search for the corresponding amplifiers in the IAM database. The connector gets this value on startup from a custom property of the element, called "DEVICE_ID".

On this page, you need to configure the credentials to connect with the SQL database.

- **Database Name:** The name of the database, by default SNMPc.
- **Server IP:** The IP address of the database.
- **User Name:** The user name to connect to the database.
- **Password:** The password that is required to log in.

Afterwards, you can click **Force Refresh** to update the provisioning to the current status of the IAM database. On the right side, the status of the import is displayed with the **DB Import State** and **DB Response Message.**

From version **1.0.0.18 onwards**, **fast provisioning** is supported. Fast provisioning will only provision the changes since the last time it was executed. You can configure the interval at which fast provisioning should be executed by setting the **Fast Provisioning Interval**. It is also possible to configure the **daily provisioning** by setting the exact time at which it should be executed in the **Daily Provisioning Time** parameter.

Note: The **fast provisioning changes** **require an update of the GetAmpCollectorDataV01** stored procedure.

### Thread Pool Info Page

This page contains statistics regarding the multithreaded timer, which this connector uses to poll the amplifiers as efficiently as possible.

- **Thread Pool Usage:** Indicates how many threads are in use.
- **Thread Pool Waiting:** Indicates how many threads are waiting because all the threads of the thread pool are in use.
- **Thread Pool Max Duration:** Indicates how many milliseconds the slowest thread took.
- **Thread Pool Avg Duration:** Indicates how many milliseconds a thread took on average.
- **Thread Pool Executed:** Indicates how many threads where executed during the 5-second interval.
- **Thread Pool Dynamic Size:** Indicates how many items can be placed in a waiting state. When the waiting thread pool has reached the stack size, a notice alarm will be generated.

## Notes

Version 1.0.0.1 of the connector does not support any SNMP traps.

Version 1.0.0.2 of the connector does support SNMP traps.
