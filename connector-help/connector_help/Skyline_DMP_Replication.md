---
uid: Connector_help_Skyline_DMP_Replication
---

# Skyline DMP Replication

With the **Skyline DMP Replication** connector, you can monitor the DMP (DataMiner Probe) information and define a set of parameters on the system that you want to follow (using subscriptions). All statuses, retrieved values and counters can be monitored and trended.

This element is intended to hold a summary of all important data and info from a probe. Replicating all the probe elements on a remote agent will create one central point to view all data over multiple probes.

## About

The Skyline DMP Replication connector will periodically poll the DMP information and alarms. Other values are retrieved using subscriptions. This means that these updates come in very quickly.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x | Initial version | No | No |
| 1.0.1.x | - Updated protocol to Unicode.<br>- Added Views & Services Table with 5 dynamic columns per table (Elements, Alarms, Services & Views). A filter functionality is also available.<br>- Added Message Overview Table. This table will be used to transfer sets between HQ & DMP.<br>- Correlation and Automation will handle the sets on the HQ via an alarm trigger on the message table on the replicated element. | No | No |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

### Installation

For the installation of this connector, just create an element using this protocol. As the element retrieves data from the Microsoft Platform element, make sure the latter is running and has trending enabled on **Total Processor Load** and **Total Commit Charge**.

## Usage

### General

This page displays general information from the DMP, such as **Workstation Name**, **DM Software Version**, and multiple alarm counters.

The **Total Processor Load** and **Total Commit Charge (Last Hour Average)** are values that are retrieved from the last available hour of trending of the **Microsoft Platform element**.

There are also two buttons available to **Reboot DMP** and to **Restart DataMiner Software** **(SLNet included)**. A pop-up message will ask for confirmation when you use these buttons.

### DMP Elements

This page displays a table containing all the elements with their **ID**, **Name** and **Overall State**.

The probe is subscribed to all element states, so the moment an alarm state changes, it will get updated. There are 5 dynamic columns available in the table. These can be updated with generic or custom properties. This can be configured on the **Configurations** page, where you can also find a filter option to only display a subset of this table.

The table is updated every hour and the states are directly updated based on incoming subscription updates. At the bottom of the page, there is also a button to force a **manual Refresh**.

Finally, the page allows you to modify the element state of the remote elements, i.e. Start, Stop, Pause and Restart.

### DMP Parameters

This page displays a table containing all the custom parameters that you want in the summary. The table context menu allows you to perform several actions:

- **Add Parameter Subscription**: A pop-up window will ask for additional parameter values such as **Element Name**, **Parameter ID**, **Parameter Index**. The table will list these configured values along with the **Parameter Name** and the **Parameter Value**.
- **Remove Selected Parameter(s)**: All the selected parameters will be removed along with their subscriptions.
- **Clear Table***:* This option will remove all the subscriptions and clear the table. The probe is subscribed to the states, so the moment an alarm state changes, it will get updated. Elements that are stopped cannot be subscribed to, so every hour the list will be updated, and when elements are activated, they will also be subscribed to.

When parameters are added in this table, the DMP replication element will add subscriptions to these parameters. Updates will be pushed very fast.

### DMP Active Alarms

This page displays one table listing all the current active alarms, similar to the list displayed in the Active Alarms tab in the DataMiner Cube Alarm Console. There are 5 dynamic columns available in the table. These can be updated with custom properties. This can be configured on the **Configurations** page, where you can also find a filter option to only display a subset of this table.

The table is updated every minute, as well as whenever element state updates are received based on subscription updates. At the bottom of the page, there is also a button to force a **manual Refresh**.

### DMP Services

This page displays one table containing all the services from the DMP with the **Service Name** and **Overall State**. There are 5 dynamic columns available in the table. These can be updated with custom properties. This can be configured on the **Configurations** page, where you can also find a filter option to only display a subset of this table.

The table is updated every hour and the states are directly updated based on incoming subscription updates. At the bottom of the page, there is also a button to force a **manual Refresh**.

### DMP Views

This page displays one table containing all the views from the DMP with the **View Name**, **Parent View** and **Overall State**. There are 5 dynamic columns available in the table. These can be updated with custom properties. This can be configured on the **Configurations** page, where you can also find a filter option to only display a subset of this table.

The table is updated every hour and the states are directly updated based on incoming subscription updates. At the bottom of the page, there is also a button to force a **manual Refresh**.

The page also displays some counter parameters that display the number of views per severity in the displayed filtered View Table. There is also a Count parameter **Count Views With Configured Property Match**, which counts the number of views in the DMS that have a property matching the filter defined in the parameter **View Property Count Match Filter** (More information is available in the parameter information tag).

### Configurations

This page contains all the settings to update the configuration of the dynamic columns in all supported tables.

A drop-down list with the different options is available for each column. When you select the custom property option "*Property\[edit\]"*, you need to replace the value between brackets with the correct custom property name (case insensitive).

On the right-hand side of the page, in the **Table Filters** section, you can add filters for each table type. The parameter **Filter Information** contains the general information on how to create filters. When the filter is empty, the full table will be displayed.

The **Update & Refresh** button at the bottom of the page can be used to update all the column changes and to force a reload of all the tables with the new filters and columns.

Note: The first three dynamic columns of each type (Elements, Services, Alarms, Views) are of type numerical and can only be used to push **numerical** values. The remaining two dynamic columns are of type **string**.

### Message Overview

This page contains two tables that log and transfer all messages between the DMP and the replicated element at the HQ. These are intended to make it possible to perform sets over multiple DMS systems or to perform a set from a DMP towards an HQ DMS. When messages are finished, they are automatically transferred to the **Finished Table**.

The format of the new command needs to be as follows: "**setParameter**\$delimiter1\$**\<DestinationElementName Or Element DMA/EId\>**\$delimiter2\$**\<ParameterID\>**\$delimiter2\$**\<ParameterIndex\>**\$delimiter2\$***\<Value\>**".

If it is a single parameter set, the index part ("\$delimiter2\$**\<ParameterIndex\>**") can be removed.

When a command is set on either "**Command DMP to HQ**" or "**Command HQ to DMP**", the command will appear in the table.

If it is a set on the replicated element (Command HQ to DMP), the element will process the message and do the actual set described in the message.

In case of a "DMP to HQ" command, the message will appear in the table, and DataMiner replication will push this data to the replicated HQ element. In the HQ DMS, a Correlation rule will be triggered by an alarm on the **Message Time Stamp**. An Automation script will be triggered in order to process the command.

There is a cleaning mechanism to keep the table from becoming too big (**Time to Live for Finished Messages**, which can be set to *1 to 30 days*). There are also two parameters that display the current count of pending messages and executing messages. (Alarm monitoring and trending are enabled on these parameters).
