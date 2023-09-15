---
uid: Connector_help_Tektronix_Sentry_Redundancy_Analyzer
---

# Tektronix Sentry Redundancy Analyzer

This connector will read out other Tektronix Sentry and Tektronix Sentry PVQ elements and compare the statistics to see which has the biggest differences.

## About

This connector will compare two or more Tektronix Sentry or Tektronix Sentry PVQ elements and compare the Port Statistics Table, Program Statistics Table, ETR-290 Status Table and ETR-290 Summary Table to calculate their differences.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

Note: If you use a version of this connector **prior to 1.0.0.3**, create **only one element per DMA**!
If there are multiple elements using this connector on the same DMA, there may be conflicting data and elements may overwrite the data of other elements. This is no longer the case from version 1.0.0.3 onwards.

### Configuration of Probe Groups

On the **Probe Groups** page, you can add probe groups via the right-click menu of the table. You can then add probe elements (i.e. Tektronix Sentry or Tektronix Sentry PVQ elements) via the **Add Probe** column.

## Usage

### General

This page displays all the **Refresh** **States** and the **Latest Refresh** **Times** of all the tables.

It also contains a **Refresh All** button, which can be used to refresh all comparisons between the configured elements.

### Tree Probe Groups

This page contains a tree control based on the **Probe Groups Table**. Each node in the tree contains the probes that the group contains. Each node also shows all the statistics tables with alarm bubble-up.

### Probe Elements

This page contains the **Probe Elements Table**, which lists the Tektronix Sentry and Tektronix Sentry PVQ elements in the DMS. With the **Linking** column, you can group probes together to act as a single probe. This can be necessary in case a probe does not have enough capacity to hold all the data. This can then be split over two or more probes. With linking, you can combine the probes, so that the Tektronix Sentry Redundancy Analyzer will consider them to be a single probe.

### Probe Groups

This page contains the **Probe Groups Table**. As mentioned in the Configuration section above, you can create and delete probe groups in this table. You can also select the probe name of the **Linking Name** of the probes that are linked. The **State** column displays how the retrieval and calculation of the other statistics tables went.

### General States

This page contains the **Status Tables**, which display the overall state of the program and the port.

### Program Statistics

This page displays the **Program Statistics Table**, together with the **Latest Refresh Time** and **Refresh State** parameters. There is also a **Refresh** button.

### Port Statistics

This page displays the **Port Statistics Table**, together with the **Latest Refresh Time** and **Refresh State** parameters. There is also a **Refresh** button.

### ETR-290 Status

This page displays the **ETR-290 Status Table** as well the **Latest Refresh Time** and **Refresh State**. There is also a **Refresh** button.

### ETR-290 Summary

This page displays the **ETR-290 Summary Table** as well the **Latest Refresh Time** and **Refresh State**. There is also a **Refresh** button.

### Debug

This page contains the **Debug Logging** toggle button. In addition, for each of the Refresh buttons, there is a **Debug Time** parameter to see how long the refresh takes.
