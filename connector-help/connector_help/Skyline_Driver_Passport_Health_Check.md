---
uid: Connector_help_Skyline_Driver_Passport_Health_Check
---

# Skyline Driver Passport Health Check

The Skyline Driver Passport Health Check will perform an analysis on the DataMiner server processes and create a summary indicating whether there has been a memory leak. This result is used in the Skyline Driver Passport Platform report.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When a new element has been created, several things need to be configured, as detailed below.

#### Configuration page

On the **Configuration** page of the element, specify the **Microsoft DMA ID/Element ID** of the **Microsoft Platform** element that is monitoring the test server.

In addition, in the **Leak Threshold** table, thresholds need to be configured. To add a row to this table, fill in the name of a process in the **New Process Name Leak Thresholds** parameter and click the **Add Row** button. The name does not need to be the full name of the process. For example, *SLProtocol* will suffice to have a threshold for all SLProtocol processes. Wildcards (\*) are not supported, except for a process name consisting of one *\**. In that case, the thresholds of that row will be applied for process names that do not match any of the other threshold rows.

The following threshold items can be set for the categories **CPU**, **VM Size**, **Handles**, and **Threads**:

- **Minimum Level**: Minimum value that the average needs to have before the other thresholds are taken into account. This can for example be used to suppress processes that have a low memory usage of 50 MB and a rate of 10 kB/h.
- **Maximum Level**: When the average value is above this value, it will set the result to *Maximum Level Breached*. This setting is needed for example when the CPU is constantly running at 100%. No level difference will be detected, nor will there be a rate. The detected value is constant over time, because the maximum cap is reached, and no further increase is possible.
- **Level Difference**: Has 3 configurable threshold levels: *Minor*, *Major*, and *Critical*. When the analytics module detects a level shift with a value that breaches one of the thresholds, a matching \<*severity\>* *Level Shift* result will be set. As not all level differences can be detected by the analytics module, there is a backup functionality that calculates the average value of the first 3 hours, compares this with the average value of the last 3 hours, and verifies if there is a level difference. When this is the case, a matching *\<severity\> Level Difference* result will be set.
- **Rate**: Has 3 configurable threshold levels: *Minor*, *Major*, and *Critical*. When the analytics module detects a rate increase that breaches one of the thresholds, a matching *\<severity\> Leak* result will be set.

As there is only one result value per category and different issues can be detected (e.g. *Minor Leak* and *Major Level Difference*), the result value will contain the one with the highest severity.

#### Server Specs page

Specify the **Passmark Rating**, **CPU Mark Rating**, and **Disk Mark Rating** on the **Server Specs** page. These benchmark ratings cannot be retrieved with the Microsoft Platform element and need to be configured once. These values will then be used in the report that the Skyline Driver Passport Platform will generate.

### Analytics configuration

The element reads out the trend arrow icons of the trended parameters that are calculated by the analytics module. The configuration needs to be set to the correct time window, so the analytics module can have a trend icon that reflects the summary of that time window. To configure this, in DataMiner Cube, go to **System Center** \> **System settings** \> **analytics config**, set the **Minimum window duration** to *24h,* and click the *Apply* button.

Note that the specified duration will need to pass before the trend icon reflects the time window. For example, when you change the time window from 5h to 24h, the trend icon will not instantly change, but only after 24h.

## How to Use

As the element only uses a virtual connection, there will be no data traffic visible in the **Stream Viewer**.

Make sure to configure the **Leak Threshold** settings as described in the **Configuration** section above. Setting a threshold too high might result in leaks that are not detected. Setting a threshold too low might result in false positive leaks that are reported.

### General

The **General** page contains the items needed to start a health check. Set a **Scan Trend Start Point** to indicate the beginning time of the trend window. The end time of the trend window is the current time. Based on this trend window, the average and maximum values will be calculated. The analytics module uses the trend window configured in System Center. To make sure you get a correct summary, both trend windows should cover the same time span. Click the **Scan** button to start the analysis. The **Scan Status** will be set to *Scan Completed* when the analysis has finished.

The **Leak Results** table will display the result of the analysis. For every process it will show the **CPU**, **VM Size**, **Handles** and **Threads** result. It will also show the value of the **Level Difference** and **Rate**. These values could also be handy to help fine-tune the threshold configuration.

### Task Manager

The **Task Manager Avg** and **Task Manager Max** pages display the calculated average and maximum values for the processes during the configured time window.

### Other

The other pages contain the remaining parameters as retrieved from the **Microsoft Platform** element at the moment when the scan was executed.

## Notes

As this analysis can only be done based on trend results, these parameters need to be trended in the Microsoft Platform element.
