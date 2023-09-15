---
uid: Connector_help_Harmonic_Prostream_X
---

# Harmonic ProStream X

This connector can be used to monitor the Harmonic ProStream X. The ProStream X is a video stream processor and gateway. It provides a high-throughput video gateway, advanced multiplexing, IP networking and monitoring, scrambling, etc.

## About

### Version Info

| **Range**            | **Key Features**                                                                                         | **Based on** | **System Impact**                                                                                                                |
|----------------------|----------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | \- Monitoring only.                                                                                      | \-           | \-                                                                                                                               |
| 1.0.1.x \[SLC Main\] | \- Monitoring only. - Added logical output (transport streams) information and redesigned the connector. | 1.0.0.x      | Upgrading from 1.0.0.x will require adjustment of trend and alarm templates.                                                     |
| 1.1.0.x              | \- API upgrade from v2 to v4. - Logical Input and Output redundancy settings are now settable.           | 1.0.1.x      | Upgrading from 1.0.0.x or 1.0.1.x will require adjustment of trend and alarm templates, and possibly also of Automation scripts. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.5.0.181            |
| 1.1.0.x   | 3.4.1.0.13             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the ProStream X.
- **IP port**: The IP port of the destination.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page provides a quick overview of the device status. It displays the software version, serial number, device name, and uptime information.

### Security

This page allows you to log on to the device and see the current connection status.

### Device Redundancy

On this page, you can check if the device has a redundancy device active. If a redundancy device is active, you can also see the redundancy status and general information about this device.

### Network Interfaces

This page lists the available network interfaces for the device.

### Physical Inputs

On this page, the input physical TS table lists the active physical sockets, with information on the IP address, port number, socket port, etc.

### SSM

The table on this page contains the SSM (Source Specific Multicast) information. It lists the available source-specific multicast IP addresses.

### Logical Inputs

This page contains both the main and backup transport stream information. When a backup is active, it will link to the main channel that is inactive.

### Input Services

This page contains a table that lists all services. It shows if they are active and which logical input contains them.

Via a page button, you can access the input service CC errors subpage, which contains a table with information on the PIDs that have CC errors. It also shows the number of CC errors detected.

### Physical Outputs

This page is similar to the Physical Inputs page but contains information for all the physical output sockets.

### Output Services

This page is similar to the Input Services page but contains information for all the services going to the output.

This page has page buttons to the following subpages:

- **Output CC Errors**: Contains a table with information on the PIDs that have CC errors. It shows the number of CC errors detected.
- **DPI**: Contains the digital program insertion table, which lists the services that have a DPI PID.
- **Redundancy**: Displays the service redundancies summary, with basic information including the redundancy state and the mode. Also displays a table with more detailed information on the available redundancy streams.
  Note: In the current version of the connector, the Redundancy Mode is shown as an integer.
- **Slate**: Contains a table showing the status of a slate, whether it is active, and the IDs for the service used to generate the slate.
- **SPS**: Contains the Seamless Program Substitution table, with the sources for SPS.

### Bitrate pages (TS, Service and PID)

The bitrate pages contain bitrate information for the transport streams, services, and detected PIDs, respectively.

### Alarms

This page lists the alarms detected on the device.

If **Remove Deleted Alarms** is set to *Automatic*, all alarms that are cleared by the device will be removed in DataMiner. If it is set to *Manual*, all detected alarms will remain present in DataMiner until they are removed manually.

Note: It could be that not all possible incoming severities are known in the connector.

## Notes

The 1.0.0.x range of this connector only supports monitoring.

Most display keys have the primary key added in parentheses. This ensures the uniqueness of the display keys.
