---
uid: Connector_help_Generic_Comparison_Tool
---

# Generic Comparison Tool

This tool allows you to easily check and monitor if some parameters have the same data across multiple elements. It can be used to identify a misconfiguration or issue on a device that is used for redundancy, where you typically want the device to be configured exactly the same way.

The tool will try to find a reference value for a selected parameter by finding the value that is present on more than half of the elements. Any value that differs from the reference value will be listed in the tool.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                                                                                                          | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Compare parameters across multiple elements running the same protocol. - Create multiple configurations with different parameters and/or elements. - Tree view to easily navigate all configurations. - Exact match comparison. - Comparison with percentage-based tolerance. - Filter rows to be compared using primary key and wildcards. - Element state indicator. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                           | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation script: Generic Comparison Tool Configuration Wizard | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Redundancy

There is no redundancy defined.

## How to use

Before the tool can start comparing parameters, at least one **configuration** needs to be created:

1. Right-click the **Comparison Groups** table and select **Add** to open a wizard that will guide you through the process.

1. In the wizard, specify a protocol and select the elements you are interested in. It is possible to select elements running different protocol versions.

1. Select the parameters you want to create. If in the previous step elements running different protocol versions were selected, some parameters might not be listed, as they need to be available on all of the selected elements.

1. Select whether the parameters need to match exactly or if some tolerance is allowed. In case the parameter is a column of a table, you can specify a filter (wildcards are supported) to select the rows.

1. Click **Finish** to store the configuration in the tool. An initial comparison will be executed immediately.

By default, comparison groups will run every hour, but you can change and even disable this with the interval parameter.

When a comparison is in progress, the time parameter shows "busy" instead of the timestamp of last execution.

## Notes

### Unexpected Differences

If the tool does not show the differences you were expecting, check the Element State via the Elements tab of the tree control or check the Elements page. The tool is not able to perform comparisons on elements that are stopped, so they will be ignored. Elements that are paused or in timeout will probably not contain the latest data from the device. It is also possible that an element has been deleted, in which case it will also be skipped.

The tool only compares data that is available within DataMiner. It will not retrieve the latest data from the device, nor will it force the element to poll the information. In case the device does not support a subscription mechanism, try to configure a suitable timer base for the polling rate of that element. Also try to make changes to the device from within DataMiner as much as possible, as this will ensure that the updated value is immediately available to the tool.
