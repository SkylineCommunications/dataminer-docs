---
uid: Connector_help_DIBP_Active_Bearer_History
---

# DIBP Active Bearer History

**DIBP Active Bearer History** connector is used to store the changes of the **Active Bearer** **parameter** from a **DIBP Active Bearer** element.

## About

This is a virtual connector that captures changes in the **DIBP Active Bearer** element. The **active bearer** will be determined based on a combination of **Cobra/EBEM parameters (GX or WGS)** and **average ping-based latency** measurements towards **onshore devices (DMA, Gateway Router)**. These changes are captured via remote sets that include information on what time the active bearer changed, what the active bearer changed to and if there is an outage. This information is then processed and placed in a log table, which includes information on the **Active Bearer**, **Start Time**, **Stop Time**, **Duration** and **Outage**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page contains the **Active Bearer History** table. This is a custom table that keeps track of the changes of the **Active Bearer** parameter in the **DIBP Active Bearer** element. The parameters on this page are:

- **Automatic Removal**: Allows you to turn on the automatic removal feature that **cleans up the** **Active Bearer History Table** every 15 minutes based on the cleanup configuration settings.

- **Total Rows**: Shows the total number of rows in the **Active Bearer Table.**

- **Active Bearer History Table**: Keeps track of the changes of the **Active Bearer** parameter of the **DIBP Active Bearer** element. The table contains the following columns:

- **Index**: The index of the table, consisting of the **active bearer and the start time** of that bearer.
  - **Bearer**: Displays the active bearer, received from the **DIBP Active Bearer** element
  - **Start Time**: Displays the time the active bearer became active.
  - **Stop Time**: Displays the time the active bearer stopped.
  - **Duration**: Displays how long the active bearer was active.
  - **State**: Displays if there was an outage during the time the active bearer was active.

### Cleanup Configuration

This page contains parameters to configure the **automatic removal feature** that cleans up the **Active Bearer History Table** in the element. The following parameters can be configured.

- **Maximum Number of Rows**: The maximum number of rows allowed in the table.
- **Clean Up Amount**: The number of rows that are to be cleaned up every 15 minutes.
- **Maximum Age of Rows:** Determines how long a row can remain in the table before it is automatically removed.
- **Clean Up Method**: Determines the method used to clean up the table, i.e. either via **Row Count, Row Age** or a **Combination of both**.

## Notes

This connector is intended to be used together with the **DIBP Active Bearer** connector. It gathers information from the DIBP Active Bearer connector every time there is a change to the active bearer in the connector, and allows users to view previous active bearers, the time they started, the time they ended, how long they were active and if there was an outage during their active time.
