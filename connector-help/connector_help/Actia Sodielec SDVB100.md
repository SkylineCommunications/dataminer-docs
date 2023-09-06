---
uid: Connector_help_Actia_Sodielec_SDVB100
---

# Actia Sodielec SDVB100

This connector allows you to monitor and control the Actia Sodielec SDVB100 device via SNMP.

## About

| **Range**            | **Key Features**                                                                   | **Based on** | **System Impact**                                                                                                                                                                                                                                                                         |
|----------------------|------------------------------------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Initial version.                                                                   | \-           | \-                                                                                                                                                                                                                                                                                        |
| 2.0.0.x \[SLC Main\] | Changed connector name to the correct name "Actia Sodielec" instead of "Sodielec". | 1.0.0.9      | Live Update will be broken. Elements will need to use the new connector, which means that existing configuration for monitoring, reports, filters, and Automation scripts may need to be modified.If you are using an "allowed connectors" license, your license may need to be adjusted. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | B1                     |
| 2.0.0.x   | B1                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Overview Pages

This connector contains the following pages:

- The **General** and **Device Info** pages contain the general information and configuration of the device.
- On the **Polling Settings** subpage of the General page, you can manage the polling that is done to the device. See "Polling Configuration" below for more info.
- The **I/O MPEG-TS** page contains **ASI** monitoring and configuration parameters.
- The **DVB Limits** page contains the **DVB Limits Table** and other DVB limits parameters
- The **Services** page contains the **Services** and **PID** **Table**.
- The **PCR Measurements** page includes the **PCR Table** with all the measurements.
- The **ECM/EMM** page contains the **ECM Table** and **EMM Table.**
- The **Service Quality** page contains service quality configuration parameters and the **Measures Service Quality Table**.
- The **Stamping** page and subpage contain the **Stamping Table** and the **Stamping Setup Table.**
- The **Multiplex Composition** page contains monitoring parameters like Network Number, Bitrates, and Rates.
- The **SFN** page includes **SFN Packet Bitrates** and SFN configuration parameters**.**
- The **Measurement** page includes the **Measurement Table** with all available bitrates for the available entries.
- The **TR101290** page contains the **Measures TR101290 Table.**
- The **Events** page contains the **Events Table**.
- The **Alarms** page contains the **Alarms List Table** and the **Alarm V1 Table**. Any incoming alarm traps will be listed in the **Alarms List Table**.

### Polling Configuration

From range 2.0.0.x onwards, the **Polling Settings** page contains a **Polling Table** where you can define the polling intervals for the following groups of parameters:

- **System**
- **Up Time and Multiplex**
- **Structure Parameters**
- **Software Revision Table**
- **Log**
- **I/O Mpeg TS Monitoring**
- **I/O Mpeg TS Configuration**
- **DVB Limits Table**
- **DVB Limits Parameters**
- **Services**
- **PID**
- **PCR Table**
- **Date PCR**
- **ECM/EMM**
- **Service Quality Parameters**
- **Measures Services Quality Table**
- **Stamping**
- **Stamping Setup Table**
- **PID Analysis Period**
- **Network and Multiplex Parameters**
- **Bitrate Parameters**
- **Multiplex More**
- **SFN Delta**
- **SFN Delta-i**
- **SFN Monitoring**
- **SFN Configuration**
- **Measurement Table**
- **Measures TR101290 Table**
- **Date Last Cleaning Counters**
- **Events**
- **Date Last Cleaning Alarms**
- **Alarms**

By default, polling for these groups is enabled, and the same polling intervals are used as in previous versions: 10 and 30 seconds for fast parameters, 1 and 10 minutes for medium parameters, and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.
