---
uid: Connector_help_IRT_DVB-T_TX
---

# IRT DVB-T TX

This generic connector was built to retrieve all the IRT DVB-T parameters available on IRT-DVBT MIBs. It does so via SNMP polling and traps. The connector can be used in all devices that have base IRT-DVBT MIBs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

This connector has the following main pages: **Single Transmitter (SD)**, **Active Reserve (AR)**, **Passive Reserve (1+1)**, **Dual Drive (DD)**, and **N Plus 1 (1+1 R&S).**

On each of these pages, monitoring parameters are available. Some pages also have subpages for the A and B exciters, transmitters, and amplifiers.

There are also **Configuration** and **Events Configuration** subpages available. The latter allow you to define which events from the device are sent to the connector in the form of traps. When these traps are received, the relevant parameters are updated with the trap value.

There is also a **Polling Configuration** page, where you can define the polling intervals for the following groups of parameters:

- **Single Transmitter (SD)**
- **ST-Configuration**
- **ST-Events Configuration State**
- **ST-Events Configuration Priority**
- **Active Reserve (AR)**
- **AR-Configuration**
- **AR-Events Configuration State**
- **AR-Events Configuration Priority**
- **Exciter A-AR Monitoring**
- **Exciter A-AR Events Configuration State**
- **Exciter A-AR Events Configuration Priority**
- **Amplifier A-AR Monitoring**
- **Amplifier A-AR Events Configuration State**
- **Amplifier A-AR Events Configuration Priority**
- **Exciter B-AR Monitoring**
- **Exciter B-AR Events Configuration State**
- **Exciter B-AR Events Configuration Priority**
- **Amplifier B-AR Monitoring**
- **Amplifier B-AR Events Configuration State**
- **Amplifier B-AR Events Configuration Priority**
- **Passive Reserve (1+1)**
- **PR-Configuration**
- **PR-Events Configuration State**
- **PR-Events Configuration Priority**
- **Transmitter A-PR Monitoring**
- **Transmitter A-PR Events Configuration State**
- **Transmitter A-PR Events Configuration Priority**
- **Transmitter B-PR Monitoring**
- **Transmitter B-PR Events Configuration State**
- **Transmitter B-PR Events Configuration Priority**
- **Dual Drive (DD)**
- **DD-Configuration**
- **DD-Events Configuration State**
- **DD-Events Configuration Priority**
- **Exciter A-DD Monitoring**
- **Exciter A-DD Events Configuration State**
- **Exciter A-DD Events Configuration Priority**
- **Exciter B-DD Monitoring**
- **Exciter B-DD Events Configuration State**
- **Exciter B-DD Events Configuration Priority**
- **N Plus 1 Monitoring**
- **DVB N+1 Main Transmitter Configuration Table**
- **DVB N+1 Reserve Transmitter Configuration**
- **N+1 Configuration**
- **N+1 Events Configuration State**
- **N+1 Events Configuration Priority**
- **N+1 Main Transmitter Events Configuration State Table**
- **N+1 Main Transmitter Events Configuration Priority Table**
- **N+1 Reserve Transmitter Events Configuration State**
- **N+1 Reserve Transmitter Events Configuration Priority**
- **Transmitter A-N+1 Monitoring Table**
- **Transmitter A-N+1 Events Configuration State**
- **Transmitter A-N+1 Events Configuration Priority**
- **Transmitter B-N+1 Monitoring**
- **Transmitter B-N+1 Configuration**
- **Transmitter B-N+1 Events Configuration State**
- **Transmitter B-N+1 Events Configuration Priority**

By default, polling is enabled for these groups, and the following polling intervals are used: 10 seconds for fast parameters, 1 minute for medium parameters, and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

The **SNMP Overview Table** allows you to enter information to retrieve data from a specific OID. It is also possibly to specify the name of an Automation script to execute when a new value is received after polling compared to the previous value. The dummy in the Automation script needs to be named "dummy1" to make sure that the element gets correctly passed to the Automation script. The parameter name of the row is passed to the first parameter in the Automation script.
