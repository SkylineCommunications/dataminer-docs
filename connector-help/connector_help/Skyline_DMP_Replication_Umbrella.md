---
uid: Connector_help_Skyline_DMP_Replication_Umbrella
---

# Skyline DMP Replication Umbrella

With the **Skyline DMP Replication Umbrella** connector, you can monitor multiple DMPs (DataMiner Probe) information located on different remote agents and define a set of parameters on each system that you want to follow. All statuses, retrieved values and counters can be monitored and trended.

This element is intended to hold a summary of all important data and info from the different probes. Replicating all the probe elements on a remote agent will create one central point to view all data over multiple probes.

## About

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | -                     |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

#### Virtual Main Connection

This connector uses a **virtual connection** and does not require any input during element creation.

### Initialization

As the element retrieves data from the Microsoft Platform element, make sure the latter is running and has trending enabled on **Total Processor Load** and **Total Commit Charge**.

At startup, the connector collects all the different DMP elements using the Skyline Replication DMP connector. A table with the columns Element Name and State is displayed in the Configuration sub-tab under the General page. By default, the state of each element is set to 'Disabled'.

### General

This page displays general information from the DMPs, such as **Total Amount of Elements, Total Amount of Active Elements**, and multiple alarm counters.

A 'Configuration' page button is also displayed and it may be used to enable/disable which probe the connector should retrieve information from.

A 'Polling Time' button indicates how often the connector should poll DMP information of elements, active alarms, services and views.

### DMP Elements

This page displays a table containing all the elements defined in the system with their **ID**, **Name**, **Overall State, Communication State** and **Element State.**

### DMP Active Alarms

This page displays one table listing all the current active alarms, similar to the list displayed in the Active Alarms tab in the DataMiner Cube Alarm Console. There are 5 dynamic columns available in the table. These are custom properties that can be defined on each probe (Skyline DMP replication protocol).

### DMP Services

This page displays one table containing all the services from the DMP with the **Service Name**, **Overall State** and **Communication State**. There are 5 dynamic columns available in the table. These are custom properties that can be defined on each probe (Skyline DMP replication protocol).

### >DMP Views

This page displays one table containing all the views from the DMP with the **View Name**, **Parent View**, **Overall State** and **Communication State**. There are 5 dynamic columns available in the table. These are custom properties that can be defined on each probe (Skyline DMP replication protocol).
