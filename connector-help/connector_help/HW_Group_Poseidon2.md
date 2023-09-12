---
uid: Connector_help_HW_Group_Poseidon2
---

# HW Group Poseidon2

The **HW Group Poseidon2** driver is used to monitor the HW Group Poseidon2 Event Transceiver integrated devices of type 3266, 3268, 3468, and 4002.

This driver will monitor the overall status of the device. General system information, input/output information and sensor status are retrieved via simple **SNMP** parameter and table polling.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |
| 2.0.0.x   | Use of SNMPv3    | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.4.8                  |
| 2.0.0.x   | 1.2.1.1                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     |                       |                         |

## Configuration

### Connections

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.222.*
- **Device address:** Not required.

SNMPv2 settings:

- **Port number**: The port of the connected device, e.g. *161.*
- **Get community string**: The community string used when reading values from the device, e.g. *public.*
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

SNMPv3 settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password.
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password.

## How to use

On the **General** page, general system parameters are displayed: **System Description**, **Object ID**, **System Up Time**, **Contact**, **System Name, Location** and **Services**.

The **Tables** page contains information about the system monitored by the device. Input/output and sensor information is displayed in three tables.

Below the Sensors table, the **Average Value Calculation Interval** can be selected. The values in the Average Value column of the Sensors table are calculated based on this interval. You will see the average value of each row calculated over the past time interval.
