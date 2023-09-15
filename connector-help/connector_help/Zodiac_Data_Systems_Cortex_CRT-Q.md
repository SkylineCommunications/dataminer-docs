---
uid: Connector_help_Zodiac_Data_Systems_Cortex_CRT-Q
---

# Zodiac Data Systems Cortex CRT-Q

This connector can be used to retrieve information from the **Cortex Command Ranging and Telemetry Unit** of the vendor **Zodiac Data Systems**. This device is an integrated command ranging and telemetry baseband system for satellite ground control stations. It performs telemetry processing (payload data processing up to 20 Mbps, LEOP and housekeeping operations), satellite telecommanding and ranging for GEO, MEO and LEO spacecraft.

This connector uses serial communication over TCP/IP. It follows the structure of the commands and responses described in the documentation of the Cortex STI 100013_CRT. The protocol will sequentially send serial commands over TCP/IP and retrieve the responses that will be mapped onto displayed parameters to show the device status.

## About

### Version Info

| **Range**            | **Key Features**                                                          | **Based on** | **System Impact**                                                                                                                                       |
|----------------------|---------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Initial version.                                                          | \-           | This range does not support DVEs. It assumes there is only 1 TMU.                                                                                       |
| 1.0.1.x \[SLC Main\] | Implemented support for new firmware. (See "Product Info" section below.) | 1.0.0.1      | This range uses DVEs. It is not downwards compatible with the 1.0.0.x range. Some parameters have been renamed. It allows for multiple DCUs, TMUs, etc. |

### Product Info

| **Range** | **Supported Firmware**                                               |
|-----------|----------------------------------------------------------------------|
| 1.01.x    | Kernel 2, CRT Software revision 10 Kernel 6, CRT Software revision 3 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| 1.0.1.x   | No                  | Yes                     | \-                    | Zodiac Data Systems Cortex CRT-Q - TMU<br>[Zodiac Data Systems Cortex CRT-Q - IFR](xref:Connector_help_Zodiac_Data_Systems_Cortex_CRT-Q_-_IFR)<br>[Zodiac Data Systems Cortex CRT-Q - IFM](xref:Connector_help_Zodiac_Data_Systems_Cortex_CRT-Q_-_IFM)<br>[Zodiac Data Systems Cortex CRT-Q - RAU](xref:Connector_help_Zodiac_Data_Systems_Cortex_CRT-Q_-_RAU)<br>[Zodiac Data Systems Cortex CRT-Q - DCU](xref:Connector_help_Zodiac_Data_Systems_Cortex_CRT-Q_-_DCU) |

## Configuration

### Connections

#### Serial (Cortex Monitoring Data) Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: Required. By default, the connector will use the port 3000, CORTEX Monitoring data (MON).
  - **Bus address**: Not required. By default, the bus address of the device is disabled.

#### Serial (IP Connection - Cortex Control Data) Connection 1

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: Required. By default, the connector will use the port 3001, CORTEX Control data (CRTL).
  - **Bus address**: Not required. By default, the bus address of the device is disabled.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector shows the general parameters and alarms for this device. It also shows the different parameters for the modules in tables. It allows you see which modules were detected in the device, and how the TMUs are associated.

A page exists per supported module (TMU, IFR, IFM, RAU, DCU). The connector will export different connectors based on the availability of those modules. A list of the supported modules can be found in the "System Info" table above.
