---
uid: Connector_help_Hirschmann_Multimedia_Rover_TAB7_Manager
---

# Hirschmann Multimedia Rover TAB7 Manager

This manager connector is intended for the retrieval of service information from Astro Devices in a DataMiner system, in order to use this information to populate Round Robin Tables in **Hirschmann Multimedia Rover TAB7** elements controlling **TAB7 probes**.

## About

This is a virtual connector. All operations are done via inter-elements calls.

NOTE: This manager connector is only compatible with versions *1.0.0.5* and higher of the **Hirschmann Multimedia Rover TAB7** protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Source

This page displays all the Astro devices detected on the DMA, with the associated information: **Device Source**, **View/Region**, **Administration Status**, etc.

When a source is missing, it can be removed from the **Source Table**. To see the Astro-associated services in the **Central Service Overview Table**, fill in the **View/Region**.

If a source is no longer present in the system, you can remove it by clicking the **Remove** button on the corresponding line.

You can also export the table in CSV format, edit the region names and import the file again by specifying the **CSV Path** and clicking the **Import From CSV** button.

### Probes

On this page, the **Destination Probes** table contains details about the **Rover TAB7** probes available on the DMA. This includes the **Probe Destination**, **View/Region**, **Status** (Monitor, Round Robin, etc.), **Probe Subscription**, etc.

If a probe is no longer present in the system, you can remove it by clicking the **Remove** button on the corresponding line. To see the Rover-associated services in the **Central Service Overview Table**, fill in the **View/Region**.

In the **RR Plan** column, you can choose a *Round Robin* plan to apply to the probe (taken from the following directory: *C:\Skyline DataMiner\Documents\Hirschmann Multimedia Rover TAB7 Manager*) and then click the **Upload** **RR Plan** button to confirm the action. You can also **Start/Stop** a Round Robin scan with the **Start RR** and **Stop RR** buttons.

### Central Service Overview

This page shows the **Central Service Overview Table**, which contains the results of the comparison of the Astro and Rover TAB7 configurations. The following information is provided: **Service Name**, **Astro Frequency**, **Probe A/B Frequency**, **Status** (the result of the comparison) and **Details** (a detailed explanation of the fault status, if any).

The table is only populated with the services associated to the Rover probes and Astros for which the **View/Region** has manually be set. Refer to the "Source" and "Probes" sections above for more details.

The **Refresh Hour** parameter allows you to define the exact time each day when the comparison procedure must be done. You can also enforce the procedure on demand by clicking the **CSO Refresh** button. The last refresh time is displayed by the **Last CSO Refresh** parameter.

### Round Robin Plan

On this page, you can:

- Create a Round Robin plan from the current Astro configuration in a region, by selecting the **Region** and then clicking the **Create RR Plan** button, or
- Load the plan from a file, by selecting the **Region**, setting a file name with the **RR Plan** parameter and clicking the **Load in RR Plan Table** button.

The **Round Robin Table** is then filled in. You can edit the fields and save the changes in a new file by clicking the **Save RR Plan** button.

When you click the **Apply RR Plan** button, the content of the file selected with the **RR Plan** parameter is applied to all the probes found in the region displayed by the **Region** parameter. As such, if you want the manual changes you made in the **Round Robin Table** to be applied to the probes, click **Save RR Plan** and then click **Apply RR Plan**.

If you have manually added a file with a Round Robin plan in the directory *C:\Skyline DataMiner\Documents\Hirschmann Multimedia Rover TAB7 Manager*, you can use the **Refresh List** parameter after you have selected the corresponding **Region**. However, keep in mind that the name of the files must follow a specific syntax, as otherwise they are ignored: *RRPlan_Region_timestamp.csv* (e.g. *RRPlan_Amsterdam_11082016100633.csv*).

The **Round Robin Table** provides the following information for each channel: **Service Name**, **Channel Mode**, **Type**, **Frequency**, **RF Matrix**, **Audio Frequency**, **Master Channel**, **Channel** and **QAM Symbol Rate.**

### Service Profile Templates

This page contains the **Service Profile Table**, where you can define multiple Round Robin thresholds.

To do so, first click the **Add Service Profile** button to add a line. The following thresholds can then be manually adjusted: **PAL - RR Min Level**, **PAL - RR Max Level**, **PAL - Min C/N**, **PAL - Min/Max Vision/Snd1**, **PAL - Min/Max Vision/Snd2** and **FM - Min/Max Level**. Finally, in the **Apply to Region** column, select a region from the list (*All, Amsterdam, Brabant*, etc.) or type your own value. You can then apply these thresholds by clicking the **Apply** button on the same line.

You can remove a row by clicking the **Remove** button or clear the complete table with the **Clear All** button.
