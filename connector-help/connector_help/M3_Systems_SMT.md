---
uid: Connector_help_M3_Systems_SMT
---

# M3 Systems SMT

This connector is designed to manage the M3 Systems SMT device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.4.0                |

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

- **IP address/host**: The polling IP of the device.
  - **IP port**: The port of the device. Default: *5000*.

## How to Use

This connector consists of the following pages:

- **General**: Displays general information about the device, such as the **Version**, **Disk Occupation,** **Session Status**, etc.
- **GNSS (Global navigation satellite system) KPI Values**: Contains two tables, the **L1 KPI Table** and the **L5 KPI Table**. Each table displays the current values and the limits of the KPIs monitored by the device.
- **Shelter KPI Values**: Contains two tables, the **Shelter Temperature KPI Table** and the **Shelter Humidity KPI Table**, where the KPI values are stored related to the humidity and temperature in the shelter.
- **Export**: Allows you to export the KPIs, generate a report, and fetch IQ values.
- **Log**: Displays a table with the logs of the device.
