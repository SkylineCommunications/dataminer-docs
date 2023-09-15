---
uid: Connector_help_M3_Systems_StellaNGC
---

# M3 Systems StellaNGC

This connector is used to manage the M3 Systems StellaNGC device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0.9.4.0 0.10.1.0       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

This connector consists of the following pages:

- **General**: Displays general information about the device, such as the **Version**, **Disk Occupation,** **Session Status**, etc.
- **KPI Values**: Contains two tables, the **L1 KPI Table** and the **L5 KPI Table**. Each table displays the current values and the limits of the KPIs monitored by the device.
- **Export**: Allows you to export the KPIs, generate a report and fetch IQ values.
- **Log**: Displays a table with the logs of the device.
