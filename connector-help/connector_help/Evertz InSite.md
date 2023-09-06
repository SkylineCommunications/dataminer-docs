---
uid: Connector_help_Evertz_InSite
---

# Evertz InSite

This connector communicates with the Evertz InSite API. It retrieves system information about the hosts and the notifications available on Evertz InSite.

## About

### Version Info

| **Range**            | **Key Features**                         | **Based on** | **System Impact**                                                                           |
|----------------------|------------------------------------------|--------------|---------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                         | \-           | \-                                                                                          |
| 1.0.1.x              | Separate notification cleanup procedure. | 1.0.0.12     | Notification tables have been modified. Clean up existing information and adjust templates. |
| 1.0.1.x \[SLC Main\] | Added session cookie/modified API calls. | 1.0.1.2      | Command URL change. Additional JSON may not be backwards compatible.                        |

### Product Info

| **Range** | **Supported Firmware**           |
|-----------|----------------------------------|
| 1.0.0.x   | v.0.10.3 a.305 Beta 9            |
| 1.0.1.x   | v.0.10.3 a.305 Beta 9            |
| 1.1.0.x   | v.11.0.2 a.1043 Release 11 + SP2 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *https://\[host ip\]*.
- **IP port**: Default: *443*.
- **Bus address**: Default: *bypassproxy*.

### Initialization

On the **General** page, specify the Evertz InSite credentials. Note that the API currently does not check these credentials.

On the **Polling Configuration** page, you can modify the polling frequency of the groups if necessary.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector displays the retrieved information on the following data pages:

- **General**: Displays status parameters as reported by the API. The Host Presence information is calculated based on the reported system information. This is also where you can specify the **credentials** to be used by the element. However, note that these are currently not verified by the API.

- **Host Tree**: Contains a tree structure with the information retrieved from the API structured as hosts. When you select a host, you will be able to check its information, including CPU, memory usage, and notifications.

- **Hosts**: Contains a table with the detected hosts and their status (i.e. *Present*/*Missing*). You can also define an IP address for each host. This will be used to relate the notifications to a specific host. If no IP is defined, the notifications will be linked to a \[Missing\] placeholder.

- **System information**: Contains page buttons to the following subpages:

- **CPU**: Shows a table with CPU information, i.e. the host name, the number of cores, and performance information.
  - **Disk**: Shows a table with disk information, i.e. the host name, the disk name, and IO operations.
  - **File System**: Shows a table with file system information, i.e. the host name, the number of files, and size information in GB.
  - **Memory**: Shows a table with memory information, i.e. the host name, memory usage information, and swap memory usage information.
  - **Process**: Shows a table with process information retrieved, i.e. the process name and PID, host name, state, CPU, and memory.

- **Notifications**: Displays a table with notification information. The information is retrieved from notifications based on the IPs specified on the Hosts page.You can configure the maximum number of notifications to keep and the number of days a notification should be kept.
