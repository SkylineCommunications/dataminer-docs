---
uid: Connector_help_Skyline_Concurrent_Offload_MGMT
---

# Skyline Concurrent Offload MGMT

The main purpose of this driver is to create separate cache folders per offload destination, which will be copies of the original source offload folder.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

On the **Configuration** page, you must configure the **source folder** from where the offload files should be retrieved.

This page also allows you to configure the **interval** at which the driver will check the source folder for new files. By default, this is 10 seconds.

On the **General** page, all **destination folders** can be configured in the table (via the right-click menu).

### Redundancy

There is no redundancy defined.

## How to use

In order to support central database data offloading to multiple destinations (e.g. MySQL, AWS Kinesis, etc.) at the same time, a separate driver will be used, which processes the offload files available in the default system cache offload folder and copies these offload files to multiple separate destination folders. The main purpose of this driver is to create separate cache folders per offload destination. This will simplify the management of the offload files for each offload destination in cases where the destination becomes unavailable for a period of time.

Statistics are available regarding the files that currently exist in the source offload folder.

For information on how to configure the element, refer to the "Initialization" section above.
