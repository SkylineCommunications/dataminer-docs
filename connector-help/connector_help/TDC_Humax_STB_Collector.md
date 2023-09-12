---
uid: Connector_help_TDC_Humax_STB_Collector
---

# TDC Humax STB Collector

This driver can be used to retrieve information from managed set-top boxes (STBs). For this purpose, it will query the Humax database.

## About

The STB collectors are grouped per region (i.e. per back-end manager), which means that all the STBs from a specific region will be managed by a collector that is in turn managed by the back-end manager for that region.

One collector will first need to collect the STB MACs that will be inserted into the IAM database, in order to provision the other collectors.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### General

On this page, you can configure the following settings:

- **Manager State**: Determines whether the element functions as a manager*.*

- **Offload Mode**: Determines if a full offload is implemented or if only changes are offloaded.

- **IAM Database**: Provisioning database (DB) configuration. You can also determine whether **Fast Provisioning** or **Normal Provisioning** is used.

- **Provisioning DB Name**: Name of the database where the IAM provisioning data can be found.
  - **Provisioning DB Server**: Server address of the database where the IAM provisioning data can be found.
  - **Provisioning DB Username**: Username to connect to the database where the IAM provisioning data can be found.
  - **Provisioning DB Password**: Password to connect to the database where the IAM provisioning data can be found.

- **Directories**: Directories of the DSL file.
  - **DSL Directory**: Directory of DSL file.
  - **DSL Comparison Directory**: Directory of the DSL file to use for comparison.

- **Humax Database**: Provisioning database (DB) configuration.
  - **Humax DB Name**: Name of the database where the Humax data can be found.
  - **Humax DB Server**: Server address of the database where the Humax data can be found.
  - **Humax DB Port**: Port of the database where the Humax data can be found.
  - **Humax DB Username**: Username to connect to the database where the Humax data can be found.
  - **Humax DB Password**: Password to connect to the database where the Humax data can be found.

- **Provisioning Settings**: Provisioning time settings.

- **Daily Provisioning Time**: The time of day when the daily provisioning should occur.
  - **Fast Provisioning Interval**: Interval between provisioning when fast provisioning is enabled.

### STB

On this page, you can check information regarding the managed STBs available in the STB Table.

You can also define the number of STBs, configure the minimum poll timing and the size of the query partitions for KPI updates, and to manually start a KPI update.

### Tuners

On this page, you can check all the tuner information available on the STBs.

### Info

On this page, you can find and configure extra information regarding the STBs:

- **STB Timestamp**: Timestamp from the last update record from the IP STB DB.
- **STB Period**: Allows you to specify the number of hours in a period. This setting should be applied to all IP STB collectors and will only be applied at 00:00:00 of the first day of the next month. Initial value set to 10.
- **STB Month Trigger Time**: The time when the **STB Period** will be applied.
- **STB BER Threshold**: Allows you to define the bit error rate threshold.
- **STB LQ Threshold**: Allows you to define the low quality threshold.
- **STB VLQ Threshold**: Allows you to define the very low quality threshold.

### Debug

This page contains a summary of information that can also be found on other pages, i.e. **STB Timestamp**, **STB Period**, **STB Month Trigger Time**, **STB BER Threshold**, **STB LQ Threshold**, **STB VLQ Threshold**.

You can also find the following additional information:

- **Last Daily Provisioning**: The time when daily provisioning was last done.
- **Last Fast Provisioning**: The time when fast provisioning was last done.

## Notes

The STB topology information needs to be retrieved from the Humax database, which is an Oracle database.
