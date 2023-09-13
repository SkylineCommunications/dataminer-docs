---
uid: Connector_help_Skyline_Enhanced_Service
---

# Skyline Enhanced Service

This driver allows you to detect and monitor the root cause of alarms found in a service. To do so, you need to indicate which alarms have which root cause.
You can also combine multiple alarms, by configuring which alarms are required and which are forbidden for a certain root cause.

## About

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact** |
|----------------------|---------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                      | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Parameter names and IDs have changed. | 1.0.0.x      | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creating the enhanced service

Once the driver has been installed on the DMA, you can activate it as follows:

1. Right-click in the Surveyor and select *New* \> *Service*.

1. Specify the name and optionally the description of the new service.

1. Expand the Advanced section and select the protocol *Skyline Enhanced Service*.

1. Configure the service as detailed in the DataMiner Help (*Basic DataMiner functionality* \> *Services and service templates* \> *Adding a service*):

   - Add elements to the service, optionally within a group.

   - Specify an alias for each element. This is the name that will be used for this element within the service. The alias must be unique in the service.

   - Optionally, select to only include specific parameters for an element.

   - For more options, check the DataMiner Help.

## How to use

### Add new rule

When you add a new rule, configure the following parameters:

- **Selected rule:** Specify the name of the rule. This will be displayed in the service when the rule is triggered.

- **Raised Root Cause Alarm:** Specify the name of the root cause. This will be displayed if one of the underlying rules is triggered.

- **Component Alias:** Select which component should cause the rule to trigger.

- **Alarm Parameter**: Select which parameter (of a previously selected component) should trigger the rule.

- **Severity**: Indicate the minimum severity required to trigger the rule.

- **Type**: Set this parameter to *required* if the rule should be triggered as soon as the parameter has the selected severity. Otherwise, set it to *forbidden*.

### Rule priorities

If multiple rules are activated, the rule with the highest priority will be shown.
